using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("TASK 01");
            int select;
            do
            {
                Console.Clear();
                Console.WriteLine("Select the number of a task:");
                Console.WriteLine("1. RECTANGLE.");
                Console.WriteLine("2. TRIANGLE.");
                Console.WriteLine("3. ANOTHER TRIANGLE.");
                Console.WriteLine("4. X-MAS TREE.");
                Console.WriteLine("5. SUM OF NUMBERS.");
                Console.WriteLine("6. FONT ADJUSTMENT.");
                Console.WriteLine("7. ARRAY PROCESSING.");
                Console.WriteLine("8. NO POSITIVE.");
                Console.WriteLine("9. NON-NEGATIVE SUM.");
                Console.WriteLine("10. 2D ARRAY.");
                Console.WriteLine("11. Average String Length.");
                Console.WriteLine("12. Char Doubler.");
                Console.WriteLine("0. Exit.");
                if (int.TryParse(Console.ReadLine(), out select))
                {
                    switch (select)
                    {
                        case 1:
                            Console.Clear();
                            Console.WriteLine("Task 1.1 RECTANGLE:");
                            Task11.Rectangle();
                            Console.ReadKey();
                            break;
                        case 2:
                            Console.Clear();
                            Console.WriteLine("Task 1.2 TRIANGLE:");
                            Task12.Triangle();
                            Console.ReadKey();
                            break;
                        case 3:
                            Console.Clear();
                            Console.WriteLine("Task 1.3 ANOTHER TRIANGLE:");
                            Task13.AnotherTriangle();
                            Console.ReadKey();
                            break;
                        case 4:
                            Console.Clear();
                            Console.WriteLine("Task 1.4 X-MAS TREE:");
                            Task14.Xmas();
                            Console.ReadKey();
                            break;
                        case 5:
                            Console.Clear();
                            Console.WriteLine("Task 1.5 SUM OF NUMBERS:");
                            Task15.SumOfNumbers();
                            Console.ReadKey();
                            break;
                        case 6:
                            Console.Clear();
                            Console.WriteLine("Task 1.6 FONT ADJUSTMENT:");
                            Task16.FontAdjustment();
                            Console.ReadKey();
                            break;
                        case 7:
                            Console.Clear();
                            Console.WriteLine("Task 1.7 ARRAY PROCESSING:");
                            Task17.ArrayProcessing();
                            Console.ReadKey();
                            break;
                        case 8:
                            Console.Clear();
                            Console.WriteLine("Task 1.8 NO POSITIVE:");
                            Task18.NoPositive();
                            Console.ReadKey();
                            break;
                        case 9:
                            Console.Clear();
                            Console.WriteLine("Task 1.9 NON-NEGATIVE SUM:");
                            Task19.NonNegativeSum();
                            Console.ReadKey();
                            break;
                        case 10:
                            Console.Clear();
                            Console.WriteLine("Task 1.10 2D ARRAY:");
                            Task110.Array2D();
                            Console.ReadKey();
                            break;
                        case 11:
                            Console.Clear();
                            Console.WriteLine("Task 1.11 AVERAGE STRING LENGTH:");
                            Task111.AverageStringLength();
                            Console.ReadKey();
                            break;
                        case 12:
                            Console.Clear();
                            Console.WriteLine("Task 1.12 CHAR DOUBLER:");
                            Task112.CharDoubler();
                            Console.ReadKey();
                            break;
                        case 0:
                            break;
                        default:
                            Console.WriteLine("Wrong number!");
                            Console.ReadKey();
                            break;
                    }
                }
                else
                {
                    select = -1;
                    Console.WriteLine("Invalid input!");
                    Console.ReadKey();
                }
            }
            while (select != 0);
        }
    }
}
