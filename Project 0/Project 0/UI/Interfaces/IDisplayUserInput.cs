using System;
using System.Collections.Generic;
using System.Text;

namespace Project_0
{
    interface IDisplayUserInput
    {
        public Utility.OperationState GetUserSelection();

        public bool WaitForUserConfirmation();

        public int GetUserOptionNumberSelection();
    }
}
