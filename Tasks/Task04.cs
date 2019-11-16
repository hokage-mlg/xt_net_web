using System;
using System.Collections.Generic;
using System.Text;

namespace Tasks0
{
    class Task04
    {
        public static void ArrayDisplay(int height)
        {
            Random rnd = new Random();
            int[][] arrays = new int[height][];
            for (int i = 0; i < height; i++)
            {
                Console.Write("Number of elements in {0} array: ", i + 1);
                int width = int.Parse(Console.ReadLine());
                arrays[i] = new int[width];
            }
            for (int i = 0; i < arrays.Length; i++)
            {
                for (int j = 0; j < arrays[i].Length; j++)
                    arrays[i][j] = rnd.Next(0, 100);
            }
            Console.WriteLine();
            Console.WriteLine("Default arrays: ");
            WriteArray(arrays);
            SortArray(arrays);
            Console.WriteLine("Sorted arrays: ");
            WriteArray(arrays);
        }
        public static void WriteArray(int[][] arrays)
        {
            //Hope it is right {}
            Console.Write("{");
            foreach (int[] i in arrays)
            {
                Console.Write("{");
                foreach (int j in i)
                {
                    Console.Write(j.ToString() + ",");
                }
                Console.Write("},");
            }
            Console.WriteLine("}\n");
        }
        public static void SortArray(int[][] arrays)
        {
            int i = 0;
            foreach (int[] arr in arrays)
                i += arr.Length;
            int[] temp = new int[i];
            i = 0;
            for (int n = 0; n < arrays.Length; n++)
            {
                for (int m = 0; m < arrays[n].Length; m++)
                {
                    temp[i] = arrays[n][m];
                    i++;
                }
            }
            i = 0;
            Array.Sort(temp);       
            for (int n = 0; n < arrays.Length; n++)
            {
                for (int m = 0; m < arrays[n].Length; m++)
                {
                    arrays[n][m] = temp[i];
                    i++;
                }
            }
        }
    }
}
