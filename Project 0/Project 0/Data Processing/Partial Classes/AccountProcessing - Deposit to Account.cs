using System;
using System.Collections.Generic;
using System.Text;

namespace Project_0
{
    partial class AccountProcessing
    {
        private void DepositToAccount()
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
                    Utility.RebuildAccountListForDepositableAccounts(ref allAccounts, allCheckingAccounts, allBusinessAccounts);

                    // Display header.
                    workingDisplay?.ClearDisplay();
                    workingDisplay?.DisplayCustomerInformation(activeCustomer);

                    // Display account selection message.
                    SelectDepositAccount(allAccounts);

                    // Await user to return to main menu.
                    workingDisplay?.DisplayReturningToMainMenu();
                    workingDisplay?.WaitForUserConfirmation();
                }
            }
        }

        private void SelectDepositAccount(List<Account> allAccounts)
        {
            int? accountID = -1;
            workingDisplay?.DisplayDepositAccountOptions(allAccounts.ToArray());
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
                    ProcessDepositAmount();
                }
                else
                {
                    workingDisplay?.DisplayInvalidSelection();
                }
            }
        }

        private void ProcessDepositAmount()
        {
            if (activeAccount != null)
            {
                double? userInput = 0.0;

                // Display header information.
                workingDisplay?.ClearDisplay();
                workingDisplay?.DisplayCustomerInformation(activeCustomer);
                workingDisplay?.DisplayAccountForDepositing(activeAccount as IAccountInfo);

                // Get new deposit value.
                userInput = workingDisplay?.GetUserValueInput();

                // Check if input value is valid.
                if (userInput != null)
                {
                    if (userInput >= 0.0)
                    {
                        // Process deposit.
                        (activeAccount as IAccountInfo).DepositAmount(userInput.GetValueOrDefault(0.0));

                        // Display changed results.
                        workingDisplay?.ClearDisplay();
                        workingDisplay?.DisplayCustomerInformation(activeCustomer);
                        workingDisplay?.DisplayAccountInfo(activeAccount as IAccountInfo);
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
