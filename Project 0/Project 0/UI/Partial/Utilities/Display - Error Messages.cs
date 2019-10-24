using System;
using System.Collections.Generic;
using System.Text;

namespace Project_0
{
    partial class Display : IDisplayGeneral, IDisplayAccount, IDisplayCustomer
    {
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

        public void DisplayInvalidEntry()
        {
            Console.WriteLine("ERROR!");
            Console.WriteLine("INVALID ENTRY INPUTTED!");
        }
    }
}