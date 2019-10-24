using System;
using System.Collections.Generic;
using System.Text;

namespace Project_0
{
    partial class AccountProcessing
    {
        /// <summary>
        /// Displays header of current customer information.
        /// </summary>
        private void CustomerHeader()
        {
            workingDisplay?.ClearDisplay();
            workingDisplay?.DisplayCustomerInformation(activeCustomer);
        }

        /// <summary>
        /// Displays header with current customer infomation and current account information.
        /// </summary>
        private void FullAccountHeader()
        {
            CustomerHeader();
            ShortAccountHeader();
        }

        /// <summary>
        /// Displays header of account information.
        /// </summary>
        /// <param name="currentAccount">Specific account to display. DEFAULT: Current ActiveAccount.</param>
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