using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoneyATM.Domain.Core.Enum
{
    /// <summary>
    /// Enum representando as opções do menu principal
    /// </summary>
    public enum MenuOption
    {
        BALANCE_INQUIRY = 1,
        WITHDRAWAL = 2,
        DEPOSIT = 3,
        EXIT_ATM = 4
    }
}
