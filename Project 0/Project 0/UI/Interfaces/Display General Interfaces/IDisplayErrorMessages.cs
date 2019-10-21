using System;
using System.Collections.Generic;
using System.Text;

namespace Project_0.GeneralInterfaces
{
    interface IDisplayErrorMessages
    {
        public void DisplayInvalidAmount();

        public void DisplayWithdrawalOverdraftProtection();

        public void DisplayInvalidSelection();

        public void DisplayInvalidIndexOption();
    }
}
