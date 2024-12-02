using HW_Week15.Contract.RepositoryInterface;
using HW_Week15.Data;
using HW_Week15.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW_Week15.Repository;

public class CardRepository : ICardRepository
{
    private readonly ApplicationDbContext _context;

    public CardRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public List<Card> GetAllCards() => _context.Cards.Include(c => c.User).ToList();

    public Card GetCardByNumber(string cardNumber) =>
        _context.Cards.Include(c => c.User)
                      .FirstOrDefault(c => c.CardNumber == cardNumber);

    public void AddCard(Card card)
    {
        _context.Cards.Add(card);
        _context.SaveChanges();
    }

    public void UpdateCard(Card card)
    {
        _context.Cards.Update(card);
        _context.SaveChanges();
    }

    public void DeleteCard(int id)
    {
        var card = _context.Cards.Find(id);
        if (card != null)
        {
            _context.Cards.Remove(card);
            _context.SaveChanges();
        }
    }
}
