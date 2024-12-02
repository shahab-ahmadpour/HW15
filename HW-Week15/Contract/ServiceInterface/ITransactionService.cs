using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW_Week15.Contract.ServiceInterface;

public interface ITransactionService
{
    void Transfer(string sourceCardNumber, string destinationCardNumber, decimal amount);
}
