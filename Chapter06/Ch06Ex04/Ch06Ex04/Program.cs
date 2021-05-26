using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ch06Ex04
{
    class Program
    {
        static void Write()
        {
            Console.WriteLine("myString = {0}", myString);
        }

        static void Main(string[] args)
        {
            string myString = "String defined in Main()";
            Write();
            Console.ReadKey();
        }
    }
}
