using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoneyATM.Domain.Core.Entities
{
    /// <summary>
    /// A conta de classe representa uma conta bancária.
    /// </summary>
    public class Account
    {
        protected int AccountNumber { get; set; }
        protected int Pin { get; set; }
        protected decimal AvailableBalance { get; set; }
        protected decimal TotalBalance { get; set; }

        public Account(int theAccountNumber, int thePIN,
           decimal theAvailableBalance, decimal theTotalBalance)
        {
            AccountNumber = theAccountNumber;
            Pin = thePIN;
            AvailableBalance = theAvailableBalance;
            TotalBalance = theTotalBalance;
        } 

        public bool ValidatePIN(int userPIN)
        {
            return (userPIN == Pin);
        } 

        public void Credit(decimal amount)
        {
            TotalBalance += amount; 
        } 

        public void Debit(decimal amount)
        {
            AvailableBalance -= amount; 
            TotalBalance -= amount; 
        } 
    }
}
