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

                    // Split appart main account list.
                    Utility.SeperateAccounts(allAccounts, ref allCheckingAccounts, ref allBusinessAccounts, ref allTermAccounts, ref allLoanAccounts);

                    // Display header.
                    workingDisplay?.ClearDisplay();
                    workingDisplay?.DisplayCustomerInformation(activeCustomer);

                    // Display all accounts.
                    DisplayAllAccounts(allCheckingAccounts, allBusinessAccounts, allTermAccounts, allLoanAccounts);

                    // Display account selection message.
                    SelectCloseAccount(allAccounts);

                    // Await user to return to main menu.
                    workingDisplay?.DisplayReturningToMainMenu();
                    workingDisplay?.WaitForUserConfirmation();
                }
            }
        }

        private void SelectCloseAccount(List<Account> allAccounts)
        {
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
                    ProcessCloseAccountConfirmation(actualValue);
                }
                else
                {
                    workingDisplay?.DisplayInvalidSelection();
                }
            }
        }

        private void ProcessCloseAccountConfirmation(int accountNumber)
        {
            // Display header.
            workingDisplay?.ClearDisplay();
            workingDisplay?.DisplayCustomerInformation(activeCustomer);
            workingDisplay?.DisplayAccountInfo(activeAccount as IAccountInfo);

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
