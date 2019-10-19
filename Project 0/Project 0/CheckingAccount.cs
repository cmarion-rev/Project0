using System;
using System.Collections.Generic;
using System.Text;

namespace Project_0
{
    class CheckingAccount : Account, IAccountInfo
    {
        public CheckingAccount(Customer newCustomer) : base()
        {
            AccountNumber = IAccountInfo.totalAccounts++;

            // Set customer references.
            Customer = newCustomer;
            // CustomerID = newCustomer.CustomerID;

            // Set initial account balance.
            AccountBalance = 0.0;
        }

        public static double InterestRate { get; set; }

        public int AccountNumber { get; }

        public int CustomerID { get; set; }

        public Customer Customer { get; set; }

        public double AccountBalance { get; private set; }

        public Utility.TransactionErrorCodes LastTransactionState { get; private set; }

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
            throw new NotImplementedException();
        }
    }
}
