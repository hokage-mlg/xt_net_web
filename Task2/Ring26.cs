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
        public Ring26(Point center, double outerRadius, double innerRadius) : base(center, outerRadius)
        {
            if (innerRadius <= 0 || outerRadius <= 0)
                throw new ArgumentException("Radius must be > 0!");
            if (innerRadius > outerRadius)
                throw new ArgumentException("The inner radius cannot be larger than the outer");
            InnerRadius = innerRadius;
        }
        public static Ring26 InputRing()
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
        public double LengthRing => base.Length + (2 * Math.PI * InnerRadius);
        public double AreaRing => base.Area - (Math.PI * Math.Pow(InnerRadius, 2));
        public override string ToString()
        {
            return base.ToString() + Environment.NewLine
                + string.Format("- Inner Radius: {0}\n" + "- Total length: {1}\n"
                + "- Area of ring: {2}", InnerRadius, LengthRing, AreaRing);
        }
    }
}
