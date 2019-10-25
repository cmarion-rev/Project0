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

        public void DisplayAccountBalanceRemaining(int accountID, double amount)
        {
            Console.WriteLine("Account #{0} cannot be closed! Balance still remains. {1}", accountID, amount.ToString("C2"));
        }

        public void DisplayAccountLoanBalanceRemaining(int accountID, double amount)
        {
            Console.WriteLine("Account #{0} cannot be closed! Loan balance still remains. {1}", accountID, amount.ToString("C2"));
        }

        public void DisplayAccountOverdraftRemaining(int accountID, double amount)
        {
            Console.WriteLine("Account #{0} cannot be closed! Overdraft balance still remains. {1}", accountID, amount.ToString("C2"));
        }
    }
}