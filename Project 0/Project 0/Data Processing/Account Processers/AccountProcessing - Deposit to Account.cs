using System;
using System.Collections.Generic;
using System.Text;

namespace Project_0
{
    partial class AccountProcessing
    {
        /// <summary>
        /// Process user deposit to account.
        /// </summary>
        private void DepositToAccount()
        {
            if (activeCustomer != null)
            {
                // Get all accounts for current selected customer.
                List<Account> allAccounts = new List<Account>(activeCustomer.GetAllAccounts());

                // Check if any account exists.
                if (allAccounts.Count > 0)
                {
                    // Get lists of depositable accounts.
                    List<CheckingAccount> allCheckingAccounts = activeCustomer.GetCheckingAccounts();
                    List<BusinessAccount> allBusinessAccounts = activeCustomer.GetBusinessAccounts();

                    // Rebuild accounts list for depositable accounts.
                    Utility.RebuildAccountListForDepositableAccounts(allAccounts, allCheckingAccounts, allBusinessAccounts);

                    // Display header.
                    CustomerHeader();

                    // Display account selection message.
                    bool isGoodTransaction = SelectDepositAccount(allAccounts);

                    // Await user to return to main menu.
                    if (isGoodTransaction)
                    {
                        ReturningToMainMenu();
                    }
                }
            }
        }

        /// <summary>
        /// Process user selection of account to deposit.
        /// </summary>
        /// <param name="allAccounts">Master list of all accounts.</param>
        /// <returns>Returns, True if process succeeded. Otherwise, False.</returns>
        private bool SelectDepositAccount(List<Account> allAccounts)
        {
            bool result = false;

            int? accountID = -1;

            // Get user selection of deposit account number.
            workingDisplay?.DisplayDepositAccountOptions(allAccounts.ToArray());
            accountID = workingDisplay?.GetUserOptionNumberSelection();

            // Check if account selected is in current list.
            if (accountID != null)
            {
                bool isValueFound = false;
                int actualID = accountID.GetValueOrDefault(-1);

                // Check for specific account in master account list.s
                foreach (Account currentAccount in allAccounts)
                {
                    if (currentAccount.AccountNumber == actualID)
                    {
                        isValueFound = true;
                        activeAccount = currentAccount;
                        break;
                    }
                }

                // Check if value was found.
                if (isValueFound)
                {
                    result = ProcessDepositAmount();
                }
                else
                {
                    InvalidSelection(true);
                }
            }

            return result;
        }

        /// <summary>
        /// PRocess user deposit amount.
        /// </summary>
        /// <returns>Returns, True if process succeeded. Otherwise, False.</returns>
        private bool ProcessDepositAmount()
        {
            bool result = false;

            // Check if activeAccount references a valid Account object.
            if (activeAccount != null)
            {
                double? userInput = 0.0;

                // Display header information.
                CustomerHeader();

                // Get new deposit value.
                workingDisplay?.DisplayAccountForDepositing(activeAccount);
                userInput = workingDisplay?.GetUserValueInput();

                // Check if input value is valid.
                if (userInput != null)
                {
                    if (userInput >= 0.0)
                    {
                        // Process deposit.
                        activeAccount.DepositAmount(Math.Round((userInput.GetValueOrDefault(0.0)), 2));

                        // Display changed results.
                        FullAccountHeader();

                        result = true;
                    }
                    else
                    {
                        InvalidAmount(true);
                    }
                }
                else
                {
                    InvalidAmount(true);
                }
            }

            return result;
        }
    }
}