using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2.VectorGraphEdit27
{
    class Ring : Circle
    {
        public double InnerRadius { get; set; }
        public Ring(Point center, double innerRadius, double outerRadius) : base(center, outerRadius)
        {
            if (innerRadius <= 0 || outerRadius <= 0)
                throw new ArgumentException("Radius must be > 0!");
            if (innerRadius > outerRadius)
                throw new ArgumentException("The inner radius cannot be larger than the outer");
            InnerRadius = innerRadius;
        }
        public double InnerLength => 2 * Math.PI * InnerRadius;
        public double Area => (Math.PI * Math.Pow(Radius, 2)) - (Math.PI * Math.Pow(InnerRadius, 2));
        public override void ShowInfo()
        {
            Console.WriteLine("Ring characteristics:\n" +
                "- Center coordinates: ({0},{1})\n" +
                "- Inner radius: {2}\n" +
                "- Outer radius: {3}\n" +
                "- Inner length: {4}\n" +
                "- Outer length: {5}\n" +
                "- Area: {6}",
                Center.X, Center.Y, InnerRadius, Radius, InnerLength, Length, Area);
        }
    }
}
