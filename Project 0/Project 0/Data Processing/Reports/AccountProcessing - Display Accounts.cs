using System;
using System.Collections.Generic;
using System.Text;

namespace Project_0
{
    partial class AccountProcessing
    {
        /// <summary>
        /// Displays all accounts for current customer.
        /// </summary>
        private void DisplayCustomerAccounts()
        {
            if (activeCustomer != null)
            {
                // Get all accounts for current selected customer.
                List<CheckingAccount> allCheckingAccounts = activeCustomer.GetCheckingAccounts();
                List<BusinessAccount> allBusinessAccounts = activeCustomer.GetBusinessAccounts();
                List<TermDepositAccount> allTermAccounts = activeCustomer.GetTermDepositAccounts();
                List<LoanAccount> allLoanAccounts = activeCustomer.GetLoanAccounts();

                // Display header.
                CustomerHeader();

                // Display all accounts.
                DisplayAllAccounts(allCheckingAccounts, allBusinessAccounts, allTermAccounts, allLoanAccounts);

                // Await user to return to main menu.
                ReturningToMainMenu();
            }
        }

        /// <summary>
        /// Displays all accounts, by type, for current customer.
        /// </summary>
        /// <param name="allCheckingAccounts">List of all checking accounts.</param>
        /// <param name="allBusinessAccounts">List of all business accounts.</param>
        /// <param name="allTermAccounts">List of all term accounts.</param>
        /// <param name="allLoanAccounts">List of all loan accounts.</param>
        private void DisplayAllAccounts(List<CheckingAccount> allCheckingAccounts,
                                        List<BusinessAccount> allBusinessAccounts,
                                        List<TermDepositAccount> allTermAccounts,
                                        List<LoanAccount> allLoanAccounts)
        {
            // Check if any checking accounts.
            if (allCheckingAccounts.Count > 0)
            {
                workingDisplay?.DisplayAllCustomerAccountsByType(Utility.AccountType.CHECKING, allCheckingAccounts.ToArray());
            }

            // Check if any business accounts.
            if (allBusinessAccounts.Count > 0)
            {
                workingDisplay?.DisplayAllCustomerAccountsByType(Utility.AccountType.BUSINESS, allBusinessAccounts.ToArray());
            }

            // Check if any term accounts.
            if (allTermAccounts.Count > 0)
            {
                workingDisplay?.DisplayAllCustomerAccountsByType(Utility.AccountType.TERM, allTermAccounts.ToArray());
            }

            // Check if any loan accounts.
            if (allLoanAccounts.Count > 0)
            {
                workingDisplay?.DisplayAllCustomerAccountsByType(Utility.AccountType.LOAN, allLoanAccounts.ToArray());
            }
        }
    }
}