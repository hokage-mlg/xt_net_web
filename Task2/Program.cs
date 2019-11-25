using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("TASK 02");
            int select;
            do
            {
                Console.Clear();
                Console.WriteLine("Select the number of a task:");
                Console.WriteLine("1. ROUND.");
                Console.WriteLine("2. TRIANGLE.");
                Console.WriteLine("3. USER.");
                Console.WriteLine("4. MY STRING.");
                Console.WriteLine("5. EMPLOYEE.");
                Console.WriteLine("6. RING.");
                Console.WriteLine("7. VECTOR GRAPHICS EDITOR.");
                Console.WriteLine("8. GAME.");
                Console.WriteLine("0. Exit.");
                if (int.TryParse(Console.ReadLine(), out select))
                {
                    switch (select)
                    {
                        case 1:
                            Console.Clear();
                            Console.WriteLine("Task 2.1 ROUND:");
                            Round21 round1 = new Round21();
                            Console.WriteLine(round1.ToString());
                            Console.ReadKey();
                            break;
                        case 2:
                            Console.Clear();
                            Console.WriteLine("Task 2.2 TRIANGLE:");
                            Triangle22 triangle1 = new Triangle22();
                            Console.WriteLine(triangle1.ToString());
                            Console.ReadKey();
                            break;
                        case 3:
                            Console.Clear();
                            Console.WriteLine("Task 2.3 USER:");
                            User23 user1 = new User23();
                            Console.WriteLine(user1.ToString());
                            Console.ReadKey();
                            break;
                        case 4:
                            Console.Clear();
                            Console.WriteLine("Task 2.4 MY STRING:");

                            Console.ReadKey();
                            break;
                        case 5:
                            Console.Clear();
                            Console.WriteLine("Task 2.5 EMPLOYEE:");

                            Console.ReadKey();
                            break;
                        case 6:
                            Console.Clear();
                            Console.WriteLine("Task 2.6 RING:");

                            Console.ReadKey();
                            break;
                        case 7:
                            Console.Clear();
                            Console.WriteLine("Task 2.7 VECTOR GRAPHICS EDITOR:");

                            Console.ReadKey();
                            break;
                        case 8:
                            Console.Clear();
                            Console.WriteLine("Task 2.8 GAME:");

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
