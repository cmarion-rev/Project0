using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace Project_0
{
    class Display : IDisplayGeneral, IDisplayAccount, IDisplayCustomer
    {
        #region ERROR MESSAGES

        public void DisplayInvalidAmount()
        {
            Console.WriteLine("ERROR!");
            Console.WriteLine("INVALID AMOUNT ENTERED!");
        }

        public void DisplayInvalidIndexOption()
        {
            Console.WriteLine("ERROR!");
            Console.WriteLine("INVALID SELECTION NUMBER!");
        }

        public void DisplayInvalidSelection()
        {
            Console.WriteLine("ERROR!");
            Console.WriteLine("INVALID SELECTION ENTERED!");
        }
        
        public void DisplayWithdrawalOverdraftProtection()
        {
            Console.WriteLine("WARNING!");
            Console.WriteLine("AMOUNT SELECTED EXCEEDS ACCOUNT BALANCE!");
        }

        public void DisplayReturningToMainMenu()
        {
            Console.WriteLine("Returning to Main Menu.");
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
            int result = -1;

            // Wait for user input.
            string inputLine = Console.ReadLine().Trim();

            // Check for valid input.
            if (int.TryParse(inputLine, out result))
            {
                // Check if entered amount was a positive value.

            }
            else
            {
                result = -1;
            }

            return result;
        }

        public Utility.OperationState GetUserSelection(Utility.MainMenuOptions menuOptions)
        {
            Utility.OperationState result = Utility.OperationState.INVALID_OPTION;

            // Wait for user input.
            Console.Write("Please select an option: ");
            string inputLine = Console.ReadLine().Trim();
            int inputValue = -1;

            // Check first value for selected user input.
            if (int.TryParse(inputLine.Substring(0, 1), out inputValue))
            {
                // Check inputted value against avaliable options.
                switch (inputValue)
                {
                    case 1:
                        // Register new account.
                        if ((menuOptions&Utility.MainMenuOptions.REGISTER_NEW_CUSTOMER) == Utility.MainMenuOptions.REGISTER_NEW_CUSTOMER)
                        {
                            result = Utility.OperationState.REGISTER;
                        }
                        break;

                    case 2:
                        // Open new account.
                        if ((menuOptions & Utility.MainMenuOptions.OPEN_NEW_ACCOUNT) == Utility.MainMenuOptions.OPEN_NEW_ACCOUNT)
                        {
                            result = Utility.OperationState.OPEN_ACCOUNT;
                        }
                        break;

                    case 3:
                        // Close account.
                        if ((menuOptions & Utility.MainMenuOptions.CLOSE_ACCOUNT) == Utility.MainMenuOptions.CLOSE_ACCOUNT)
                        {
                            result = Utility.OperationState.CLOSE_ACCOUNT;
                        }
                        break;

                    case 4:
                        // Deposit.
                        if ((menuOptions & Utility.MainMenuOptions.DEPOSIT_AMOUNT) == Utility.MainMenuOptions.DEPOSIT_AMOUNT)
                        {
                            result = Utility.OperationState.DEPOSIT;
                        }
                        break;

                    case 5:
                        // Withdraw.
                        if ((menuOptions & Utility.MainMenuOptions.WITHDRAW_AMOUNT) == Utility.MainMenuOptions.WITHDRAW_AMOUNT)
                        {
                            result = Utility.OperationState.WITHDRAW;
                        }
                        break;

                    case 6:
                        // Transfer.
                        if ((menuOptions & Utility.MainMenuOptions.TRANSFER_AMOUNT) == Utility.MainMenuOptions.TRANSFER_AMOUNT)
                        {
                            result = Utility.OperationState.TRANSFER;
                        }
                        break;

                    case 7:
                        // Pay loan.
                        if ((menuOptions & Utility.MainMenuOptions.PAY_LOAN_INSTALLMENT) == Utility.MainMenuOptions.PAY_LOAN_INSTALLMENT)
                        {
                            result = Utility.OperationState.PAY_LOAN;
                        }
                        break;

                    case 8:
                        // Display accounts.
                        if ((menuOptions & Utility.MainMenuOptions.DISPLAY_ALL_ACCOUNTS) == Utility.MainMenuOptions.DISPLAY_ALL_ACCOUNTS)
                        {
                            result = Utility.OperationState.DISPLAY_ACCOUNTS;
                        }
                        break;

                    case 9:
                        // Display transactions.
                        if ((menuOptions & Utility.MainMenuOptions.DISPLAY_ALL_TRANSACTIONS) == Utility.MainMenuOptions.DISPLAY_ALL_TRANSACTIONS)
                        {
                            result = Utility.OperationState.DISPLAY_TRANSACTIONS;
                        }
                        break;

                    default:
                        result = Utility.OperationState.INVALID_OPTION;
                        break;
                }
            }
            else if (char.ToUpper(inputLine[0]) == 'Q')
            {
                // Exit program called.
                result = Utility.OperationState.EXIT_PROGRAM;
            }

            return result;
        }

        public double GetUserValueInput()
        {
            double result = -1.0;

            // Wait for user input.
            string inputLine = Console.ReadLine().Trim();

            // Check for valid input.
            if (double.TryParse(inputLine, out result))
            {
                // Check if entered amount was a positive value.

            }
            else
            {
                result = -1.0;
            }

            return result;
        }

        public bool WaitForUserConfirmation()
        {
            bool result = false;

            // Wait for user input.
            Console.Write("Press 'Enter' to continue.");

            // Waiting loop for Enter key press.
            while (!result)
            {
                ConsoleKeyInfo inputKey = Console.ReadKey(false);
                if (inputKey.Key == ConsoleKey.Enter)
                {
                    result = true;
                }
                Thread.Sleep(5);
            }

            return result;
        }

        #endregion

        #region ACCOUNT OPTIONS

        public void DisplayAllAccountTransactions(ITransactionRecord[] allTransactions)
        {
            // DateTime a;
            // a.ToShortDateString() + a.ToShortTimeString();

            int transactionID = -1;
            double transactionAmount = -1.0;
            bool isDeposit = true;
            DateTime timeStamp;

            Console.WriteLine("Post ID #\t:\tDeposit Amount\t:\tWithdraw Amount\t:\tDate / Time");

            foreach (ITransactionRecord item in allTransactions)
            {
                // Check if transaction was marked as valid.
                if (item.TransactionCode == Utility.TransactionErrorCodes.SUCCESS)
                {
                    transactionID = item.TransactionID;
                    transactionAmount = item.TransactionAmount;
                    timeStamp = item.TransactionDateTime;

                    // Check if transaction is deposit or withdrawal.
                    if (item is DepositRecord)
                    {
                        isDeposit = true;
                    }
                    else if (item is WithdrawalRecord)
                    {
                        isDeposit = false;
                    }
                    else
                    {
                        // Error condition! 
                        // Skip this record!
                        continue;
                    }

                    // Output record.
                    Console.WriteLine("{0,9}\t \t{1,14}\t \t{2,15}\t \t{3}", 
                                        transactionID, 
                                        isDeposit ? transactionAmount.ToString("C2") : "", 
                                        isDeposit ? "" : (-transactionAmount).ToString("C2"), 
                                        $"{timeStamp.ToShortDateString()} - {timeStamp.ToShortTimeString()}");
                }
            }

        }

        #region ACCOUNT DEPOSIT OPTIONS
        
        public void DisplayAccountForDepositing(IAccountInfo newAccount)
        {
            DisplayAccountInfo(newAccount);

            Console.WriteLine();
            Console.Write("Please enter amount to deposit: ");
        }

        public void DisplayDepositAccountOptions(Account[] allAccounts)
        {
            DisplayAllCustomerAccounts(allAccounts);

            Console.WriteLine();
            Console.Write("Please enter account number to deposit to: ");
        }

        #endregion

        #region ACCOUNT WITHDRAWAL OPTIONS

        public void DisplayAccountForWithdrawing(IAccountInfo newAccount)
        {
            DisplayAccountInfo(newAccount);

            Console.WriteLine();
            Console.Write("Please enter amount to withdraw: ");
        }

        public void DisplayWithdrawalAccountOptions(Account[] allAccounts)
        {
            DisplayAllCustomerAccounts(allAccounts);

            Console.WriteLine();
            Console.Write("Please enter account number to withdraw from: ");
        }

        #endregion

        #region ACCOUNT TRANSFER OPTIONS

        public void DisplayTransferSourceAccount(Account[] allAccounts)
        {
            DisplayAllCustomerAccounts(allAccounts);

            Console.WriteLine();
            Console.Write("Please enter account number to transfer from: ");
        }

        public void DisplayTransferDestinationAccount(Account[] allAccounts)
        {
            DisplayAllCustomerAccounts(allAccounts);

            Console.WriteLine();
            Console.Write("Please enter account number to transfer to: ");
        }

        public void DisplayAccountTransfer(IAccountInfo sourceAccount, IAccountInfo destinationAccount)
        {
            Console.WriteLine("Source Account");
            DisplayAccountInfo(sourceAccount);

            Console.WriteLine();
            
            Console.WriteLine("Destination Account");
            DisplayAccountInfo(destinationAccount);

            Console.WriteLine();
            Console.Write("Please enter amount to transfer: ");
        }

        #endregion

        #region LOAN ACCOUNT OPTIONS

        public void DisplayLoanAccountSelection(Account[] allAccounts)
        {
            DisplayAllCustomerAccounts(allAccounts);

            Console.WriteLine();
            Console.Write("Please enter account number to deposit to: ");
        }

        public void DisplayLoanInstallment(IAccountInfo newAccount)
        {
            DisplayAccountInfo(newAccount);

            Console.WriteLine();
            Console.Write("Please enter amount of installment: ");
        }

        #endregion

        private void DisplayAccountInfo(IAccountInfo newAccount)
        {
            string accountType = GetAccountType(newAccount);

            Console.WriteLine("Account # {0}", newAccount.AccountNumber);
            Console.WriteLine("Account Type: {0}", accountType);

            // Check for business account.
            if (newAccount is BusinessAccount)
            {
                Console.WriteLine("Account Balance: {0}", (newAccount.AccountBalance - (newAccount as BusinessAccount).OverdraftBalance).ToString("C2"));
            }
            else
            {
                Console.WriteLine("Account Balance: {0}", newAccount.AccountBalance.ToString("C2"));
            }
        }
        
        private string GetAccountType(IAccountInfo newAccount)
        {
            string result = "";

            if (newAccount is CheckingAccount)
            {
                result = "Checking";
            }
            else if (newAccount is BusinessAccount)
            {
                result = "Business";
            }
            else if (newAccount is LoanAccount)
            {
                result = "Loan";
            }
            else if (newAccount is TermDepositAccount)
            {
                result = "CD";
            }
            else
            {
                result = "INVALID!";
            }

            return result;
        }

        #endregion

        #region CUSTOMER OPTIONS

        public void DisplayAllCustomerAccounts(Account[] allAccounts)
        {
                int accountNumber = 0;
                string accountType = "";
                double currentBalance = 0.0;

            Console.WriteLine("Account #\t:\tAccount Type\t:\tAccount Balance");
            foreach (IAccountInfo item in allAccounts)
            {
                accountNumber = item.AccountNumber;

                // Check for type of account.
                if (item is CheckingAccount)
                {
                    currentBalance = item.AccountBalance;
                    accountType = "Checking";
                }
                else if (item is BusinessAccount)
                {
                    currentBalance = item.AccountBalance - (item as BusinessAccount).OverdraftBalance;
                    accountType = "Business";
                }
                else if (item is LoanAccount)
                {
                    currentBalance = item.AccountBalance;
                    accountType = "Loan";
                }
                else if (item is TermDepositAccount)
                {
                    currentBalance = item.AccountBalance;
                    accountType = "CD";
                }
                else
                {
                    accountType = "INVALID!";
                    currentBalance = -1.0;
                }

                // Display this account.
                Console.WriteLine("{0,9}\t \t{1,12}\t \t{2,15}", accountNumber.ToString("D1"), accountType, currentBalance.ToString("C2"));
            }
        }

        public void DisplayCustomerInformation(Customer newCustomer)
        {
            Console.WriteLine("Customer: {0}", newCustomer.FullName);
            Console.WriteLine("Customer ID: {0}", newCustomer.CustomerID);
            Console.WriteLine();
        }

        #endregion
    }
}