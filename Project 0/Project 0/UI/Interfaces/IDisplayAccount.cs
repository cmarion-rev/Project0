using System;
using System.Collections.Generic;
using System.Text;

using Project_0.AccountInterfaces;

namespace Project_0
{
    interface IDisplayAccount : IDisplayAccountTransactions, 
                                IDisplayAccountDeposit, 
                                IDisplayAccountWithdraw, 
                                IDisplayAccountTransfer, 
                                IDisplayAccountLoanPayment
    {
    }
}