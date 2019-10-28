using System;
using System.Collections.Generic;
using System.Text;

namespace Project_0
{
    partial class AccountProcessing
    {
        /// <summary>
        /// Display all transactions for a specific account.
        /// </summary>
        private void DisplayTransactionsForAccount()
        {
            if (activeCustomer != null)
            {
                // Get all accounts for current selected customer.
                List<Account> allAccounts = activeCustomer.GetAllAccounts();

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

        /// <summary>
        /// Displays all accounts for user selection.
        /// </summary>
        /// <param name="allAccounts">List of all accounts.</param>
        /// <param name="allCheckingAccounts">Reference list for all checking accounts.</param>
        /// <param name="allBusinessAccounts">Reference list for all business accounts.</param>
        /// <param name="allTermAccounts">Reference list for all term accounts.</param>
        /// <param name="allLoanAccounts">Reference list for all loan accounts.</param>
        /// <returns>Returns, True if user select a valid account number. Otherwise, False.</returns>
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

                // Check all accounts for user selection.
                foreach (Account currentAccount in allAccounts)
                {
                    if (currentAccount.AccountNumber == actualID)
                    {
                        activeAccount = currentAccount;
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

        /// <summary>
        /// Displays all transaction records for user selected account.
        /// </summary>
        private void DisplayAccountTransactions()
        {
            if (activeAccount != null)
            {
                // Display header
                FullAccountHeader();

                // Display records.
                workingDisplay.DisplayAllAccountTransactions(activeAccount.GetTransactionRecords());

                // Reset current active account.
                ResetActiveAccount();
            }
        }
    }
}