using System;
using System.Collections.Generic;
using System.Text;

namespace Project_0.AccountInterfaces
{
    interface IDisplayAccountLoanPayment
    {
        public void DisplayLoanAccountSelection(Account[] allAccounts);

        public void DisplayLoanInstallment();
    }
}
