using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoneyATM.Domain.Core.Entities
{
    /// <summary>
    /// Representa o caixa dispensador do caixa eletrônico
    /// </summary>
    public class CashDispenser
    {
      
        private const int _INITIAL_COUNT = 500;
        private int _billCount;

      
        public CashDispenser()
        {
            _billCount = _INITIAL_COUNT; 
        } 

        public void DispenseCash(decimal amount)
        {
            int billsRequired = ((int)amount) / 20;
            _billCount -= billsRequired;
        } 

        public bool IsSufficientCashAvailable(decimal amount)
        {
            int billsRequired = ((int)amount) / 20;

            return (_billCount >= billsRequired);
        } 
    }
}
