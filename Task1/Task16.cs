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
            Console.WriteLine("Введите:");
            var input = int.Parse(Console.ReadLine());
            FontStyle currentStyle = FontStyle.None;
            switch (input)
            {
                case 1:
                    currentStyle = FontStyle.Bold;
                    break;
                case 2:
                    currentStyle = FontStyle.Italic;
                    break;
                case 3:
                    currentStyle = FontStyle.Underline;
                    break;
                default: 
                    currentStyle = FontStyle.None;
                    break;                   
            }
            Console.WriteLine(currentStyle);
        }
        [Flags]
        public enum FontStyle : byte
        {
            None=0,
            Bold=1,
            Italic=2,
            Underline=3
        }
    }
}
