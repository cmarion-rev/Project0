using System;
using System.Collections.Generic;
using System.Text;

namespace Project_0
{
    partial class Display : IDisplayGeneral, IDisplayAccount, IDisplayCustomer
    {
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
    }
}