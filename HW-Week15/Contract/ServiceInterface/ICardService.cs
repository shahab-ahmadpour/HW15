using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW_Week15.Contract.ServiceInterface;

public interface ICardService
{
    decimal GetBalance(string cardNumber);
    void ChangePassword(string cardNumber, string newPassword);
}
