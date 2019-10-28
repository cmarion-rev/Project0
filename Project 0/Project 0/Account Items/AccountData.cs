using System;
using System.Collections.Generic;
using System.Text;

namespace Project_0
{
    public class AccountData
    {
        public int ID { get; set; }

        public Utility.AccountType AccountType { get; set; }

        public int CustomerID { get; set; }

        public double AccountBalance { get; set; }

        public Utility.TransactionCodes LastTransactionState { get; set; }

        public DateTime MaturityDate { get; set; }

        public float InterestRate { get; set; }

        public bool IsActive { get; set; }

        public bool IsOpen { get; set; }
    }
}