using HW_Week15.Contract.RepositoryInterface;
using HW_Week15.Contract.ServiceInterface;
using HW_Week15.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW_Week15.Services;

public class CardService : ICardService
{
    private readonly ICardRepository _cardRepository;

    public CardService(ICardRepository cardRepository)
    {
        _cardRepository = cardRepository;
    }

    public decimal GetBalance(string cardNumber)
    {
        var card = _cardRepository.GetCardByNumber(cardNumber);
        if (card == null)
            throw new Exception("Card not found.");
        return card.Balance;
    }

    public void ChangePassword(string cardNumber, string newPassword)
    {
        var card = _cardRepository.GetCardByNumber(cardNumber);
        if (card == null)
            throw new Exception("Card not found.");
        card.Password = newPassword;
        _cardRepository.UpdateCard(card);
    }
}
