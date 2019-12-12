using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task4
{
    static class NumberArraySum44
    {
        public static void NumberArraySum()
        {
            int length = 10;
            var rnd = new Random();
            Console.WriteLine("Sum of int array demonstration:");
            var arrInt = new int[length];
            for (int i = 0; i < arrInt.Length; i++)
                arrInt[i] = rnd.Next(0, 50);
            Console.WriteLine("Int array:");
            CustomSort41.DisplayArray(arrInt);
            Console.WriteLine();
            Console.WriteLine("Sum: {0}", arrInt.Sum());
            Console.WriteLine("Sum of double array demonstration:");
            var arrDouble = new double[length];
            for (int i = 0; i < arrDouble.Length; i++)
                arrDouble[i] = rnd.NextDouble() * 10;
            Console.WriteLine("Double array:");
            CustomSort41.DisplayArray(arrDouble);
            Console.WriteLine();
            Console.WriteLine("Sum: {0:0.#}  ", arrDouble.Sum());
        }
        public static T Sum<T>(this T[] arr, Func<T, T, T> cmplx)
        {
            T sum = default;
            foreach (var i in arr)
                sum = cmplx(sum, i);
            return sum;
        }
    }
}
