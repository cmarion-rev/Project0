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

        public enum TransactionErrorCodes
        {
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
            OPEN_NEW_ACCOUNT = 1 << 1,
            CLOSE_ACCOUNT = 1 << 2,
            WITHDRAW_AMOUNT = 1 << 3,
            DEPOSIT_AMOUNT = 1 << 4,
            TRANSFER_AMOUNT = 1 << 5,
            PAY_LOAN_INSTALLMENT = 1 << 6,
            DISPLAY_ALL_ACCOUNTS = 1 << 7,
            DISPLAY_ALL_TRANSACTIONS = 1 << 8,
            //

            //
            EXIT_PROGRAM = 1 << 16,
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
            foreach (IAccountInfo item in allAccounts)
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

        public static void RebuildAccountListForDepositableAccounts(ref List<Account> allAccounts, List<CheckingAccount> allCheckingAccounts, List<BusinessAccount> allBusinessAccounts)
        {
            allAccounts.Clear();
            allAccounts.AddRange(allCheckingAccounts);
            allAccounts.AddRange(allBusinessAccounts);
        }

        public static void RebuildAccountListForWithdrawableAccounts(ref List<Account> allAccounts, List<CheckingAccount> allCheckingAccounts, List<BusinessAccount> allBusinessAccounts, List<TermDepositAccount> allTermAccounts)
        {
            RebuildAccountListForDepositableAccounts(ref allAccounts, allCheckingAccounts, allBusinessAccounts);

            // Check for term accounts for  maturity.
            foreach (TermDepositAccount item in allTermAccounts)
            {
                if (item.MaturityDate.Subtract(DateTime.Now).TotalDays > 0)
                {
                    allAccounts.Add(item);
                }
            }
        }

        #endregion
    }
}