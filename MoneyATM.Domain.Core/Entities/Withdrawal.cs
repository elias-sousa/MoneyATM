using MoneyATM.Domain.Core.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoneyATM.Domain.Core.Entities
{
    public class Withdrawal : Transaction
    {
        private decimal amount; 
        private Keyboard keypad; 
        private CashDispenser cashDispenser; 

        private const int CANCELED = 6;

        public Withdrawal(int userAccountNumber, Screen atmScreen,
           BankDatabase atmBankDatabase, Keyboard atmKeypad,
           CashDispenser atmCashDispenser)
           : base(userAccountNumber, atmScreen, atmBankDatabase)
        {
            keypad = atmKeypad;
            cashDispenser = atmCashDispenser;
        } 

        public override void Execute()
        {
            bool cashDispensed = false; 

            bool transactionCanceled = false;

            do
            {
                int selection = DisplayMenuOfAmounts();

                if (selection != CANCELED)
                {
                    amount = selection;

                    decimal availableBalance =
                       Database.GetAvailableBalance(AccountNumber);

                    if (amount <= availableBalance)
                    {
                        if (cashDispenser.IsSufficientCashAvailable(amount))
                        {
                            Database.Debit(AccountNumber, amount);

                            cashDispenser.DispenseCash(amount); 
                            cashDispensed = true; 

                            UserScreen.DisplayMessageLine(
                               "\nPlease take your cash from the cash dispenser.");
                        } 
                        else 
                            UserScreen.DisplayMessageLine(
                               "\nInsufficient cash available in the ATM." +
                               "\n\nPlease choose a smaller amount.");
                    } 
                    else 
                        UserScreen.DisplayMessageLine(
                         "\nInsufficient cash available in your account." +
                            "\n\nPlease choose a smaller amount.");
                } 
                else
                {
                    UserScreen.DisplayMessageLine("\nCanceling transaction...");
                    transactionCanceled = true; 
                } 
            } while ((!cashDispensed) && (!transactionCanceled));
        } 

        private int DisplayMenuOfAmounts()
        {
            int userChoice = 0;

            int[] amounts = { 0, 20, 40, 60, 00, 200 };


            while (userChoice == 0)
            {
                UserScreen.DisplayMessageLine("\nWithdrawal options:");
                UserScreen.DisplayMessageLine("1 - $20");
                UserScreen.DisplayMessageLine("2 - $40");
                UserScreen.DisplayMessageLine("3 - $60");
                UserScreen.DisplayMessageLine("4 - $ 00");
                UserScreen.DisplayMessageLine("5 - $200");
                UserScreen.DisplayMessageLine("6 - Cancel transaction");
                UserScreen.DisplayMessage(
                    "\nChoose a withdrawal option (1-6): ");

                int input = keypad.GetInput();

                switch (input)
                {
                    case 1:
                    case 2:
                    case 3:
                    case 4:
                    case 5:
                        userChoice = amounts[input]; 
                        break;
                    case CANCELED:  
                        userChoice = CANCELED; 
                        break;
                    default:
                        UserScreen.DisplayMessageLine(
                            "\nInvalid selection. Try again.");
                        break;
                } 
            } 

            return userChoice;
        } 
    }
}
