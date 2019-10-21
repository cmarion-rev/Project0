using System;
using System.Collections.Generic;
using System.Text;

namespace Project_0
{
    interface IDisplayAccountLoanPayment
    {
        public void DisplayLoanAccountSelection(Account[] allAccounts);

        public void DisplayLoanInstallment();
    }
}
