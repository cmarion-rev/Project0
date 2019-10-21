using System;
using System.Collections.Generic;
using System.Text;

namespace Project_0
{
    interface IAccountDataRemoveAccounts
    {
        public bool RemoveAccount(Account newAccount);
                    
        public bool RemoveCheckingAccount(CheckingAccount newAccount);
                    
        public bool RemoveBusinessAccount(BusinessAccount newAccount);
                    
        public bool RemoveTermAccount(TermDepositAccount newAccount);
                    
        public bool RemoveLoanAccount(LoanAccount newAccount);
    }
}
