using System;
using System.Collections.Generic;
using System.Text;

namespace Project_0
{
    public interface IAccountInfo : IDeposit, IWithdrawal, IAccountError
    {
        protected static int totalAccounts = 0;

        public int AccountNumber { get; }

        public int CustomerID { get; set; }

        public Customer Customer { get; set; }

        public double AccountBalance { get; }
    }
}