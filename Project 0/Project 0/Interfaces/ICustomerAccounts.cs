using System;
using System.Collections.Generic;
using System.Text;

namespace Project_0
{
    interface ICustomerAccounts : ICustomerAccountUpdates
    {
        public int GetNumberOfAccounts();

        public List<Account> GetAccounts();
        
        public List<CheckingAccount> GetCheckingAccounts();
        
        public List<BusinessAccount> GetBusinessAccounts();
        
        public List<TermDepositAccount> GetTermDepositAccounts();
        
        public List<LoanAccount> GetLoanAccounts();

        public Account GetAccount(int index);
    }
}