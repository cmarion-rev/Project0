using System;
using System.Collections.Generic;
using System.Text;

namespace Project_0
{
    partial class AccountProcessing
    {
        private static AccountProcessing workingInstance = null;

        public static AccountProcessing Instance
        {
            get
            {
                if (workingInstance == null)
                {
                    workingInstance = new AccountProcessing();
                }
                return workingInstance;
            }
        }

        AccountProcessing()
        {

        }

        #region WORKING SPACE

        Customer activeCustomer;
        Account activeAccount;

        Display workingDisplay;
        CustomerData workingCustomerStorage;
        AccountStorage workingAccountStorage;

        /// <summary>
        /// Starts main program process.
        /// </summary>
        public void Start()
        {
            bool isGameLoopActive = true;

            // Setup inital internal linkage.
            LinkToDevices();

            // Clear active components.
            ResetActiveAccount();
            ResetActiveCustomer();

            // Start main program loop.
            do
            {
                isGameLoopActive = MainProgramLoop(isGameLoopActive);
            } while (isGameLoopActive);
        }
             
        #endregion
    }
}