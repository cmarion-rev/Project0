using System;
using System.Collections.Generic;
using System.Text;

namespace Project_0
{
    public class TermDepositAccount : Account
    {
        public TermDepositAccount(Customer newCustomer) : base()
        {
            AccountNumber = IAccountInfo.GetNewAccountNumber();
            AccountType = Utility.AccountType.TERM;

            // Set customer references.
            Customer = newCustomer;
            CustomerID = newCustomer.CustomerID;
            Customer.AddAccount(this);

            // Set initial account balance.
            AccountBalance = 0.0;

            // Default 1 Year term.
            MaturityDate = DateTime.Now.AddYears(1);
        }

        public override Utility.AccountType AccountType { get; }

        public override int AccountNumber { get; }

        public override DateTime MaturityDate { get; set; }

        public override int CustomerID { get; set; }

        public override Customer Customer { get; set; }

        public override double AccountBalance { get; protected set; }

        public override Utility.TransactionErrorCodes LastTransactionState { get; protected set; }

        /// <summary>
        /// Deposits funds to account.
        /// </summary>
        /// <param name="newAmount">Amount to be deposited.</param>
        /// <returns>Returns true if transaction is valid; Otherwise, false.</returns>
        public override bool DepositAmount(double newAmount)
        {
            bool result = true;
            LastTransactionState = Utility.TransactionErrorCodes.SUCCESS;

            // Check if amount selected is a valid number.
            if (newAmount > 0.0f)
            {
                AccountBalance += newAmount;
                totalRecords.Add(new DepositRecord() { TransactionAmount = newAmount, TransactionCode = Utility.TransactionErrorCodes.SUCCESS });
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
            bool result = true;
            LastTransactionState = Utility.TransactionErrorCodes.SUCCESS;

            // Check if amount selected is a valid number.
            if (newAmount > 0.0)
            {
                // Check if maturity date has passed.
                result = CheckMaturity(newAmount);
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
        /// Checks account for proper maturity before allowing withdrawal.
        /// </summary>
        /// <param name="newAmount">Amount to be withdrawn.</param>
        /// <returns>Returns true if transaction is valid; Otherwise, false.</returns>
        private bool CheckMaturity(double newAmount)
        {
            bool result = true;
            
            if (MaturityDate.Date.Subtract(DateTime.Now).Days > -1)
            {
                // Check if withdraw amount does not exceed current account amount.
                result = CheckOverdrafting(newAmount);
            }
            else
            {
                // Maturity not reached.
                result = false;
                LastTransactionState = Utility.TransactionErrorCodes.TERM_PROTECTION;
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
                // Over Draft error.
                result = false;
                LastTransactionState = Utility.TransactionErrorCodes.OVERDRAFT_PROTECTION;
            }

            return result;
        }
    }
}