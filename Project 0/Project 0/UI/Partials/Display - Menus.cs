using System;
using System.Collections.Generic;
using System.Text;

namespace Project_0
{
    partial class Display : IDisplayGeneral, IDisplayAccount, IDisplayCustomer
    {
        public void DisplayMainMenu(Utility.MainMenuOptions newOptions)
        {
            // Check if Register New Customer option is set.
            Console.WriteLine((newOptions & Utility.MainMenuOptions.REGISTER_NEW_CUSTOMER) == Utility.MainMenuOptions.REGISTER_NEW_CUSTOMER ? "(1) Register new customer." : "");

            // Check if Change Customer option is set.
            Console.WriteLine((newOptions & Utility.MainMenuOptions.CHANGE_CUSTOMER) == Utility.MainMenuOptions.CHANGE_CUSTOMER ? "(2) Change customer." : "");

            // Check if Open New Account option is set.
            Console.WriteLine((newOptions & Utility.MainMenuOptions.OPEN_NEW_ACCOUNT) == Utility.MainMenuOptions.OPEN_NEW_ACCOUNT ? "(3) Open new account." : "");

            // Check if Close Account option is set.
            Console.WriteLine((newOptions & Utility.MainMenuOptions.CLOSE_ACCOUNT) == Utility.MainMenuOptions.CLOSE_ACCOUNT ? "(4) Close account." : "");

            // Check if Deposit Amount option is set.
            Console.WriteLine((newOptions & Utility.MainMenuOptions.DEPOSIT_AMOUNT) == Utility.MainMenuOptions.DEPOSIT_AMOUNT ? "(5) Deposit to account." : "");

            // Check if Withdraw Amount option is set.
            Console.WriteLine((newOptions & Utility.MainMenuOptions.WITHDRAW_AMOUNT) == Utility.MainMenuOptions.WITHDRAW_AMOUNT ? "(6) Withdraw from account." : "");

            // Check if Transfer Amount option is set.
            Console.WriteLine((newOptions & Utility.MainMenuOptions.TRANSFER_AMOUNT) == Utility.MainMenuOptions.TRANSFER_AMOUNT ? "(7) Transfer between accounts." : "");

            // Check if Pay Loan Installment option is set.
            Console.WriteLine((newOptions & Utility.MainMenuOptions.PAY_LOAN_INSTALLMENT) == Utility.MainMenuOptions.PAY_LOAN_INSTALLMENT ? "(8) Pay loan installment." : "");

            // Check if Display Accounts option is set.
            Console.WriteLine((newOptions & Utility.MainMenuOptions.DISPLAY_ALL_ACCOUNTS) == Utility.MainMenuOptions.DISPLAY_ALL_ACCOUNTS ? "(9) Display all accounts." : "");

            // Check if Display Transactions option is set.
            Console.WriteLine((newOptions & Utility.MainMenuOptions.DISPLAY_ALL_TRANSACTIONS) == Utility.MainMenuOptions.DISPLAY_ALL_TRANSACTIONS ? "(0) Display all transactions for an account." : "");

            // Display exit program option.
            Console.WriteLine();
            Console.WriteLine("(Q) Exit Program.");
            Console.WriteLine();
            Console.WriteLine();
        }

        public void DisplayReturningToMainMenu()
        {
            Console.WriteLine();
            Console.WriteLine("Returning to Main Menu.");
        }

        public void ClearDisplay()
        {
            Console.Clear();
        }
    }
}