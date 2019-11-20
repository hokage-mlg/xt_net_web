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
            int n = int.Parse(Console.ReadLine());
            int[] nums = new int[n];
            Random rnd = new Random();
            for (int i = 0; i < n; i++)
                nums[i] = rnd.Next(0, 100);
            Console.WriteLine("Default array:");
            WriteArray(nums);          
            FindMin(nums);
            FindMax(nums);
            Console.WriteLine("Sorted array:");
            SortArray(nums);
            WriteArray(nums);
        }
        public static void WriteArray(int[] arr)
        {
            foreach (int i in arr)
            {
                Console.Write(i.ToString() + " ");
            }
            Console.WriteLine();
        }
        public static int[] SortArray(int[] nums)
        {
            int temp;
            for (int i = 0; i < nums.Length - 1; i++)
            {
                for (int j = i + 1; j < nums.Length; j++)
                {
                    if (nums[i] > nums[j])
                    {
                        temp = nums[i];
                        nums[i] = nums[j];
                        nums[j] = temp;
                    }
                }
            }
            return nums;
        }
        public static void FindMin(int[] nums)
        {
            int min = nums[0];
            for (int i = 0; i < nums.Length; i++)
            {
                if (min > nums[i])              
                    min = nums[i];               
            }
            Console.WriteLine("Min: "+ min);
        }
        public static void FindMax(int[] nums)
        {
            int max = nums[0];
            for (int i = 0; i < nums.Length; i++)
            {
                if (max < nums[i])             
                    max = nums[i];               
            }
            Console.WriteLine("Max: " + max);
        }
    }
}
