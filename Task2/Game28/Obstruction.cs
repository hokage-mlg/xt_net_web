using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2.Game28
{
    abstract class Obstruction : GameObject, IHit
    {
        public abstract void Hit(IMove move);
    }
}
