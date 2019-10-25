using System;
using System.Collections.Generic;
using System.Text;

namespace Project_0
{
    class AccountStorage : IAccountDataAddAccounts, IAccountDataGetAccounts, IAccountDataRemoveAccounts
    {
        private readonly Dictionary<Utility.AccountType, List<Account>> allAccounts = new Dictionary<Utility.AccountType, List<Account>>();

        private static AccountStorage workingInstance = null;

        public static AccountStorage Instance
        {
            get
            {
                if (workingInstance == null)
                {
                    workingInstance = new AccountStorage();
                }
                return workingInstance;
            }
        }

        AccountStorage()
        {
            allAccounts = new Dictionary<Utility.AccountType, List<Account>>();

            // Add new keys.
            allAccounts.Add(Utility.AccountType.CHECKING, new List<Account>());
            allAccounts.Add(Utility.AccountType.BUSINESS, new List<Account>());
            allAccounts.Add(Utility.AccountType.TERM, new List<Account>());
            allAccounts.Add(Utility.AccountType.LOAN, new List<Account>());
        }

        #region ADD ACCOUNTS

        public Account GenerateNewAccount(Utility.AccountType newType, Customer currentCustomer, double newBalance = 0.0)
        {
            Account newAccount = null;

            switch (newType)
            {
                case Utility.AccountType.CHECKING:
                    newAccount = AddNewCheckingAccount(currentCustomer,newBalance);
                    break;

                case Utility.AccountType.BUSINESS:
                    newAccount = AddNewBusinessAccount(currentCustomer, newBalance);
                    break;

                case Utility.AccountType.TERM:
                    newAccount = AddNewTermAccount(currentCustomer, newBalance);
                    break;

                case Utility.AccountType.LOAN:
                    newAccount = AddNewLoanAccount(currentCustomer, newBalance);
                    break;

                default:
                    break;
            }

            return newAccount;
        }

        public Account GenerateNewBusinessAccount(Customer currentCustomer, double newBalance = 0.0)
        {
            Account newAccount = null;

            newAccount = AddNewBusinessAccount(currentCustomer, newBalance);

            return newAccount;
        }

        public Account GenerateNewCheckingAccount(Customer currentCustomer, double newBalance = 0.0)
        {
            Account newAccount = null;

            newAccount = AddNewCheckingAccount(currentCustomer, newBalance);

            return newAccount;
        }

        public Account GenerateNewLoanAccount(Customer currentCustomer, double newBalance = 0.0)
        {
            Account newAccount = null;

            newAccount = AddNewLoanAccount(currentCustomer, newBalance);

            return newAccount;
        }

        public Account GenerateNewTermAccount(Customer currentCustomer, double newBalance = 0.0)
        {
            Account newAccount = null;

            newAccount = AddNewTermAccount(currentCustomer, newBalance);

            return newAccount;
        }

        private Account AddNewCheckingAccount(Customer currentCustomer, double newBalance = 0.0)
        {
            Account newAccount = null;

            // Generate new account data.
            AccountData newData = GenerateNewAccountData();

            // Create new checking account.
            newAccount = new CheckingAccount(currentCustomer, newData, newBalance);

            // Add new checking account to master list inside dictionary.
            allAccounts[Utility.AccountType.CHECKING].Add(newAccount);

            return newAccount;
        }

        private Account AddNewBusinessAccount(Customer currentCustomer, double newBalance = 0.0)
        {
            Account newAccount = null;

            // Generate new account data.
            AccountData newData = GenerateNewAccountData();

            // Create new checking account.
            newAccount = new BusinessAccount(currentCustomer, newData, newBalance);

            // Add new checking account to master list inside dictionary.
            allAccounts[Utility.AccountType.BUSINESS].Add(newAccount);

            return newAccount;
        }

        private Account AddNewTermAccount(Customer currentCustomer, double newBalance = 0.0)
        {
            Account newAccount = null;

            // Generate new account data.
            AccountData newData = GenerateNewAccountData();

            // Create new checking account.
            newAccount = new TermDepositAccount(currentCustomer, newData, newBalance);

            // Add new checking account to master list inside dictionary.
            allAccounts[Utility.AccountType.TERM].Add(newAccount);

            return newAccount;
        }

        private Account AddNewLoanAccount(Customer currentCustomer, double newBalance = 0.0)
        {
            Account newAccount = null;

            // Generate new account data.
            AccountData newData = GenerateNewAccountData();

            // Create new checking account.
            newAccount = new LoanAccount(currentCustomer, newData, newBalance);

            // Add new checking account to master list inside dictionary.
            allAccounts[Utility.AccountType.LOAN].Add(newAccount);

            return newAccount;
        }


        private AccountData GenerateNewAccountData()
        {
            // Create new accountdata.
            AccountData newData = new AccountData();

            return newData;
        }

        #endregion

        #region GET ACCOUNTS

        public int GetAccountsCount()
        {
            int result = 0;

            foreach (var item in allAccounts)
            {
                result += item.Value.Count;
            }

            return result;
        }

