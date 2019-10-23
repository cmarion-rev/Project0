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

        private void ShortAccountHeader()
        {
            workingDisplay?.DisplayAccountInfo(activeAccount as IAccountInfo);
        }
    }
}
