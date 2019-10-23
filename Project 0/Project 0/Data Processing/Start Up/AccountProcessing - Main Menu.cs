using System;
using System.Collections.Generic;
using System.Text;

namespace Project_0
{ 
    partial class AccountProcessing
    {
        private Utility.MainMenuOptions GetCurrentMainMenuOptions()
        {
            Utility.MainMenuOptions result = 0;

            // Check if new customers can be created.
            if (workingCustomerStorage != null)
            {
                result |= Utility.MainMenuOptions.REGISTER_NEW_CUSTOMER;

                if (workingCustomerStorage.GetAllCustomers().Length > 1)
                {
                    result |= Utility.MainMenuOptions.CHANGE_CUSTOMER;
                }
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
                        result |= Utility.MainMenuOptions.DISPLAY_ALL_TRANSACTIONS;

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
    }
}
