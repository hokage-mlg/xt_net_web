using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2.Game28
{
    class Cherry : Bonus
    {
        public override void GiveBonus(Player player)
        {
            Console.WriteLine("Eat cherry: MP +5");
        }
    }
}
