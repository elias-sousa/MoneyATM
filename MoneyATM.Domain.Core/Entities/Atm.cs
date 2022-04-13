using MoneyATM.Domain.Core.Abstract;
using MoneyATM.Domain.Core.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoneyATM.Domain.Core.Entities
{
    /// <summary>
    /// Representa um caixa automático
    /// </summary>
    public class Atm
    {
        private bool _userAuthenticated; // true se o usuário for autenticado
        private int _currentAccountNumber; // user's account number
        private Screen _screen; // referência à tela de caixas eletrônicos
        private Keyboard _keypad; // referência ao teclado do caixa eletrônico
        private CashDispenser _cashDispenser; // referência o dispensador de notas do caixa eletrônico
        private DepositSlot _depositSlot; // referência ao slot de depósito do caixa eletrônico
        private BankDatabase _bankDatabase; // referência ao banco de dados de informações da conta

        public Atm()
        {
            _userAuthenticated = false; // usuário não está autenticado para iniciar
            _currentAccountNumber = 0; // sem número de conta corrente para iniciar
            _screen = new Screen(); 
            _keypad = new Keyboard(); 
            _cashDispenser = new CashDispenser(); 
            _depositSlot = new DepositSlot(); 
            _bankDatabase = new BankDatabase(); 
        }

        public void Run()
        {
            while (true) // loop infinito
            {
                while (!_userAuthenticated)
                {
                    _screen.DisplayMessageLine("\nWelcome!");
                    AuthenticateUser(); 
                } 

                PerformTransactions(); 
                _userAuthenticated = false; 
                _currentAccountNumber = 0; 
                _screen.DisplayMessageLine("\nThank you! Goodbye!");
            } 
        } 

        private void AuthenticateUser()
        {
            _screen.DisplayMessage("\nPlease enter your account number: ");
            int accountNumber = _keypad.GetInput();

            _screen.DisplayMessage("\nEnter your PIN: ");
            int pin = _keypad.GetInput();

            // set userAuthenticated to boolean value returned by database
            _userAuthenticated =
               _bankDatabase.AuthenticateUser(accountNumber, pin);

            // check whether authentication succeeded
            if (_userAuthenticated)
                _currentAccountNumber = accountNumber; // save user's account #
            else
                _screen.DisplayMessageLine(
                      "Invalid account number or PIN. Please try again.");
        } // end method AuthenticateUser

        // display the main menu and perform transactions
        private void PerformTransactions()
        {
            Transaction currentTransaction; // transaction being processed
            bool userExited = false; // user has not chosen to exit

            // loop while user has not chosen exit option
            while (!userExited)
            {
                // show main menu and get user selection
                int mainMenuSelection = DisplayMainMenu();

                // decide how to proceed based on user's menu selection
                switch ((MenuOption)mainMenuSelection)
                {
                    // user chooses to perform one of three transaction types
                    case MenuOption.BALANCE_INQUIRY:
                    case MenuOption.WITHDRAWAL:
                    case MenuOption.DEPOSIT:
                        currentTransaction =
                           CreateTransaction(mainMenuSelection);
                        currentTransaction.Execute();
                        break;
                    case MenuOption.EXIT_ATM: 
                        _screen.DisplayMessageLine("\nExiting the system...");
                        userExited = true; 
                        break;
                    default:
                        _screen.DisplayMessageLine(
                           "\nYou did not enter a valid selection. Try again.");
                        break;
                } 
            } 
        } 

        private int DisplayMainMenu()
        {
            _screen.DisplayMessageLine("\nMain menu:");
            _screen.DisplayMessageLine("1 - View my balance");
            _screen.DisplayMessageLine("2 - Withdraw cash");
            _screen.DisplayMessageLine("3 - Deposit funds");
            _screen.DisplayMessageLine("4 - Exit\n");
            _screen.DisplayMessage("Enter a choice: ");
            return _keypad.GetInput(); 
        } 

        private Transaction CreateTransaction(int type)
        {
            Transaction temp = null; 

            switch ((MenuOption)type)
            {
                case MenuOption.BALANCE_INQUIRY:
                    temp = new BalanceInquiry(_currentAccountNumber,
                       _screen, _bankDatabase);
                    break;
                case MenuOption.WITHDRAWAL:  
                    temp = new Withdrawal(_currentAccountNumber, _screen,
                         _bankDatabase, _keypad, _cashDispenser);
                    break;
                case MenuOption.DEPOSIT: 
                    temp = new Deposit(_currentAccountNumber, _screen,
                         _bankDatabase, _keypad, _depositSlot);
                    break;
            } 

            return temp;
        } 
    }
}
