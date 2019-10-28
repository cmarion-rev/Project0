using System;
using System.Collections.Generic;
using System.Text;

namespace Project_0
{
    partial class AccountProcessing
    {
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

        private bool SelectLoanAccount(List<LoanAccount> allLoanAccounts)
        {
            bool result = false;

            int? accountID = -1;
            workingDisplay?.DisplayLoanAccountSelection(allLoanAccounts.ToArray());
            accountID = workingDisplay?.GetUserOptionNumberSelection();

            // Check if account selected is in current list.
            if (accountID != null)
            {
                bool isValueFound = false;
                int actualID = accountID.GetValueOrDefault(-1);
                foreach (IAccountInfo currentAccount in allLoanAccounts)
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
                    result = ProcessLoanPayment();
                }
                else
                {
                    InvalidSelection(true);
                }
            }

            return result;
        }

        private bool ProcessLoanPayment()
        {
            bool result = false;

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
                        (activeAccount as LoanAccount).DepositAmount(userInput.GetValueOrDefault(0.0));

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