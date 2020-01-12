using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Task7
{
    class EmailFinder73
    {
        public static void EmailFinder()
        {
            Console.WriteLine("Input text:");
            var str = Console.ReadLine();
            var filter = @"[a-z0-9]+([_\.\-][a-z0-9]+)*@[a-z0-9]+([\.\-][a-z0-9]+)*\.[a-z]{2,6}";
            var regex = new Regex(filter, RegexOptions.Compiled);
            var result = regex.Matches(str);
            if (result.Count > 0)
            {
                Console.WriteLine("Email addresses found in text:");
                foreach (Match item in result)
                    Console.WriteLine(item.Value);
            }
            else
                Console.WriteLine("This text does not contains valid emails.");
        }
    }
}
