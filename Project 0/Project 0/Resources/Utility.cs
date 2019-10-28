using System;
using System.Collections.Generic;
using System.Text;

namespace Project_0
{
    public class Utility
    {
        #region ENUMERATORS

        public enum AccountType
        {
            CHECKING,
            BUSINESS,
            TERM,
            LOAN,

            _COUNT,
        }

        public enum OperationState
        {
            INVALID_OPTION = -1,

            REGISTER,
            CHANGE_USER,
            OPEN_ACCOUNT,
            CLOSE_ACCOUNT,
            WITHDRAW,
            DEPOSIT,
            TRANSFER,
            PAY_LOAN,
            DISPLAY_ACCOUNTS,
            DISPLAY_TRANSACTIONS,


            EXIT_PROGRAM,
        }

        public enum TransactionType
        {
            INVALID_DATA = -1,

            OPEN_ACCOUNT,

            DEPOSIT,
            WITHDRAWAL,

            CLOSE_ACCOUNT = 16,
        }

        public enum TransactionCodes
        {
            INVALID_DATA = -1,

            SUCCESS,

            // Withdrawal Errors.
            OVERDRAFT_PROTECTION,
            TERM_PROTECTION,

            // Deposit Errors.
            INVALID_AMOUNT,
        }

        [Flags]
        public enum MainMenuOptions
        {
            REGISTER_NEW_CUSTOMER = 1 << 0,
            CHANGE_CUSTOMER = 1 << 1,
            OPEN_NEW_ACCOUNT = 1 << 2,
            CLOSE_ACCOUNT = 1 << 3,
            WITHDRAW_AMOUNT = 1 << 4,
            DEPOSIT_AMOUNT = 1 << 5,
            TRANSFER_AMOUNT = 1 << 6,
            PAY_LOAN_INSTALLMENT = 1 << 7,
            DISPLAY_ALL_ACCOUNTS = 1 << 8,
            DISPLAY_ALL_TRANSACTIONS = 1 << 9,
            //

            //
            EXIT_PROGRAM = 1 << 15,
        }

        #endregion

        #region FUNCTIONS

        public static bool ValidateName(string newName)
        {
            bool result = true;

            foreach (char letter in newName)
            {
                if (!char.IsLetter(letter))
                {
                    result = false;
                    break;
                }
            }

            return result;
        }

        public static string CaptializeName(string newName)
        {
            string result = "";

            for (int index = 0; index < newName.Length; index++)
            {
                result += index > 0 ? char.ToLower(newName[index]) : char.ToUpper(newName[index]);
            }

            return result;
        }

        public static void SeperateAccounts(List<Account> allAccounts,
                                            List<CheckingAccount> allCheckingAccounts,
                                            List<BusinessAccount> allBusinessAccounts,
                                            List<TermDepositAccount> allTermAccounts,
                                            List<LoanAccount> allLoanAccounts)
        {
            // Loop through all accounts and seperate to proper sub-list.
            foreach (Account item in allAccounts)
            {
                switch (item.AccountType)
                {
                    case AccountType.CHECKING:
                        if (allCheckingAccounts != null)
                        {
                            allCheckingAccounts.Add(item as CheckingAccount);
                        }
                        break;

                    case AccountType.BUSINESS:
                        if (allBusinessAccounts != null)
                        {
                            allBusinessAccounts.Add(item as BusinessAccount);
                        }
                        break;

                    case AccountType.TERM:
                        if (allTermAccounts != null)
                        {
                            allTermAccounts.Add(item as TermDepositAccount);
                        }
                        break;

                    case AccountType.LOAN:
                        if (allLoanAccounts != null)
                        {
                            allLoanAccounts.Add(item as LoanAccount);
                        }
                        break;

                    default:
                        break;
                }
            }
        }

        public static void RebuildAccountListForDepositableAccounts(List<Account> allAccounts, List<CheckingAccount> allCheckingAccounts, List<BusinessAccount> allBusinessAccounts)
        {
            allAccounts.Clear();
            allAccounts.AddRange(allCheckingAccounts);
            allAccounts.AddRange(allBusinessAccounts);
        }

        public static void RebuildAccountListForWithdrawableAccounts(List<Account> allAccounts, List<CheckingAccount> allCheckingAccounts, List<BusinessAccount> allBusinessAccounts, List<TermDepositAccount> allTermAccounts)
        {
            // Clear out all accounts.
            allAccounts.Clear();

            // Check all Checking accounts for withdrawable balance.
            foreach (CheckingAccount currentAccount in allCheckingAccounts)
            {
                if (currentAccount.AccountBalance > 0.0)
                {
                    allAccounts.Add(currentAccount);
                }
            }

            // Check all Business accounts for withdrawable balance.
            allAccounts.AddRange(allBusinessAccounts);

            // Check for term accounts for  maturity.
            foreach (TermDepositAccount currentAccount in allTermAccounts)
            {
                if (currentAccount.MaturityDate.Subtract(DateTime.Now).TotalDays < 0)
                {
                    if (currentAccount.AccountBalance > 0.0)
                    {
                        allAccounts.Add(currentAccount);
                    }
                }
            }
        }

        #endregion
    }
}