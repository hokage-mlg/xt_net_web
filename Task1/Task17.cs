using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1
{
    class Task17
    {
        public static void ArrayProcessing()
        {
            Console.WriteLine("Enter the dimension:");
            if (int.TryParse(Console.ReadLine(), out var n) && n > 0)
            {
                var nums = new int[n];
                var rnd = new Random();
                for (var i = 0; i < n; i++)
                    nums[i] = rnd.Next(0, 100);
                Console.WriteLine("Default array:");
                WriteArray(nums);
                FindMin(nums);
                FindMax(nums);
                Console.WriteLine("Sorted array:");
                SortArray(nums);
                WriteArray(nums);
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
        public static int[] SortArray(int[] nums)
        {
            for (var i = 0; i < nums.Length - 1; i++)
            {
                for (var j = i + 1; j < nums.Length; j++)
                {
                    if (nums[i] > nums[j])
                    {
                        var temp = nums[i];
                        nums[i] = nums[j];
                        nums[j] = temp;
                    }
                }
            }
            return nums;
        }
        public static void FindMin(int[] nums)
        {
            var min = nums[0];
            for (var i = 0; i < nums.Length; i++)
                if (min > nums[i])
                    min = nums[i];
            Console.WriteLine($"Min: {min}");
        }
        public static void FindMax(int[] nums)
        {
            var max = nums[0];
            for (var i = 0; i < nums.Length; i++)
                if (max < nums[i])
                    max = nums[i];
            Console.WriteLine($"Max: {max}");
        }
    }
}
