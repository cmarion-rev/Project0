﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Project_0
{
    class Utility
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
            WITHDRAW_SUCCESS,
            DEPOSIT_SUCCESS,

            OVERDRAFT,
            TERM_PROTECTION,
        }
    }
}
