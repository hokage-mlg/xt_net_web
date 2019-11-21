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
            int n = int.Parse(Console.ReadLine());
            int[,,] nums = new int[n, n, n];
            FillUpArray(nums);
            Console.WriteLine("Default array:");
            WriteArray(nums);
            ZeroSwitch(nums);
            Console.WriteLine("Transformed array:");
            WriteArray(nums);
        }
        public static void FillUpArray(int[,,] arr)
        {
            Random rnd = new Random();
            for (int i = 0; i < arr.GetLength(0); i++)
                for (int j = 0; j < arr.GetLength(1); j++)
                    for (int k = 0; k < arr.GetLength(2); k++)
                        arr[i, j, k] = rnd.Next(-50, 50);
        }
        public static void WriteArray(int[,,] arr)
        {
            for (int i = 0; i < arr.GetLength(0); i++)
            {
                Console.Write("Array #{0}: \n", i + 1);
                for (int j = 0; j < arr.GetLength(1); j++)
                {
                    for (int k = 0; k < arr.GetLength(2); k++)
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
            for (int i = 0; i < arr.GetLength(0); i++)
                for (int j = 0; j < arr.GetLength(1); j++)
                    for (int k = 0; k < arr.GetLength(2); k++)
                        if (arr[i, j, k] < 0)
                            arr[i, j, k] = 0;
        }
    }
}
