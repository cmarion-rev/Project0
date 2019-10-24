using System;
using System.Collections.Generic;
using System.Text;

namespace Project_0
{
    partial class Display : IDisplayGeneral, IDisplayAccount, IDisplayCustomer
    {
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
    }
}