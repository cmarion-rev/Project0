using System;
using System.Collections.Generic;
using System.Text;

namespace Project_0
{
    class AccountData : IAccountDataAddAccounts, IAccountDataGetAccounts, IAccountDataRemoveAccounts
    {
        private readonly Dictionary<Utility.AccountType, List<Account>> allAccounts = new Dictionary<Utility.AccountType, List<Account>>();

        public static AccountData Instance { get; private set; }

        AccountData()
        {
            if (Instance == null)
            {
                Instance = this;
                allAccounts = new Dictionary<Utility.AccountType, List<Account>>();

                // Add new keys.
                allAccounts.Add(Utility.AccountType.CHECKING, new List<Account>());
                allAccounts.Add(Utility.AccountType.BUSINESS, new List<Account>());
                allAccounts.Add(Utility.AccountType.TERM, new List<Account>());
                allAccounts.Add(Utility.AccountType.LOAN, new List<Account>());
            }
        }


        #region ADD ACCOUNTS

        public bool AddAccount(Account newAccount)
        {
           
        }

        public bool AddBusinessAccount(BusinessAccount newAccount)
        {
            throw new NotImplementedException();
        }

        public bool AddCheckingAccount(CheckingAccount newAccount)
        {
            throw new NotImplementedException();
        }

        public bool AddLoanAccount(LoanAccount newAccount)
        {
            throw new NotImplementedException();
        }

        public bool AddTermAccount(TermDepositAccount newAccount)
        {
            throw new NotImplementedException();
        }

        #endregion

        #region GET ACCOUNTS

        public Account GetAccount(int accountNumber)
        {
            throw new NotImplementedException();
        }

        public BusinessAccount GetBusinessAccount(int accountNumber)
        {
            throw new NotImplementedException();
        }

        public CheckingAccount GetCheckingAccount(int accountNumber)
        {
            throw new NotImplementedException();
        }

        public LoanAccount GetLoanAccount(int accountNumber)
        {
            throw new NotImplementedException();
        }

        public TermDepositAccount GetTermAccount(int accountNumber)
        {
            throw new NotImplementedException();
        }

        #endregion

        #region REMOVE ACCOUNTS

        public bool RemoveAccount(Account newAccount)
        {
            throw new NotImplementedException();
        }

        public bool RemoveBusinessAccount(BusinessAccount newAccount)
        {
            throw new NotImplementedException();
        }

        public bool RemoveCheckingAccount(CheckingAccount newAccount)
        {
            throw new NotImplementedException();
        }

        public bool RemoveLoanAccount(LoanAccount newAccount)
        {
            throw new NotImplementedException();
        }

        public bool RemoveTermAccount(TermDepositAccount newAccount)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
