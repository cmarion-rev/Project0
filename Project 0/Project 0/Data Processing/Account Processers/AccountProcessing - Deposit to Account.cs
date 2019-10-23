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
                    Utility.SeperateAccounts(allAccounts, allCheckingAccounts, allBusinessAccounts, null, null);

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

        private bool SelectDepositAccount(List<Account> allAccounts)
        {
            bool result = false;

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
                    result = ProcessDepositAmount();
                }
                else
                {
                    InvalidSelection(true);
                }
            }

            return result;
        }

        private bool ProcessDepositAmount()
        {
            bool result = false;

            if (activeAccount != null)
            {
                double? userInput = 0.0;

                // Display header information.
                CustomerHeader();

                // Get new deposit value.
                workingDisplay?.DisplayAccountForDepositing(activeAccount as IAccountInfo);
                userInput = workingDisplay?.GetUserValueInput();

                // Check if input value is valid.
                if (userInput != null)
                {
                    if (userInput >= 0.0)
                    {
                        // Process deposit.
                        (activeAccount as IAccountInfo).DepositAmount(userInput.GetValueOrDefault(0.0));

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