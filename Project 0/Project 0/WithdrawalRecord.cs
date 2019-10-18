﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Project_0
{
    class WithdrawalRecord : ITransactionRecord
    {
        public WithdrawalRecord()
        {
            TransactionID = ITransactionRecord.TransactionNumber++;
        }

        public int TransactionID { get; }

        public double TransactionAmount { get; set; }

        public Utility.TransactionErrorCodes TransactionCode { get; set; }
    }
}