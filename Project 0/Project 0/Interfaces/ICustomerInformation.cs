using System;
using System.Collections.Generic;
using System.Text;

namespace Project_0
{
    interface ICustomerInformation
    {
        private static int totalCustomers = 0;

        protected static int GetNewCustomerNumber()
        {
            return ++totalCustomers;
        }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string FullName { get; }
    }
}