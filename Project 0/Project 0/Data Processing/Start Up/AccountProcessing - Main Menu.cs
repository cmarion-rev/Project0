using System;
using System.Collections.Generic;
using System.Text;

namespace Project_0
{
    partial class AccountProcessing
    {
        /// <summary>
        /// Gets the current selection option for Main Menu.
        /// </summary>
        /// <returns>Returns bit-flag set enumerator representing all avaliable menu options.</returns>
        private Utility.MainMenuOptions GetCurrentMainMenuOptions()
        {
            Utility.MainMenuOptions result = 0;

            // Check if new customers can be created.
            if (workingCustomerStorage != null)
            {
                result |= Utility.MainMenuOptions.REGISTER_NEW_CUSTOMER;

                if (workingCustomerStorage.GetAllCustomers().Length > 1)
                {
                    result |= Utility.MainMenuOptions.CHANGE_CUSTOMER;
                }
            }

            // Check if current customer exists.
            if (activeCustomer != null)
            {
                // Check if accounts can be created.
                if (workingAccountStorage != null)
                {
                    result |= Utility.MainMenuOptions.OPEN_NEW_ACCOUNT;
                    List<Account> allAccounts = activeCustomer.GetAllAccounts();

                    // Check if customer has accounts that can be closed.
                    if (allAccounts.Count > 0)
                    {
                        result |= Utility.MainMenuOptions.CLOSE_ACCOUNT;
                        result |= Utility.MainMenuOptions.DISPLAY_ALL_ACCOUNTS;
                        result |= Utility.MainMenuOptions.DISPLAY_ALL_TRANSACTIONS;

                        // Check if customer has more that one account, to allow transferring.
                        if (allAccounts.Count > 1)
                        {
                            // Check if atleast two accounts can be part of transfer.
                            if (CheckCustomerAccountsForTransferable(allAccounts))
                            {
                                result |= Utility.MainMenuOptions.TRANSFER_AMOUNT;
                            }
                        }

                        // Check if customer has a depositable account.
                        if (CheckCustomerAccountsForDepositable(allAccounts))
                        {
                            result |= Utility.MainMenuOptions.DEPOSIT_AMOUNT;
                        }

                        // Check if customer has a withdrawable account.
                        if (CheckCustomerAccountsForWithdrawable(allAccounts))
                        {
                            result |= Utility.MainMenuOptions.WITHDRAW_AMOUNT;
                        }

                        // Check if customer has a loan account for paying installments to.
                        if (CheckCustomerAccountsForLoanPayable(allAccounts))
                        {
                            result |= Utility.MainMenuOptions.PAY_LOAN_INSTALLMENT;
                        }
                    }
                }
            }

            // Enable exit program.
            result |= Utility.MainMenuOptions.EXIT_PROGRAM;

            return result;
        }

        /// <summary>
        /// Checks all available accounts for a depositable account.
        /// </summary>
        /// <param name="allAccounts">List of all accounts.</param>
        /// <returns>Returns, True if a valid depositable account was found. Otherwise, False.</returns>
        private bool CheckCustomerAccountsForDepositable(List<Account> allAccounts)
        {
            bool result = false;

            if (allAccounts != null)
            {
                // Check all accounts for being either Checking or Business.
                foreach (Account currentAccount in allAccounts)
                {
                    switch (currentAccount.AccountType)
                    {
                        case Utility.AccountType.CHECKING:
                        case Utility.AccountType.BUSINESS:
                            result = true;
                            break;

                        default:
                            break;
                    }

                    // Exit loop on a valid account find.
                    if (result)
                    {
                        break;
                    }
                }
            }

            return result;
        }

        /// <summary>
        /// Checks all avaliable accounts for two transferable accounts.
        /// </summary>
        /// <param name="allAccounts">List of all accounts.</param>
        /// <returns>Returns, True if two valid withdrawable accounts were found. Otherwise, False.</returns>
        private bool CheckCustomerAccountsForTransferable(List<Account> allAccounts)
        {
            bool result = false;

            if (allAccounts != null)
            {
                result = CheckAllAccountsforTransferability(allAccounts);
            }

            return result;
        }

