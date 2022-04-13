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
        private int _accountNumber; 
        private Screen _userScreen;
        private BankDatabase _database; 
                                       
        public Transaction(int userAccount, Screen theScreen,
           BankDatabase theDatabase)
        {
            _accountNumber = userAccount;
            _userScreen = theScreen;
            _database = theDatabase;
        } 
          
        public int AccountNumber
        {
            get
            {
                return _accountNumber;
            } 
        } 
        public Screen UserScreen
        {
            get
            {
                return _userScreen;
            } 
        } 

        public BankDatabase Database
        {
            get
            {
                return _database;
            } 
        } 
          
        public abstract void Execute();
    }
}
