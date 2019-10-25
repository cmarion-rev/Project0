using System;
using System.Collections.Generic;
using System.Text;

namespace Project_0
{
    public abstract class Account : IAccountTransaction, IAccountInfo
    {
        protected readonly List<ITransactionRecord> totalRecords = new List<ITransactionRecord>();

        public Account(AccountData newAccount)
        {
            if (myAccount != newAccount)
            {
                myAccount = newAccount;
            }
            totalRecords = new List<ITransactionRecord>();
        }

        protected AccountData myAccount;

        public virtual Utility.AccountType AccountType
        {
            get
            {
                return myAccount?.AccountType ?? (Utility.AccountType)(-1);
            }
            set
            {
                if (myAccount != null)
                {
                    myAccount.AccountType = value;
                }
            }
        }

        public int AccountNumber
        {
            get
            {
                return myAccount?.AccountNumber ?? -1;
            }
        }

        public int CustomerID
        {
            get
            {
                return myAccount?.CustomerID ?? -1;
            }
        }

        public Customer Customer
        {
            get
            {
                return myAccount?.Customer ?? null;
            }
        }

        public double AccountBalance
        {
            get
            {
                return myAccount?.AccountBalance ?? 0.0;
            }
        }

        public Utility.TransactionErrorCodes LastTransactionState
        {
            get
            {
                return myAccount?.LastTransactionState ?? (Utility.TransactionErrorCodes)(-1);
            }
        }

        public ITransactionRecord[] GetTransactionRecords()
        {
            return totalRecords.ToArray();
        }

        public abstract bool DepositAmount(double newAmount);

        public abstract bool WithdrawAmount(double newAmount);
    }
}