using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1
{
    class Task11
    {
        public static void Rectangle()
        {
            int a, b;
            Console.WriteLine("Enter side values:");
            try
            {
                Console.WriteLine("Input \'a\' size:");
                a = int.Parse(Console.ReadLine());
                Console.WriteLine("Input \'b\' size:");
                b = int.Parse(Console.ReadLine());
            }
            catch
            {
                Console.WriteLine("Invalid argument");
                return;
            }
            if (a > 0 && b > 0)
                Console.WriteLine("Area: " + a * b);
            else
                Console.WriteLine("Use only positive numbers");
        }
    }
}
