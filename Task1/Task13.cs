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
            int n = int.Parse(Console.ReadLine());
            for (int i = 1; i <= n; i++)
            {
                for (int j = 1; j <= n - i; j++)
                {
                    Console.Write(" ");
                }
                for (int r = 1; r <= i; r++)
                {
                    Console.Write("*");
                }
                for (int l = i - 1; l >= 1; l--)
                {
                    Console.Write("*");
                }
                Console.WriteLine();
            }
        }
    }
}
