using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1
{
    class Task15
    {
        public static void SumOfNumbers()
        {
            int sum = 0;
            int lim = 1000;
            for (int i = 0; i < lim; i++)
            {
                if (i % 3 == 0 || i % 5 == 0)
                {
                    sum += i;
                }
            }
            Console.WriteLine("Sum: " + sum);
        }
    }
}
