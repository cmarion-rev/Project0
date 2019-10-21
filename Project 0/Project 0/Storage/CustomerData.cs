using System;
using System.Collections.Generic;
using System.Text;

namespace Project_0
{
    class CustomerData : ICustomerDataAddCustomer, ICustomerDataGetCustomer, ICustomerDataRemoveCustomer
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

        public bool AddCustomer(Customer newCustomer)
        {
            throw new NotImplementedException();
        }

        public Customer GetCustomer(int customerID)
        {
            throw new NotImplementedException();
        }

        public Customer[] GetAllCustomers()
        {
            throw new NotImplementedException();
        }

        public bool RemoveCustomer(Customer newCustomer)
        {
            throw new NotImplementedException();
        }

        public bool RemoveCustomer(int customerID)
        {
            throw new NotImplementedException();
        }
    }
}
