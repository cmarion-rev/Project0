using System;
using System.Collections.Generic;
using System.Text;

namespace Project_0
{
    partial class Display : IDisplayGeneral, IDisplayAccount, IDisplayCustomer
    {
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
    }
}