using System;
using System.Collections.Generic;
using System.Text;

namespace Project_0
{
    interface IWithdrawal
    {
        public Utility.TransactionErrorCodes WithdrawState { get; }

        public bool WithdrawAmount(double newAmount);

        public Utility.TransactionErrorCodes LastWithdrawError();
    }
}
