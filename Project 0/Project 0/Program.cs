using System;

namespace Project_0
{
    class Program
    {
        static void Main(string[] args)
        {
            // Get primary instance of main AccountProcessing program.
            AccountProcessing mainProgram = AccountProcessing.Instance;

            // Start main program.
            mainProgram.Start();
        }
    }
}