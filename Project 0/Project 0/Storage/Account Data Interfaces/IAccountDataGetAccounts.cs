using System;
using System.Collections.Generic;
using System.Text;

namespace Project_0
{
    interface IAccountDataGetAccounts
    {
        public Account GetAccount(int accountNumber);
                    
        public CheckingAccount GetCheckingAccount(int accountNumber);
                    
        public BusinessAccount GetBusinessAccount(int accountNumber);
                    
        public TermDepositAccount GetTermAccount(int accountNumber);
                    
        public LoanAccount GetLoanAccount(int accountNumber);

        public int GetAccountsCount();
    }
}
