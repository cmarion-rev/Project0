using System;
using System.Collections.Generic;
using System.Text;

namespace Project_0
{
    interface IAccountDataAddAccounts
    {
        public bool AddAccount(Account newAccount);

        public bool AddCheckingAccount(CheckingAccount newAccount);
        
        public bool AddBusinessAccount(BusinessAccount newAccount);
        
        public bool AddTermAccount(TermDepositAccount newAccount);
        
        public bool AddLoanAccount(LoanAccount newAccount);
    }
}
