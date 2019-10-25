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
                    // Display header.
                    CustomerHeader();

                    // Display options.
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
                            InvalidSelection();
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
                CustomerHeader();
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
                        InvalidAmount();
                    }
                }
                else
                {
                    isGoodResult = false;
                    InvalidAmount();
                }
            } while (!isGoodResult);

            // Initialize new account.
            activeAccount = workingAccountStorage?.GenerateNewCheckingAccount(activeCustomer, startingBalance.GetValueOrDefault(0.0));
        }

        private void CreateNewBusinessAccount()
        {
            bool isGoodResult = false;
            double? startingBalance = 0.0;

            // Loop for starting balance of account.
            do
            {
                // Display initial information for setting up initial balance.
                CustomerHeader();
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
                        InvalidAmount();
                    }
                }
                else
                {
                    isGoodResult = false;
                    InvalidAmount();
                }
            } while (!isGoodResult);

            // Initialize new account.
            activeAccount = workingAccountStorage?.GenerateNewBusinessAccount(activeCustomer, startingBalance.GetValueOrDefault(0.0));
        }

        private void CreateNewLoanAccount()
        {
            bool isGoodResult = false;
            double? startingBalance = 0.0;

            // Loop for starting balance of account.
            do
            {
                // Display initial information for setting up initial balance.
                CustomerHeader();
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
                        InvalidAmount();
                    }
                }
                else
                {
                    isGoodResult = false;
                    InvalidAmount();
                }
            } while (!isGoodResult);

            // Initialize new account.
            activeAccount = workingAccountStorage?.GenerateNewLoanAccount(activeCustomer, startingBalance.GetValueOrDefault(0.0));
        }

        private void CreateNewTermAccount()
        {
            bool isGoodResult = false;
            double? startingBalance = 0.0;

            // Loop for starting balance of account.
            do
            {
                // Display initial information for setting up initial balance.
                CustomerHeader();
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
                        InvalidAmount();
                    }
                }
                else
                {
                    isGoodResult = false;
                    InvalidAmount();
                }
            } while (!isGoodResult);

            // Initialize new account.
            activeAccount = workingAccountStorage?.GenerateNewTermAccount(activeCustomer, startingBalance.GetValueOrDefault(0.0));
        }
    }
}