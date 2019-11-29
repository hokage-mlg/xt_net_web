using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2.VectorGraphEdit27
{
    abstract class Figure
    {
        public Point Center { get; set; }
        public Figure(Point center)
        {
            Center = center;
        }
        public abstract void ShowInfo();
    }
}
