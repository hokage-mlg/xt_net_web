using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1
{
    class Task12
    {
        public static void Triangle()
        {
            Console.WriteLine("Input number of lines:");
            if (int.TryParse(Console.ReadLine(), out var n) && n > 0)
                for (var i = "*"; i.Length <= n; i += "*")
                    Console.WriteLine(i);
            else
                throw new ArgumentException("Invalid argument. Use only positive numbers");
        }
    }
}
