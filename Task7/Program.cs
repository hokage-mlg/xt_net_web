using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task7
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("TASK 07");
            int select;
            do
            {
                Console.Clear();
                Console.WriteLine("Select the number of a task:");
                Console.WriteLine("1. DATE EXISTANCE.");
                Console.WriteLine("2. HTML REPLACER.");
                Console.WriteLine("3. EMAIL FINDER.");
                Console.WriteLine("4. NUMBER VALIDATOR.");
                Console.WriteLine("5. TIME COUNTER.");
                Console.WriteLine("0. Exit.");
                if (int.TryParse(Console.ReadLine(), out select))
                {
                    switch (select)
                    {
                        case 1:
                            Console.Clear();
                            Console.WriteLine("Task 7.1 DATE EXISTANCE:");
                            DateExistance71.DateExistance();
                            Console.ReadKey();
                            break;
                        case 2:
                            Console.Clear();
                            Console.WriteLine("Task 7.2 HTML REPLACER:");
                            HtmlReplacer72.HtmlReplacer();
                            Console.ReadKey();
                            break;
                        case 3:
                            Console.Clear();
                            Console.WriteLine("Task 7.3 EMAIL FINDER:");
                            EmailFinder73.EmailFinder();
                            Console.ReadKey();
                            break;
                        case 4:
                            Console.Clear();
                            Console.WriteLine("Task 7.4 NUMBER VALIDATOR:");
                            NumberValidator74.NumberValidator();
                            Console.ReadKey();
                            break;
                        case 5:
                            Console.Clear();
                            Console.WriteLine("Task 7.5 TIME COUNTER:");
                            TimeCounter75.TimeCounter();
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
