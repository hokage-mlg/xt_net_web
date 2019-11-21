using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1
{
    class Task19
    {
        public static void NonNegativeSum()
        {
            Console.WriteLine("Enter the dimension:");
            int n = int.Parse(Console.ReadLine());
            int[] nums = new int[n];
            Random rnd = new Random();
            for (int i = 0; i < n; i++)
                nums[i] = rnd.Next(-50, 50);
            Console.WriteLine("Default array:");
            WriteArray(nums);
            SumArray(nums);
        }
        public static void WriteArray(int[] arr)
        {
            foreach (int i in arr)
                Console.Write(i.ToString() + " ");
            Console.WriteLine();
        }
        public static void SumArray(int[] arr)
        {
            int sum = 0;
            foreach (int i in arr)
                if (i > 0)
                    sum += i;
            Console.WriteLine("Sum: " + sum);
        }
    }
}
