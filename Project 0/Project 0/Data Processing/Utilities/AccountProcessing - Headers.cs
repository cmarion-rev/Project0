using System;
using System.Collections.Generic;
using System.Text;

namespace Project_0
{
    partial class AccountProcessing
    {
        private void CustomerHeader()
        {
            workingDisplay?.ClearDisplay();
            workingDisplay?.DisplayCustomerInformation(activeCustomer);
        }

        private void FullAccountHeader()
        {
            CustomerHeader();
            ShortAccountHeader();
        }

        private void ShortAccountHeader(Account currentAccount = null)
        {
            if (currentAccount == null)
            {
                workingDisplay?.DisplayAccountInfo(activeAccount);
            }
            else
            {
                workingDisplay?.DisplayAccountInfo(currentAccount);
            }
        }
    }
}