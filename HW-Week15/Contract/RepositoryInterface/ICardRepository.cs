using HW_Week15.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW_Week15.Contract.RepositoryInterface;

public interface ICardRepository
{
    List<Card> GetAllCards();
    Card GetCardByNumber(string cardNumber);
    void AddCard(Card card);
    void UpdateCard(Card card);
    void DeleteCard(int id);
}
