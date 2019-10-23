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
                // Get all accounts for current selected customer.
                List<Account> allAccounts = activeCustomer.GetAllAccounts();

                // Check if any account exists.
                if (allAccounts.Count > 0)
                {
                    List<CheckingAccount> allCheckingAccounts = new List<CheckingAccount>();
                    List<BusinessAccount> allBusinessAccounts = new List<BusinessAccount>();
                    List<TermDepositAccount> allTermAccounts = new List<TermDepositAccount>();
                    List<LoanAccount> allLoanAccounts = new List<LoanAccount>();

                    // Create reference accounts.
                    List<Account> allDepositableAccounts = new List<Account>();
                    List<Account> allWithdrawableAccounts = new List<Account>();

                    // Split appart main account list.
                    Utility.SeperateAccounts(allAccounts, ref allCheckingAccounts, ref allBusinessAccounts, ref allTermAccounts, ref allLoanAccounts);

                    // Rebuild accounts list for depositable accounts.
                    Utility.RebuildAccountListForDepositableAccounts(ref allDepositableAccounts, allCheckingAccounts, allBusinessAccounts);
                    Utility.RebuildAccountListForWithdrawableAccounts(ref allWithdrawableAccounts, allCheckingAccounts, allBusinessAccounts, allTermAccounts);

                    // Start account transfer process.
                    ProcessAccountTransfer(allDepositableAccounts, allWithdrawableAccounts);

                    // Await user to return to main menu.
                    workingDisplay?.DisplayReturningToMainMenu();
                    workingDisplay?.WaitForUserConfirmation();
                }
            }
        }

        private void ProcessAccountTransfer(List<Account> allDepositAccounts, List<Account> allWithdrawAccounts)
        {
            Account sourceAccount = null;
            Account destinationAccount = null;

            // Run Loop to get source account.
            do
            {
                // Display header.
                workingDisplay?.ClearDisplay();
                workingDisplay?.DisplayCustomerInformation(activeCustomer);

                // Get user selection of transfer source.
                int? accountID = -1;
                workingDisplay?.DisplayTransferSourceAccount(allDepositAccounts.ToArray());
                accountID = workingDisplay?.GetUserOptionNumberSelection();

                // Check if good source account decided.
                if (accountID != null)
                {
                    bool isGoodValue = false;
                    int sourceAccountNumber = accountID.GetValueOrDefault(-1);
                    foreach (IAccountInfo currentAccount in allDepositAccounts)
                    {
                        if (currentAccount.AccountNumber == sourceAccountNumber)
                        {
                            isGoodValue = true;
                            sourceAccount = (currentAccount as Account);
                            break;
                        }
                    }

                    // Check if good value was found.
                    if (isGoodValue)
                    {
                        // Remove this account from withdraw accounts.
                        for (int index = 0; index < allWithdrawAccounts.Count; ++index)
                        {
                            // Check if current accout is selected number.
                            if ((allWithdrawAccounts[index] as IAccountInfo).AccountNumber == sourceAccountNumber)
                            {
                                allWithdrawAccounts.RemoveAt(index);
                                break;
                            }
                        }
                    }
                    else
                    {
                        // Invalid entry.
                        workingDisplay?.DisplayInvalidSelection();
                        workingDisplay?.WaitForUserConfirmation();
                        sourceAccount = null;
                    }
                }
            } while (sourceAccount == null);

            // Run Loop to get destination acount.
            do
            {
                // Display header.
                workingDisplay?.ClearDisplay();
                workingDisplay?.DisplayCustomerInformation(activeCustomer);
                workingDisplay?.DisplayAccountInfo(sourceAccount as IAccountInfo);

                // Display header.
                workingDisplay?.ClearDisplay();
                workingDisplay?.DisplayCustomerInformation(activeCustomer);

                // Get user selection of transfer source.
                int? accountID = -1;
                workingDisplay?.DisplayTransferDestinationAccount(allWithdrawAccounts.ToArray());
                accountID = workingDisplay?.GetUserOptionNumberSelection();

                // Check if good source account decided.
                if (accountID != null)
                {
                    bool isGoodValue = false;
                    int sourceAccountNumber = accountID.GetValueOrDefault(-1);
                    foreach (IAccountInfo currentAccount in allWithdrawAccounts)
                    {
                        if (currentAccount.AccountNumber == sourceAccountNumber)
                        {
                            isGoodValue = true;
                            destinationAccount = (currentAccount as Account);
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
                        workingDisplay?.DisplayInvalidSelection();
                        workingDisplay?.WaitForUserConfirmation();
                        destinationAccount = null;
                    }
                }

            } while (destinationAccount == null);

            // Process transfer amount.
            ProcessTransferAmount(sourceAccount, destinationAccount);
        }

        private void ProcessTransferAmount(Account sourceAccount, Account destinationAccount)
        {
            double? transferAmount = 0.0;

            // Display header.
            workingDisplay?.ClearDisplay();
            workingDisplay?.DisplayCustomerInformation(activeCustomer);

            workingDisplay?.DisplayAccountTransfer(sourceAccount as IAccountInfo, destinationAccount as IAccountInfo);
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
                        workingDisplay?.DisplayTransferSuccessful(sourceAccount as IAccountInfo, destinationAccount as IAccountInfo);
                        workingDisplay?.WaitForUserConfirmation();
                    }
                }
                else
                {
                    // Invalid entry.
                    workingDisplay?.DisplayInvalidAmount();
                    workingDisplay?.WaitForUserConfirmation();
                }
            }
            else
            {
                // Invalid entry.
                workingDisplay?.DisplayInvalidEntry();
                workingDisplay?.WaitForUserConfirmation();
            }

        }

        private bool CheckSourceAccountFunds(IAccountInfo sourceAccount, double withdrawAmount)
        {
            bool result = false;

            result = sourceAccount.WithdrawAmount(withdrawAmount);

            return result;
        }

        private void TransfertoDestinationAccount(IAccountInfo destinationAccount, double depositAmount)
        {

        }
    }
}