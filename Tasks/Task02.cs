using System;
using System.Collections.Generic;
using System.Text;

namespace Tasks0
{
    class Task02
    {
        public static bool isPrime(int N)
        {
            if (N == 0 || N == 1) return false;
            if (N == 2) return true;
            var lim = Math.Ceiling(Math.Sqrt(N));
            for (int i = 2; i <= lim; i++)
            {
                if (N % i == 0) return false;
            }
            return true;
        }
        public static void isPrimeDisplay(int N)
        {
            if (isPrime(N))
            {
                Console.WriteLine("It is prime\n");
            }
            else
            {
                Console.WriteLine("It is not prime\n");
            }
        }
    }
}
