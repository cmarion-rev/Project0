using System;
using System.Collections.Generic;
using System.Text;

namespace Project_0
{
    partial class AccountProcessing
    {
        /// <summary>
        /// Transfer balance between user selected accounts.
        /// </summary>
        private void TransferBetweenAccounts()
        {
            // Check if activeCustomer has a reference to a valid Customer object.
            if (activeCustomer != null)
            {
                bool isGoodProcess = false;

                // Get all potential usable accounts.
                List<CheckingAccount> allCheckingAccounts = activeCustomer.GetCheckingAccounts();
                List<BusinessAccount> allBusinessAccounts = activeCustomer.GetBusinessAccounts();
                List<TermDepositAccount> allTermAccounts = activeCustomer.GetTermDepositAccounts();

                // Create reference accounts.
                List<Account> allDepositableAccounts = new List<Account>();
                List<Account> allWithdrawableAccounts = new List<Account>();

                // Rebuild accounts list for depositable accounts.
                Utility.RebuildAccountListForDepositableAccounts(allDepositableAccounts, allCheckingAccounts, allBusinessAccounts);
                Utility.RebuildAccountListForWithdrawableAccounts(allWithdrawableAccounts, allCheckingAccounts, allBusinessAccounts, allTermAccounts);

                // Start account transfer process.
                isGoodProcess = ProcessAccountTransfer(allDepositableAccounts, allWithdrawableAccounts);

                // Await user to return to main menu.
                if (isGoodProcess)
                {
                    workingDisplay?.DisplayReturningToMainMenu();
                    workingDisplay?.WaitForUserConfirmation();
                }
            }
        }

        /// <summary>
        /// Process user selection of accounts to transfer between.
        /// </summary>
        /// <param name="allDepositAccounts">List of all accounts that can be deposited into.</param>
        /// <param name="allWithdrawAccounts">List of all accounts that can be withdrawn from.</param>
        /// <returns>Returns, True if process was successful. Otherwise, False.</returns>
        private bool ProcessAccountTransfer(List<Account> allDepositAccounts, List<Account> allWithdrawAccounts)
        {
            bool result = false;
            
            Account sourceAccount = null;
            Account destinationAccount = null;

            // Run Loop to get source account.
            do
            {
                // Display header.
                CustomerHeader();

                // Get user selection of transfer source.
                int? accountID = -1;
                workingDisplay?.DisplayTransferSourceAccount(allWithdrawAccounts.ToArray());
                accountID = workingDisplay?.GetUserOptionNumberSelection();

                // Check if good source account decided.
                if (accountID != null)
                {
                    bool isGoodValue = false;
                    int sourceAccountNumber = accountID.GetValueOrDefault(-1);

                    // Loop through all withdrawabl accounts to find specified account.
                    foreach (Account currentAccount in allWithdrawAccounts)
                    {
                        if (currentAccount.AccountNumber == sourceAccountNumber)
                        {
                            isGoodValue = true;
                            sourceAccount = currentAccount;
                            break;
                        }
                    }

                    // Check if good value was found.
                    if (isGoodValue)
                    {
                        // Remove this account from withdraw accounts.
                        for (int index = 0; index < allDepositAccounts.Count; ++index)
                        {
                            // Check if current accout is selected number.
                            if (allDepositAccounts[index].AccountNumber == sourceAccountNumber)
                            {
                                allDepositAccounts.RemoveAt(index);
                                break;
                            }
                        }
                    }
                    else
                    {
                        // Invalid entry.
                        InvalidSelection(true);
                        sourceAccount = null;
                        break;
                    }
                }
            } while (sourceAccount == null);

            // Check if a valid source account was selected and found.
            if (sourceAccount != null)
            {
                // Run Loop to get destination acount.
                do
                {
                    // Display header.
                    CustomerHeader();
                    ShortAccountHeader(sourceAccount);

                    // Get user selection of transfer destination.
                    int? accountID = -1;
                    workingDisplay?.DisplayTransferDestinationAccount(allDepositAccounts.ToArray());
                    accountID = workingDisplay?.GetUserOptionNumberSelection();

                    // Check if good source account decided.
                    if (accountID != null)
                    {
                        bool isGoodValue = false;
                        int sourceAccountNumber = accountID.GetValueOrDefault(-1);
                        foreach (Account currentAccount in allDepositAccounts)
                        {
                            if (currentAccount.AccountNumber == sourceAccountNumber)
                            {
                                isGoodValue = true;
                                destinationAccount = currentAccount;
                                break;
                            }
                        }

                        // Check if good value was found.
                        if (isGoodValue)
                        {

                        }
                        else
                        {
                            // Invalid entry.
                            InvalidSelection(true);
                            destinationAccount = null;
                            break;
                        }
                    }

                } while (destinationAccount == null);
            }

            // Process transfer amount.
            if (sourceAccount != null && destinationAccount != null)
            {
                result = ProcessTransferAmount(sourceAccount, destinationAccount);
            }

            return result;
        }

        /// <summary>
        /// Process user amount to transfer between accounts.
        /// </summary>
        /// <param name="sourceAccount">Source Account object reference.</param>
        /// <param name="destinationAccount">Destination Account object reference.</param>
        /// <returns>Returns, True if process was successful. Otherwise, False.</returns>
        private bool ProcessTransferAmount(Account sourceAccount, Account destinationAccount)
        {
            bool result = false;
            
            double? transferAmount = 0.0;

            // Display header.
            CustomerHeader();

            // Get user input for amount to transfer.
            workingDisplay?.DisplayAccountTransfer(sourceAccount, destinationAccount);
            transferAmount = workingDisplay?.GetUserValueInput();

            // Check for valid input.
            if (transferAmount != null)
            {
                double realAmount = transferAmount.GetValueOrDefault(0.0);
                if (realAmount > 0.0)
                {
                    // Check if source account can cover amount.
                    bool isValidTransaction = CheckSourceAccountFunds(sourceAccount, realAmount);
                    if (isValidTransaction)
                    {
                        // Deposit to destination account.
                        TransfertoDestinationAccount(destinationAccount, realAmount);

                        // Display successful transfer message.
                        workingDisplay?.DisplayTransferSuccessful(sourceAccount, destinationAccount);
                        result = true;
                    }
                    else
                    {
                        // Source account funds exceeded.
                        OverdraftProtection(true);
                    }
                }
                else
                {
                    // Invalid entry.
                    InvalidAmount(true);
                }
            }
            else
            {
                // Invalid entry.
                InvalidEntry(true);
            }

            return result;
        }

        /// <summary>
        /// Checks if source account can withdraw specified amount.
        /// </summary>
        /// <param name="sourceAccount">Source Account object reference.</param>
        /// <param name="withdrawAmount">Amount to withdraw.</param>
        /// <returns>Returns, true if withdrawal was successful. Otherwise, False.</returns>
        private bool CheckSourceAccountFunds(Account sourceAccount, double withdrawAmount)
        {
            bool result = false;

            result = sourceAccount.WithdrawAmount(Math.Round(withdrawAmount, 2));

            return result;
        }

        /// <summary>
        /// Deposits balance to destination account.
        /// </summary>
        /// <param name="destinationAccount">Destination Account object reference.</param>
        /// <param name="depositAmount">Amount to deposit.</param>
        private void TransfertoDestinationAccount(Account destinationAccount, double depositAmount)
        {
            destinationAccount.DepositAmount(Math.Round(depositAmount, 2));
        }
    }
}