using System;
using System.Collections.Generic;
using System.Text;

using Project_0.CustomerInterfaces;

namespace Project_0
{
    interface IDisplayCustomer : IDisplayCustomerAccounts,
                                 IDisplayCustomerInformation, 
                                 IDisplayRegisterCustomer,
                                 IDisplayCustomerGroup
                                    
    {
    }
}