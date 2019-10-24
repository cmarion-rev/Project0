using System;
using System.Collections.Generic;
using System.Text;

namespace Project_0
{
    partial class Display : IDisplayGeneral, IDisplayAccount, IDisplayCustomer
    {
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
    }
}