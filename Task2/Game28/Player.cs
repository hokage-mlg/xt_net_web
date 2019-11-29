using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2.Game28
{
    class Player : GameObject, IMove, IHit
    {
        public int HP { get; set; }
        public int MP { get; set; }
        public int Speed { get; set; }
        public void Move()
        {
            Console.WriteLine("*Player moving...*");
        }
        public void Hit(IMove move)
        {
            Console.WriteLine("*Player hit!*");
        }
    }
}
