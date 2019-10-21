using System;
using System.Collections.Generic;
using System.Text;

namespace Project_0
{
    interface ICustomerDataRemoveCustomer
    {
        public bool RemoveCustomer(Customer newCustomer);

        public bool RemoveCustomer(int customerID);
    }
}
