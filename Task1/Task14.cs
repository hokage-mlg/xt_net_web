using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1
{
    class Task14
    {
        public static void Xmas()
        {
            Console.WriteLine("Input number of triangles:");
            if (int.TryParse(Console.ReadLine(), out var n) && n > 0)
            {
                for (var i = 1; i <= n; i++)
                {
                    for (var j = 0; j < i; j++)
                    {
                        var branch = new String('*', j);
                        Console.WriteLine(branch.PadLeft(n) + "*" + branch);
                    }
                }
            }
            else
                throw new ArgumentException("Invalid argument. Use only positive numbers");
        }
    }
}
