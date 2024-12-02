using HW_Week15.Contract.RepositoryInterface;
using HW_Week15.Contract.ServiceInterface;
using HW_Week15.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW_Week15.Services;

public class TransactionService : ITransactionService
{
    private readonly ICardRepository _cardRepository;
    private readonly ITransactionRepository _transactionRepository;

    public TransactionService(ICardRepository cardRepository, ITransactionRepository transactionRepository)
    {
        _cardRepository = cardRepository;
        _transactionRepository = transactionRepository;
    }

    public void Transfer(string sourceCardNumber, string destinationCardNumber, decimal amount)
    {
        var sourceCard = _cardRepository.GetCardByNumber(sourceCardNumber);
        var destinationCard = _cardRepository.GetCardByNumber(destinationCardNumber);

        if (sourceCard == null)
            throw new Exception("Source card not found.");
        if (destinationCard == null)
            throw new Exception("Destination card not found.");
        if (destinationCard.User == null)
            throw new Exception("Destination card does not have an associated user.");

        Console.WriteLine($"Recipient Cardholder: {destinationCard.User.Name}");
        Console.Write("Do you confirm the recipient information? (yes/no): ");
        var confirmation = Console.ReadLine();
        if (confirmation?.ToLower() != "yes")
        {
            Console.WriteLine("Transaction cancelled.");
            return;
        }

        var verificationCode = GenerateVerificationCode();
        SaveVerificationCodeToFile(verificationCode);

        Console.Write("Enter the verification code: ");
        var enteredCode = Console.ReadLine();

        if (!ValidateVerificationCode(enteredCode, verificationCode))
        {
            throw new Exception("Invalid or expired verification code.");
        }

        decimal fee = amount > 1000 ? 0.015m * amount : 0.005m * amount;

        if (sourceCard.Balance < amount + fee)
            throw new Exception("Insufficient balance.");

        sourceCard.Balance -= (amount + fee);
        destinationCard.Balance += amount;

        _cardRepository.UpdateCard(sourceCard);
        _cardRepository.UpdateCard(destinationCard);

        _transactionRepository.AddTransaction(new Transaction
        {
            SourceCardId = sourceCard.Id,
            DestinationCardId = destinationCard.Id,
            Amount = amount,
            Fee = fee,
            Date = DateTime.Now
        });

        Console.WriteLine("Transaction successful.");
    }


    private string GenerateVerificationCode()
    {
        var random = new Random();
        return random.Next(10000, 99999).ToString();
    }

    private string SaveVerificationCodeToFile(string code)
    {
        var filePath = Path.Combine(Directory.GetCurrentDirectory(), "VerificationCode.txt");

        File.WriteAllText(filePath, $"{code};{DateTime.UtcNow}");

        Console.WriteLine($"Verification code saved at: {filePath}");
        return filePath;
    }

    private bool ValidateVerificationCode(string enteredCode, string originalCode)
    {
        var filePath = Path.Combine(Directory.GetCurrentDirectory(), "VerificationCode.txt");

        if (!File.Exists(filePath))
            return false;

        var fileContent = File.ReadAllText(filePath);
        var parts = fileContent.Split(';');
        if (parts.Length != 2)
            return false;

        var savedCode = parts[0];
        var savedTime = DateTime.Parse(parts[1]);

        return savedCode == enteredCode && (DateTime.UtcNow - savedTime).TotalMinutes <= 5;
    }

}
