using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Task7
{
    class HtmlReplacer72
    {
        public static void HtmlReplacer()
        {
            Console.WriteLine("Input text:");
            var str = Console.ReadLine();
            var filter = @"<\/?[\w\s]*>|<.+[\W]>";
            var target = "_";
            var regex = new Regex(filter, RegexOptions.Compiled);
            var result = regex.Replace(str, target);
            Console.WriteLine($"Result:\n{result}");
        }
    }
}
