using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2
{
    class Round21
    {
        public double x, y, radius;
        public Round21()
        {
            Console.WriteLine("Input x coordinate:");
            double x = double.Parse(Console.ReadLine());
            this.x = x;
            Console.WriteLine("Input y coordinate:");
            double y = double.Parse(Console.ReadLine());
            this.y = y;
            Console.WriteLine("Input radius:");
            double Radius = double.Parse(Console.ReadLine());
            this.Radius = Radius;
        }
        public double Radius
        {
            get { return radius; }
            set
            {
                if (value <= 0)
                    throw new ArgumentException("Radius must be > 0!");
                radius = value;
            }
        }
        public double Length
        {
            get { return (2 * Math.PI * radius); }
        }
        public double Area
        {
            get { return (Math.PI * Math.Pow(radius, 2)); }
        }
        public override string ToString()
        {
            return (string.Format("Round characteristics:\n" +
                "- center: ({0},{1})\n" +
                "- radius: {2}\n" +
                "- length: {3}\n" +
                "- area: {4}", x, y, Radius, Length, Area));
        }
    }
}
