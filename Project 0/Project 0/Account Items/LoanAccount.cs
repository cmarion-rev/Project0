using System;
using System.Collections.Generic;
using System.Text;

namespace Project_0
{
    public class LoanAccount : Account
    {
        public LoanAccount(Customer newCustomer, AccountData newAccount, double newBalance = 0.0) : base(newAccount)
        {
            if (newAccount != null)
            {
                // Set initial account balance.
                newAccount.AccountNumber = IAccountInfo.GetNewAccountNumber();
                newAccount.AccountType = Utility.AccountType.LOAN;
                newAccount.LastTransactionState = Utility.TransactionCodes.SUCCESS;
                if (newBalance > 0.0)
                {
                    newAccount.AccountBalance = newBalance;
                    totalRecords.Add(new TransactionRecord(Utility.TransactionType.OPEN_ACCOUNT) { TransactionAmount = newBalance });
                }
                else
                {
                    newAccount.AccountBalance = 0.0;
                }

                // Set customer references.
                newAccount.Customer = newCustomer;
                newAccount.CustomerID = newCustomer?.CustomerID ?? -1;
            }
            Customer.AddAccount(this);
        }

        /// <summary>
        /// Deposits funds to account.
        /// </summary>
        /// <param name="newAmount">Installment amount to be paid.</param>
        /// <returns>Returns true if transaction is valid; Otherwise, false.</returns>
        public override bool DepositAmount(double newAmount)
        {
            bool result = false;

            if (myAccount != null)
            {
                myAccount.LastTransactionState = Utility.TransactionCodes.SUCCESS;

                // Check if amount selected is a valid number.
                if (newAmount > 0.0f)
                {
                    // Check if new amount exceeds current balance.
                    if (newAmount > AccountBalance)
                    {
                        // Notify of over payment.

                        // Set account balance to $0.00
                        totalRecords.Add(new TransactionRecord(Utility.TransactionType.WITHDRAWAL) { TransactionAmount = AccountBalance});
                        myAccount.AccountBalance = 0.0;
                    }
                    else if (newAmount == AccountBalance)
                    {
                        // Final payment.
                        totalRecords.Add(new TransactionRecord(Utility.TransactionType.WITHDRAWAL) { TransactionAmount = newAmount});
                        myAccount.AccountBalance = 0.0;
                    }
                    else
                    {
                        // Reduce current account balance.
                        totalRecords.Add(new TransactionRecord(Utility.TransactionType.WITHDRAWAL) { TransactionAmount = newAmount });
                        myAccount.AccountBalance -= newAmount;
                    }
                    result = true;
                }
                else
                {
                    // Invalid amount selected.
                    myAccount.LastTransactionState = Utility.TransactionCodes.INVALID_AMOUNT;
                }
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

            if (myAccount != null)
            {
                myAccount.LastTransactionState = Utility.TransactionCodes.INVALID_AMOUNT;
            }

            /* 
             * DO NOT ALLOW WITHDRAWAL ON LOAN ACCOUNT.
             */

            return result;
        }
    }
}