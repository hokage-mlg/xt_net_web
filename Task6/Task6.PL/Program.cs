using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task6.PL
{
    class Program
    {
        static void Main(string[] args)
        {
            Run();
        }
        private static void Run()
        {
            while (true)
            {
                ConsoleDisplay.MenuDisplay();
                if (!int.TryParse(Console.ReadLine(), out int input))
                {
                    Console.WriteLine("Incorrect input. Try again!");
                    continue;
                }
                switch (input)
                {
                    case 1:
                        {
                            ChoiceMode.UserMode();
                            break;
                        }
                    case 2:
                        {
                            ChoiceMode.AwardMode();
                            break;
                        }
                    case 0:
                        break;
                    default:
                        break;
                }
                if (input == 0)
                    break;
            }
        }
    }
}
