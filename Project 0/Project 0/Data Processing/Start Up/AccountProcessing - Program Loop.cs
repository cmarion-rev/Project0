using System;
using System.Collections.Generic;
using System.Text;

namespace Project_0
{
    partial class AccountProcessing
    {
        private bool MainProgramLoop(bool isGameLoopActive)
        {
            Utility.MainMenuOptions menuOption = 0;

            // Clear display for next menu draw.
            workingDisplay?.ClearDisplay();

            // Get avaliable options for Main Menu.
            menuOption = GetCurrentMainMenuOptions();

            // If customer is selected, display customer.
            if (activeCustomer != null)
            {
                workingDisplay?.DisplayCustomerInformation(activeCustomer);
            }

            // Display Main Menu.
            workingDisplay?.DisplayMainMenu(menuOption);

            // Get user menu selection.
            Utility.OperationState? userReturn = workingDisplay?.GetUserSelection(menuOption);

            // Process user input value.
            if (userReturn != null)
            {
                switch (userReturn.GetValueOrDefault())
                {
                    case Utility.OperationState.REGISTER:
                        RegisterNewCustomer();
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