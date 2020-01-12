using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1
{
    class Task110
    {
        public static void Array2D()
        {
            Console.WriteLine("Enter the dimension:");
            if (int.TryParse(Console.ReadLine(), out var n) && n > 0)
            {
                int[,] nums = new int[n, n];
                FillUpArray(nums);
                Console.WriteLine("Default array:");
                WriteArray(nums);
                SumArray(nums);
            }
            else
                throw new ArgumentException("Invalid argument. Use only positive numbers");
        }
        public static void FillUpArray(int[,] arr)
        {
            var rnd = new Random();
            for (var i = 0; i < arr.GetLength(0); i++)
                for (var j = 0; j < arr.GetLength(1); j++)
                    arr[i, j] = rnd.Next(0, 50);
        }
        public static void WriteArray(int[,] arr)
        {
            for (var i = 0; i < arr.GetLength(0); i++)
            {
                for (var j = 0; j < arr.GetLength(1); j++)
                    Console.Write("{0,3}", arr[i, j]);
                Console.WriteLine();
            }
        }
        public static void SumArray(int[,] arr)
        {
            var sum = 0;
            for (var i = 0; i < arr.GetLength(0); i++)
                for (var j = 0; j < arr.GetLength(1); j++)
                    if ((i + j) % 2 == 0)
                        sum += arr[i, j];
            Console.WriteLine($"Sum: {sum}");
        }
    }
}
