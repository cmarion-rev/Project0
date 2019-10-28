using System;
using System.Collections.Generic;
using System.Text;

namespace Project_0
{
    partial class AccountProcessing
    {
        private void TransferBetweenAccounts()
        {
            if (activeCustomer != null)
            {
                List<CheckingAccount> allCheckingAccounts = activeCustomer.GetCheckingAccounts();
                List<BusinessAccount> allBusinessAccounts = activeCustomer.GetBusinessAccounts();
                List<TermDepositAccount> allTermAccounts = activeCustomer.GetTermDepositAccounts();
                bool isGoodProcess = false;

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

        private bool ProcessAccountTransfer(List<Account> allDepositAccounts, List<Account> allWithdrawAccounts)
        {
            Account sourceAccount = null;
            Account destinationAccount = null;
            bool result = false;

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
                            if ((allDepositAccounts[index] as IAccountInfo).AccountNumber == sourceAccountNumber)
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

            if (sourceAccount != null)
            {
                // Run Loop to get destination acount.
                do
                {
                    // Display header.
                    CustomerHeader();
                    ShortAccountHeader(sourceAccount);

                    // Get user selection of transfer source.
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

        private bool ProcessTransferAmount(Account sourceAccount, Account destinationAccount)
        {
            bool result = false;
            double? transferAmount = 0.0;

            // Display header.
            CustomerHeader();
            workingDisplay?.DisplayAccountTransfer(sourceAccount, destinationAccount);
            transferAmount = workingDisplay?.GetUserValueInput();

            // Check for valid input.
            if (transferAmount != null)
            {
                double realAmount = transferAmount.GetValueOrDefault(0.0);
                if (realAmount > 0.0)
                {
                    // Check if source account can cover amount.
                    bool isValidTransaction = CheckSourceAccountFunds(sourceAccount as IAccountInfo, realAmount);
                    if (isValidTransaction)
                    {
                        // Deposit to destination account.
                        TransfertoDestinationAccount(destinationAccount as IAccountInfo, realAmount);

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

        private bool CheckSourceAccountFunds(IAccountInfo sourceAccount, double withdrawAmount)
        {
            bool result = false;

            result = sourceAccount.WithdrawAmount(Math.Round(withdrawAmount, 2));

            return result;
        }

        private void TransfertoDestinationAccount(IAccountInfo destinationAccount, double depositAmount)
        {
            destinationAccount.DepositAmount(Math.Round(depositAmount, 2));
        }
    }
}