using System;
using System.Collections.Generic;
using System.Text;

namespace Project_0
{
    public class Utility
    {
        public enum OperationState
        {
            REGISTER,
            OPEN_ACCOUNT,
            CLOSE_ACCOUNT,
            WITHDRAW,
            DEPOSIT,
            TRANSFER,
            PAY_LOAN,
            DISPLAY_ACCOUNTS,
            DISPLAY_TRANSACTIONS,
        }

        public enum TransactionErrorCodes
        {
            SUCCESS,

            // Withdrawal Errors.
            OVERDRAFT,
            TERM_PROTECTION,

            // Deposit Errors.
            INVALID_AMOUNT,
        }
    }
}
