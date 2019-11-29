using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2.Game28
{
    abstract class Monster : GameObject, IMove, IHit
    {
        public int Speed { get; set; }
        public string Name { get; set; }
        abstract public void Move();
        abstract public void Hit(IMove movable);
    }
}