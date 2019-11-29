using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2.Game28
{
    class Wolf : Monster
    {
        public Wolf() { Speed = 10; Name = "Wolf"; }
        public override void Move()
        {
            Console.WriteLine("*Wolf run!*");
        }
        public override void Hit(IMove move)
        {
            Console.WriteLine("*Wolf hit!*");
        }
    }
}
