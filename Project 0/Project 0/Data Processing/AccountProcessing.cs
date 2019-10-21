using System;
using System.Collections.Generic;
using System.Text;

namespace Project_0
{
    class AccountProcessing
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
                        break;

                    case Utility.OperationState.CLOSE_ACCOUNT:
                        break;

                    case Utility.OperationState.WITHDRAW:
                        break;

                    case Utility.OperationState.DEPOSIT:
                        break;

                    case Utility.OperationState.TRANSFER:
                        break;

                    case Utility.OperationState.PAY_LOAN:
                        break;

                    case Utility.OperationState.DISPLAY_ACCOUNTS:
                        break;

                    case Utility.OperationState.DISPLAY_TRANSACTIONS:
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

        #region INITIAL SETUP METHODS

        private void LinkToDevices()
        {
            // Link to Customer Storage.
            workingCustomerStorage = CustomerData.Instance;

            // Link to Account Storage.
            workingAccountStorage = AccountData.Instance;

            // Link to Display.
            workingDisplay = Display.Instance;
        }

        private void ResetActiveCustomer()
        {
            activeCustomer = null;
        }

        private void ResetActiveAccount()
        {
            activeAccount = null;
        }

        #endregion 

        #region MAIN MENU METHODS

        private Utility.MainMenuOptions GetCurrentMainMenuOptions()
        {
            Utility.MainMenuOptions result = 0;

            // Check if new customers can be created.
            if (workingCustomerStorage != null)
            {
                result |= Utility.MainMenuOptions.REGISTER_NEW_CUSTOMER;
            }

            // Check if current customer exists.
            if (activeCustomer != null)
            {
                // Check if accounts can be created.
                if (workingAccountStorage != null)
                {
                    result |= Utility.MainMenuOptions.OPEN_NEW_ACCOUNT;

                    // Check if customer has accounts that can be closed.
                    if (activeCustomer.GetAllAccounts().Count > 0)
                    {
                        List<Account> allAccounts = activeCustomer.GetAllAccounts();

                        result |= Utility.MainMenuOptions.CLOSE_ACCOUNT;
                        result |= Utility.MainMenuOptions.DISPLAY_ALL_ACCOUNTS;

                        // Check if customer has more that one account, to allow transferring.
                        if (activeCustomer.GetAllAccounts().Count > 1)
                        {
                            // Check if atleast two accounts can be part of transfer.
                            if (CheckCustomerAccountsForTransferable(allAccounts))
                            {
                                result |= Utility.MainMenuOptions.TRANSFER_AMOUNT;
                            }
                        }

                        // Check if customer has a depositable account.
                        if (CheckCustomerAccountsForDepositable(allAccounts))
                        {
                            result |= Utility.MainMenuOptions.DEPOSIT_AMOUNT;
                        }

                        // Check if customer has a withdrawable account.
                        if (CheckCustomerAccountsForWithdrawable(allAccounts))
                        {
                            result |= Utility.MainMenuOptions.WITHDRAW_AMOUNT;
                        }

                        // Check if customer has a loan account for paying installments to.
                        if (CheckCustomerAccountsForLoanPayable(allAccounts))
                        {
                            result |= Utility.MainMenuOptions.PAY_LOAN_INSTALLMENT;
                        }
                    }
                }
            }

            // Check if any account is available for displaying transactions.
            if (workingAccountStorage?.GetAccountsCount() > 0)
            {
                result |= Utility.MainMenuOptions.DISPLAY_ALL_TRANSACTIONS;
            }

            // Enable exit program.
            result |= Utility.MainMenuOptions.EXIT_PROGRAM;

            return result;
        }

        private bool CheckCustomerAccountsForDepositable(List<Account> allAccounts)
        {
            bool result = false;

            if (allAccounts != null)
            {
                foreach (IAccountInfo currentAccount in allAccounts)
                {
                    switch (currentAccount.AccountType)
                    {
                        case Utility.AccountType.CHECKING:
                        case Utility.AccountType.BUSINESS:
                            result = true;
                            break;

                        default:
                            break;
                    }

                    // Exit loop on valid account find.
                    if (result)
                    {
                        break;
                    }
                }
            }

            return result;
        }

        private bool CheckCustomerAccountsForTransferable(List<Account> allAccounts)
        {
            bool result = false;
            int count = 0;

            if (allAccounts != null)
            {
                foreach (IAccountInfo currentAccount in allAccounts)
                {
                    switch (currentAccount.AccountType)
                    {
                        case Utility.AccountType.CHECKING:
                        case Utility.AccountType.BUSINESS:
                            ++count;
                            break;

                        default:
                            break;
                    }

                    // Exit loop on valid account find.
                    if (count > 1)
                    {
                        result = true;
                        break;
                    }
                }
            }

            return result;
        }

