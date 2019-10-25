using System;
using System.Collections.Generic;
using System.Text;

namespace Project_0.TransactionItems
{
    class TransactionData
    {
        public int ID { get; set; }

        public int SourceAccountID { get; set; }

        public int DestinationAccountID { get; set; }

        public double Amount { get; set; }

        public int TransactionCode { get; set; }

        public DateTime TimeStamp { get; set; }
    }
}