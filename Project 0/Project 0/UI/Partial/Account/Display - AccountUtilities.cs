using System;
using System.Collections.Generic;
using System.Text;

namespace Project_0
{
    partial class Display : IDisplayGeneral, IDisplayAccount, IDisplayCustomer
    {
        public void DisplayAccountTransactionSelection()
        {
            Console.Write("Please select an account number to display all transactions for: ");
        }

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

        public void DisplayAccountOptions()
        {
            for (int index = 0; index < (int)Utility.AccountType._COUNT; ++index)
            {
                switch ((Utility.AccountType)index)
                {
                    case Utility.AccountType.CHECKING:
                        Console.WriteLine($"({index + 1}) Checking Account");
                        break;

                    case Utility.AccountType.BUSINESS:
                        Console.WriteLine($"({index + 1}) Business Account");
                        break;

                    case Utility.AccountType.TERM:
                        Console.WriteLine($"({index + 1}) CD Account");
                        break;

                    case Utility.AccountType.LOAN:
                        Console.WriteLine($"({index + 1}) Loan Account");
                        break;

                    default:
                        break;
                }
            }
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("(0) Return to Main Menu");
            Console.WriteLine();
            Console.Write("Please select an option: ");
        }

        public void DisplayAccountInfo(Account newAccount)
        {
            string accountType = GetAccountType(newAccount);

            Console.WriteLine("Account # {0}", newAccount.AccountNumber);
            Console.WriteLine("Account Type: {0}", accountType);

            // Check for business account.
            switch (newAccount.AccountType)
            {
                case Utility.AccountType.TERM:
                    Console.WriteLine("Account Balance: {0}", newAccount.AccountBalance.ToString("C2"));
                    Console.WriteLine("Maturity Date: {0}", (newAccount as TermDepositAccount).MaturityDate.ToShortDateString());
                    break;

                case Utility.AccountType.BUSINESS:
                case Utility.AccountType.CHECKING:
                case Utility.AccountType.LOAN:
                    Console.WriteLine("Account Balance: {0}", newAccount.AccountBalance.ToString("C2"));
                    break;

                default:
                    break;
            }
        }

        private string GetAccountType(IAccountInfo newAccount)
        {
            string result = "";

            switch (newAccount.AccountType)
            {
                case Utility.AccountType.CHECKING:
                    result = "Checking";
                    break;

                case Utility.AccountType.BUSINESS:
                    result = "Business";
                    break;

                case Utility.AccountType.TERM:
                    result = "CD";
                    break;

                case Utility.AccountType.LOAN:
                    result = "Loan";
                    break;

                default:
                    result = "INVALID!";
                    break;
            }

            return result;
        }
    }
}
