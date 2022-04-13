using MoneyATM.Domain.Core.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoneyATM.Domain.Core.Entities
{
    public class BalanceInquiry : Transaction
    {
        public BalanceInquiry(int userAccountNumber,
            Screen atmScreen, BankDatabase atmBankDatabase)
            : base(userAccountNumber, atmScreen, atmBankDatabase) { }

        public override void Execute()
        {
            decimal availableBalance =
               Database.GetAvailableBalance(AccountNumber);

            decimal totalBalance = Database.GetTotalBalance(AccountNumber);

            UserScreen.DisplayMessageLine("\nBalance Information:");
            UserScreen.DisplayMessage(" - Available balance: ");
            UserScreen.DisplayDollarAmount(availableBalance);
            UserScreen.DisplayMessage("\n - Total balance: ");
            UserScreen.DisplayDollarAmount(totalBalance);
            UserScreen.DisplayMessageLine("");
        } 
    }
}
