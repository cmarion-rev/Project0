﻿using System;
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

        public Utility.TransactionErrorCodes TransactionCode
        {
            get
            {
                return (Utility.TransactionErrorCodes)(myTransaction?.TransactionCode ?? -1);
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

        public int SourceAccount
        {
            get
            {
                return myTransaction?.SourceAccountID ?? -1;
            }
            set
            {
                if (myTransaction!=null)
                {
                    if (value > -1)
                    {
                        myTransaction.SourceAccountID = value;
                    }
                }
            }
        }

        public int DestinationAccount
        {
            get
            {
                return myTransaction?.DestinationAccountID ?? -1;
            }
            set
            {
                if (myTransaction != null)
                {
                    if (value > -1)
                    {
                        myTransaction.DestinationAccountID = value;
                    }
                }
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