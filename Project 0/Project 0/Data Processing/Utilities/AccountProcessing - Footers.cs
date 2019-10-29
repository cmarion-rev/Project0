using System;
using System.Collections.Generic;
using System.Text;

namespace Project_0
{
    partial class AccountProcessing
    {
        /// <summary>
        /// Displays invalid user selection message.
        /// </summary>
        /// <param name="returnToMainMenu">True, to display returning to main menu message. False, if not.</param>
        private void InvalidSelection(bool returnToMainMenu = false)
        {
            workingDisplay?.DisplayInvalidSelection();
            // Check if sequence is returning to main menu.
            if (returnToMainMenu)
            {
                workingDisplay?.DisplayReturningToMainMenu();
            }
            workingDisplay?.WaitForUserConfirmation();
        }

        /// <summary>
        /// Displays returning to main menu message.
        /// </summary>
        private void ReturningToMainMenu()
        {
            workingDisplay?.DisplayReturningToMainMenu();
            workingDisplay?.WaitForUserConfirmation();
        }

        /// <summary>
        /// Displays account overdraft protection message.
        /// </summary>
        /// <param name="returnToMainMenu">True, to display returning to main menu message. False, if not.</param>
        private void OverdraftProtection(bool returnToMainMenu = false)
        {
            workingDisplay?.DisplayWithdrawalOverdraftProtection();
            // Check if sequence is returning to main menu.
            if (returnToMainMenu)
            {
                workingDisplay?.DisplayReturningToMainMenu();
            }
            workingDisplay?.WaitForUserConfirmation();
        }

        /// <summary>
        /// Displays invalid user entry message.
        /// </summary>
        /// <param name="returnToMainMenu">True, to display returning to main menu message. False, if not.</param>
        private void InvalidEntry(bool returnToMainMenu = false)
        {
            workingDisplay?.DisplayInvalidEntry();
            // Check if sequence is returning to main menu.
            if (returnToMainMenu)
            {
                workingDisplay?.DisplayReturningToMainMenu();
            }
            workingDisplay?.WaitForUserConfirmation();
        }

        /// <summary>
        /// Displays invalid user entered amount message.
        /// </summary>
        /// <param name="returnToMainMenu">True, to display returning to main menu message. False, if not.</param>
        private void InvalidAmount(bool returnToMainMenu = false)
        {
            workingDisplay?.DisplayInvalidAmount();
            // Check if sequence is returning to main menu.
            if (returnToMainMenu)
            {
                workingDisplay?.DisplayReturningToMainMenu();
            }
            workingDisplay?.WaitForUserConfirmation();
        }
    }
}