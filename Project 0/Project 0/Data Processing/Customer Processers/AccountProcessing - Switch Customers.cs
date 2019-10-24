using System;
using System.Collections.Generic;
using System.Text;

namespace Project_0
{
    partial class AccountProcessing
    {
        private void SwitchCustomers()
        {
            if (workingCustomerStorage != null)
            {
                if (activeCustomer != null)
                {
                    bool isGoodProcess = false;

                    // Display header.
                    CustomerHeader();

                    // Process Customer Selection.
                    ProcessCustomerSelection();

                    // Return to Main Menu.
                    if (isGoodProcess)
                    {
                        ReturningToMainMenu();
                    }
                }
            }
        }

        private bool ProcessCustomerSelection()
        {
            bool result = false;

            int? userInput = -1;
            List<Customer> allCustomer = new List<Customer>(workingCustomerStorage.GetAllCustomers());

            // Display Customer List.
            allCustomer.Remove(activeCustomer);
            workingDisplay?.DisplayCustomerList(allCustomer.ToArray(), activeCustomer);

            // Get user selection.
            userInput = workingDisplay?.GetUserOptionNumberSelection();

            // Check for valid input.
            if (userInput != null)
            {
                if (userInput > 0)
                {
                    int realID = userInput.GetValueOrDefault(-1);
                    foreach (Customer nextCustomer in allCustomer)
                    {
                        if (nextCustomer.CustomerID == realID)
                        {
                            // Switch to new user.
                            activeCustomer = nextCustomer;
                            result = true;

                            // Display new header.
                            CustomerHeader();
                            break;
                        }
                    }
                }
            }

            return result;
        }
    }
}