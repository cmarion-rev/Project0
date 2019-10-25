using System;
using System.Collections.Generic;
using System.Text;

namespace Project_0
{
    public class AccountData
    {
        public Utility.AccountType AccountType { get; set; }

        public int AccountNumber { get; set; }

        public int CustomerID { get; set; }

        public Customer Customer { get; set; }

        public double AccountBalance { get; set; }

        public Utility.TransactionErrorCodes LastTransactionState { get; set; }

        public DateTime MaturityDate { get; set; }
    }
}