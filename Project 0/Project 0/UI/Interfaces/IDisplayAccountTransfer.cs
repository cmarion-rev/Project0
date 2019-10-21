using System;
using System.Collections.Generic;
using System.Text;

namespace Project_0
{
    interface IDisplayAccountTransfer
    {
        public void DisplayAccountTransferSource(Account[] newAccount);
        
        public void DisplayAccountTransferDestination(Account[] newAccount);

        public void DisplayAccountTransfer(Account[] sourceAccount, Account[] destinationAccount);
    }
}
