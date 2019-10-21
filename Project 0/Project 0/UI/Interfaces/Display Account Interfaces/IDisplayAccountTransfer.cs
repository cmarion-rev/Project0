using System;
using System.Collections.Generic;
using System.Text;

namespace Project_0.AccountInterfaces
{
    interface IDisplayAccountTransfer
    {
        public void DisplayTransferSourceAccount(Account[] allAccounts);
        
        public void DisplayTransferDestinationAccount(Account[] allAccounts);

        public void DisplayAccountTransfer(Account[] sourceAccount, Account[] destinationAccount);
    }
}
