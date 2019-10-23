using System;
using System.Collections.Generic;
using System.Text;

namespace Project_0
{
    partial class AccountProcessing
    {
        private void InvalidSelection(bool returnToMainMenu = false)
        {
            workingDisplay?.DisplayInvalidSelection();
            if (returnToMainMenu)
            {
                workingDisplay?.DisplayReturningToMainMenu();
            }
            workingDisplay?.WaitForUserConfirmation();
        }

        private void ReturningToMainMenu()
        {
            workingDisplay?.DisplayReturningToMainMenu();
            workingDisplay?.WaitForUserConfirmation();
        }

        private void InvalidEntry(bool returnToMainMenu=false)
        {
            workingDisplay?.DisplayInvalidEntry();
            if (returnToMainMenu)
            {
                workingDisplay?.DisplayReturningToMainMenu();
            }
            workingDisplay?.WaitForUserConfirmation();
        }

        private void InvalidAmount(bool returnToMainMenu = false)
        {
            workingDisplay?.DisplayInvalidAmount();
            if (returnToMainMenu)
            {
                workingDisplay?.DisplayReturningToMainMenu();
            }
            workingDisplay?.WaitForUserConfirmation();
        }
    }
}