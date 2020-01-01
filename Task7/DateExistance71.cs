using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Task7
{
    class DateExistance71
    {
        public static void DateExistance()
        {
            Console.WriteLine("Input text:");
            string str = Console.ReadLine();
            string filter = @"(?:(?:31(-)(?:0?[13578]|1[02]))\1|(?:(?:29|30)(-)(?:0?[1,3-9]|1[0-2])\2))(?:(?:1[6-9]|[2-9]\d)?\d{2})\b|\b(?:29(-)0?2\3(?:(?:(?:1[6-9]|[2-9]\d)?(?:0[48]|[2468][048]|[13579][26])|(?:(?:16|[2468][048]|[3579][26])00))))\b|\b(?:0?[1-9]|1\d|2[0-8])(-)(?:(?:0?[1-9])|(?:1[0-2]))\4(?:(?:1[6-9]|[2-9]\d)?\d{2})";
            Regex regex = new Regex(filter, RegexOptions.Compiled);
            if (regex.IsMatch(str))
                Console.WriteLine($"This text \"{str}\" has date");
            else
                Console.WriteLine($"This text \"{str}\" has no date");
        }
    }
}
