using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3
{
    class WordFrequency32
    {
        public void WordFrequency()
        {
            Console.WriteLine("Input text:");
            string str = Console.ReadLine();
            Dictionary<string, int> uStr = UniqueWords(str);
            Console.WriteLine("Number of unique words: {0}", uStr.Count);
            foreach (var u in uStr)
                Console.WriteLine("Word - {0} appears in text {1} times", u.Key, u.Value);
        }
        private static Dictionary<string, int> UniqueWords(string str)
        {
            str = str.ToLower();
            var words = str.Split(new char[] { ' ', '.' }, StringSplitOptions.RemoveEmptyEntries);
            Dictionary<string, int> res = new Dictionary<string, int>();
            foreach (var w in words)
            {
                if (res.ContainsKey(w))
                    res[w]++;
                else
                    res.Add(w, 1);
            }
            return res;
        }
    }
}
