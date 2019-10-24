using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace Project_0
{
    partial class Display : IDisplayGeneral, IDisplayAccount, IDisplayCustomer
    {
        private static Display workingInstance = null;

        public static Display Instance
        {
            get
            {
                if (workingInstance == null)
                {
                    workingInstance = new Display();
                }
                return workingInstance;
            }
        }

        Display()
        {

        }

        #region CUSTOMER OPTIONS

     
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

        public void DisplayCustomerList(Customer[] allCustomers, Customer currentCustomer)
        {
            Console.Clear();

            // Display current customer.
            Console.WriteLine("Current Customer");
            Console.WriteLine("Customer: {0}", currentCustomer.FullName);
            Console.WriteLine("Customer ID: {0}", currentCustomer.CustomerID);
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("Customer ID#\t:\tCustomer Name");

            // Display list of other customers.
            foreach (Customer otherCustomer in allCustomers)
            {
                Console.WriteLine("{0,12}\t \t{1} {2}", otherCustomer.CustomerID, otherCustomer.FirstName, otherCustomer.LastName);
            }

            Console.WriteLine();
            Console.Write("Please select a customer ID: ");
        }

        #endregion
    }
}