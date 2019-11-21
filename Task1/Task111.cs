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
            string str = Console.ReadLine();
            HashSet<char> alp = str.ToHashSet();
            HashSet<char> sep = new HashSet<char>();
            HashSet<char> pun = new HashSet<char>();
            foreach (char c in alp)
            {
                if (Char.IsSeparator(c))
                    sep.Add(c);
                else if (Char.IsPunctuation(c))
                    pun.Add(c);
            }
            string[] words = str.Split(sep.ToArray());
            FindAvrLen(words, pun);
        }
        public static void FindAvrLen(string[] words, HashSet<char> pun, int wordsLen = 0)
        {
            for (int i = 0; i < words.Length; i++)
            {
                words[i] = words[i].Trim(pun.ToArray());
                wordsLen += words[i].Length;
            }
            double avrLen = (double)wordsLen / words.Length;
            Console.WriteLine("Average word length is " + avrLen);
        }
    }
}
