using System;
using System.Collections.Generic;
using System.Text;

namespace Project_0
{
    interface IWithdrawal
    {
        public Utility.WithdrawalErrorCodes WithdrawState { get; }

        public bool WithdrawAmount(double newAmount);

        public Utility.WithdrawalErrorCodes LastWithdrawError();
    }
}
