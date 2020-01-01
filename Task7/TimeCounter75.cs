using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Task7
{
    class TimeCounter75
    {
        public static void TimeCounter()
        {
            Console.WriteLine("Input text:");
            string str = Console.ReadLine();
            string filter = @"\b([0-9]|0[0-9]|1[0-9]|2[0-3]):[0-5][0-9]\b";
            Regex regex = new Regex(filter, RegexOptions.Compiled);
            var result = regex.Matches(str).Count;
            Console.WriteLine($"Time is present in the text {result} times");
        }
    }
}
