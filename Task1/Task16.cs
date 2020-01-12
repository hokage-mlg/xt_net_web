using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1
{
    class Task16
    {
        public static void FontAdjustment()
        {
            var currentStyle = new FontStyle();
            byte input;
            do
            {
                Console.WriteLine("Параметры надписи: " + currentStyle);
                Console.WriteLine("Введите:");
                Console.WriteLine("\t1: bold");
                Console.WriteLine("\t2: italic");
                Console.WriteLine("\t3: underline");
                Console.WriteLine("\t0: exit");
                if (Byte.TryParse(Console.ReadLine(), out input))
                {
                    if (input > 3)
                    {
                        Console.WriteLine("Incorrect number");
                        continue;
                    }
                    if (currentStyle.HasFlag((FontStyle)Math.Pow(2, input - 1)))
                        currentStyle ^= (FontStyle)Math.Pow(2, input - 1);
                    else
                        currentStyle ^= (FontStyle)Math.Pow(2, input - 1);
                }
                else
                    Console.WriteLine("Error");
            }
            while (input != 0);
        }
        [Flags]
        public enum FontStyle : byte
        {
            None = 0,
            Bold = 1,
            Italic = 2,
            Underline = 4
        }
    }
}
