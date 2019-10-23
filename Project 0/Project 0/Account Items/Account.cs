using System;
using System.Collections.Generic;
using System.Text;

namespace Project_0
{
    public abstract class Account: IAccountTransaction, IAccountInfo
    {
        protected List<ITransactionRecord> totalRecords = new List<ITransactionRecord>();

        public abstract Utility.AccountType AccountType { get; }
        
        public Account()
        {
            totalRecords = new List<ITransactionRecord>();
        }
        
        public abstract int AccountNumber { get; }
        
        public abstract int CustomerID { get; set; }
        
        public abstract Customer Customer { get; set; }
        
        public abstract double AccountBalance { get; protected set; }
        
        public abstract Utility.TransactionErrorCodes LastTransactionState { get; protected set; }

        public ITransactionRecord[] GetTransactionRecords()
        {
            return totalRecords.ToArray();
        }

        public abstract bool DepositAmount(double newAmount);
        
        public abstract bool WithdrawAmount(double newAmount);
    }
}
