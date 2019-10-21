using System;
using System.Collections.Generic;
using System.Text;

namespace Project_0
{
    public class BusinessAccount : Account, IAccountInfo
    {
        public BusinessAccount(Customer newCustomer) : base()
        {
            AccountNumber = IAccountInfo.GetNewAccountNumber();
            AccountType = Utility.AccountType.BUSINESS;

            // Set customer references.
            Customer = newCustomer;
            CustomerID = newCustomer.CustomerID;

            // Set initial account balance.
            AccountBalance = 0.0;
            OverdraftBalance = 0.0;
        }

        public Utility.AccountType AccountType { get; private set; }

        public int AccountNumber { get; }

        public int CustomerID { get ; set ; }
        public Customer Customer { get ; set; }

        public double AccountBalance { get; private set; }

        public Utility.TransactionErrorCodes LastTransactionState { get; private set; }

        public double OverdraftBalance { get; private set; }

        /// <summary>
        /// Deposits funds to account.
        /// </summary>
        /// <param name="newAmount">Amount to be deposited.</param>
        /// <returns>Returns True if transaction is valid; Otherwise, False.</returns>
        public bool DepositAmount(double newAmount)
        {
            bool result = true;
            bool canDepositAccount = true;
            LastTransactionState = Utility.TransactionErrorCodes.SUCCESS;

            // Check if amount selected is a valid number.
            if (newAmount > 0.0f)
            {
                // Check for overdrafted balance.
                canDepositAccount = CheckOverdraft(ref newAmount);

                // Check if not still overdrafted.
                if (canDepositAccount)
                {
                    AccountBalance += newAmount;
                    totalRecords.Add(new DepositRecord() { TransactionAmount = newAmount, TransactionCode = Utility.TransactionErrorCodes.SUCCESS });
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
        /// Check overdrafted balance of account.
        /// </summary>
        /// <param name="newAmount">Amount to be deposited.</param>
        /// <returns>Returns True if deposit amount can still be added to account balance. Otherwise, False.</returns>
        private bool CheckOverdraft(ref double newAmount)
        {
            bool result = true;

            // Check if account is overdrafted.
            if (OverdraftBalance > 0.0)
            {
                // Check if amount with fulfill overdraft amount.
                if (OverdraftBalance <= newAmount)
                {
                    // Decrement amount by current overdraft balance.
                    newAmount -= OverdraftBalance;

                    // Clear overdraft balance.
                    OverdraftBalance = 0.0;
                    result = true;
                }
                else
                {
                    // Decrement overdraft balance.
                    OverdraftBalance -= newAmount;
                    totalRecords.Add(new DepositRecord() { TransactionAmount = newAmount, TransactionCode = Utility.TransactionErrorCodes.SUCCESS });
                    result = false;
                }
            }

            return result;
        }

        /// <summary>
        /// Withdraws funds from account, if possible.
        /// </summary>
        /// <param name="newAmount">Amount to be withdrawn.</param>
        /// <returns>Returns True if transaction is valid; Otherwise, False.</returns>
        public bool WithdrawAmount(double newAmount)
        {
            bool result = true;
            LastTransactionState = Utility.TransactionErrorCodes.SUCCESS;

            // Check if amount selected is a valid number.
            if (newAmount > 0.0)
            {
                // Check if withdraw amount does not exceed current account amount.
                CheckOverdrafting(newAmount);
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
        /// Checks account for avaliable funds to be withdrawn.
        /// </summary>
        /// <param name="newAmount">Amount to be withdrawn.</param>
        /// <returns>Returns true if transaction is valid; Otherwise, false.</returns>
        private bool CheckOverdrafting(double newAmount)
        {
            bool result = true;

            if (newAmount <= AccountBalance)
            {
                AccountBalance -= newAmount;
                totalRecords.Add(new WithdrawalRecord() { TransactionAmount = newAmount, TransactionCode = Utility.TransactionErrorCodes.SUCCESS });
            }
            else
            {
                // Check if account balance exists.
                if (AccountBalance > 0.0)
                {
                    newAmount -= AccountBalance;
                    AccountBalance = 0.0;
                }
                OverdraftBalance += newAmount;
                totalRecords.Add(new WithdrawalRecord() { TransactionAmount = newAmount, TransactionCode = Utility.TransactionErrorCodes.SUCCESS });
            }

            return result;
        }
    }
}