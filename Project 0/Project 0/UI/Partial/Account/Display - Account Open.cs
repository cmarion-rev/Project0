using System;
using System.Collections.Generic;
using System.Text;

namespace Project_0
{
    partial class Display : IDisplayGeneral, IDisplayAccount, IDisplayCustomer
    {
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
    }
}