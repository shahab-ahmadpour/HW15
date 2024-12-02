using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW_Week15.Entities;

public class Card
{
    public int Id { get; set; }
    public string CardNumber { get; set; }
    public string Password { get; set; }
    public decimal Balance { get; set; }
    public int UserId { get; set; }
    public User User { get; set; }
}
