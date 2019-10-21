using System;
using System.Collections.Generic;
using System.Text;

namespace Project_0
{
    interface ICustomerDataGetCustomer
    {
        public Customer GetCustomer(int customerID);

        public Customer[] GetAllCustomers();
    }
}
