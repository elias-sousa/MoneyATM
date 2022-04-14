using MoneyATM.Domain.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoneyATM.Domain.Core.Abstract
{
    /// <summary>
    /// Abstract base class Transaction represents an ATM transaction. 
    /// </summary>
    public abstract class Transaction
    {
        protected int AccountNumber { get; set; }
        protected Screen UserScreen { get; set; }
        protected BankDatabase Database { get; set; }

        public Transaction(int userAccount, Screen theScreen,
           BankDatabase theDatabase)
        {
            AccountNumber = userAccount;
            UserScreen = theScreen;
            Database = theDatabase;
        } 
                    
        public abstract void Execute();
    }
}
