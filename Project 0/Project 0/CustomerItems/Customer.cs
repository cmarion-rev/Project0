using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;


namespace Project_0
{
    public class Customer : ICustomerAccounts
    {
        private static int totalCustomers = 0;

        public int CustomerID { get;  }

        private List<Account> accounts = new List<Account>();

        Customer()
        {
            CustomerID = ++totalCustomers;
            accounts = new List<Account>();
        }

        public List<Account> GetAccounts()
        {
            return accounts;
        }

        public List<CheckingAccount> GetCheckingAccounts()
        {
            List<CheckingAccount> result = new List<CheckingAccount>();

            result = accounts.Where(account => account is CheckingAccount).ToList().Cast<CheckingAccount>().ToList();

            return result;
        }

        public List<BusinessAccount> GetBusinessAccounts()
        {
            List<BusinessAccount> result = new List<BusinessAccount>();

            result = accounts.Where(account => account is BusinessAccount).ToList().Cast<BusinessAccount>().ToList();

            return result;
        }

        public List<TermDepositAccount> GetTermDepositAccounts()
        {
            List<TermDepositAccount> result = new List<TermDepositAccount>();

            result = accounts.Where(account => account is TermDepositAccount).ToList().Cast<TermDepositAccount>().ToList();

            return result;
        }

        public List<LoanAccount> GetLoanAccounts()
        {
            List<LoanAccount> result = new List<LoanAccount>();

            result = accounts.Where(account => account is LoanAccount).ToList().Cast<LoanAccount>().ToList();

            return result;
        }

        public Account GetAccount(int index)
        {
            throw new NotImplementedException();
        }

        public bool AddAccount(Account newAccount)
        {
            throw new NotImplementedException();
        }

        public bool RemoveAccount(Account newAccount)
        {
            throw new NotImplementedException();
        }

        public int GetNumberOfAccounts()
        {
            return accounts.Count;
        }
    }
}