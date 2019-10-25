using System;
using System.Collections.Generic;
using System.Text;

namespace Project_0
{
    interface IAccountDataAddAccounts
    {
        public Account GenerateNewAccount(Customer currentCustomer);

        public Account GenerateNewCheckingAccount(Customer currentCustomer);

        public Account GenerateNewBusinessAccount(Customer currentCustomer);

        public Account GenerateNewTermAccount(Customer currentCustomer);

        public Account GenerateNewLoanAccount(Customer currentCustomer);
    }
}