        public Account GetAccount(int accountNumber)
        {
            Account result = null;

            foreach (var accountList in allAccounts)
            {
                switch (accountList.Key)
                {
                    case Utility.AccountType.CHECKING:
                        result = GetCheckingAccount(accountNumber);
                        break;

                    case Utility.AccountType.BUSINESS:
                        result = GetBusinessAccount(accountNumber);
                        break;

                    case Utility.AccountType.TERM:
                        result = GetTermAccount(accountNumber);
                        break;

                    case Utility.AccountType.LOAN:
                        result = GetLoanAccount(accountNumber);
                        break;

                    default:
                        break;
                }

                if (result != null)
                {
                    break;
                }
            }

            return result;
        }

        public BusinessAccount GetBusinessAccount(int accountNumber)
        {
            BusinessAccount result = null;

            foreach (BusinessAccount accountRecord in allAccounts[Utility.AccountType.BUSINESS])
            {
                if (accountRecord.AccountNumber == accountNumber)
                {
                    result = accountRecord;
                    break;
                }
            }

            return result;
        }

        public CheckingAccount GetCheckingAccount(int accountNumber)
        {
            CheckingAccount result = null;

            foreach (CheckingAccount accountRecord in allAccounts[Utility.AccountType.CHECKING])
            {
                if (accountRecord.AccountNumber == accountNumber)
                {
                    result = accountRecord;
                    break;
                }
            }

            return result;
        }

        public LoanAccount GetLoanAccount(int accountNumber)
        {
            LoanAccount result = null;

            foreach (LoanAccount accountRecord in allAccounts[Utility.AccountType.LOAN])
            {
                if (accountRecord.AccountNumber == accountNumber)
                {
                    result = accountRecord;
                    break;
                }
            }

            return result;
        }

        public TermDepositAccount GetTermAccount(int accountNumber)
        {
            TermDepositAccount result = null;

            foreach (TermDepositAccount accountRecord in allAccounts[Utility.AccountType.TERM])
            {
                if (accountRecord.AccountNumber == accountNumber)
                {
                    result = accountRecord;
                    break;
                }
            }

            return result;
        }

        #endregion

        #region REMOVE ACCOUNTS

        public bool RemoveAccount(Account newAccount)
        {
            bool result = false;

            if (newAccount is CheckingAccount)
            {
                result = RemoveCheckingAccount(newAccount as CheckingAccount);
            }
            else if (newAccount is BusinessAccount)
            {
                result = RemoveBusinessAccount(newAccount as BusinessAccount);
            }
            else if (newAccount is TermDepositAccount)
            {
                result = RemoveTermAccount(newAccount as TermDepositAccount);
            }
            else if (newAccount is LoanAccount)
            {
                result = RemoveLoanAccount(newAccount as LoanAccount);
            }

            return result;
        }

        public bool RemoveBusinessAccount(BusinessAccount newAccount)
        {
            bool result = false;
            int accountIndex = allAccounts[Utility.AccountType.BUSINESS].IndexOf(newAccount);

            if (accountIndex > -1)
            {
                Customer currentCustomer = newAccount.Customer;

                // Check if current account has remaining balance.
                if (newAccount.AccountBalance > 0.0)
                {
                    // Run account close confirmation.

                }
                else if (newAccount.AccountBalance < 0.0)
                {
                    // Run account close overdraft confirmation.

                }

                // Remove all relation to this account object.
                result = RemoveSpecificAccount(currentCustomer, Utility.AccountType.BUSINESS, newAccount, accountIndex);
            }

            return result;
        }

        public bool RemoveCheckingAccount(CheckingAccount newAccount)
        {
            bool result = false;
            int accountIndex = allAccounts[Utility.AccountType.CHECKING].IndexOf(newAccount);

            if (accountIndex > -1)
            {
                Customer currentCustomer = newAccount.Customer;

                // Check if current account has remaining balance.
                if (newAccount.AccountBalance > 0.0)
                {
                    // Run account close confirmation.
                }

                // Remove all relation to this account object.
                result = RemoveSpecificAccount(currentCustomer, Utility.AccountType.CHECKING, newAccount, accountIndex);
            }

            return result;
        }

        public bool RemoveLoanAccount(LoanAccount newAccount)
        {
            bool result = false;
            int accountIndex = allAccounts[Utility.AccountType.LOAN].IndexOf(newAccount);

            if (accountIndex > -1)
            {
                Customer currentCustomer = newAccount.Customer;

                // Check if current account has remaining balance.
                if (newAccount.AccountBalance > 0.0)
                {
                    // Run account close confirmation.
                }

                // Remove all relation to this account object.
                result = RemoveSpecificAccount(currentCustomer, Utility.AccountType.LOAN, newAccount, accountIndex);
            }

            return result;
        }

        public bool RemoveTermAccount(TermDepositAccount newAccount)
        {
            bool result = false;
            int accountIndex = allAccounts[Utility.AccountType.TERM].IndexOf(newAccount);

            if (accountIndex > -1)
            {
                Customer currentCustomer = newAccount.Customer;

                // Check if current account has remaining balance.
                if (newAccount.AccountBalance > 0.0)
                {
                    // Run account close confirmation.
                }

                // Remove all relation to this account object.
                result = RemoveSpecificAccount(currentCustomer, Utility.AccountType.TERM, newAccount, accountIndex);
            }

            return result;
        }

        private bool RemoveSpecificAccount(Customer currentCustomer, Utility.AccountType currentAccountType, Account currentAccount, int accountIndex)
        {
            bool result = true;

            result = currentCustomer.RemoveAccount(currentAccount);
            allAccounts[currentAccountType].RemoveAt(accountIndex);

            return true;
        }

        #endregion
    }
}