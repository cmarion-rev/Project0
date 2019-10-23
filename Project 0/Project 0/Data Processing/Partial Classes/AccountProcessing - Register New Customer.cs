using System;
using System.Collections.Generic;
using System.Text;

namespace Project_0
{
    partial class AccountProcessing
    {
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
    }
}