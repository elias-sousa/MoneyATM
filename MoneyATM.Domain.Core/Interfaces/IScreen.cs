using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoneyATM.Domain.Core.Interfaces
{
    public interface IScreen
    {
        void DisplayMessage(string message);
        void DisplayMessageLine(string message);
        void DisplayDollarAmount(decimal amount);
    }
}
