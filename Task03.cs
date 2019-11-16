using System;
using System.Collections.Generic;
using System.Text;

namespace Tasks0
{
    class Task03
    {
        public static void Square(int n)
        {
            double enter = n / 2 + 1;
            for (int row = 1; row <= n; row++)
            {
                for (int col = 1; col <= n; col++)
                {
                    if (row == enter && col == enter) Console.Write(" ");
                    else
                        Console.Write("*");
                }
                Console.WriteLine();
            }
        }
    }
}
