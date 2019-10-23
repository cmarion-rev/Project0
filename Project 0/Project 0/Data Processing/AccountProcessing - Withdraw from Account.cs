using System;
using System.Collections.Generic;
using System.Text;

namespace Project_0
{
    partial class AccountProcessing
    {
        private void WithdrawFromAccount()
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

                    // Split appart main account list.
                    Utility.SeperateAccounts(allAccounts, ref allCheckingAccounts, ref allBusinessAccounts, ref allTermAccounts, ref allLoanAccounts);

                    // Rebuild accounts list for depositable accounts.
                    Utility.RebuildAccountListForWithdrawableAccounts(ref allAccounts, allCheckingAccounts, allBusinessAccounts, allTermAccounts);

                    // Display header.
                    workingDisplay?.ClearDisplay();
                    workingDisplay?.DisplayCustomerInformation(activeCustomer);

                    // Display account selection message.
                    SelectWithdrawAccount(allAccounts);

                    // Await user to return to main menu.
                    workingDisplay?.DisplayReturningToMainMenu();
                    workingDisplay?.WaitForUserConfirmation();
                }
            }
        }

        private void SelectWithdrawAccount(List<Account> allAccounts)
        {
            int? accountID = -1;
            workingDisplay?.DisplayWithdrawalAccountOptions(allAccounts.ToArray());
            accountID = workingDisplay?.GetUserOptionNumberSelection();

            // Check if account selected is in current list.
            if (accountID != null)
            {
                bool isValueFound = false;
                int actualID = accountID.GetValueOrDefault(-1);
                foreach (IAccountInfo currentAccount in allAccounts)
                {
                    if (currentAccount.AccountNumber == actualID)
                    {
                        isValueFound = true;
                        activeAccount = (currentAccount as Account);
                        break;
                    }
                }

                // Check if value was found.
                if (isValueFound)
                {
                    ProcessWithdrawAmount();
                }
                else
                {
                    workingDisplay?.DisplayInvalidSelection();
                }
            }
        }

        private void ProcessWithdrawAmount()
        {
            if (activeAccount != null)
            {
                double? userInput = 0.0;

                // Display header information.
                workingDisplay?.ClearDisplay();
                workingDisplay?.DisplayCustomerInformation(activeCustomer);
                workingDisplay?.DisplayAccountForWithdrawing(activeAccount as IAccountInfo);

                // Get new deposit value.
                userInput = workingDisplay?.GetUserValueInput();

                // Check if input value is valid.
                if (userInput != null)
                {
                    if (userInput >= 0.0)
                    {
                        // Process withdrawal.
                        bool isGoodTransaction = (activeAccount as IAccountInfo).WithdrawAmount(userInput.GetValueOrDefault(0.0));

                        // Check if withdrawal was successful.
                        if (isGoodTransaction)
                        {
                            // Display changed results.
                            workingDisplay?.ClearDisplay();
                            workingDisplay?.DisplayCustomerInformation(activeCustomer);
                            workingDisplay?.DisplayAccountInfo(activeAccount as IAccountInfo);
                        }
                        else
                        {
                            switch ((activeAccount as IAccountInfo).LastTransactionState)
                            {
                                case Utility.TransactionErrorCodes.OVERDRAFT_PROTECTION:
                                    // Report overdraw attempt.
                                    workingDisplay?.DisplayWithdrawalOverdraftProtection();
                                    break;

                                case Utility.TransactionErrorCodes.TERM_PROTECTION:
                                    // Report term account non-maturity.
                                    // workingDisplay?.
                                    break;

                                case Utility.TransactionErrorCodes.INVALID_AMOUNT:
                                    // Report invalid withdraw error.
                                    workingDisplay?.DisplayInvalidAmount();
                                    break;

                                default:
                                    break;
                            }
                        }
                    }
                    else
                    {
                        workingDisplay?.DisplayInvalidAmount();
                    }
                }
                else
                {
                    workingDisplay?.DisplayInvalidAmount();
                }
            }
        }
    }
}