        private bool CheckAllAccountsforTransferability(List<Account> allAccounts)
        {
            bool result = false;
            Account aWithdrawAccount = null;
            Account aSecondAccount = null;

            // Check all term accounts first for potential withdrawal account.
            foreach (Account currentAccount in allAccounts)
            {
                switch (currentAccount.AccountType)
                {
                    case Utility.AccountType.TERM:
                        // Check if term account has reached maturity.
                        if ((currentAccount as TermDepositAccount).MaturityDate.Subtract(DateTime.Now).TotalDays < 0)
                        {
                            // Check if account has a balance to withdraw from.
                            if (currentAccount.AccountBalance > 0.0)
                            {
                                aWithdrawAccount = currentAccount;
                            }
                        }
                        break;

                    default:
                        break;
                }

                // Check if valid withdrawal account was found.
                if (aWithdrawAccount != null)
                {
                    break;
                }
            }

            // If a good withdrawal account was not found in term accounts, check all other accounts for valid account.
            if (aWithdrawAccount == null)
            {
                foreach (Account currentAccount in allAccounts)
                {
                    switch (currentAccount.AccountType)
                    {
                        case Utility.AccountType.CHECKING:
                        case Utility.AccountType.BUSINESS:
                            // Check if account has a balance to withdraw from.
                            if (currentAccount.AccountBalance > 0.0)
                            {
                                aWithdrawAccount = currentAccount;
                            }
                            break;

                        default:
                            break;
                    }

                    // Check if valid withdrawal account was found.
                    if (aWithdrawAccount != null)
                    {
                        break;
                    }
                }
            }

            // If a good withdrawal account was found, check for a second account to deposit to.
            if (aWithdrawAccount != null)
            {
                // Check all accounts for atleast two valid accounts.
                foreach (Account currentAccount in allAccounts)
                {
                    switch (currentAccount.AccountType)
                    {
                        case Utility.AccountType.CHECKING:
                        case Utility.AccountType.BUSINESS:
                            if (currentAccount != aWithdrawAccount)
                            {
                                aSecondAccount = currentAccount;
                            }
                            break;

                        default:
                            break;
                    }

                    // Exit loop on valid accounts found.
                    if (aSecondAccount != null)
                    {
                        result = true;
                        break;
                    }
                }
            }

            return result;
        }

        /// <summary>
        /// Checks all avaliable accounts for a withdrawable account.
        /// </summary>
        /// <param name="allAccounts">List of all accounts.</param>
        /// <returns>Returns, True if a valid withdrawabl account was found. Otherwise, False.</returns>
        private bool CheckCustomerAccountsForWithdrawable(List<Account> allAccounts)
        {
            bool result = false;

            if (allAccounts != null)
            {
                // Check all accounts for a valid account.
                foreach (IAccountInfo currentAccount in allAccounts)
                {
                    switch (currentAccount.AccountType)
                    {
                        case Utility.AccountType.CHECKING:
                        case Utility.AccountType.BUSINESS:
                            result = true;
                            break;

                        case Utility.AccountType.TERM:
                            result = (currentAccount as TermDepositAccount).MaturityDate.Subtract(DateTime.Now).TotalDays < 0;
                            break;

                        default:
                            break;
                    }

                    // Exit loop on valid account find.
                    if (result)
                    {
                        break;
                    }
                }
            }

            return result;
        }

        /// <summary>
        /// Checks all avaliable accounts for a loan account.
        /// </summary>
        /// <param name="allAccounts">List of all accounts.</param>
        /// <returns>Returns, True if a valid loan account was found. Otherwise, False.</returns>
        private bool CheckCustomerAccountsForLoanPayable(List<Account> allAccounts)
        {
            bool result = false;

            if (allAccounts != null)
            {
                // Check all accounts for a valid account.
                foreach (IAccountInfo currentAccount in allAccounts)
                {
                    switch (currentAccount.AccountType)
                    {
                        case Utility.AccountType.LOAN:
                            result = true;
                            break;

                        default:
                            break;
                    }

                    // Exit loop on valid account find.
                    if (result)
                    {
                        break;
                    }
                }
            }

            return result;
        }
    }
}