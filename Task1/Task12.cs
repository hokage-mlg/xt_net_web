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
            int n = int.Parse(Console.ReadLine());
            for (string i = "*"; i.Length <= n; i += "*")
            {
                Console.WriteLine(i);
            }
        }
    }
}
