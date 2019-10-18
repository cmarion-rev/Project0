using System;
using System.Collections.Generic;
using System.Text;

namespace Project_0
{
    interface ITransactionRecord
    {
        public static int TransactionNumber = 0;

        public int TransactionID { get; }

        public double TransactionAmount { get; set; }

        public Utility.TransactionErrorCodes TransactionCode { get; set; }
    }
}