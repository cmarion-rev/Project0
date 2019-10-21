using System;
using System.Collections.Generic;
using System.Text;

namespace Project_0.CustomerInterfaces
{
    interface IDisplayCustomerAccounts
    {
        public void DisplayAllCustomerAccounts(Account[] allAccounts);

        public void DisplayAllCustomerAccountsByType(Utility.AccountType currentAccountType, Account[] allAccountsByType);
    }
}