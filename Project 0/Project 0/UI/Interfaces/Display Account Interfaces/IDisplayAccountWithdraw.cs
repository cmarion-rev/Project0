using System;
using System.Collections.Generic;
using System.Text;

namespace Project_0.AccountInterfaces
{
    interface IDisplayAccountWithdraw
    {
        public void DisplayAccountForWithdrawing(Account newAccount);

        public void DisplayWithdrawalAccountOptions(Account[] allAccounts);
    }
}