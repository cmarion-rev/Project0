using System;
using System.Collections.Generic;
using System.Text;

namespace Project_0
{
    public class Customer
    {
        private static int totalCustomers = 0;

        public int CustomerID { get;  }

        private List<Account> accounts = new List<Account>();

        Customer()
        {
            CustomerID = ++totalCustomers;
            accounts = new List<Account>();
        }


    }
}