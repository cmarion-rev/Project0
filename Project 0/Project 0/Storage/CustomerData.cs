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
            bool result = true;

            int customerIndex = allCustomer.IndexOf(newCustomer);
            if (customerIndex < 0)
            {
                allCustomer.Add(newCustomer);
            }
            else
            {
                result = false;
            }
            
            return result;
        }

        public Customer GetCustomer(int customerID)
        {
            Customer result = null;

            if (customerID > -1)
            {
                if (customerID < allCustomer.Count)
                {
                    result = allCustomer[customerID];
                }
            }

            return result;
        }

        public Customer[] GetAllCustomers()
        {
            return allCustomer.ToArray();
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
