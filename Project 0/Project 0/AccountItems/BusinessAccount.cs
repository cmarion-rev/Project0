using System;
using System.Collections.Generic;
using System.Text;

namespace Project_0
{
    class BusinessAccount : Account, IAccountInfo
    {
        public BusinessAccount(Customer newCustomer) : base()
        {
            AccountNumber = IAccountInfo.totalAccounts++;

            // Set customer references.
            Customer = newCustomer;
            // CustomerID = newCustomer.CustomerID;

            // Set initial account balance.
            AccountBalance = 0.0;
        }

        public int AccountNumber { get; }

        public int CustomerID { get ; set ; }
        public Customer Customer { get ; set; }

        public double AccountBalance { get; private set; }

        public Utility.TransactionErrorCodes LastTransactionState { get; private set; }

        public double OverdraftBalance { get; private set; }

        public bool DepositAmount(double newAmount)
        {
            throw new NotImplementedException();
        }

        public bool WithdrawAmount(double newAmount)
        {
            throw new NotImplementedException();
        }
    }
}