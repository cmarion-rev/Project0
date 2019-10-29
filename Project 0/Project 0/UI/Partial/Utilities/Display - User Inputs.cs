using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace Project_0
{
    partial class Display : IDisplayGeneral, IDisplayAccount, IDisplayCustomer
    {
        public int GetUserOptionNumberSelection()
        {
            int result = -1;

            // Wait for user input.
            string inputLine = Console.ReadLine().Trim();

            // Check for valid input.
            if (inputLine.Length > 0)
            {
                if (int.TryParse(inputLine, out result))
                {
                    // Check if entered amount was a positive value.

                }
                else
                {
                    result = -1;
                }
            }

            return result;
        }

        public Utility.OperationState GetUserSelection(Utility.MainMenuOptions menuOptions)
        {
            Utility.OperationState result = Utility.OperationState.INVALID_OPTION;

            // Wait for user input.
            Console.Write("Please select an option: ");
            string inputLine = Console.ReadLine().Trim();
            int inputValue = -1;

            // Check first value for selected user input.
            if (inputLine.Length > 0)
            {
                if (int.TryParse(inputLine.Substring(0, 1), out inputValue))
                {
                    // Check inputted value against avaliable options.
                    switch (inputValue)
                    {
                        case 1:
                            // Register new account.
                            if ((menuOptions & Utility.MainMenuOptions.REGISTER_NEW_CUSTOMER) == Utility.MainMenuOptions.REGISTER_NEW_CUSTOMER)
                            {
                                result = Utility.OperationState.REGISTER;
                            }
                            break;

                        case 2:
                            // Register new account.
                            if ((menuOptions & Utility.MainMenuOptions.CHANGE_CUSTOMER) == Utility.MainMenuOptions.CHANGE_CUSTOMER)
                            {
                                result = Utility.OperationState.CHANGE_USER;
                            }
                            break;

                        case 3:
                            // Open new account.
                            if ((menuOptions & Utility.MainMenuOptions.OPEN_NEW_ACCOUNT) == Utility.MainMenuOptions.OPEN_NEW_ACCOUNT)
                            {
                                result = Utility.OperationState.OPEN_ACCOUNT;
                            }
                            break;

                        case 4:
                            // Close account.
                            if ((menuOptions & Utility.MainMenuOptions.CLOSE_ACCOUNT) == Utility.MainMenuOptions.CLOSE_ACCOUNT)
                            {
                                result = Utility.OperationState.CLOSE_ACCOUNT;
                            }
                            break;

                        case 5:
                            // Deposit.
                            if ((menuOptions & Utility.MainMenuOptions.DEPOSIT_AMOUNT) == Utility.MainMenuOptions.DEPOSIT_AMOUNT)
                            {
                                result = Utility.OperationState.DEPOSIT;
                            }
                            break;

                        case 6:
                            // Withdraw.
                            if ((menuOptions & Utility.MainMenuOptions.WITHDRAW_AMOUNT) == Utility.MainMenuOptions.WITHDRAW_AMOUNT)
                            {
                                result = Utility.OperationState.WITHDRAW;
                            }
                            break;

                        case 7:
                            // Transfer.
                            if ((menuOptions & Utility.MainMenuOptions.TRANSFER_AMOUNT) == Utility.MainMenuOptions.TRANSFER_AMOUNT)
                            {
                                result = Utility.OperationState.TRANSFER;
                            }
                            break;

                        case 8:
                            // Pay loan.
                            if ((menuOptions & Utility.MainMenuOptions.PAY_LOAN_INSTALLMENT) == Utility.MainMenuOptions.PAY_LOAN_INSTALLMENT)
                            {
                                result = Utility.OperationState.PAY_LOAN;
                            }
                            break;

                        case 9:
                            // Display accounts.
                            if ((menuOptions & Utility.MainMenuOptions.DISPLAY_ALL_ACCOUNTS) == Utility.MainMenuOptions.DISPLAY_ALL_ACCOUNTS)
                            {
                                result = Utility.OperationState.DISPLAY_ACCOUNTS;
                            }
                            break;

                        case 0:
                            // Display transactions.
                            if ((menuOptions & Utility.MainMenuOptions.DISPLAY_ALL_TRANSACTIONS) == Utility.MainMenuOptions.DISPLAY_ALL_TRANSACTIONS)
                            {
                                result = Utility.OperationState.DISPLAY_TRANSACTIONS;
                            }
                            break;

                        default:
                            result = Utility.OperationState.INVALID_OPTION;
                            break;
                    }
                }
                else if (char.ToUpper(inputLine[0]) == 'Q')
                {
                    // Exit program called.
                    result = Utility.OperationState.EXIT_PROGRAM;
                }
            }

            return result;
        }

        public double GetUserValueInput()
        {
            double result = -1.0;

            // Wait for user input.
            string inputLine = Console.ReadLine().Trim();

            // Check for valid input.
            if (inputLine.Length > 0)
            {
                if (double.TryParse(inputLine, out result))
                {
                    // Check if entered amount was a positive value.
                    if (result > 0.0)
                    {
                        // Allow pass through.

                    }
                    else
                    {
                        result = -1.0;
                    }
                }
                else
                {
                    result = -1.0;
                }
            }

            return result;
        }

        public bool WaitForUserConfirmation()
        {
            bool result = false;

            // Wait for user input.
            Console.Write("Press 'Enter' to continue.");

            // Waiting loop for Enter key press.
            while (!result)
            {
                ConsoleKeyInfo inputKey = Console.ReadKey(true);
                if (inputKey.Key == ConsoleKey.Enter)
                {
                    result = true;
                }
                Thread.Sleep(5);
            }

            return result;
        }

        public string GetUserStringInput()
        {
            string result = "";

            result = Console.ReadLine().Trim();

            return result;
        }
    }
}