using HW_Week15.Contract.ServiceInterface;
using HW_Week15.Data;
using HW_Week15.Repository;
using HW_Week15.Services;

ApplicationDbContext context = new ApplicationDbContext();

var userRepository = new UserRepository(context);
var cardRepository = new CardRepository(context);
var transactionRepository = new TransactionRepository(context);

var userService = new UserService(userRepository);
var cardService = new CardService(cardRepository);
var transactionService = new TransactionService(cardRepository, transactionRepository);


while (true)
{
    Console.WriteLine("\n--- Menu ---");
    Console.WriteLine("1. View Card Balance");
    Console.WriteLine("2. Change Card Password");
    Console.WriteLine("3. Transfer Money");
    Console.WriteLine("4. Exit");
    Console.Write("Choose an option: ");

    var choice = Console.ReadLine();

    switch (choice)
    {
        case "1":
            ViewCardBalance(cardService);
            break;

        case "2":
            ChangeCardPassword(cardService);
            break;

        case "3":
            TransferMoney(transactionService);
            break;

        case "4":
            Console.WriteLine("Goodbye!");
            return;

        default:
            Console.WriteLine("Invalid option. Please try again.");
            break;
    }
}


static void ViewCardBalance(ICardService cardService)
{
    Console.Write("\nEnter Card Number: ");
    var cardNumber = Console.ReadLine();

    try
    {
        var balance = cardService.GetBalance(cardNumber);
        Console.WriteLine($"Card Balance: {balance:C}");
    }
    catch (Exception ex)
    {
        Console.WriteLine($"Error: {ex.Message}");
    }
}

static void ChangeCardPassword(ICardService cardService)
{
    Console.Write("\nEnter Card Number: ");
    var cardNumber = Console.ReadLine();
    Console.Write("Enter New Password: ");
    var newPassword = Console.ReadLine();

    try
    {
        cardService.ChangePassword(cardNumber, newPassword);
        Console.WriteLine("Password updated successfully.");
    }
    catch (Exception ex)
    {
        Console.WriteLine($"Error: {ex.Message}");
    }
}

static void TransferMoney(ITransactionService transactionService)
{
    Console.Write("\nEnter Source Card Number: ");
    var sourceCard = Console.ReadLine();
    Console.Write("Enter Destination Card Number: ");
    var destinationCard = Console.ReadLine();
    Console.Write("Enter Amount: ");
    if (!decimal.TryParse(Console.ReadLine(), out var amount))
    {
        Console.WriteLine("Invalid amount. Please try again.");
        return;
    }

    try
    {
        transactionService.Transfer(sourceCard, destinationCard, amount);
    }
    catch (Exception ex)
    {
        Console.WriteLine($"Error: {ex.Message}");
    }
}