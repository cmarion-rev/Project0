using System;
using System.Collections.Generic;
using System.Text;

namespace Project_0.AccountInterfaces
{
    interface IDisplayAccountTransactions
    {
        public void DisplayAllAccountTransactions(ITransactionRecord[] allTransactions);
    }
}