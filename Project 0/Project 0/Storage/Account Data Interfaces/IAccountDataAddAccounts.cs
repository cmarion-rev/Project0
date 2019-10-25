using System;
using System.Collections.Generic;
using System.Text;

namespace Project_0
{
    interface IAccountDataAddAccounts
    {
        public Account GenerateNewAccount(Utility.AccountType newType, Customer currentCustomer, double newBalace = 0.0);

        public Account GenerateNewCheckingAccount(Customer currentCustomer, double newBalace = 0.0);

        public Account GenerateNewBusinessAccount(Customer currentCustomer, double newBalace = 0.0);

        public Account GenerateNewTermAccount(Customer currentCustomer, double newBalace = 0.0);

        public Account GenerateNewLoanAccount(Customer currentCustomer, double newBalace = 0.0);
    }
}