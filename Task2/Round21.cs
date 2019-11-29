using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2
{
    class Round21
    {
        public Point Center { get; set; }
        private double _radius;
        public Round21(Point Center, double Radius)
        {
            this.Center = Center;
            this.Radius = Radius;
        }
        public static Round21 InputRound()
        {
            Console.WriteLine("Input x coordinate:");
            int x = int.Parse(Console.ReadLine());
            Console.WriteLine("Input y coordinate:");
            int y = int.Parse(Console.ReadLine());
            Console.WriteLine("Input radius:");
            double Radius = double.Parse(Console.ReadLine());
            return new Round21(new Point(x, y), Radius);
        }
        public double Radius
        {
            get { return _radius; }
            set
            {
                if (value <= 0)
                    throw new ArgumentException("Radius must be > 0!");
                _radius = value;
            }
        }
        public virtual double Length
        {
            get { return (2 * Math.PI * _radius); }
        }
        public virtual double Area
        {
            get { return (Math.PI * Math.Pow(_radius, 2)); }
        }
        public override string ToString()
        {
            return (string.Format("Round characteristics:\n" +
                "- Center: ({0},{1})\n" +
                "- Radius: {2}\n" +
                "- Length: {3}\n" +
                "- Area: {4}", Center.X, Center.Y, Radius, Length, Area));
        }
    }
}
