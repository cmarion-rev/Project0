using System;
using System.Collections.Generic;
using System.Text;

namespace Project_0
{
    interface IDisplayAccountTransactions
    {
        public void DisplayAllAccountTransactions(ITransactionRecord[] allTransactions);
    }
}