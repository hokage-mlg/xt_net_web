using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1
{
    class Task112
    {
        public static void CharDoubler()
        {
            Console.WriteLine("Input first line:");
            var str1 = Console.ReadLine();
            Console.WriteLine("Input second line:");
            var str2 = Console.ReadLine();
            var strRes = "";
            foreach (var ch in str1)
                if (!str2.Contains(ch))
                    strRes += ch;
                else
                {
                    strRes += ch;
                    strRes += ch;
                }
            Console.WriteLine($"Result: {strRes}\n");
        }
    }
}
