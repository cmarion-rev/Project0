﻿using System;

namespace Project_0
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            AccountProcessing mainProgram = AccountProcessing.Instance;

            mainProgram.Start();
        }
    }
}