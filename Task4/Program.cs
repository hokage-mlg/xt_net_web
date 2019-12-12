using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task4
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("TASK 04");
            int select;
            do
            {
                Console.Clear();
                Console.WriteLine("Select the number of a task:");
                Console.WriteLine("1. CUSTOM SORT.");
                Console.WriteLine("2. CUSTOM SORT DEMO.");
                Console.WriteLine("3. SORTING UNIT.");
                Console.WriteLine("4. NUMBER ARRAY SUM.");
                Console.WriteLine("5. TO INT OR NOT TO INT?");
                Console.WriteLine("6. I SEEK YOU.");
                Console.WriteLine("0. Exit.");
                if (int.TryParse(Console.ReadLine(), out select))
                {
                    switch (select)
                    {
                        case 1:
                            Console.Clear();
                            Console.WriteLine("Task 4.1 CUSTOM SORT:");
                            CustomSort41.CustomSort();
                            Console.ReadKey();
                            break;
                        case 2:
                            Console.Clear();
                            Console.WriteLine("Task 4.2 CUSTOM SORT DEMO:");
                            CustomSortDemo42.CustomSortDemo();
                            Console.ReadKey();
                            break;
                        case 3:
                            Console.Clear();
                            Console.WriteLine("Task 4.3 SORTING UNIT:");
                            SortingUnit43.SortingUnit();
                            Console.ReadKey();
                            break;
                        case 4:
                            Console.Clear();
                            Console.WriteLine("Task 4.4 NUMBER ARRAY SUM:");
                            NumberArraySum44.NumberArraySum();
                            Console.ReadKey();
                            break;
                        case 5:
                            Console.Clear();
                            Console.WriteLine("Task 4.5 TO INT OR NOT TO INT?:");
                            ToIntOrNotToInt45.ToIntOrNotToInt();
                            Console.ReadKey();
                            break;
                        case 6:
                            Console.Clear();
                            Console.WriteLine("Task 4.6 I SEEK YOU:");
                            Console.WriteLine("Task is not completed\n" +
                                "Dear trainer,\n" +
                                "I am in my fourth year at university, so the exam time has been shifted to early December. " +
                                "I have to take exams every day, so unfortunately, I did not have enough time for this task." +
                                " After I pass the exams, I will definitely complete it. Please excuse me.\n" +
                                "Yours sincerely,\n" +
                                "Nikita Vasin\n" +
                                "Student");
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
