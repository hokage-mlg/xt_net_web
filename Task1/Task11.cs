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
            Console.WriteLine("Enter side values (\'a\' and \'b\'):");
            if (int.TryParse(Console.ReadLine(), out var a)
                && int.TryParse(Console.ReadLine(), out var b)
                && a > 0
                && b > 0)
                Console.WriteLine($"Area: {a * b}");
            else
                throw new ArgumentException("Invalid argument. Use only positive numbers");
        }
    }
}
