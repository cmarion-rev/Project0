using System;
using System.Collections.Generic;
using System.Text;

namespace Project_0
{
    partial class AccountProcessing
    {
        private static AccountProcessing workingInstance = null;

        public static AccountProcessing Instance
        {
            get
            {
                if (workingInstance == null)
                {
                    workingInstance = new AccountProcessing();
                }
                return workingInstance;
            }
        }

        AccountProcessing()
        {

        }

        #region WORKING SPACE

        Customer activeCustomer;
        Account activeAccount;

        Display workingDisplay;
        CustomerData workingCustomerStorage;
        AccountData workingAccountStorage;

        public void Start()
        {
            bool isGameLoopActive = true;

            // Setup inital internal linkage.
            LinkToDevices();

            // Clear active components.
            ResetActiveAccount();
            ResetActiveCustomer();

            // Start main program loop.
            do
            {
                isGameLoopActive = MainProgramLoop(isGameLoopActive);
            } while (isGameLoopActive);
        }

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
                        workingDisplay?.DisplayInvalidSelection();
                        workingDisplay?.WaitForUserConfirmation();
                        break;
                }
            }
            else
            {
                workingDisplay?.DisplayInvalidSelection();
                workingDisplay?.WaitForUserConfirmation();
            }

            return isGameLoopActive;
        }

        #region PAY LOAN INSTALLMENT METHODS

        #endregion

        #region DISPLAY CUSTOMER ACCOUNTS METHODS

        #endregion

        #region DISPLAY ACCOUNT TRANSACTION METHODS

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

                    // Split appart main account list.
                    Utility.SeperateAccounts(allAccounts, ref allCheckingAccounts, ref allBusinessAccounts, ref allTermAccounts, ref allLoanAccounts);

                    // Display header.
                    workingDisplay?.ClearDisplay();
                    workingDisplay?.DisplayCustomerInformation(activeCustomer);

                    // Process user input selection.
                    ProcessAccountForTransactionDisplay(allAccounts, allCheckingAccounts, allBusinessAccounts, allTermAccounts, allLoanAccounts);

                    // Await user to return to main menu.
                    workingDisplay?.DisplayReturningToMainMenu();
                    workingDisplay?.WaitForUserConfirmation();
                }
            }
        }

        private void ProcessAccountForTransactionDisplay(List<Account> allAccounts, 
                                                         List<CheckingAccount> allCheckingAccounts,
                                                         List<BusinessAccount> allBusinessAccounts,
                                                         List<TermDepositAccount> allTermAccounts,
                                                         List<LoanAccount> allLoanAccounts)
        {
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
                        break;
                    }
                }

                if (!isFound)
                {
                    workingDisplay?.DisplayInvalidSelection();
                }
            }
        }

        private void DisplayAccountTransactions()
        {
            if (activeAccount != null)
            {
                // Display header
                workingDisplay?.ClearDisplay();
                workingDisplay?.DisplayCustomerInformation(activeCustomer);
                workingDisplay?.DisplayAccountInfo(activeAccount as IAccountInfo);
             
                // Display records.
                workingDisplay.DisplayAllAccountTransactions(activeAccount.GetTransactionRecords());

                activeAccount = null;
            }
        }

        #endregion

        #endregion
    }
}