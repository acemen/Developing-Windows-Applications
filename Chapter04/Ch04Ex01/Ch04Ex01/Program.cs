﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ch04Ex01
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter an integer:");
            int Myint = Convert.ToInt32(Console.ReadLine());
            bool isLessThan10 = Myint < 10;
            bool isBetween0And5 = (0 <= Myint) && (Myint <= 5);
            Console.WriteLine("Integer less than 10? {0}", isLessThan10);
            Console.WriteLine("Integer between 0 and 5? {0}", isBetween0And5);
            Console.WriteLine("Exactly one of the above is true? {0}", isLessThan10 ^ isBetween0And5);
            Console.ReadKey();
        }
    }
}