using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2.Game28
{
    class Bear : Monster
    {

        public Bear() { Speed = 5; Name = "Bear"; }
        public override void Move()
        {
            Console.WriteLine("*Bear run!*");
        }
        public override void Hit(IMove move)
        {
            Console.WriteLine("*Bear hit!*");
        }
    }
}
