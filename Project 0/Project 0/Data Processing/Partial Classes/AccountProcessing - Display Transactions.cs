using System;
using System.Collections.Generic;
using System.Text;

namespace Project_0
{
    partial class AccountProcessing
    {
        private void DisplayTransactionsForAccount()
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
                    Utility.SeperateAccounts(allAccounts, ref allCheckingAccounts, ref allBusinessAccounts, ref allTermAccounts, ref allLoanAccounts);

                    // Display header.
                    CustomerHeader();

                    // Process user input selection.
                    isGoodProcess = ProcessAccountForTransactionDisplay(allAccounts, allCheckingAccounts, allBusinessAccounts, allTermAccounts, allLoanAccounts);

                    // Await user to return to main menu.
                    if (isGoodProcess)
                    {
                        ReturningToMainMenu();
                    }
                }
            }
        }

        private bool ProcessAccountForTransactionDisplay(List<Account> allAccounts,
                                                         List<CheckingAccount> allCheckingAccounts,
                                                         List<BusinessAccount> allBusinessAccounts,
                                                         List<TermDepositAccount> allTermAccounts,
                                                         List<LoanAccount> allLoanAccounts)
        {
            bool result = false;

            int? accountID = -1;
            DisplayAllAccounts(allCheckingAccounts, allBusinessAccounts, allTermAccounts, allLoanAccounts);
            workingDisplay?.DisplayAccountTransactionSelection();
            accountID = workingDisplay?.GetUserOptionNumberSelection();

            // Check if account selected is in current list.
            if (accountID != null)
            {
                bool isFound = false;
                int actualID = accountID.GetValueOrDefault(-1);
                foreach (IAccountInfo currentAccount in allAccounts)
                {
                    if (currentAccount.AccountNumber == actualID)
                    {
                        activeAccount = (currentAccount as Account);
                        DisplayAccountTransactions();
                        isFound = true;
                        result = true;
                        break;
                    }
                }

                // Check if account selected was not found.
                if (!isFound)
                {
                    InvalidSelection(true);
                }
            }

            return result;
        }

        private void DisplayAccountTransactions()
        {
            if (activeAccount != null)
            {
                // Display header
                FullAccountHeader();

                // Display records.
                workingDisplay.DisplayAllAccountTransactions(activeAccount.GetTransactionRecords());

                // Reset current active account.
                activeAccount = null;
            }
        }
    }
}