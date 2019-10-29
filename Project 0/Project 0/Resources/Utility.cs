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

        /// <summary>
        /// Validates string to be character only.
        /// </summary>
        /// <param name="newName">String to verify.</param>
        /// <returns>Returns, True if string contains only character/letters. Otherwise, False.</returns>
        public static bool ValidateName(string newName)
        {
            bool result = true;

            // Check each letter in string for being only a character/letter.
            foreach (char letter in newName)
            {
                // If current letter is not a valid character, break loop and return false.
                if (!char.IsLetter(letter))
                {
                    result = false;
                    break;
                }
            }

            return result;
        }

        /// <summary>
        /// Capitalizes input string.
        /// </summary>
        /// <param name="newName">String to properly capitalize.</param>
        /// <returns>Returns string with first character in uppercase and all other letters in lower case.</returns>
        public static string CaptializeName(string newName)
        {
            string result = "";

            // Loop through all letter indexes in string.
            for (int index = 0; index < newName.Length; index++)
            {
                // If index is 0, append new string with index character as uppercase; 
                // Otherwise, append new string with index character as lowercase.
                result += index > 0 ? char.ToLower(newName[index]) : char.ToUpper(newName[index]);
            }

            return result;
        }

        /// <summary>
        /// Seperates out all accounts into their specific individual lists.
        /// </summary>
        /// <param name="allAccounts">Master account list.</param>
        /// <param name="allCheckingAccounts">List of only checking accounts.</param>
        /// <param name="allBusinessAccounts">List of only business accounts.</param>
        /// <param name="allTermAccounts">List of only term accounts.</param>
        /// <param name="allLoanAccounts">List of only loan accounts.</param>
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

        /// <summary>
        /// Refills master account list from each other individual account list.
        /// </summary>
        /// <param name="allAccounts">Master account list.</param>
        /// <param name="allCheckingAccounts">List of only checking accounts.</param>
        /// <param name="allBusinessAccounts">List of only business accounts.</param>
        public static void RebuildAccountListForDepositableAccounts(List<Account> allAccounts, List<CheckingAccount> allCheckingAccounts, List<BusinessAccount> allBusinessAccounts)
        {
            // Clear out all previous data in master account list.
            allAccounts.Clear();

            // Fill master account list with each individual list.
            allAccounts.AddRange(allCheckingAccounts);
            allAccounts.AddRange(allBusinessAccounts);
        }

        /// <summary>
        /// Refills master account list from each other individual account list.
        /// </summary>
        /// <param name="allAccounts">Master account list.</param>
        /// <param name="allCheckingAccounts">List of only checking accounts.</param>
        /// <param name="allBusinessAccounts">List of only business accounts.</param>
        /// <param name="allTermAccounts">List of only term accounts.</param>
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