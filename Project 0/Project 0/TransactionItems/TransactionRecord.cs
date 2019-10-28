using System;
using System.Collections.Generic;
using System.Text;

namespace Project_0
{
    class TransactionRecord : ITransactionRecord
    {
        private TransactionData myTransaction = null;

        public TransactionRecord(Utility.TransactionType transactionType)
        {
            myTransaction = ITransactionRecord.GenerateNewTransactionData();

            if (myTransaction != null)
            {
                myTransaction.ID = ITransactionRecord.GenerateNewID();
                myTransaction.TimeStamp = DateTime.Now;
                myTransaction.TransactionType = (int)transactionType;
                myTransaction.TransactionCode = (int)Utility.TransactionCodes.SUCCESS;
            }
        }

        public int TransactionID
        {
            get
            {
                return myTransaction?.ID ?? -1;
            }
        }

        public double TransactionAmount
        {
            get
            {
                return myTransaction?.Amount ?? 0.0;
            }
            set
            {
                if (myTransaction != null)
                {
                    if (value > 0.0)
                    {
                        myTransaction.Amount = value;
                    }
                }
            }
        }

        public Utility.TransactionCodes TransactionCode
        {
            get
            {
                return (Utility.TransactionCodes)(myTransaction?.TransactionCode ?? -1);
            }
            set
            {
                if (myTransaction != null)
                {
                    myTransaction.TransactionCode = (int)value;
                }
            }
        }

        public DateTime TransactionDateTime
        {
            get
            {
                return myTransaction?.TimeStamp ?? DateTime.Now;
            }
        }

        public Utility.TransactionType TransactionType
        {
            get
            {
                return (Utility.TransactionType)(myTransaction?.TransactionType ?? -1);
            }
        }
    }
}