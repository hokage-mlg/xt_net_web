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
                            Round21 round = Round21.InputRound();
                            Console.WriteLine(round.ToString());
                            Console.ReadKey();
                            break;
                        case 2:
                            Console.Clear();
                            Console.WriteLine("Task 2.2 TRIANGLE:");
                            Triangle22 triangle = Triangle22.InputTriangle();
                            Console.WriteLine(triangle.ToString());
                            Console.ReadKey();
                            break;
                        case 3:
                            Console.Clear();
                            Console.WriteLine("Task 2.3 USER:");
                            User23 user = User23.InputUser();
                            Console.WriteLine(user.ToString());
                            Console.ReadKey();
                            break;
                        case 4:
                            Console.Clear();
                            Console.WriteLine("Task 2.4 MY STRING:");
                            Console.WriteLine("Input string:");
                            string myStr = Console.ReadLine();
                            MyString24 str = new MyString24(myStr);
                            Console.WriteLine("Input substring:");
                            string subStr = Console.ReadLine();
                            str.MyStringDisplay(subStr);
                            Console.ReadKey();
                            break;
                        case 5:
                            Console.Clear();
                            Console.WriteLine("Task 2.5 EMPLOYEE:");
                            Employee25 employee = Employee25.InputEmployee();
                            Console.WriteLine(employee.ToString());
                            Console.ReadKey();
                            break;
                        case 6:
                            Console.Clear();
                            Console.WriteLine("Task 2.6 RING:");
                            Ring26 ring = Ring26.InputRing();
                            Console.WriteLine(ring.ToString());
                            Console.ReadKey();
                            break;
                        case 7:
                            Console.Clear();
                            Console.WriteLine("Task 2.7 VECTOR GRAPHICS EDITOR:");
                            VectorGraphEdit27.VectorGraphEdit27 editor = new VectorGraphEdit27.VectorGraphEdit27();
                            editor.CreateFigure();
                            Console.ReadKey();
                            break;
                        case 8:
                            Console.Clear();
                            Console.WriteLine("Task 2.8 GAME:");
                            Game28.Game28 game = new Game28.Game28();
                            game.GameDisplay();
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
