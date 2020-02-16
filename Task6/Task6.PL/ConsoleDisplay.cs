using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task6.PL
{
    public class ConsoleDisplay
    {
        public static void MenuDisplay()
        {
            Console.Clear();
            Console.WriteLine("Task 6.");
            Console.WriteLine("Select mode:");
            Console.WriteLine("1. Users mode.");
            Console.WriteLine("2. Awards mode.");
            Console.WriteLine("0. Exit.");
        }
        public static void UserMenuDisplay()
        {
            Console.Clear();
            Console.WriteLine("User select mode.");
            Console.WriteLine("1. Add user.");
            Console.WriteLine("2. Show user by ID.");
            Console.WriteLine("3. Show all users.");
            Console.WriteLine("4. Delete user by ID.");
            Console.WriteLine("5. Reward user.");
            Console.WriteLine("6. Take award from user.");
            Console.WriteLine("0. Exit.");
        }
        public static void AwardMenuDisplay()
        {
            Console.Clear();
            Console.WriteLine("Award select mode.");
            Console.WriteLine("1. Add award.");
            Console.WriteLine("2. Show award by ID.");
            Console.WriteLine("3. Show all awards.");
            Console.WriteLine("0. Exit.");
        }
    }
}
