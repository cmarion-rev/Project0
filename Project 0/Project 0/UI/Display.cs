using System;
using System.Collections.Generic;
using System.Text;

namespace Project_0
{
    class Display : IDisplayGeneral, IDisplayAccount, IDisplayCustomer
    {
        #region ERROR MESSAGES

        public void DisplayInvalidAmount()
        {
            throw new NotImplementedException();
        }

        public void DisplayInvalidIndexOption()
        {
            throw new NotImplementedException();
        }

        public void DisplayInvalidSelection()
        {
            throw new NotImplementedException();
        }
        
        public void DisplayWithdrawalOverdraftProtection()
        {
            throw new NotImplementedException();
        }

        #endregion

        #region MENUS

        public void DisplayMainMenu(Utility.MainMenuOptions newOptions)
        {
            throw new NotImplementedException();
        }

        #endregion

        #region USER INPUTS

        public int GetUserOptionNumberSelection()
        {
            throw new NotImplementedException();
        }

        public Utility.OperationState GetUserSelection()
        {
            throw new NotImplementedException();
        }

        public double GetUserValueInput()
        {
            throw new NotImplementedException();
        }

        public bool WaitForUserConfirmation()
        {
            throw new NotImplementedException();
        }

        #endregion

        #region ACCOUNT OPTIONS

        public void DisplayAllAccountTransactions(ITransactionRecord[] allTransactions)
        {
            throw new NotImplementedException();
        }

        #region ACCOUNT DEPOSIT OPTIONS
        
        public void DisplayAccountForDepositing(Account newAccount)
        {
            throw new NotImplementedException();
        }

        public void DisplayDepositAccountOptions(Account[] allAccounts)
        {
            throw new NotImplementedException();
        }

        #endregion

        #region ACCOUNT WITHDRAWAL OPTIONS

        public void DisplayAccountForWithdrawing(Account newAccount)
        {
            throw new NotImplementedException();
        }

        public void DisplayWithdrawalAccountOptions(Account[] allAccounts)
        {
            throw new NotImplementedException();
        }

        #endregion

        #region ACCOUNT TRANSFER OPTIONS

        public void DisplayTransferSourceAccount(Account[] allAccounts)
        {
            throw new NotImplementedException();
        }

        public void DisplayTransferDestinationAccount(Account[] allAccounts)
        {
            throw new NotImplementedException();
        }

        public void DisplayAccountTransfer(Account[] sourceAccount, Account[] destinationAccount)
        {
            throw new NotImplementedException();
        }

        #endregion

        #region LOAN ACCOUNT OPTIONS

        public void DisplayLoanAccountSelection(Account[] allAccounts)
        {
            throw new NotImplementedException();
        }

        public void DisplayLoanInstallment()
        {
            throw new NotImplementedException();
        }

        #endregion
        
        #endregion

        #region CUSTOMER OPTIONS

        public void DisplayAllCustomerAccounts(Account[] allAccounts)
        {
            throw new NotImplementedException();
        }

        public void DisplayCustomerInformation(Customer newCustomer)
        {
            throw new NotImplementedException();
        }
     
        #endregion
    }
}