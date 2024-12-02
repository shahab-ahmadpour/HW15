using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW_Week15.Entities;

public class Transaction
{
    public int Id { get; set; }
    public decimal Amount { get; set; }
    public DateTime Date { get; set; }
    public int SourceCardId { get; set; }
    public int DestinationCardId { get; set; }
    public decimal Fee { get; set; }
    public Card SourceCard { get; set; }
    public Card DestinationCard { get; set; }
}
