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
            int n = int.Parse(Console.ReadLine());
            int[,] nums = new int[n, n];
            FillUpArray(nums);
            Console.WriteLine("Default array:");
            WriteArray(nums);
            SumArray(nums);
        }
        public static void FillUpArray(int[,] arr)
        {
            Random rnd = new Random();
            for (int i = 0; i < arr.GetLength(0); i++)
                for (int j = 0; j < arr.GetLength(1); j++)
                    arr[i, j] = rnd.Next(0, 50);
        }
        public static void WriteArray(int[,] arr)
        {
            for (int i = 0; i < arr.GetLength(0); i++)
            {
                for (int j = 0; j < arr.GetLength(1); j++)
                {
                    Console.Write("{0,3}", arr[i, j]);
                }
                Console.WriteLine();
            }
        }
        public static void SumArray(int[,] arr)
        {
            int sum = 0;
            for (int i = 0; i < arr.GetLength(0); i++)
            {
                for (int j = 0; j < arr.GetLength(1); j++)
                {
                    if ((i + j) % 2 == 0)
                        sum += arr[i, j];
                }
            }
            Console.WriteLine("Sum:" + sum);
        }
    }
}
