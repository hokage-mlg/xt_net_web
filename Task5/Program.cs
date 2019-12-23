using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task5
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("TASK 05");
            int select;
            do
            {
                Console.Clear();
                Console.WriteLine("Select the number of a task:");
                Console.WriteLine("1. BACKUP SYSTEM.");
                Console.WriteLine("0. Exit.");
                if (int.TryParse(Console.ReadLine(), out select))
                {
                    switch (select)
                    {
                        case 1:
                            Console.Clear();
                            Console.WriteLine("Task 5.1 BACKUP SYSTEM:");
                            BackupSystem51.BackupSystem();
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
