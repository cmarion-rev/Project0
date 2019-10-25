using System;
using System.Collections.Generic;
using System.Text;

namespace Project_0
{
    partial class AccountProcessing
    {
        /// <summary>
        /// Create new customer data object.
        /// </summary>
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
            activeCustomer = workingCustomerStorage?.AddCustomer(firstName, lastName);
        }

        /// <summary>
        /// Generate new first name from user input.
        /// </summary>
        /// <param name="firstName">Reference string of customer first name.</param>
        /// <returns>Returns, True if user entered name was valid. Otherwise, False.</returns>
        private bool ProcessFirstName(ref string firstName)
        {
            bool result = false;

            if (firstName.Length > 0)
            {
                workingDisplay?.DisplayCustomerFirstNameRequest(firstName);
                result = true;
            }
            else
            {
                workingDisplay?.DisplayCustomerFirstNameRequest();
                firstName = workingDisplay?.GetUserStringInput();
                if (firstName == null)
                {
                    // Display error to user and restart loop.
                    firstName = "";
                    InvalidEntry();
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
                        result = true;
                    }
                    else
                    {
                        // Display error to user and restart loop.
                        firstName = "";
                        InvalidEntry();
                    }
                }
            }

            return result;
        }

        /// <summary>
        /// Generate new last name from user input.
        /// </summary>
        /// <param name="lastName">Reference string of customer last name.</param>
        /// <returns>Returns, True if user entered name was valid. Otherwise, False.</returns>
        private bool ProcessLastName(ref string lastName)
        {
            bool result = false;

            if (lastName.Length > 0)
            {
                workingDisplay?.DisplayCustomerLastNameRequest(lastName);
                result = true;
            }
            else
            {
                workingDisplay?.DisplayCustomerLastNameRequest();
                lastName = workingDisplay?.GetUserStringInput();
                if (lastName == null)
                {
                    // Display error to user and restart loop.
                    lastName = "";
                    InvalidEntry();
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
                        result = true;
                    }
                    else
                    {
                        // Display error to user and restart loop.
                        lastName = "";
                        InvalidEntry();
                    }
                }
            }

            return result;
        }
    }
}