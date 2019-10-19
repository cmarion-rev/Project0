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
            bool result = true;

            if (newAccount is CheckingAccount)
            {
                result = AddNewCheckingAccount(newAccount);
            }
            else if (newAccount is BusinessAccount)
            {
                result = AddNewBusinessAccount(newAccount);
            }
            else if (newAccount is TermDepositAccount)
            {
                result = AddNewTermAccount(newAccount);
            }
            else if (newAccount is LoanAccount)
            {
                result = AddNewLoanAccount(newAccount);
            }

            return result;
        }       

        public bool AddBusinessAccount(BusinessAccount newAccount)
        {
            bool result = true;

            result = AddNewBusinessAccount(newAccount);

            return result;
        }

        public bool AddCheckingAccount(CheckingAccount newAccount)
        {
            bool result = true;

            result = AddNewCheckingAccount(newAccount);

            return result;
        }

        public bool AddLoanAccount(LoanAccount newAccount)
        {
            bool result = true;

            result = AddNewLoanAccount(newAccount);

            return result;
        }

        public bool AddTermAccount(TermDepositAccount newAccount)
        {
            bool result = true;

            result = AddNewTermAccount(newAccount);

            return result;
        }


        private bool AddNewCheckingAccount(Account newAccount)
        {
            bool result = true;

            if (allAccounts[Utility.AccountType.CHECKING].Contains(newAccount))
            {
                result = false;
            }
            else
            {
                allAccounts[Utility.AccountType.CHECKING].Add(newAccount);
            }

            return result;
        }

        private bool AddNewBusinessAccount(Account newAccount)
        {
            bool result = true;

            if (allAccounts[Utility.AccountType.BUSINESS].Contains(newAccount))
            {
                result = false;
            }
            else
            {
                allAccounts[Utility.AccountType.BUSINESS].Add(newAccount);
            }

            return result;
        }

        private bool AddNewTermAccount(Account newAccount)
        {
            bool result = true;

            if (allAccounts[Utility.AccountType.TERM].Contains(newAccount))
            {
                result = false;
            }
            else
            {
                allAccounts[Utility.AccountType.TERM].Add(newAccount);
            }

            return result;
        }

        private bool AddNewLoanAccount(Account newAccount)
        {
            bool result = true;

            if (allAccounts[Utility.AccountType.LOAN].Contains(newAccount))
            {
                result = false;
            }
            else
            {
                allAccounts[Utility.AccountType.LOAN].Add(newAccount);
            }

            return result;
        }

        #endregion

        #region GET ACCOUNTS

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
                if (newAccount.AccountBalance > 0.0 | newAccount.OverdraftBalance > 0.0)
                {
                    // Run account close confirmation.
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
