using System;
using System.Collections.Generic;
using System.Text;

namespace Project_0.CustomerInterfaces
{ 
    interface IDisplayCustomerGroup
    {
        public void DisplayCustomerList(Customer[] allCustomers, Customer currentCustomer);
    }
}
