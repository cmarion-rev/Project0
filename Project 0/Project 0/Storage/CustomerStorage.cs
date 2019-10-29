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

        /// <summary>
        /// Create new customer.
        /// </summary>
        /// <param name="firstName">Customer first name.</param>
        /// <param name="lastName">Customer last name.</param>
        /// <returns>Returns new Customer object.</returns>
        public Customer AddCustomer(string firstName, string lastName)
        {
            Customer newCustomer = null;

            // Generate new customer data.
            CustomerData newData = GenerateNewCustomerData();
            newCustomer = new Customer(newData)
            {
                FirstName = firstName,
                LastName = lastName
            };

            // Add new customer to master list.
            if (allCustomer != null)
            {
                allCustomer.Add(newCustomer);
            }
            
            return newCustomer;
        }

        /// <summary>
        /// Get customer by ID.
        /// </summary>
        /// <param name="customerID">ID of customer.</param>
        /// <returns>Returns Customer object reference.</returns>
        public Customer GetCustomer(int customerID)
        {
            Customer result = null;

            // Check if ID is within valid range.
            if (customerID > -1)
            {
                if (customerID < allCustomer.Count)
                {
                    result = allCustomer[customerID];
                }
            }

            return result;
        }

        /// <summary>
        /// Get all customers.
        /// </summary>
        /// <returns>Returns an array of all customer objects currently in storage.</returns>
        public Customer[] GetAllCustomers()
        {
            return allCustomer.ToArray();
        }

        /// <summary>
        /// Remove customer from storage.
        /// </summary>
        /// <param name="newCustomer">Reference customer object.</param>
        /// <returns>Returns, True if customer was properly removed from storage. Otherwise, False.</returns>
        public bool RemoveCustomer(Customer newCustomer)
        {
            bool result = true;

            // Get list index of referenced customer object.
            int customerIndex = allCustomer.IndexOf(newCustomer);
           
            // Check if index value is valid.
            if (customerIndex > -1)
            {
                // Remove all relevant accounts from current customer.
                List<Account> allCustomerAccounts = newCustomer.GetAllAccounts();
                if (allCustomerAccounts.Count > 0)
                {
                    // Remove all customer accounts from storage.
                    AccountStorage activeAccountStorage = AccountStorage.Instance;
                    foreach (Account item in allCustomerAccounts)
                    {
                        activeAccountStorage?.RemoveAccount(item);
                    }
                }

                // Remove customer from data set.
                allCustomer.RemoveAt(customerIndex);
            }
            else
            {
                // Customer not present in storage.
                result = false;
            }

            return result;
        }

        /// <summary>
        /// Remove customer from storage.
        /// </summary>
        /// <param name="customerID">ID of customer to remove.</param>
        /// <returns>Returns, True if customer was properly removed from storage. Otherwise, False.</returns>
        public bool RemoveCustomer(int customerID)
        {
            bool result = false;

            // Check if ID is within valid range.
            if (customerID > -1)
            {
                if (customerID < allCustomer.Count)
                {
                    // Get reference of specific customer.
                    Customer currentCustomer = allCustomer[customerID];

                    // Remove customer object from storage.
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

        /// <summary>
        /// Generate new CustomerData object.
        /// </summary>
        /// <returns>Returns a new CustomerData property object.</returns>
        private CustomerData GenerateNewCustomerData()
        {
            CustomerData newData = null;

            newData = new CustomerData();

            return newData;
        }
    }
}