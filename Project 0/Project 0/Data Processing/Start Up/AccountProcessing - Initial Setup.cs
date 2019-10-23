using System;
using System.Collections.Generic;
using System.Text;

namespace Project_0
{
    partial class AccountProcessing
    {
        private void LinkToDevices()
        {
            // Link to Customer Storage.
            workingCustomerStorage = CustomerData.Instance;

            // Link to Account Storage.
            workingAccountStorage = AccountData.Instance;

            // Link to Display.
            workingDisplay = Display.Instance;
        }

        private void ResetActiveCustomer()
        {
            activeCustomer = null;
        }

        private void ResetActiveAccount()
        {
            activeAccount = null;
        }
    }
}