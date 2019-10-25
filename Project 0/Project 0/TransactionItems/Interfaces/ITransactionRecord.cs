using System;
using System.Collections.Generic;
using System.Text;

namespace Project_0
{
    public interface ITransactionRecord
    {
        private static int TransactionNumber = 0;
        public static int GenerateNewID()
        {
            return ++TransactionNumber;
        }

        public static TransactionData GenerateNewTransactionData()
        {
            TransactionData newData = null;

            newData = new TransactionData();

            return newData;
        }

        public int TransactionID { get; }

        public double TransactionAmount { get; set; }

        public Utility.TransactionErrorCodes TransactionCode { get; set; }

        public DateTime TransactionDateTime { get; }

        public int SourceAccount { get; set; }
       
        public int DestinationAccount { get; set; }

        public Utility.TransactionType TransactionType { get; }
    }
}