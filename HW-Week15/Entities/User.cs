using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW_Week15.Entities;

public class User
{
    public int Id { get; set; }
    public string Name { get; set; }
    public List<Card> Cards { get; set; }
}
