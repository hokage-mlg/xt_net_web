using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1
{
    class Task13
    {
        public static void AnotherTriangle()
        {
            Console.WriteLine("Input number of lines:");
            if (int.TryParse(Console.ReadLine(), out var n) && n > 0)
            {
                for (var i = 1; i <= n; i++)
                {
                    for (var j = 1; j <= n - i; j++)
                        Console.Write(" ");
                    for (var r = 1; r <= i; r++)
                        Console.Write("*");
                    for (var l = i - 1; l >= 1; l--)
                        Console.Write("*");
                    Console.WriteLine();
                }
            }
            else
                throw new ArgumentException("Invalid argument. Use only positive numbers");
        }
    }
}
