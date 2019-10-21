using System;
using System.Collections.Generic;
using System.Text;

namespace Project_0.CustomerInterfaces
{
    interface IDisplayRegisterCustomer
    {
        public void DisplayCustomerFirstNameRequest(string newName = "");

        public void DisplayCustomerLastNameRequest(string newName = "");
    }
}
