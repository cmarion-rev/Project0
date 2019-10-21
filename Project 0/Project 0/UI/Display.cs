using System;
using System.Collections.Generic;
using System.Text;

namespace Project_0
{
    class Display : IDisplayGeneral, IDisplayAccount, IDisplayCustomer
    {
        #region ERROR MESSAGES

        public void DisplayInvalidAmount()
        {
            throw new NotImplementedException();
        }

        public void DisplayInvalidIndexOption()
        {
            throw new NotImplementedException();
        }

        public void DisplayInvalidSelection()
        {
            throw new NotImplementedException();
        }
        
        public void DisplayWithdrawalOverdraftProtection()
        {
            throw new NotImplementedException();
        }

        #endregion

        #region MENUS

        public void DisplayMainMenu(Utility.MainMenuOptions newOptions)
        {
            // Check if Register New Customer option is set.
            Console.WriteLine((newOptions & Utility.MainMenuOptions.REGISTER_NEW_CUSTOMER) == Utility.MainMenuOptions.REGISTER_NEW_CUSTOMER ? "(1) Register new customer." : "");
            
            // Check if Open New Account option is set.
            Console.WriteLine((newOptions & Utility.MainMenuOptions.OPEN_NEW_ACCOUNT) == Utility.MainMenuOptions.OPEN_NEW_ACCOUNT ? "(2) Open new account." : "");
            
            // Check if Close Account option is set.
            Console.WriteLine((newOptions & Utility.MainMenuOptions.CLOSE_ACCOUNT) == Utility.MainMenuOptions.CLOSE_ACCOUNT ? "(3) Close account." : "");

            // Check if Deposit Amount option is set.
            Console.WriteLine((newOptions & Utility.MainMenuOptions.DEPOSIT_AMOUNT) == Utility.MainMenuOptions.DEPOSIT_AMOUNT ? "(4) Deposit to account." : "");
            
            // Check if Withdraw Amount option is set.
            Console.WriteLine((newOptions & Utility.MainMenuOptions.WITHDRAW_AMOUNT) == Utility.MainMenuOptions.WITHDRAW_AMOUNT ? "(5) Withdraw from account." : "");

            // Check if Transfer Amount option is set.
            Console.WriteLine((newOptions & Utility.MainMenuOptions.TRANSFER_AMOUNT) == Utility.MainMenuOptions.TRANSFER_AMOUNT ? "(6) Transfer between accounts." : "");

            // Check if Pay Loan Installment option is set.
            Console.WriteLine((newOptions & Utility.MainMenuOptions.PAY_LOAN_INSTALLMENT) == Utility.MainMenuOptions.PAY_LOAN_INSTALLMENT ? "(7) Pay loan installment." : "");
            
            // Check if Display Accounts option is set.
            Console.WriteLine((newOptions & Utility.MainMenuOptions.DISPLAY_ALL_ACCOUNTS) == Utility.MainMenuOptions.DISPLAY_ALL_ACCOUNTS ? "(8) Display all accounts." : "");

            // Check if Display Transactions option is set.
            Console.WriteLine((newOptions & Utility.MainMenuOptions.DISPLAY_ALL_TRANSACTIONS) == Utility.MainMenuOptions.DISPLAY_ALL_TRANSACTIONS ? "(9) Display all transactions for an account." : "");

            // Display exit program option.
            Console.WriteLine();
            Console.WriteLine("(Q) Exit Program.");
            Console.WriteLine();
        }

        public void ClearDisplay()
        {
            Console.Clear();
        }

        #endregion

        #region USER INPUTS

        public int GetUserOptionNumberSelection()
        {
            throw new NotImplementedException();
        }

        public Utility.OperationState GetUserSelection(Utility.MainMenuOptions menuOptions)
        {
            Utility.OperationState result = Utility.OperationState.INVALID_OPTION;

            string inputLine = Console.ReadLine();
            int inputValue = -1;
            if (int.TryParse(inputLine, out inputValue))
            {
                switch (inputValue)
                {
                    case 1:

                        break;

                    case 2:

                        break;

                    case 3:

                        break;

                    case 4:

                        break;

                    case 5:

                        break;

                    case 6:

                        break;

                    case 7:

                        break;

                    case 8:

                        break;

                    case 9:

                        break;

                    default:
                        result = Utility.OperationState.INVALID_OPTION;
                        break;
                }
            }



            return result;
        }

        public double GetUserValueInput()
        {
            throw new NotImplementedException();
        }

        public bool WaitForUserConfirmation()
        {
            throw new NotImplementedException();
        }

        #endregion

        #region ACCOUNT OPTIONS

        public void DisplayAllAccountTransactions(ITransactionRecord[] allTransactions)
        {
            throw new NotImplementedException();
        }

        #region ACCOUNT DEPOSIT OPTIONS
        
        public void DisplayAccountForDepositing(Account newAccount)
        {
            throw new NotImplementedException();
        }

        public void DisplayDepositAccountOptions(Account[] allAccounts)
        {
            throw new NotImplementedException();
        }

        #endregion

        #region ACCOUNT WITHDRAWAL OPTIONS

        public void DisplayAccountForWithdrawing(Account newAccount)
        {
            throw new NotImplementedException();
        }

        public void DisplayWithdrawalAccountOptions(Account[] allAccounts)
        {
            throw new NotImplementedException();
        }

        #endregion

        #region ACCOUNT TRANSFER OPTIONS

        public void DisplayTransferSourceAccount(Account[] allAccounts)
        {
            throw new NotImplementedException();
        }

        public void DisplayTransferDestinationAccount(Account[] allAccounts)
        {
            throw new NotImplementedException();
        }

        public void DisplayAccountTransfer(Account[] sourceAccount, Account[] destinationAccount)
        {
            throw new NotImplementedException();
        }

        #endregion

        #region LOAN ACCOUNT OPTIONS

        public void DisplayLoanAccountSelection(Account[] allAccounts)
        {
            throw new NotImplementedException();
        }

        public void DisplayLoanInstallment()
        {
            throw new NotImplementedException();
        }

        #endregion
        
        #endregion

        #region CUSTOMER OPTIONS

        public void DisplayAllCustomerAccounts(Account[] allAccounts)
        {
            throw new NotImplementedException();
        }

        public void DisplayCustomerInformation(Customer newCustomer)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}