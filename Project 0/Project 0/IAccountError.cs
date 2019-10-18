using System;
using System.Collections.Generic;
using System.Text;

namespace Project_0
{
    public interface IAccountError
    {
        public Utility.TransactionErrorCodes LastTransactionState { get; }
    }
}