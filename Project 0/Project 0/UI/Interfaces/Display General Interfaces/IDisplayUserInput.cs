using System;
using System.Collections.Generic;
using System.Text;

namespace Project_0.GeneralInterfaces
{
    interface IDisplayUserInput
    {
        public Utility.OperationState GetUserSelection(Utility.MainMenuOptions menuOptions);

        public bool WaitForUserConfirmation();

        public int GetUserOptionNumberSelection();

        public double GetUserValueInput();

        public string GetUserStringInput();
    }
}
