using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task4
{
    class CustomSort41
    {
        public static void CustomSort()
        {
            var length = 10;
            var rnd = new Random();
            var arrInt = new int[length];
            var arrDouble = new double[length];
            Console.WriteLine("Int Array:");
            for (int i = 0; i < length; i++)
                arrInt[i] = rnd.Next(0, 50);
            DisplayArray(arrInt);
            Console.WriteLine();
            Console.WriteLine("Sort ascending:");
            SortArray(arrInt, (a, b) => a < b);
            DisplayArray(arrInt);
            Console.WriteLine();
            Console.WriteLine("Sort descending:");
            SortArray(arrInt, (a, b) => a > b);
            DisplayArray(arrInt);
            Console.WriteLine();
            Console.WriteLine("Double array:");
            for (int i = 0; i < length; i++)
                arrDouble[i] = rnd.NextDouble() * 10;
            DisplayArray(arrDouble);
            Console.WriteLine();
            Console.WriteLine("Sort ascending:");
            SortArray(arrDouble, (a, b) => a < b);
            DisplayArray(arrDouble);
            Console.WriteLine();
            Console.WriteLine("Sort descending:");
            SortArray(arrDouble, (a, b) => a > b);
            DisplayArray(arrDouble);
        }
        public static void DisplayArray<T>(T[] arr) where T : notnull
        {
            for (int i = 0; i < arr.Length; i++)
                Console.Write("{0:0.#}  ", arr[i]);
        }
        public static void SortArray<T>(T[] arr, Func<T, T, bool> ordering) where T : notnull
        {
            if (arr == null || ordering == null)
                throw new ArgumentException("Check arguments");
            for (int i = 0; i < arr.Length - 1; i++)
            {
                int swap = i;
                for (int j = i; j < arr.Length; j++)
                    if (ordering(arr[j], arr[swap]))
                        swap = j;
                if (swap != i)
                    Switch<T>(ref arr[i], ref arr[swap]);
            }
        }
        public static void Switch<T>(ref T n1, ref T n2) where T : notnull
        {
            T tmp = n1;
            n1 = n2;
            n2 = tmp;
        }
    }
}
