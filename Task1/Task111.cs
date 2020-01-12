using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1
{
    class Task111
    {
        public static void AverageStringLength()
        {
            Console.WriteLine("Input text:");
            var str = Console.ReadLine();
            var alp = str.ToHashSet();
            var sep = new HashSet<char>();
            var pun = new HashSet<char>();
            foreach (var c in alp)
            {
                if (char.IsSeparator(c))
                    sep.Add(c);
                else if (char.IsPunctuation(c))
                    pun.Add(c);
            }
            string[] words = str.Split(sep.ToArray());
            FindAvrLen(words, pun);
        }
        public static void FindAvrLen(string[] words, HashSet<char> pun, int wordsLen = 0)
        {
            for (var i = 0; i < words.Length; i++)
            {
                words[i] = words[i].Trim(pun.ToArray());
                wordsLen += words[i].Length;
            }
            var avrLen = (double)wordsLen / words.Length;
            Console.WriteLine($"Average word length is {avrLen}");
        }
    }
}
