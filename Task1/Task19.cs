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
            if (int.TryParse(Console.ReadLine(), out var n) && n > 0)
            {
                var nums = new int[n];
                var rnd = new Random();
                for (var i = 0; i < n; i++)
                    nums[i] = rnd.Next(-50, 50);
                Console.WriteLine("Default array:");
                WriteArray(nums);
                SumArray(nums);
            }
            else
                throw new ArgumentException("Invalid argument. Use only positive numbers");
        }
        public static void WriteArray(int[] arr)
        {
            foreach (var i in arr)
                Console.Write(i.ToString() + " ");
            Console.WriteLine();
        }
        public static void SumArray(int[] arr)
        {
            var sum = 0;
            foreach (var i in arr)
                if (i > 0)
                    sum += i;
            Console.WriteLine($"Sum: {sum}");
        }
    }
}
