using System;
using System.Collections.Generic;
using System.Text;

namespace Project_0
{
    class AccountData : IAccountDataAddAccounts, IAccountDataGetAccounts, IAccountDataRemoveAccounts
    {
        private List<CheckingAccount> allCheckingAccounts = new List<CheckingAccount>();
        private List<BusinessAccount> allBusinessAccounts = new List<BusinessAccount>();
        private List<TermDepositAccount> allTermAccounts = new List<TermDepositAccount>();
        private List<LoanAccount> allLoanAccounts = new List<LoanAccount>();

        public bool AddAccount(Account newAccount)
        {
            throw new NotImplementedException();
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
    }
}
