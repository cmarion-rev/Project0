using System;
using System.Collections.Generic;
using System.Text;

namespace Project_0
{
    public class LoanAccount : Account
    {
        public LoanAccount(Customer newCustomer, double InitialValue = 0.0) : base()
        {
            AccountNumber = IAccountInfo.GetNewAccountNumber();
            AccountType = Utility.AccountType.LOAN;

            // Set customer references.
            Customer = newCustomer;
            CustomerID = newCustomer.CustomerID;
            Customer.AddAccount(this);

            // Set initial account balance.
            AccountBalance = InitialValue;
            LastTransactionState = Utility.TransactionErrorCodes.SUCCESS;
            totalRecords.Add(new DepositRecord() { TransactionAmount = InitialValue, TransactionCode = Utility.TransactionErrorCodes.SUCCESS });
        }

        public override Utility.AccountType AccountType { get; }

        public override int AccountNumber { get; }

        public override int CustomerID { get; set; }

        public override Customer Customer { get; set; }

        public override double AccountBalance { get; protected set; }

        public override Utility.TransactionErrorCodes LastTransactionState { get; protected set; }

        /// <summary>
        /// Deposits funds to account.
        /// </summary>
        /// <param name="newAmount">Installment amount to be paid.</param>
        /// <returns>Returns true if transaction is valid; Otherwise, false.</returns>
        public override bool DepositAmount(double newAmount)
        {
            bool result = true;
            LastTransactionState = Utility.TransactionErrorCodes.SUCCESS;

            // Check if amount selected is a valid number.
            if (newAmount > 0.0f)
            {
                // Check if new amount exceeds current balance.
                if (newAmount > AccountBalance)
                {
                    // Notify of over payment.

                    // Set account balance to $0.00
                    totalRecords.Add(new WithdrawalRecord() { TransactionAmount = AccountBalance, TransactionCode = Utility.TransactionErrorCodes.SUCCESS });
                    AccountBalance = 0.0;
                }
                else if (newAmount == AccountBalance)
                {
                    // Final payment.
                    totalRecords.Add(new WithdrawalRecord() { TransactionAmount = newAmount, TransactionCode = Utility.TransactionErrorCodes.SUCCESS });
                    AccountBalance = 0.0;
                }
                else
                {
                    // Reduce current account balance.
                    totalRecords.Add(new WithdrawalRecord() { TransactionAmount = newAmount, TransactionCode = Utility.TransactionErrorCodes.SUCCESS });
                    AccountBalance -= newAmount;
                }
            }
            else
            {
                // Invalid amount selected.
                result = false;
                LastTransactionState = Utility.TransactionErrorCodes.INVALID_AMOUNT;
            }

            return result;
        }

        /// <summary>
        /// Withdraws funds from account, if possible.
        /// </summary>
        /// <param name="newAmount">Amount to be withdrawn.</param>
        /// <returns>Returns true if transaction is valid; Otherwise, false.</returns>
        public override bool WithdrawAmount(double newAmount)
        {
            bool result = false;
            LastTransactionState = Utility.TransactionErrorCodes.INVALID_AMOUNT;

            /* 
             * DO NOT ALLOW WITHDRAWAL ON LOAN ACCOUNT.
             */

            return result;
        }
    }
}