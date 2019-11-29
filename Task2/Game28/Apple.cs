using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2.Game28
{
    class Apple : Bonus
    {
        public override void GiveBonus(Player player)
        {
            Console.WriteLine("Eat apple: HP +5");
        }
    }
}
