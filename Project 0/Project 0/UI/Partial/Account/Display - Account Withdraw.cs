using System;
using System.Collections.Generic;
using System.Text;

namespace Project_0
{
    partial class Display : IDisplayGeneral, IDisplayAccount, IDisplayCustomer
    {
        public void DisplayAccountForWithdrawing(Account newAccount)
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
    }
}