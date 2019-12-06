using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3
{
    class Lost31
    {
        public void Lost()
        {
            Console.WriteLine("Input max size (N):");
            if (int.TryParse(Console.ReadLine(), out int input))
            {
                var list = new LinkedList<int>(Enumerable.Range(1, input));
                var currentItem = list.First;
                Console.WriteLine("Sequence numbers of people:");
                Console.WriteLine(string.Join(" ", list));
                while (list.Count != 1)
                {
                    list.Remove(currentItem.Next ?? list.First);
                    currentItem = currentItem.Next ?? list.First;
                }
                Console.WriteLine("Remaining person number:");
                Console.WriteLine(list.First.Value);
                Console.ReadKey();
            }
        }
    }
}
