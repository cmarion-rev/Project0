using System;
using System.Collections.Generic;
using System.Text;

namespace Project_0.AccountInterfaces
{
    interface IDisplayAccountClose
    {
        public void DisplayAccountCloseSelection();

        public void DisplayAccountCloseConfirmation();

        public void DisplayAccountCloseCompleted(int accountNumber);
    }
}