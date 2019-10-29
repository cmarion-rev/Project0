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

        /// <summary>
        /// Create a new account.
        /// </summary>
        /// <param name="newType">Type of account to create.</param>
        /// <param name="currentCustomer">Owing customer.</param>
        /// <param name="newBalance">Starting balance.</param>
        /// <returns>Returns a new Account object.</returns>
        public Account GenerateNewAccount(Utility.AccountType newType, Customer currentCustomer, double newBalance = 0.0)
        {
            Account newAccount = null;

            // Create new account based on specified type.
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

        /// <summary>
        /// Creates a new business account.
        /// </summary>
        /// <param name="currentCustomer">Owing customer.</param>
        /// <param name="newBalance">Starting balance.</param>
        /// <returns>Returns a new BusinessAccount object.</returns>
        public Account GenerateNewBusinessAccount(Customer currentCustomer, double newBalance = 0.0)
        {
            Account newAccount = null;

            // Generate new business account object.
            newAccount = AddNewBusinessAccount(currentCustomer, newBalance);

            return newAccount;
        }

        /// <summary>
        /// Creates a new checking account.
        /// </summary>
        /// <param name="currentCustomer">Owing customer.</param>
        /// <param name="newBalance">Starting balance.</param>
        /// <returns>Returns a new CheckingAccount object.</returns>
        public Account GenerateNewCheckingAccount(Customer currentCustomer, double newBalance = 0.0)
        {
            Account newAccount = null;

            // Generate new checking account object.
            newAccount = AddNewCheckingAccount(currentCustomer, newBalance);

            return newAccount;
        }

        /// <summary>
        /// Creates a new loan account.
        /// </summary>
        /// <param name="currentCustomer">Owing customer.</param>
        /// <param name="newBalance">Starting balance.</param>
        /// <returns>Returns a new LoanAccount object.</returns>
        public Account GenerateNewLoanAccount(Customer currentCustomer, double newBalance = 0.0)
        {
            Account newAccount = null;

            // Generate new loan account object.
            newAccount = AddNewLoanAccount(currentCustomer, newBalance);

            return newAccount;
        }

        /// <summary>
        /// Creates a new term account.
        /// </summary>
        /// <param name="currentCustomer">Owing customer.</param>
        /// <param name="newBalance">Starting balance.</param>
        /// <returns>Returns a new TermDepositAccount object.</returns>
        public Account GenerateNewTermAccount(Customer currentCustomer, double newBalance = 0.0)
        {
            Account newAccount = null;

            // Generate new term account object.
            newAccount = AddNewTermAccount(currentCustomer, newBalance);

            return newAccount;
        }

        /// <summary>
        /// Generate new CheckingAccount object.
        /// </summary>
        /// <param name="currentCustomer">Owing customer.</param>
        /// <param name="newBalance">Starting balance.</param>
        /// <returns>Returns a new CheckingAccount object.</returns>
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

        /// <summary>
        /// Generate new BusinessAccount object.
        /// </summary>
        /// <param name="currentCustomer">Owing customer.</param>
        /// <param name="newBalance">Starting balance.</param>
        /// <returns>Returns a new BusinessAccount object.</returns>
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

        /// <summary>
        /// Generate new TermDepositAccount object.
        /// </summary>
        /// <param name="currentCustomer">Owing customer.</param>
        /// <param name="newBalance">Starting balance.</param>
        /// <returns>Returns a new TermDepositAccount object.</returns>
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

        /// <summary>
        /// Generate new LoanAccount object.
        /// </summary>
        /// <param name="currentCustomer">Owing customer.</param>
        /// <param name="newBalance">Starting balance.</param>
        /// <returns>Returns a new LoanAccount object.</returns>
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
        
        /// <summary>
        /// Generate new AccountData propery object.
        /// </summary>
        /// <returns>Returns a new AccountData propert object.</returns>
        private AccountData GenerateNewAccountData()
        {
            // Create new accountdata.
            AccountData newData = new AccountData();

            return newData;
        }

        #endregion

        #region GET ACCOUNTS

        /// <summary>
        /// Get total accounts stored.
        /// </summary>
        /// <returns>Returns an integer number representing count of all stored account objects.</returns>
        public int GetAccountsCount()
        {
            int result = 0;

            // Loop through all accounts in main dictionary to get master count.
            foreach (var item in allAccounts)
            {
                result += item.Value.Count;
            }

            return result;
        }

        /// <summary>
        /// Get account by account ID number.
        /// </summary>
        /// <param name="accountNumber">ID number of specific account.</param>
        /// <returns>Returns Account object of specified account ID.</returns>
        public Account GetAccount(int accountNumber)
        {
            Account result = null;

            // Loop through all lists in the master dictionary to find specific account.
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

        /// <summary>
        /// Get business account by account ID number.
        /// </summary>
        /// <param name="accountNumber">ID number of specific account.</param>
        /// <returns>Returns BusinessAccount object of specified account ID.</returns>
        public BusinessAccount GetBusinessAccount(int accountNumber)
        {
            BusinessAccount result = null;

            // Loop through each account in the list to find the specific account number.
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

        /// <summary>
        /// Get checking account by account ID number.
        /// </summary>
        /// <param name="accountNumber">ID number of specific account.</param>
        /// <returns>Returns CheckingAccount object of specified account ID.</returns>
        public CheckingAccount GetCheckingAccount(int accountNumber)
        {
            CheckingAccount result = null;

            // Loop through each account in the list to find the specific account number.
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

        /// <summary>
        /// Get loan account by account ID number.
        /// </summary>
        /// <param name="accountNumber">ID number of specific account.</param>
        /// <returns>Returns LoanAccount object of specified account ID.</returns>
        public LoanAccount GetLoanAccount(int accountNumber)
        {
            LoanAccount result = null;

            // Loop through each account in the list to find the specific account number.
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

        /// <summary>
        /// Get term account by account ID number.
        /// </summary>
        /// <param name="accountNumber">ID number of specific account.</param>
        /// <returns>Returns TermDepositAccount object of specified account ID.</returns>
        public TermDepositAccount GetTermAccount(int accountNumber)
        {
            TermDepositAccount result = null;

            // Loop through each account in the list to find the specific account number.
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

        /// <summary>
        /// Remove account from storage.
        /// </summary>
        /// <param name="newAccount">Account object reference to remove.</param>
        /// <returns>Returns, True if the referenced account was in storage. Otherwise, False.</returns>
        public bool RemoveAccount(Account newAccount)
        {
            bool result = false;

            // Check which account type this account is, to remove from.
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

        /// <summary>
        /// Remove business account from storage.
        /// </summary>
        /// <param name="newAccount">BusinessAccount object reference to remove.</param>
        /// <returns>Returns, True if the referenced account was in storage. Otherwise, False.</returns>
        public bool RemoveBusinessAccount(BusinessAccount newAccount)
        {
            bool result = false;

            // Get list index of reference account.
            int accountIndex = allAccounts[Utility.AccountType.BUSINESS].IndexOf(newAccount);

            // Check if a good index was returned.
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

        /// <summary>
        /// Remove checking account from storage.
        /// </summary>
        /// <param name="newAccount">CheckingAccount object reference to remove.</param>
        /// <returns>Returns, True if the referenced account was in storage. Otherwise, False.</returns>
        public bool RemoveCheckingAccount(CheckingAccount newAccount)
        {
            bool result = false;

            // Get list index of reference account.
            int accountIndex = allAccounts[Utility.AccountType.CHECKING].IndexOf(newAccount);

            // Check if a good index was returned.
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

        /// <summary>
        /// Remove loan account from storage.
        /// </summary>
        /// <param name="newAccount">LoanAccount object reference to remove.</param>
        /// <returns>Returns, True if the referenced account was in storage. Otherwise, False.</returns>
        public bool RemoveLoanAccount(LoanAccount newAccount)
        {
            bool result = false;

            // Get list index of reference account.
            int accountIndex = allAccounts[Utility.AccountType.LOAN].IndexOf(newAccount);

            // Check if a good index was returned.
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

        /// <summary>
        /// Remove term account from storage.
        /// </summary>
        /// <param name="newAccount">TermDepositAccount object reference to remove.</param>
        /// <returns>Returns, True if the referenced account was in storage. Otherwise, False.</returns>
        public bool RemoveTermAccount(TermDepositAccount newAccount)
        {
            bool result = false;

            // Get list index of reference account.
            int accountIndex = allAccounts[Utility.AccountType.TERM].IndexOf(newAccount);

            // Check if a good index was returned.
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

        /// <summary>
        /// Remove specific account from storage.
        /// </summary>
        /// <param name="currentCustomer">Owning customer.</param>
        /// <param name="currentAccountType">Type of Account.</param>
        /// <param name="currentAccount">Account reference object.</param>
        /// <param name="accountIndex">Index of account object.</param>
        /// <returns>Returns, True if removal was successfull. Otherwise, False.</returns>
        private bool RemoveSpecificAccount(Customer currentCustomer, Utility.AccountType currentAccountType, Account currentAccount, int accountIndex)
        {
            bool result = false;

            // Remove account from current customer.
            if (currentCustomer != null)
            {
                result = currentCustomer.RemoveAccount(currentAccount);
            }

            // Remove account from specific account type list and index.
            allAccounts[currentAccountType].RemoveAt(accountIndex);

            return true;
        }

        #endregion
    }
}