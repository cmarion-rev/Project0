using System;
using System.Collections.Generic;
using System.Text;

namespace Project_0
{
    public class BusinessAccount : Account
    {
        public BusinessAccount(Customer newCustomer, AccountData newAccount, double newBalance = 0.0) : base(newAccount)
        {
            // Initialize new account.
            if (newAccount != null)
            {
                newAccount.AccountNumber = IAccountInfo.GetNewAccountNumber();
                newAccount.AccountType = Utility.AccountType.BUSINESS;
                newAccount.AccountBalance = newBalance;
                newAccount.LastTransactionState = Utility.TransactionErrorCodes.SUCCESS;

                // Set customer references.
                newAccount.Customer = newCustomer;
                newAccount.CustomerID = newCustomer?.CustomerID ?? -1;
            }
            Customer.AddAccount(this);
        }

        /// <summary>
        /// Deposits funds to account.
        /// </summary>
        /// <param name="newAmount">Amount to be deposited.</param>
        /// <returns>Returns True if transaction is valid; Otherwise, False.</returns>
        public override bool DepositAmount(double newAmount)
        {
            bool result = false;
            if (myAccount != null)
            {
                myAccount.LastTransactionState = Utility.TransactionErrorCodes.SUCCESS;

                // Check if amount selected is a valid number.
                if (newAmount > 0.0f)
                {
                    myAccount.AccountBalance += newAmount;
                    totalRecords.Add(new DepositRecord() { TransactionAmount = newAmount, TransactionCode = Utility.TransactionErrorCodes.SUCCESS });
                    result = true;
                }
                else
                {
                    // Invalid amount selected.
                    myAccount.LastTransactionState = Utility.TransactionErrorCodes.INVALID_AMOUNT;
                }
            }

            return result;
        }

        /// <summary>
        /// Withdraws funds from account, if possible.
        /// </summary>
        /// <param name="newAmount">Amount to be withdrawn.</param>
        /// <returns>Returns True if transaction is valid; Otherwise, False.</returns>
        public override bool WithdrawAmount(double newAmount)
        {
            bool result = false;

            if (myAccount != null)
            {
                myAccount.LastTransactionState = Utility.TransactionErrorCodes.SUCCESS;

                // Check if amount selected is a valid number.
                if (newAmount > 0.0)
                {
                    // Check if withdraw amount does not exceed current account amount.
                    myAccount.AccountBalance -= newAmount;
                    totalRecords.Add(new WithdrawalRecord() { TransactionAmount = newAmount, TransactionCode = Utility.TransactionErrorCodes.SUCCESS });
                    result = true;
                }
                else
                {
                    // Invalid amount selected.
                    myAccount.LastTransactionState = Utility.TransactionErrorCodes.INVALID_AMOUNT;
                }
            }

            return result;
        }
    }
}