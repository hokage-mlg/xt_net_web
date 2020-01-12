using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2
{

    class Ring26 : Round21
    {
        public double InnerRadius { get; set; }
        public Ring26(Point Center, double OuterRadius, double InnerRadius) : base(Center, OuterRadius)
        {
            if (InnerRadius <= 0 || OuterRadius <= 0)
                throw new ArgumentException("Radius must be > 0!");
            if (InnerRadius > OuterRadius)
                throw new ArgumentException("The inner radius cannot be larger than the outer");
            this.InnerRadius = InnerRadius;
        }
        public static Ring26 InputRing()
        {
            try
            {
                Console.WriteLine("Input x coordinate:");
                int x = int.Parse(Console.ReadLine());
                Console.WriteLine("Input y coordinate:");
                int y = int.Parse(Console.ReadLine());
                Console.WriteLine("Input outer radius:");
                double outerRadius = double.Parse(Console.ReadLine());
                Console.WriteLine("Input inner radius:");
                double innerRadius = double.Parse(Console.ReadLine());
                return new Ring26(new Point(x, y), outerRadius, innerRadius);
            }
            catch (Exception e)
            {
                throw new ArgumentException("Incorrect input:\n", e.Message);
            }
        }
        public double LengthRing => base.Length + (2 * Math.PI * InnerRadius);
        public double AreaRing => base.Area - (Math.PI * Math.Pow(InnerRadius, 2));
        public override string ToString() =>
            base.ToString() + Environment.NewLine
                + string.Format($"- Inner Radius: {InnerRadius}\n" + $"- Total length: {LengthRing}\n"
                + $"- Area of ring: {AreaRing}");
    }
}
