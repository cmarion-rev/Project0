using System;
using System.Collections.Generic;
using System.Text;

namespace Project_0
{
    interface Account
    {
        public int CustomerID { get; set; }

        public Customer Customer { get; set; }

        public double AccountBalance { get; set; }
    }
}
