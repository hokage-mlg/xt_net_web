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
            string str1 = Console.ReadLine();
            Console.WriteLine("Input second line:");
            string str2 = Console.ReadLine();
            string strRes = "";
            foreach (char ch in str1)
                if (!str2.Contains(ch))
                    strRes += ch;
                else
                {
                    strRes += ch;
                    strRes += ch;
                }
            Console.WriteLine("Result:\n" + strRes);
            Console.ReadKey();
        }
    }
}
