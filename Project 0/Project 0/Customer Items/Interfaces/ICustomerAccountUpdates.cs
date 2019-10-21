using System;
using System.Collections.Generic;
using System.Text;

namespace Project_0
{
    interface ICustomerAccountUpdates
    {
        public bool AddAccount(Account newAccount);

        public bool RemoveAccount(Account newAccount);
    }
}