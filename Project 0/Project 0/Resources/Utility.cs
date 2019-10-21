using System;
using System.Collections.Generic;
using System.Text;

namespace Project_0
{
    public class Utility
    {
        public enum AccountType
        {
            CHECKING,
            BUSINESS,
            TERM,
            LOAN,
        }

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


            EXIT_PROGRAM,
        }

        public enum TransactionErrorCodes
        {
            SUCCESS,

            // Withdrawal Errors.
            OVERDRAFT_PROTECTION,
            TERM_PROTECTION,

            // Deposit Errors.
            INVALID_AMOUNT,
        }

        [Flags]
        public enum MainMenuOptions
        {
            REGISTER_NEW_CUSTOMER = 1 << 0,
            OPEN_NEW_ACCOUNT = 1 << 1,
            CLOSE_ACCOUNT = 1 << 2,
            WITHDRAW_AMOUNT = 1 << 3,
            DEPOSIT_AMOUNT = 1 << 4,
            TRANSFER_AMOUNT = 1 << 5,
            PAY_LOAN_INSTALLMENT = 1 << 6,
            DISPLAY_ALL_ACCOUNTS = 1 << 7,
            DISPLAY_ALL_TRANSACTIONS = 1 << 8,
            //

            //
            EXIT_PROGRAM = 1 << 16,
        }
    }
}
