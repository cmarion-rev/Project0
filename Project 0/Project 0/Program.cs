using System;

namespace Project_0
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            Do();
        }

        static void Do()
        {
            Customer A = new Customer()
            {
              
            };

            A.AddAccount(new CheckingAccount(A) { CustomerID = A.CustomerID });

            A.GetAccountByNumber(1);
        }
    }
}