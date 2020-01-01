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
            string str = Console.ReadLine();
            string filter = @"<\/?[\w\s]*>|<.+[\W]>";
            string target = "_";
            Regex regex = new Regex(filter, RegexOptions.Compiled);
            string result = regex.Replace(str, target);
            Console.WriteLine("Result:");
            Console.WriteLine(result);
        }
    }
}
