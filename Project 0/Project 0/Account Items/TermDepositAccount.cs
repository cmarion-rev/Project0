using System;
using System.Collections.Generic;
using System.Text;

namespace Project_0
{
    public class TermDepositAccount : Account
    {
        public TermDepositAccount(Customer newCustomer, AccountData newAccount, double newBalance = 0.0) : base(newAccount)
        {
            if (newAccount != null)
            {
                // Set initial account.
                newAccount.AccountNumber = IAccountInfo.GetNewAccountNumber();
                newAccount.AccountType = Utility.AccountType.TERM;
                newAccount.LastTransactionState = Utility.TransactionErrorCodes.SUCCESS;
                if (newBalance > 0.0)
                {
                    newAccount.AccountBalance = newBalance;
                    totalRecords.Add(new DepositRecord() { TransactionAmount = newBalance, TransactionCode = Utility.TransactionErrorCodes.SUCCESS });
                }
                else
                {
                    newAccount.AccountBalance = 0.0;
                }

                // Set customer references.
                newAccount.Customer = newCustomer;
                newAccount.CustomerID = newCustomer.CustomerID;

                // Default 1 Year term.
                newAccount.MaturityDate = DateTime.Now.AddYears(1);
            }
            Customer.AddAccount(this);
        }

        /// <summary>
        /// Deposits funds to account.
        /// </summary>
        /// <param name="newAmount">Amount to be deposited.</param>
        /// <returns>Returns true if transaction is valid; Otherwise, false.</returns>
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
        /// <returns>Returns true if transaction is valid; Otherwise, false.</returns>
        public override bool WithdrawAmount(double newAmount)
        {
            bool result = false;

            if (myAccount != null)
            {
                myAccount.LastTransactionState = Utility.TransactionErrorCodes.SUCCESS;

                // Check if amount selected is a valid number.
                if (newAmount > 0.0)
                {
                    // Check if maturity date has passed.
                    result = CheckMaturity(newAmount);
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
        /// Checks account for proper maturity before allowing withdrawal.
        /// </summary>
        /// <param name="newAmount">Amount to be withdrawn.</param>
        /// <returns>Returns true if transaction is valid; Otherwise, false.</returns>
        private bool CheckMaturity(double newAmount)
        {
            bool result = false;

            if (myAccount != null)
            {
                if (myAccount.MaturityDate.Date.Subtract(DateTime.Now).Days < 0)
                {
                    // Check if withdraw amount does not exceed current account amount.
                    result = CheckOverdrafting(newAmount);
                }
                else
                {
                    // Maturity not reached.
                    myAccount.LastTransactionState = Utility.TransactionErrorCodes.TERM_PROTECTION;
                }
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
            bool result = false;

            if (myAccount != null)
            {
                if (newAmount <= AccountBalance)
                {
                    myAccount.AccountBalance -= newAmount;
                    totalRecords.Add(new WithdrawalRecord() { TransactionAmount = newAmount, TransactionCode = Utility.TransactionErrorCodes.SUCCESS });
                    result = true;
                }
                else
                {
                    // Over Draft error.
                    myAccount.LastTransactionState = Utility.TransactionErrorCodes.OVERDRAFT_PROTECTION;
                }
            }

            return result;
        }
    }
}