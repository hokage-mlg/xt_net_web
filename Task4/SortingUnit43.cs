using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Task4
{
    class SortingUnit43
    {
        private static int _threadNumber = 0;
        public static event Action<string> OnSortFinish = delegate { };
        public static void SortingUnit()
        {
            int length = 100;
            int threads = 0;
            var rnd = new Random();
            var arrInt = new int[length];
            var arrDouble = new double[length];
            OnSortFinish += (element) =>
            {
                Console.WriteLine(element);
                threads++;
            };
            for (int i = 0; i < length; i++)
            {
                arrInt[i] = rnd.Next(0, 50);
                arrDouble[i] = rnd.NextDouble() * 10;
            }
            SortThread(arrInt, (a, b) => a < b);
            SortThread(arrDouble, (a, b) => a > b);
            while (threads != 2)
            {
                Console.WriteLine("Sorting...");
                Thread.Sleep(1000);
                Thread.Sleep(1000);
            }
            Console.WriteLine("Elements in ascending sorted int array");
            CustomSort41.DisplayArray(arrInt);
            Console.WriteLine();
            Console.WriteLine("Elements in descending sorted double array");
            CustomSort41.DisplayArray(arrDouble);
        }
        public static void SortThread<T>(T[] arr, Func<T, T, bool> ordering)
        {
            var threadNumber = ++_threadNumber;
            new Thread(() =>
            {
                CustomSort41.SortArray(arr, ordering);
                OnSortFinish?.Invoke($"Sorting done in {threadNumber} thread");
            }).Start();
        }
    }
}
