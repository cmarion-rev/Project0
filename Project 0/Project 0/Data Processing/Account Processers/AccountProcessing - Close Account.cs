using System;
using System.Collections.Generic;
using System.Text;

namespace Project_0
{
    partial class AccountProcessing
    {
        private void CloseAccount()
        {
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
                    List<LoanAccount> allLoanAccounts = activeCustomer.GetLoanAccounts();
                    bool isGoodProcess = false;

                    // Display header.
                    CustomerHeader();

                    // Display all accounts.
                    DisplayAllAccounts(allCheckingAccounts, allBusinessAccounts, allTermAccounts, allLoanAccounts);

                    // Display account selection message.
                    isGoodProcess = SelectCloseAccount(allAccounts);

                    // Await user to return to main menu.
                    if (isGoodProcess)
                    {
                        ReturningToMainMenu();
                    }
                }
            }
        }

        private bool SelectCloseAccount(List<Account> allAccounts)
        {
            bool result = false;

            int? accountID = -1;

            workingDisplay?.DisplayAccountCloseSelection();
            accountID = workingDisplay?.GetUserOptionNumberSelection();

            // Check if user input is valid.
            if (accountID != null)
            {
                int actualValue = accountID.GetValueOrDefault(-1);
                bool isAccountFound = false;
                // Search list for valid accout number.
                foreach (Account currentAccount in allAccounts)
                {
                    if (currentAccount.AccountNumber == actualValue)
                    {
                        isAccountFound = true;
                        activeAccount = currentAccount;
                        break;
                    }
                }

                if (isAccountFound)
                {
                    bool canClose = true;

                    // Check if account has remaining balance.
                    switch (activeAccount.AccountType)
                    {
                        case Utility.AccountType.CHECKING:
                        case Utility.AccountType.TERM:
                            if (activeAccount.AccountBalance > 0.0)
                            {
                                workingDisplay?.DisplayAccountBalanceRemaining(activeAccount.AccountNumber, activeAccount.AccountBalance);
                                canClose = false;
                            }
                            break;

                        case Utility.AccountType.BUSINESS:
                            if (activeAccount.AccountBalance > 0.0)
                            {
                                workingDisplay?.DisplayAccountBalanceRemaining(activeAccount.AccountNumber, activeAccount.AccountBalance);
                                canClose = false;
                            }
                            else if (activeAccount.AccountBalance < 0.0)
                            {
                                workingDisplay?.DisplayAccountOverdraftRemaining(activeAccount.AccountNumber, activeAccount.AccountBalance);
                                canClose = false;
                            }
                            break;

                        case Utility.AccountType.LOAN:
                            if (activeAccount.AccountBalance > 0.0)
                            {
                                workingDisplay?.DisplayAccountLoanBalanceRemaining(activeAccount.AccountNumber, activeAccount.AccountBalance);
                                canClose = false;
                            }
                            break;

                        default:
                            break;
                    }

                    // Check if account was validated to be closed.
                    if (canClose)
                    {
                        result = ProcessCloseAccountConfirmation(actualValue);
                    }
                    else
                    {
                        result = false;
                        workingDisplay?.WaitForUserConfirmation();
                    }
                }
                else
                {
                    InvalidSelection(true);
                }
            }

            return result;
        }

        private bool ProcessCloseAccountConfirmation(int accountNumber)
        {
            bool result = true;

            // Display header.
            FullAccountHeader();

            // Get final account close confirmation.
            workingDisplay?.DisplayAccountCloseConfirmation();
            string lastChance = workingDisplay?.GetUserStringInput();

            // Check for valid entry to close account.
            if (lastChance != null)
            {
                if (lastChance.Length > 0)
                {
                    if (char.ToUpper(lastChance[0]) == 'Y')
                    {
                        // Close account.
                        FinalAccountCloseProcess(accountNumber);
                    }
                }
            }

            return result;
        }

        private void FinalAccountCloseProcess(int accountNumber)
        {
            if (workingAccountStorage != null)
            {
                activeAccount?.CloseAccount();
                workingAccountStorage?.RemoveAccount(activeAccount);
                ResetActiveAccount();
                workingDisplay?.DisplayAccountCloseCompleted(accountNumber);
            }
        }
    }
}