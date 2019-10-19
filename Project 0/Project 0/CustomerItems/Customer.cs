using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;


namespace Project_0
{
    public class Customer : ICustomerAccounts
    {
        private static int totalCustomers = 0;

        public int CustomerID { get; }

        private List<Account> customerAccounts = new List<Account>();

        public Customer()
        {
            CustomerID = ++totalCustomers;
            customerAccounts = new List<Account>();
        }

        public List<Account> GetAccounts()
        {
            return customerAccounts;
        }

        public List<CheckingAccount> GetCheckingAccounts()
        {
            List<CheckingAccount> result = new List<CheckingAccount>();

            result = customerAccounts.Where(account => account is CheckingAccount).ToList().Cast<CheckingAccount>().ToList();

            return result;
        }

        public List<BusinessAccount> GetBusinessAccounts()
        {
            List<BusinessAccount> result = new List<BusinessAccount>();

            result = customerAccounts.Where(account => account is BusinessAccount).ToList().Cast<BusinessAccount>().ToList();

            return result;
        }

        public List<TermDepositAccount> GetTermDepositAccounts()
        {
            List<TermDepositAccount> result = new List<TermDepositAccount>();

            result = customerAccounts.Where(account => account is TermDepositAccount).ToList().Cast<TermDepositAccount>().ToList();

            return result;
        }

        public List<LoanAccount> GetLoanAccounts()
        {
            List<LoanAccount> result = new List<LoanAccount>();

            result = customerAccounts.Where(account => account is LoanAccount).ToList().Cast<LoanAccount>().ToList();

            return result;
        }

        public Account GetAccount(int index)
        {
            Account result = null;

            if (index > -1)
            {
                if (index < customerAccounts.Count)
                {
                    result = customerAccounts[index];
                }
            }

            return result;
        }

        public bool AddAccount(Account newAccount)
        {
            bool result = true;

            if (customerAccounts.Contains(newAccount))
            {
                result = false;
            }
            else
            {
                customerAccounts.Add(newAccount);
            }

            return result;
        }

        public bool RemoveAccount(Account newAccount)
        {
            bool result = true;

            int index = customerAccounts.IndexOf(newAccount);
            if (index > -1)
            {
                customerAccounts.RemoveAt(index);
            }
            else
            {
                result = false;
            }

            return result;
        }

        public int GetNumberOfAccounts()
        {
            return customerAccounts.Count;
        }

        public Account GetAccountByNumber(int accountNumber)
        {
            Account result = null;

            foreach (IAccountInfo currentAccount in customerAccounts)
            {
                if (currentAccount.AccountNumber == accountNumber)
                {
                    result = (currentAccount as Account);
                    break;
                }
            }

            return result;
        }
    }
}