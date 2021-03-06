﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task4
{
    class CustomSortDemo42
    {
        public static void CustomSortDemo()
        {
            Console.WriteLine("Default text:\n");
            var str = "Lorem ipsum dolor sit amet, consectetur adipiscing elit.\n" +
                "Mauris vel purus aliquet, faucibus nisl quis, sollicitudin lectus.\n" +
                "Nam aliquam scelerisque sem eget ornare.\n" +
                "Donec at pharetra nulla, a iaculis ex.";
            Console.WriteLine(str);
            var words = str.Split(new char[] { ' ', '.', ',', '\n' }, StringSplitOptions.RemoveEmptyEntries);
            CustomSort41.SortArray(words, (n1, n2) =>
             {
                 if (n1.Length != n2.Length)
                     return n1.Length < n2.Length;
                 for (var i = 0; i < n1.Length; i++)
                     if (n1[i] != n2[i])
                         return n1[i] < n2[i];
                 return false;
             });
            Console.WriteLine();
            Console.WriteLine("Sorted:\n");
            CustomSort41.DisplayArray(words);
        }
    }
}
