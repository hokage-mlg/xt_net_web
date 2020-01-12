using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Task7
{
    class NumberValidator74
    {
        public static void NumberValidator()
        {
            Console.WriteLine("Input a number:");
            var str = Console.ReadLine();
            if (IsScientificNotation(str))
                Console.WriteLine("Scientific notation");
            else if (IsRegularNotation(str))
                Console.WriteLine("Regular notation");
            else
                Console.WriteLine("Not a number");
        }
        public static bool IsRegularNotation(string str)
        {
            var filter = @"^([+|-]?\d+)(.\d*)?$";
            var regex = new Regex(filter, RegexOptions.Compiled);
            return regex.IsMatch(str);
        }
        public static bool IsScientificNotation(string str)
        {
            var filter = @"\b-?[1-9](?:\.\d+)?[Ee][-+]?\d+\b";
            var regex = new Regex(filter, RegexOptions.Compiled);
            return regex.IsMatch(str);
        }
    }
}
