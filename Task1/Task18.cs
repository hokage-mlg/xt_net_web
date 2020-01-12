using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1
{
    class Task18
    {
        public static void NoPositive()
        {
            Console.WriteLine("Enter the dimension:");
            if (int.TryParse(Console.ReadLine(), out var n) && n > 0)
            {
                var nums = new int[n, n, n];
                FillUpArray(nums);
                Console.WriteLine("Default array:");
                WriteArray(nums);
                ZeroSwitch(nums);
                Console.WriteLine("Transformed array:");
                WriteArray(nums);
            }
            else
                throw new ArgumentException("Invalid argument. Use only positive numbers");
        }
        public static void FillUpArray(int[,,] arr)
        {
            var rnd = new Random();
            for (var i = 0; i < arr.GetLength(0); i++)
                for (var j = 0; j < arr.GetLength(1); j++)
                    for (var k = 0; k < arr.GetLength(2); k++)
                        arr[i, j, k] = rnd.Next(-50, 50);
        }
        public static void WriteArray(int[,,] arr)
        {
            for (var i = 0; i < arr.GetLength(0); i++)
            {
                Console.Write($"Array #{i + 1}:\n");
                for (var j = 0; j < arr.GetLength(1); j++)
                {
                    for (var k = 0; k < arr.GetLength(2); k++)
                    {
                        Console.Write(arr[i, j, k]);
                        Console.Write(" ");
                    }
                    Console.WriteLine();
                }
                Console.WriteLine();
            }
        }
        public static void ZeroSwitch(int[,,] arr)
        {
            for (var i = 0; i < arr.GetLength(0); i++)
                for (var j = 0; j < arr.GetLength(1); j++)
                    for (var k = 0; k < arr.GetLength(2); k++)
                        if (arr[i, j, k] > 0)
                            arr[i, j, k] = 0;
        }
    }
}
