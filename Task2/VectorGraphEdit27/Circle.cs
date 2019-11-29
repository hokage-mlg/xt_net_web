using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2.VectorGraphEdit27
{
    class Circle : Figure
    {
        public double Radius { get; set; }
        public Circle(Point center, double radius) : base(center)
        {
            if (radius < 0)
                throw new ArgumentException("Radius must be > 0!");
            Radius = radius;
        }
        public virtual double Length => 2 * Math.PI * Radius;
        public override void ShowInfo()
        {
            Console.WriteLine("Center of the circle is in coordinates ({0},{1})," +
                " the outer radius is {2}",
                Center.X, Center.Y, Radius);
        }
    }
}
