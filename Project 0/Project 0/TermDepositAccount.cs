using System;
using System.Collections.Generic;
using System.Text;

namespace Project_0
{
    public class TermDepositAccount : Account, IAccountInfo
    {
        public TermDepositAccount(Customer newCustomer) : base()
        {
            AccountNumber = IAccountInfo.totalAccounts++;
            Customer = newCustomer;
            // CustomerID = newCustomer.CustomerID;
            AccountBalance = 0.0;

            // Default 1 Year term.
            MaturityDate = DateTime.Now.AddYears(1);
        }

        public DateTime MaturityDate { get; set; }

        public int CustomerID { get; set; }

        public Customer Customer { get; set; }

        public double AccountBalance { get; private set; }

        public Utility.TransactionErrorCodes LastTransactionState { get; private set; }

        public int AccountNumber { get; }

        public bool DepositAmount(double newAmount)
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

        public bool WithdrawAmount(double newAmount)
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
                // Maturity not reached.
                result = false;
                LastTransactionState = Utility.TransactionErrorCodes.OVERDRAFT;
            }

            return result;
        }
    }
}