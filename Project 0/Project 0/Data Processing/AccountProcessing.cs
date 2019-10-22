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
                        OpenNewAccount();
                        break;

                    case Utility.OperationState.CLOSE_ACCOUNT:
                        break;

                    case Utility.OperationState.DEPOSIT:
                        DepositToAccount();
                        break;

                    case Utility.OperationState.WITHDRAW:
                        WithdrawFromAccount();
                        break;

                    case Utility.OperationState.TRANSFER:
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
                    List<Account> allAccounts = activeCustomer.GetAllAccounts();

                    // Check if customer has accounts that can be closed.
                    if (allAccounts.Count > 0)
                    {
                        result |= Utility.MainMenuOptions.CLOSE_ACCOUNT;
                        result |= Utility.MainMenuOptions.DISPLAY_ALL_ACCOUNTS;

                        // Check if customer has more that one account, to allow transferring.
                        if (allAccounts.Count > 1)
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

        private void RegisterNewCustomer()
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

        #endregion

        #region CLOSE ACCOUNT METHODS

        #endregion

        #region DEPOSIT TO ACCOUNT METHODS

        private void DepositToAccount()
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

                    // Rebuild accounts list for depositable accounts.
                    Utility.RebuildAccountListForDepositableAccounts(ref allAccounts, allCheckingAccounts, allBusinessAccounts);

                    // Display header.
                    workingDisplay?.ClearDisplay();
                    workingDisplay?.DisplayCustomerInformation(activeCustomer);

                    // Display account selection message.
                    SelectDepositAccount(allAccounts);

                    // Await user to return to main menu.
                    workingDisplay?.DisplayReturningToMainMenu();
                    workingDisplay?.WaitForUserConfirmation();
                }
            }
        }

        private void SelectDepositAccount(List<Account> allAccounts)
        {
            int? accountID = -1;
            workingDisplay?.DisplayDepositAccountOptions(allAccounts.ToArray());
            accountID = workingDisplay?.GetUserOptionNumberSelection();

            // Check if account selected is in current list.
            if (accountID != null)
            {
                bool isValueFound = false;
                int actualID = accountID.GetValueOrDefault(-1);
                foreach (IAccountInfo currentAccount in allAccounts)
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
                    ProcessDepositAmount();
                }
                else
                {
                    workingDisplay?.DisplayInvalidSelection();
                }
            }
        }

        private void ProcessDepositAmount()
        {
            if (activeAccount != null)
            {
                double? userInput = 0.0;

                // Display header information.
                workingDisplay?.ClearDisplay();
                workingDisplay?.DisplayCustomerInformation(activeCustomer);
                workingDisplay?.DisplayAccountForDepositing(activeAccount as IAccountInfo);

                // Get new deposit value.
                userInput = workingDisplay?.GetUserValueInput();

                // Check if input value is valid.
                if (userInput != null)
                {
                    if (userInput >= 0.0)
                    {
                        // Process deposit.
                        (activeAccount as IAccountInfo).DepositAmount(userInput.GetValueOrDefault(0.0));

                        // Display changed results.
                        workingDisplay?.ClearDisplay();
                        workingDisplay?.DisplayCustomerInformation(activeCustomer);
                        workingDisplay?.DisplayAccountInfo(activeAccount as IAccountInfo);
                    }
                    else
                    {
                        workingDisplay?.DisplayInvalidAmount();
                    }
                }
                else
                {
                    workingDisplay?.DisplayInvalidAmount();
                }
            }
        }


        #endregion

        #region WITHDRAW FROM ACCOUNT METHODS

        private void WithdrawFromAccount()
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

                    // Rebuild accounts list for depositable accounts.
                    Utility.RebuildAccountListForWithdrawableAccounts(ref allAccounts, allCheckingAccounts, allBusinessAccounts, allTermAccounts);

                    // Display header.
                    workingDisplay?.ClearDisplay();
                    workingDisplay?.DisplayCustomerInformation(activeCustomer);

                    // Display account selection message.
                    SelectWithdrawAccount(allAccounts);

                    // Await user to return to main menu.
                    workingDisplay?.DisplayReturningToMainMenu();
                    workingDisplay?.WaitForUserConfirmation();
                }
            }
        }

        private void SelectWithdrawAccount(List<Account> allAccounts)
        {
            int? accountID = -1;
            workingDisplay?.DisplayWithdrawalAccountOptions(allAccounts.ToArray());
            accountID = workingDisplay?.GetUserOptionNumberSelection();

            // Check if account selected is in current list.
            if (accountID != null)
            {
                bool isValueFound = false;
                int actualID = accountID.GetValueOrDefault(-1);
                foreach (IAccountInfo currentAccount in allAccounts)
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
                    ProcessWithdrawAmount();
                }
                else
                {
                    workingDisplay?.DisplayInvalidSelection();
                }
            }
        }

        private void ProcessWithdrawAmount()
        {
            if (activeAccount != null)
            {
                double? userInput = 0.0;

                // Display header information.
                workingDisplay?.ClearDisplay();
                workingDisplay?.DisplayCustomerInformation(activeCustomer);
                workingDisplay?.DisplayAccountForWithdrawing(activeAccount as IAccountInfo);

                // Get new deposit value.
                userInput = workingDisplay?.GetUserValueInput();

                // Check if input value is valid.
                if (userInput != null)
                {
                    if (userInput >= 0.0)
                    {
                        // Process withdrawal.
                        bool isGoodTransaction = (activeAccount as IAccountInfo).WithdrawAmount(userInput.GetValueOrDefault(0.0));

                        // Check if withdrawal was successful.
                        if (isGoodTransaction)
                        {
                            // Display changed results.
                            workingDisplay?.ClearDisplay();
                            workingDisplay?.DisplayCustomerInformation(activeCustomer);
                            workingDisplay?.DisplayAccountInfo(activeAccount as IAccountInfo);
                        }
                        else
                        {
                            switch ((activeAccount as IAccountInfo).LastTransactionState)
                            {
                                case Utility.TransactionErrorCodes.OVERDRAFT_PROTECTION:
                                    // Report overdraw attempt.
                                    workingDisplay?.DisplayWithdrawalOverdraftProtection();
                                    break;

                                case Utility.TransactionErrorCodes.TERM_PROTECTION:
                                    // Report term account non-maturity.
                                    // workingDisplay?.
                                    break;

                                case Utility.TransactionErrorCodes.INVALID_AMOUNT:
                                    // Report invalid withdraw error.
                                    workingDisplay?.DisplayInvalidAmount();
                                    break;

                                default:
                                    break;
                            }
                        }
                    }
                    else
                    {
                        workingDisplay?.DisplayInvalidAmount();
                    }
                }
                else
                {
                    workingDisplay?.DisplayInvalidAmount();
                }
            }
        }

        #endregion

        #region TRANSFER BETWEEN ACCOUNTS METHODS

        #endregion

        #region PAY LOAN INSTALLMENT METHODS

        #endregion

        #region DISPLAY CUSTOMER ACCOUNTS METHODS

        private void DisplayCustomerAccounts()
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

                    // Display all accounts.
                    DisplayAllAccounts(allCheckingAccounts, allBusinessAccounts, allTermAccounts, allLoanAccounts);

                    // Await user to return to main menu.
                    workingDisplay?.DisplayReturningToMainMenu();
                    workingDisplay?.WaitForUserConfirmation();
                }
            }
        }

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