using System;
using System.Collections.Generic;
using System.Text;

namespace Project_0
{
    public class TermDepositAccount : Account, IAccountInfo
    {
        public DateTime MaturityDate { get; set; }

        public TermDepositAccount(Customer newCustomer) : base()
        {
            AccountNumber = IAccountInfo.totalAccounts++;
            Customer = newCustomer;
            // CustomerID = newCustomer.CustomerID;
            AccountBalance = 0.0;
        }

        public int CustomerID { get; set; }

        public Customer Customer { get; set; }

        public double AccountBalance { get; private set; }

        public Utility.TransactionErrorCodes LastTransactionState { get; private set; }

        public int AccountNumber { get; }

        public bool DepositAmount(double newAmount)
        {
            bool result = true;
            LastTransactionState = Utility.TransactionErrorCodes.SUCCESS;

            if (newAmount > 0.0f)
            {
                totalRecords.Add(new DepositRecord() { TransactionAmount = newAmount, TransactionCode = Utility.TransactionErrorCodes.SUCCESS });
            }
            else
            {
                result = false;
                LastTransactionState = Utility.TransactionErrorCodes.INVALID_AMOUNT;
            }

            return result;
        }

        public bool WithdrawAmount(double newAmount)
        {
            throw new NotImplementedException();
        }

        bool IDeposit.DepositAmount(double newAmount)
        {
            throw new NotImplementedException();
        }

        bool IWithdrawal.WithdrawAmount(double newAmount)
        {
            throw new NotImplementedException();
        }
    }
}