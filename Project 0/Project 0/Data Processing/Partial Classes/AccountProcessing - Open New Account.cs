using System;
using System.Collections.Generic;
using System.Text;

namespace Project_0
{
    partial class AccountProcessing
    {
        private void OpenNewAccount()
        {
            // Check if a customer is selected.
            if (activeCustomer != null)
            {
                int? optionInput = -1;

                do
                {
                    workingDisplay?.ClearDisplay();
                    workingDisplay?.DisplayCustomerInformation(activeCustomer);
                    workingDisplay?.DisplayAccountOptions();
                    optionInput = workingDisplay?.GetUserOptionNumberSelection();

                    switch ((Utility.AccountType)(optionInput.GetValueOrDefault(-1) - 1))
                    {
                        case Utility.AccountType.CHECKING:
                            CreateNewCheckingAccount();
                            break;

                        case Utility.AccountType.BUSINESS:
                            CreateNewBusinessAccount();
                            break;

                        case Utility.AccountType.TERM:
                            CreateNewTermAccount();
                            break;

                        case Utility.AccountType.LOAN:
                            CreateNewLoanAccount();
                            break;

                        case (Utility.AccountType)(-1):
                            optionInput = 0;
                            break;

                        default:
                            // Invalid Selection.
                            workingDisplay?.DisplayInvalidSelection();
                            workingDisplay?.WaitForUserConfirmation();
                            optionInput = -1;
                            break;
                    }
                } while (optionInput < 0 || optionInput == null);
            }
        }

        private void CreateNewCheckingAccount()
        {
            bool isGoodResult = false;
            double? startingBalance = 0.0;

            // Loop for starting balance of account.
            do
            {
                // Display initial information for setting up initial balance.
                workingDisplay?.ClearDisplay();
                workingDisplay?.DisplayCustomerInformation(activeCustomer);
                workingDisplay?.DisplayNewCheckingAccountBalance();
                startingBalance = workingDisplay?.GetUserValueInput();

                // Check if input value was valid.
                if (startingBalance != null)
                {
                    if (startingBalance > 0)
                    {
                        isGoodResult = true;
                    }
                    else
                    {
                        isGoodResult = false;
                    }
                }
                else
                {
                    isGoodResult = false;
                }
            } while (!isGoodResult);

            // Initialize new account.
            activeAccount = new CheckingAccount(activeCustomer);
            (activeAccount as CheckingAccount).DepositAmount(startingBalance.GetValueOrDefault(0.0));

            // Add new checking account to account storage.
            workingAccountStorage?.AddAccount(activeAccount);
        }

        private void CreateNewBusinessAccount()
        {
            bool isGoodResult = false;
            double? startingBalance = 0.0;

            // Loop for starting balance of account.
            do
            {
                // Display initial information for setting up initial balance.
                workingDisplay?.ClearDisplay();
                workingDisplay?.DisplayCustomerInformation(activeCustomer);
                workingDisplay?.DisplayNewBusinessAccountBalance();
                startingBalance = workingDisplay?.GetUserValueInput();

                // Check if input value was valid.
                if (startingBalance != null)
                {
                    if (startingBalance > 0)
                    {
                        isGoodResult = true;
                    }
                    else
                    {
                        isGoodResult = false;
                    }
                }
                else
                {
                    isGoodResult = false;
                }
            } while (!isGoodResult);

            // Initialize new account.
            activeAccount = new BusinessAccount(activeCustomer);
            (activeAccount as BusinessAccount).DepositAmount(startingBalance.GetValueOrDefault(0.0));

            // Add new checking account to account storage.
            workingAccountStorage?.AddAccount(activeAccount);
        }

        private void CreateNewLoanAccount()
        {
            bool isGoodResult = false;
            double? startingBalance = 0.0;

            // Loop for starting balance of account.
            do
            {
                // Display initial information for setting up initial balance.
                workingDisplay?.ClearDisplay();
                workingDisplay?.DisplayCustomerInformation(activeCustomer);
                workingDisplay?.DisplayNewLoanAccountBalance();
                startingBalance = workingDisplay?.GetUserValueInput();

                // Check if input value was valid.
                if (startingBalance != null)
                {
                    if (startingBalance > 0)
                    {
                        isGoodResult = true;
                    }
                    else
                    {
                        isGoodResult = false;
                    }
                }
                else
                {
                    isGoodResult = false;
                }
            } while (!isGoodResult);

            // Initialize new account.
            activeAccount = new LoanAccount(activeCustomer);
            (activeAccount as LoanAccount).DepositAmount(startingBalance.GetValueOrDefault(0.0));

            // Add new checking account to account storage.
            workingAccountStorage?.AddAccount(activeAccount);
        }

        private void CreateNewTermAccount()
        {
            bool isGoodResult = false;
            double? startingBalance = 0.0;

            // Loop for starting balance of account.
            do
            {
                // Display initial information for setting up initial balance.
                workingDisplay?.ClearDisplay();
                workingDisplay?.DisplayCustomerInformation(activeCustomer);
                workingDisplay?.DisplayNewTermAccountBalance();
                startingBalance = workingDisplay?.GetUserValueInput();

                // Check if input value was valid.
                if (startingBalance != null)
                {
                    if (startingBalance > 0)
                    {
                        isGoodResult = true;
                    }
                    else
                    {
                        isGoodResult = false;
                    }
                }
                else
                {
                    isGoodResult = false;
                }
            } while (!isGoodResult);

            // Initialize new account.
            activeAccount = new TermDepositAccount(activeCustomer);
            (activeAccount as TermDepositAccount).DepositAmount(startingBalance.GetValueOrDefault(0.0));

            // Add new checking account to account storage.
            workingAccountStorage?.AddAccount(activeAccount);
        }

    }
}
