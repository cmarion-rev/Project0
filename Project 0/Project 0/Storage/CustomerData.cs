using System;
using System.Collections.Generic;
using System.Text;

namespace Project_0
{
    class CustomerData
    {
        private readonly List<Customer> allCustomer = new List<Customer>();

        private static CustomerData workingInstance = null;

        public static CustomerData Instance
        {
            get
            {
                if (workingInstance == null)
                {
                    workingInstance = new CustomerData();
                }
                return workingInstance;
            }
        }

        CustomerData()
        {
            allCustomer = new List<Customer>();
        }
    }
}
