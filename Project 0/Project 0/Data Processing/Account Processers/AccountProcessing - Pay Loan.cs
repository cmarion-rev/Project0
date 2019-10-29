using System;
using System.Collections.Generic;
using System.Text;

namespace Project_0
{
    partial class AccountProcessing
    {
        /// <summary>
        /// Process user loan installment.
        /// </summary>
        private void PayLoanInstallment()
        {
            if (activeCustomer != null)
            {
                List<LoanAccount> allLoanAccounts = activeCustomer.GetLoanAccounts();

                // Display header.
                CustomerHeader();

                // Display account selection message.
                bool isGoodTransaction = SelectLoanAccount(allLoanAccounts);

                // Await user to return to main menu.
                if (isGoodTransaction)
                {
                    ReturningToMainMenu();
                }
            }
        }

        /// <summary>
        /// Process user selection of loan account.
        /// </summary>
        /// <param name="allLoanAccounts">List of all loan accounts.</param>
        /// <returns>Returns, True if process succeeded. Otherwise, False.</returns>
        private bool SelectLoanAccount(List<LoanAccount> allLoanAccounts)
        {
            bool result = false;

            int? accountID = -1;

            // Get user account selection.
            workingDisplay?.DisplayLoanAccountSelection(allLoanAccounts.ToArray());
            accountID = workingDisplay?.GetUserOptionNumberSelection();

            // Check if account selected is in current list.
            if (accountID != null)
            {
                bool isValueFound = false;
                int actualID = accountID.GetValueOrDefault(-1);

                // Check if specific account number is in loan account list.
                foreach (Account currentAccount in allLoanAccounts)
                {
                    if (currentAccount.AccountNumber == actualID)
                    {
                        isValueFound = true;
                        activeAccount = currentAccount;
                        break;
                    }
                }

                // Check if value was found.
                if (isValueFound)
                {
                    result = ProcessLoanPayment();
                }
                else
                {
                    InvalidSelection(true);
                }
            }

            return result;
        }

        /// <summary>
        /// Process user installment amount input.
        /// </summary>
        /// <returns>Returns, True if process succeeded. Otherwise, False.</returns>
        private bool ProcessLoanPayment()
        {
            bool result = false;

            // Check if activeAccount is referenced to a valid Account object.
            if (activeAccount != null)
            {
                double? userInput = 0.0;

                // Display header information.
                CustomerHeader();

                // Get new deposit value.
                workingDisplay?.DisplayLoanInstallment(activeAccount);
                userInput = workingDisplay?.GetUserValueInput();

                // Check if input value is valid.
                if (userInput != null)
                {
                    if (userInput >= 0.0)
                    {
                        // Process installment payment.
                        activeAccount.DepositAmount(Math.Round(userInput.GetValueOrDefault(0.0), 2));

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