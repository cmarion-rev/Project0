using System;
using System.Collections.Generic;
using System.Text;

namespace Project_0
{
    class CustomerStorage : ICustomerDataAddCustomer, ICustomerDataGetCustomer, ICustomerDataRemoveCustomer
    {
        private readonly List<Customer> allCustomer = new List<Customer>();

        private static CustomerStorage workingInstance = null;

        public static CustomerStorage Instance
        {
            get
            {
                if (workingInstance == null)
                {
                    workingInstance = new CustomerStorage();
                }
                return workingInstance;
            }
        }

        CustomerStorage()
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
            bool result = true;
            int customerIndex = allCustomer.IndexOf(newCustomer);
           
            if (customerIndex > -1)
            {
                // Remove all relevant accounts from current customer.
                List<Account> allCustomerAccounts = newCustomer.GetAllAccounts();
                if (allCustomerAccounts.Count > 0)
                {
                    AccountStorage activeAccounts = AccountStorage.Instance;
                    foreach (Account item in allCustomerAccounts)
                    {
                        activeAccounts.RemoveAccount(item);
                    }
                }

                // Remove customer from data set.
                allCustomer.RemoveAt(customerIndex);
            }
            else
            {
                result = false;
            }

            return result;
        }

        public bool RemoveCustomer(int customerID)
        {
            bool result = true;

            if (customerID > -1)
            {
                if (customerID < allCustomer.Count)
                {
                    Customer currentCustomer = allCustomer[customerID];
                    result = RemoveCustomer(currentCustomer);
                }
                else
                {
                    result = false;
                }
            }
            else
            {
                result = false;
            }

            return result;
        }
    }
}
