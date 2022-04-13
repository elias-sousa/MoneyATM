using MoneyATM.Domain.Core.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoneyATM.Domain.Core.Entities
{
    public class Deposit : Transaction
    {
        private decimal amount; 
        private Keyboard keypad; 
        private DepositSlot depositSlot; 

        private const int CANCELED = 0;

        public Deposit(int userAccountNumber, Screen atmScreen,
           BankDatabase atmBankDatabase, Keyboard atmKeypad,
           DepositSlot atmDepositSlot)
           : base(userAccountNumber, atmScreen, atmBankDatabase)
        {
            keypad = atmKeypad;
            depositSlot = atmDepositSlot;
        } 

        public override void Execute()
        {
            amount = PromptForDepositAmount(); 

            if (amount != CANCELED)
            {
                UserScreen.DisplayMessage(
                   "\nPlease insert a deposit envelope containing ");
                UserScreen.DisplayDollarAmount(amount);
                UserScreen.DisplayMessageLine(" in the deposit slot.");

                // retrieve deposit envelope
                bool envelopeReceived = depositSlot.IsDepositEnvelopeReceived();

                // check whether deposit envelope was received
                if (envelopeReceived)
                {
                    UserScreen.DisplayMessageLine(
                       "\nYour envelope has been received.\n" +
                       "The money just deposited will not be available " +
                       "until we \nverify the amount of any " +
                       "enclosed cash, and any enclosed checks clear.");

                    // credit account to reflect the deposit
                    Database.Credit(AccountNumber, amount);
                } 
                else
                    UserScreen.DisplayMessageLine(
                       "\nYou did not insert an envelope, so the ATM has " +
                       "canceled your transaction.");
            } 
            else
                UserScreen.DisplayMessageLine("\nCanceling transaction...");
        } 

        private decimal PromptForDepositAmount()
        {
            UserScreen.DisplayMessage(
               "\nPlease input a deposit amount in CENTS (or 0 to cancel): ");
            int input = keypad.GetInput();

            if (input == CANCELED)
                return CANCELED;
            else
                return input / 100.00M;
        } 
    }
}
