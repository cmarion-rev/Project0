using System;
using System.Collections.Generic;
using System.Text;

namespace Project_0
{
    partial class Display : IDisplayGeneral, IDisplayAccount, IDisplayCustomer
    {
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
                        accountType = "CD";
                        break;

                    case Utility.AccountType.LOAN:
                        currentBalance = item.AccountBalance;
                        accountType = "Loan";
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
    }
}