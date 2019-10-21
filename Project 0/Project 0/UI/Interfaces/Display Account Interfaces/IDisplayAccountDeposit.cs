using System;
using System.Collections.Generic;
using System.Text;

namespace Project_0.AccountInterfaces
{
    interface IDisplayAccountDeposit
    {
        public void DisplayAccountForDepositing(IAccountInfo newAccount);

        public void DisplayDepositAccountOptions(Account[] allAccounts);
    }
}