        private bool CheckCustomerAccountsForWithdrawable(List<Account> allAccounts)
        {
            bool result = false;

            if (allAccounts != null)
            {
                foreach (IAccountInfo currentAccount in allAccounts)
                {
                    switch (currentAccount.AccountType)
                    {
                        case Utility.AccountType.CHECKING:
                        case Utility.AccountType.BUSINESS:
                            result = true;
                            break;

                        case Utility.AccountType.TERM:
                            result = (currentAccount as TermDepositAccount).MaturityDate.Subtract(DateTime.Now).TotalDays < 0;
                            break;

                        default:
                            break;
                    }

                    // Exit loop on valid account find.
                    if (result)
                    {
                        break;
                    }
                }
            }

            return result;
        }

        private bool CheckCustomerAccountsForLoanPayable(List<Account> allAccounts)
        {
            bool result = false;

            if (allAccounts != null)
            {
                foreach (IAccountInfo currentAccount in allAccounts)
                {
                    switch (currentAccount.AccountType)
                    {
                        case Utility.AccountType.LOAN:
                            result = true;
                            break;

                        default:
                            break;
                    }

                    // Exit loop on valid account find.
                    if (result)
                    {
                        break;
                    }
                }
            }

            return result;
        }

        #endregion

        #region REGISTER NEW CUSTOMER METHODS

        public void RegisterNewCustomer()
        {
            string firstName = "";
            string lastName = "";

            do
            {
                bool continueProcessing = true;

                workingDisplay?.ClearDisplay();
                workingDisplay?.DisplayNewCustomerScreen();

                // Process first name.
                continueProcessing = ProcessFirstName(ref firstName);
                if (continueProcessing)
                {
                    // Process last name.
                    continueProcessing = ProcessLastName(ref lastName);
                    if (!continueProcessing)
                    {
                        // Restart loop on fail.
                        continue;
                    }
                }
            } while (firstName.Length < 1 || lastName.Length < 1);

            // Create new customer object.
            activeCustomer = new Customer()
            {
                FirstName = firstName,
                LastName = lastName,
            };

            // Add customer object to storage space.
            workingCustomerStorage?.AddCustomer(activeCustomer);
        }

        private bool ProcessFirstName(ref string firstName)
        {
            bool result = true;

            if (firstName.Length > 0)
            {
                workingDisplay?.DisplayCustomerFirstNameRequest(firstName);
            }
            else
            {
                workingDisplay?.DisplayCustomerFirstNameRequest();
                firstName = workingDisplay?.GetUserStringInput();
                if (firstName == null)
                {
                    // Display error to user and restart loop.
                    firstName = "";
                    workingDisplay?.DisplayInvalidEntry();
                    workingDisplay?.WaitForUserConfirmation();
                    result = false;
                }
                else
                {
                    // Limit string to 30 characters.
                    if (firstName.Length > 30)
                    {
                        firstName = firstName.Substring(0, 30);
                    }

                    // Validate string is good.
                    if (Utility.ValidateName(firstName))
                    {
                        firstName = Utility.CaptializeName(firstName);
                    }
                    else
                    {
                        // Display error to user and restart loop.
                        firstName = "";
                        workingDisplay?.DisplayInvalidEntry();
                        workingDisplay?.WaitForUserConfirmation();
                        result = false;
                    }
                }
            }

            return result;
        }

        private bool ProcessLastName(ref string lastName)
        {
            bool result = true;

            if (lastName.Length > 0)
            {
                workingDisplay?.DisplayCustomerLastNameRequest(lastName);
            }
            else
            {
                workingDisplay?.DisplayCustomerLastNameRequest();
                lastName = workingDisplay?.GetUserStringInput();
                if (lastName == null)
                {
                    // Display error to user and restart loop.
                    lastName = "";
                    workingDisplay?.DisplayInvalidEntry();
                    workingDisplay?.WaitForUserConfirmation();
                    result = false;
                }
                else
                {
                    // Limit string to 30 characters.
                    if (lastName.Length > 30)
                    {
                        lastName = lastName.Substring(0, 30);
                    }

                    // Validate string is good.
                    if (Utility.ValidateName(lastName))
                    {
                        lastName = Utility.CaptializeName(lastName);
                    }
                    else
                    {
                        // Display error to user and restart loop.
                        lastName = "";
                        workingDisplay?.DisplayInvalidEntry();
                        workingDisplay?.WaitForUserConfirmation();
                        result = false;
                    }
                }
            }

            return result;
        }

        #endregion

        #region OPEN ACCOUNT METHODS



        #endregion

        #endregion
    }
}