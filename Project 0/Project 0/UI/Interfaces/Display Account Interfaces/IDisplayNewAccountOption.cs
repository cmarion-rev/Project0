using System;
using System.Collections.Generic;
using System.Text;

namespace Project_0.AccountInterfaces
{
    interface IDisplayNewAccountOption
    {
        public void DisplayNewCheckingAccountBalance();

        public void DisplayNewBusinessAccountBalance();

        public void DisplayNewLoanAccountBalance();

        public void DisplayNewTermAccountBalance();
    }
}
