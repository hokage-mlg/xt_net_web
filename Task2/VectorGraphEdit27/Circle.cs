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
        public Circle(Point Center, double Radius) : base(Center)
        {
            if (Radius < 0)
                throw new ArgumentException("Radius must be > 0!");
            this.Radius = Radius;
        }
        public virtual double Length => 2 * Math.PI * Radius;
        public override void ShowInfo()
        {
            Console.WriteLine("Circle characteristics:\n" +
                $"- Center coordinates: ({Center.X},{Center.Y})\n" +
                $"- Outer radius: {Radius}");
        }
    }
}
