using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2.Game28
{
    class Stone : Obstruction
    {
        public override void Hit(IMove move)
        {
            Console.WriteLine("AAH... it hurts!!! I hate this stone!");
        }
    }
}
