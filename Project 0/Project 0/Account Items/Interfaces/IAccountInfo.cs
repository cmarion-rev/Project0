using System;
using System.Collections.Generic;
using System.Text;

namespace Project_0
{
    public interface IAccountInfo : IDeposit, IWithdrawal, IAccountError
    {
        private static int totalAccounts = 0;
        protected static int GetNewAccountNumber()
        {
            return ++totalAccounts;
        }

        public Utility.AccountType AccountType { get; }

        public int AccountNumber { get; }

        public int CustomerID { get; }

        public Customer Customer { get; }

        public double AccountBalance { get; }
    }
}