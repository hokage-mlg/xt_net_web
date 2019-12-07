using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("TASK 03");
            int select;
            do
            {
                Console.Clear();
                Console.WriteLine("Select the number of a task:");
                Console.WriteLine("1. LOST.");
                Console.WriteLine("2. WORD FREQUENCY.");
                Console.WriteLine("3. DYNAMIC ARRAY.");
                Console.WriteLine("4. DYNAMIC ARRAY (HARDCORE MODE).");
                Console.WriteLine("0. Exit.");
                if (int.TryParse(Console.ReadLine(), out select))
                {
                    switch (select)
                    {
                        case 1:
                            Console.Clear();
                            Console.WriteLine("Task 3.1 LOST:");
                            Lost31 lost = new Lost31();
                            lost.Lost();
                            Console.ReadKey();
                            break;
                        case 2:
                            Console.Clear();
                            Console.WriteLine("Task 3.2 WORD FREQUENCY:");
                            WordFrequency32 str = new WordFrequency32();
                            str.WordFrequency();
                            Console.ReadKey();
                            break;
                        case 3:
                            Console.Clear();
                            Console.WriteLine("Task 3.3 DYNAMIC ARRAY:");
                            DynamicArr33<int>.DynamicArrDisplay();
                            Console.ReadKey();
                            break;
                        case 4:
                            Console.Clear();
                            Console.WriteLine("Task 3.4 DYNAMIC ARRAY (HARDCORE MODE):");
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
