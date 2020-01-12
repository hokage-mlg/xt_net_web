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
        public Ring(Point Center, double InnerRadius, double OuterRadius) : base(Center, OuterRadius)
        {
            if (InnerRadius <= 0 || OuterRadius <= 0)
                throw new ArgumentException("Radius must be > 0!");
            if (InnerRadius > OuterRadius)
                throw new ArgumentException("The inner radius cannot be larger than the outer");
            this.InnerRadius = InnerRadius;
        }
        public double InnerLength => 2 * Math.PI * InnerRadius;
        public double Area => (Math.PI * Math.Pow(Radius, 2)) - (Math.PI * Math.Pow(InnerRadius, 2));
        public override void ShowInfo()
        {
            Console.WriteLine("Ring characteristics:\n" +
                $"- Center coordinates: ({Center.X},{Center.Y})\n" +
                $"- Inner radius: {InnerRadius}\n" +
                $"- Outer radius: {Radius}\n" +
                $"- Inner length: {InnerLength}\n" +
                $"- Outer length: {Length}\n" +
                $"- Area: {Area}");
        }
    }
}
