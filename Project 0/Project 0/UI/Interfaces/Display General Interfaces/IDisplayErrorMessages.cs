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

        public void DisplayReturningToMainMenu();

        public void DisplayInvalidEntry();

        public void DisplayAccountBalanceRemaining(int accountID, double amount);

        public void DisplayAccountLoanBalanceRemaining(int accountID, double amount);

        public void DisplayAccountOverdraftRemaining(int accountID, double amount);
    }
}