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
        private int _accountNumber; 
        private int _pin; 
        private decimal _availableBalance;
        private decimal _totalBalance; 
              
        public Account(int theAccountNumber, int thePIN,
           decimal theAvailableBalance, decimal theTotalBalance)
        {
            _accountNumber = theAccountNumber;
            _pin = thePIN;
            _availableBalance = theAvailableBalance;
            _totalBalance = theTotalBalance;
        } 

        public int AccountNumber
        {
            get
            {
                return _accountNumber;
            } 
        } 

        public decimal AvailableBalance
        {
            get
            {
                return _availableBalance;
            } 
        } 

        public decimal TotalBalance
        {
            get
            {
                return _totalBalance;
            } 
        } 

        public bool ValidatePIN(int userPIN)
        {
            return (userPIN == _pin);
        } 

        public void Credit(decimal amount)
        {
            _totalBalance += amount; 
        } 

        public void Debit(decimal amount)
        {
            _availableBalance -= amount; 
            _totalBalance -= amount; 
        } 
    }
}
