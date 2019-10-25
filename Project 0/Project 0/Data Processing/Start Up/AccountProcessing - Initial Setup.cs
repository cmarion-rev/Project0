using System;
using System.Collections.Generic;
using System.Text;

namespace Project_0
{
    partial class AccountProcessing
    {
        /// <summary>
        /// Create internal linkage to necessary objects.
        /// </summary>
        private void LinkToDevices()
        {
            // Link to Customer Storage.
            workingCustomerStorage = CustomerData.Instance;

            // Link to Account Storage.
            workingAccountStorage = AccountStorage.Instance;

            // Link to Display.
            workingDisplay = Display.Instance;
        }

        /// <summary>
        /// Clear out current active customer.
        /// </summary>
        private void ResetActiveCustomer()
        {
            activeCustomer = null;
        }

        /// <summary>
        /// Clear out current active account.
        /// </summary>
        private void ResetActiveAccount()
        {
            activeAccount = null;
        }
    }
}