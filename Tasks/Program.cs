using System;
using System.Collections.Generic;
using System.Text;
using TasksVasin;

namespace Tasks0
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Task 0.1 SEQUENCE:");
            Console.WriteLine("Enter sequence border:");
            int border = int.Parse(Console.ReadLine());
            Task01.SequenceDisplay(border);

            Console.WriteLine("Task 0.2 SEQUENCE:");
            Console.WriteLine("Enter number to check:");
            int num = int.Parse(Console.ReadLine());
            Task02.isPrimeDisplay(num);

            Console.WriteLine("Task 0.3 SQUARE:");
            Console.WriteLine("Enter square size:");
            int sqSize = int.Parse(Console.ReadLine());
            Task03.Square(sqSize);

            Console.WriteLine("Task 0.4(0.5) ARRAY:");
            Console.WriteLine("Enter number of arrays:");
            int numArr = int.Parse(Console.ReadLine());
            Task04.ArrayDisplay(numArr);
        }
    }
}
