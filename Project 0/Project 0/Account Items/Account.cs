using System;
using System.Collections.Generic;
using System.Text;

namespace Project_0
{
    public abstract class Account
    {
        protected List<ITransactionRecord> totalRecords = new List<ITransactionRecord>();
        
        public Account()
        {
            totalRecords = new List<ITransactionRecord>();
        }
    }
}
