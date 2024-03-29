﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Project_0
{
    partial class AccountProcessing
    {
        /// <summary>
        /// Withdraw user specified amount from account.
        /// </summary>
        private void WithdrawFromAccount()
        {
            // Check if there is an active customer reference before proceeding.
            if (activeCustomer != null)
            {
                // Get all accounts for current selected customer.
                List<Account> allAccounts = new List<Account>(activeCustomer.GetAllAccounts());

                // Check if any account exists.
                if (allAccounts.Count > 0)
                {
                    List<CheckingAccount> allCheckingAccounts = activeCustomer.GetCheckingAccounts();
                    List<BusinessAccount> allBusinessAccounts = activeCustomer.GetBusinessAccounts();
                    List<TermDepositAccount> allTermAccounts = activeCustomer.GetTermDepositAccounts();
                    bool isGoodProcess = false;

                    // Rebuild accounts list for depositable accounts.
                    Utility.RebuildAccountListForWithdrawableAccounts(allAccounts, allCheckingAccounts, allBusinessAccounts, allTermAccounts);

                    // Display header.
                    CustomerHeader();

                    // Display account selection message.
                    isGoodProcess = SelectWithdrawAccount(allAccounts);

                    // Await user to return to main menu.
                    if (isGoodProcess)
                    {
                        workingDisplay?.DisplayReturningToMainMenu();
                        workingDisplay?.WaitForUserConfirmation();
                    }
                }
            }
        }

        /// <summary>
        /// Get user to select account to withdraw from.
        /// </summary>
        /// <param name="allAccounts">Master list of accounts.</param>
        /// <returns>Returns, True if process succeeded. Otherwise, False.</returns>
        private bool SelectWithdrawAccount(List<Account> allAccounts)
        {
            bool result = false;

            int? accountID = -1;

            // Display all active accounts.
            workingDisplay?.DisplayWithdrawalAccountOptions(allAccounts.ToArray());

            // Get user account selection.
            accountID = workingDisplay?.GetUserOptionNumberSelection();

            // Check if account selected is in current list.
            if (accountID != null)
            {
                bool isValueFound = false;
                int actualID = accountID.GetValueOrDefault(-1);

                // Loop through master account list for proper Account object reference.
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
                    result = ProcessWithdrawAmount();
                }
                else
                {
                    InvalidSelection(true);
                }
            }

            return result;
        }

        /// <summary>
        /// Process user withdrawal amount input.
        /// </summary>
        /// <returns>Returns, True if process succeeded. Otherwise, False.</returns>
        private bool ProcessWithdrawAmount()
        {
            bool result = false;

            // Check if activeAccount has a reference to a valid Account object.
            if (activeAccount != null)
            {
                double? userInput = 0.0;

                // Display header information.
                CustomerHeader();

                // Get new deposit value.
                workingDisplay?.DisplayAccountForWithdrawing(activeAccount);
                userInput = workingDisplay?.GetUserValueInput();

                // Check if input value is valid.
                if (userInput != null)
                {
                    if (userInput >= 0.0)
                    {
                        // Process withdrawal.
                        bool isGoodTransaction = activeAccount.WithdrawAmount(Math.Round(userInput.GetValueOrDefault(0.0), 2));

                        // Check if withdrawal was successful.
                        if (isGoodTransaction)
                        {
                            // Display changed results.
                            FullAccountHeader();
                            result = true;
                        }
                        else
                        {
                            switch (activeAccount.LastTransactionState)
                            {
                                case Utility.TransactionCodes.OVERDRAFT_PROTECTION:
                                    // Report overdraw attempt.
                                    OverdraftProtection(true);
                                    break;

                                case Utility.TransactionCodes.TERM_PROTECTION:
                                    // Report term account non-maturity.
                                    // workingDisplay?.
                                    break;

                                case Utility.TransactionCodes.INVALID_AMOUNT:
                                    // Report invalid withdraw error.
                                    InvalidAmount(true);
                                    break;

                                default:
                                    break;
                            }
                        }
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