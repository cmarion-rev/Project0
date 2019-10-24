using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace Project_0
{
    partial class Display : IDisplayGeneral, IDisplayAccount, IDisplayCustomer
    {
        private static Display workingInstance = null;

        public static Display Instance
        {
            get
            {
                if (workingInstance == null)
                {
                    workingInstance = new Display();
                }
                return workingInstance;
            }
        }

        Display()
        {

        }

        #region ACCOUNT OPTIONS

        #region ACCOUNT WITHDRAWAL OPTIONS

       

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

        public void DisplayAccountTransfer(Account sourceAccount, Account destinationAccount)
        {
            Console.WriteLine("Source Account");
            DisplayAccountInfo(sourceAccount);

            Console.WriteLine();

            Console.WriteLine("Destination Account");
            DisplayAccountInfo(destinationAccount);

            Console.WriteLine();
            Console.Write("Please enter amount to transfer: ");
        }

        public void DisplayTransferSuccessful(Account sourceAccount, Account destinationAccount)
        {
            Console.WriteLine();
            Console.WriteLine("Transfer from account #{0} to account #{1} successful.", sourceAccount.AccountNumber, destinationAccount.AccountNumber);
        }

        #endregion

        #region LOAN ACCOUNT OPTIONS

        public void DisplayLoanAccountSelection(Account[] allAccounts)
        {
            DisplayAllCustomerAccounts(allAccounts);

            Console.WriteLine();
            Console.Write("Please enter account number to deposit to: ");
        }

        public void DisplayLoanInstallment(Account newAccount)
        {
            DisplayAccountInfo(newAccount);

            Console.WriteLine();
            Console.Write("Please enter amount of installment: ");
        }

        #endregion

        #region NEW ACCOUNT OPTIONS

        public void DisplayNewCheckingAccountBalance()
        {
            Console.WriteLine();
            Console.WriteLine("New Checking Account.");
            Console.WriteLine("Enter starting balance amount: ");
        }

        public void DisplayNewBusinessAccountBalance()
        {
            Console.WriteLine();
            Console.WriteLine("New Business Account.");
            Console.WriteLine("Enter starting balance amount: ");
        }

        public void DisplayNewLoanAccountBalance()
        {
            Console.WriteLine();
            Console.WriteLine("New Loan.");
            Console.WriteLine("Enter initial loan amount: ");
        }

        public void DisplayNewTermAccountBalance()
        {
            Console.WriteLine();
            Console.WriteLine("New CD.");
            Console.WriteLine("Enter initial CD amount: ");
        }

        #endregion

        #region ACCOUNT CLOSE OPTIONS

        public void DisplayAccountCloseSelection()
        {
            Console.Write("Please select account number to close: ");
        }

        public void DisplayAccountCloseConfirmation()
        {
            Console.WriteLine();
            Console.Write(@"Do you wish to close this account? (Y)es\(N)o?");
        }

        public void DisplayAccountCloseCompleted(int accountNumber)
        {
            Console.WriteLine("Account #{0} has been closed.", accountNumber);
        }

        #endregion

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
                switch (item.AccountType)
                {
                    case Utility.AccountType.CHECKING:
                        currentBalance = item.AccountBalance;
                        accountType = "Checking";
                        break;

                    case Utility.AccountType.BUSINESS:
                        currentBalance = item.AccountBalance;
                        accountType = "Business";
                        break;

                    case Utility.AccountType.TERM:
                        currentBalance = item.AccountBalance;
                        accountType = "Loan";
                        break;

                    case Utility.AccountType.LOAN:
                        currentBalance = item.AccountBalance;
                        accountType = "CD";
                        break;

                    default:
                        accountType = "INVALID!";
                        currentBalance = -1.0;
                        break;
                }

                // Display this account.
                Console.WriteLine("{0,9}\t \t{1,12}\t \t{2,15}", accountNumber.ToString("D1"), accountType, currentBalance.ToString("C2"));
            }

            Console.WriteLine();
        }

        public void DisplayAllCustomerAccountsByType(Utility.AccountType currentAccountType, Account[] allAccountsByType)
        {
            int accountNumber = 0;
            double currentBalance = 0.0;

            switch (currentAccountType)
            {
                case Utility.AccountType.CHECKING:
                    Console.WriteLine("---Checking Accounts---");
                    break;

                case Utility.AccountType.BUSINESS:
                    Console.WriteLine("---Business Accounts---");
                    break;

                case Utility.AccountType.TERM:
                    Console.WriteLine("---CD Term Accounts---");
                    break;

                case Utility.AccountType.LOAN:
                    Console.WriteLine("---Loan Accounts---");
                    break;

                default:
                    // Invalid Account Type.
                    // Break from function.
                    return;
            }

            Console.WriteLine("Account #\t:\tAccount Balance");
            foreach (IAccountInfo item in allAccountsByType)
            {
                accountNumber = item.AccountNumber;

                // Check for type of account.
                switch (currentAccountType)
                {
                    case Utility.AccountType.CHECKING:
                        currentBalance = item.AccountBalance;
                        break;

                    case Utility.AccountType.BUSINESS:
                        currentBalance = item.AccountBalance;
                        break;

                    case Utility.AccountType.TERM:
                        currentBalance = item.AccountBalance;
                        break;

                    case Utility.AccountType.LOAN:
                        currentBalance = item.AccountBalance;
                        break;

                    default:
                        break;
                }

                // Display this account.
                Console.WriteLine("{0,9}\t \t{1,15}", accountNumber.ToString("D1"), currentBalance.ToString("C2"));
            }

            Console.WriteLine();
        }

        public void DisplayCustomerInformation(Customer newCustomer)
        {
            Console.WriteLine("Customer: {0}", newCustomer.FullName);
            Console.WriteLine("Customer ID: {0}", newCustomer.CustomerID);
            Console.WriteLine();
        }

        public void DisplayNewCustomerScreen()
        {
            Console.WriteLine("New Customer");
        }

        public void DisplayCustomerFirstNameRequest(string newName = "")
        {
            if (newName.Length > 0)
            {
                Console.WriteLine("First Name: {0}", newName);
            }
            else
            {
                Console.Write("First Name: ");
            }
        }

        public void DisplayCustomerLastNameRequest(string newName = "")
        {
            if (newName.Length > 0)
            {
                Console.WriteLine("Last Name: {0}", newName);
            }
            else
            {
                Console.Write("Last Name: ");
            }
        }

        public void DisplayCustomerList(Customer[] allCustomers, Customer currentCustomer)
        {
            Console.Clear();

            // Display current customer.
            Console.WriteLine("Current Customer");
            Console.WriteLine("Customer: {0}", currentCustomer.FullName);
            Console.WriteLine("Customer ID: {0}", currentCustomer.CustomerID);
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("Customer ID#\t:\tCustomer Name");

            // Display list of other customers.
            foreach (Customer otherCustomer in allCustomers)
            {
                Console.WriteLine("{0,12}\t \t{1} {2}", otherCustomer.CustomerID, otherCustomer.FirstName, otherCustomer.LastName);
            }

            Console.WriteLine();
            Console.Write("Please select a customer ID: ");
        }

        #endregion
    }
}