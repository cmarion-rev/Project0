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
                List<Account> allAccounts = activeCustomer.GetAllAccounts();

                // Check if any account exists.
                if (allAccounts.Count > 0)
                {
                    List<CheckingAccount> allCheckingAccounts = new List<CheckingAccount>();
                    List<BusinessAccount> allBusinessAccounts = new List<BusinessAccount>();
                    List<TermDepositAccount> allTermAccounts = new List<TermDepositAccount>();
                    List<LoanAccount> allLoanAccounts = new List<LoanAccount>();
                    bool isGoodProcess = false;

                    // Split appart main account list.
                    Utility.SeperateAccounts(allAccounts, allCheckingAccounts, allBusinessAccounts, allTermAccounts, allLoanAccounts);

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
                foreach (IAccountInfo currentAccount in allAccounts)
                {
                    if (currentAccount.AccountNumber == actualValue)
                    {
                        isAccountFound = true;
                        activeAccount = (currentAccount as Account);
                        break;
                    }
                }

                if (isAccountFound)
                {
                    result = ProcessCloseAccountConfirmation(actualValue);
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
                workingAccountStorage.RemoveAccount(activeAccount);
                activeAccount = null;
                workingDisplay?.DisplayAccountCloseCompleted(accountNumber);
            }
        }
    }
}