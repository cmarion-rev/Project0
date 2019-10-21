using System;
using System.Collections.Generic;
using System.Text;

namespace Project_0.UI.Interfaces
{
    interface IDisplayAccount : IDisplayAccountTransactions, IDisplayAccountDeposit, IDisplayAccountWithdraw, IDisplayAccountTransfer, IDisplayAccountLoanPayment
    {
    }
}