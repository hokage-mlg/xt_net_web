using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task4
{
    static class ToIntOrNotToInt45
    {
        public static void ToIntOrNotToInt()
        {
            Console.WriteLine("Input number:");
            string str = Console.ReadLine().Trim();
            Console.WriteLine("It's positive int: {0}", str.CheckInt());
        }
        public static bool CheckInt(this string value)
        {
            if (value == null || value.Length == 0)
                return false;
            string str = value.Trim();
            if (str.Length == 0)
                return false;
            if (str.Length == 1 && str[0] == '0')
                return false;
            foreach (var i in str)
                if (!char.IsDigit(i))
                    return false;
            return true;
        }
    }
}
