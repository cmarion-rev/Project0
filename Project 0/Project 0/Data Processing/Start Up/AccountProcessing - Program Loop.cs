﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Project_0
{
    partial class AccountProcessing
    {
        /// <summary>
        /// Main Program Running Loop.
        /// </summary>
        /// <param name="isGameLoopActive">Last loop run state.</param>
        /// <returns>Returns, True if the main loop is going to run again. Otherwise, False.</returns>
        private bool MainProgramLoop(bool isGameLoopActive)
        {
            // Define cleared flag sets.
            Utility.MainMenuOptions menuOption = 0;
            Utility.OperationState? userReturn = 0;

            // Clear display for next menu draw.
            workingDisplay?.ClearDisplay();

            // Get avaliable options for Main Menu.
            menuOption = GetCurrentMainMenuOptions();

            // If customer is selected, display customer.
            if (activeCustomer != null)
            {
                CustomerHeader();
            }

            // Display Main Menu.
            workingDisplay?.DisplayMainMenu(menuOption);

            // Get user menu selection.
            userReturn = workingDisplay?.GetUserSelection(menuOption);

            // Process user input value.
            if (userReturn != null)
            {
                switch (userReturn.GetValueOrDefault(Utility.OperationState.INVALID_OPTION))
                {
                    case Utility.OperationState.REGISTER:
                        RegisterNewCustomer();
                        break;

                    case Utility.OperationState.CHANGE_USER:
                        SwitchCustomers();
                        break;

                    case Utility.OperationState.OPEN_ACCOUNT:
                        OpenNewAccount();
                        break;

                    case Utility.OperationState.CLOSE_ACCOUNT:
                        CloseAccount();
                        break;

                    case Utility.OperationState.DEPOSIT:
                        DepositToAccount();
                        break;

                    case Utility.OperationState.WITHDRAW:
                        WithdrawFromAccount();
                        break;

                    case Utility.OperationState.TRANSFER:
                        TransferBetweenAccounts();
                        break;

                    case Utility.OperationState.PAY_LOAN:
                        PayLoanInstallment();
                        break;

                    case Utility.OperationState.DISPLAY_ACCOUNTS:
                        DisplayCustomerAccounts();
                        break;

                    case Utility.OperationState.DISPLAY_TRANSACTIONS:
                        DisplayTransactionsForAccount();
                        break;

                    case Utility.OperationState.EXIT_PROGRAM:
                        isGameLoopActive = false;
                        break;

                    case Utility.OperationState.INVALID_OPTION:
                    default:
                        InvalidSelection();
                        break;
                }
            }
            else
            {
                InvalidSelection();
            }

            return isGameLoopActive;
        }
    }
}