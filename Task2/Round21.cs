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
            try
            {
                Console.WriteLine("Input x coordinate:");
                var x = int.Parse(Console.ReadLine());
                Console.WriteLine("Input y coordinate:");
                var y = int.Parse(Console.ReadLine());
                Console.WriteLine("Input radius:");
                var radius = double.Parse(Console.ReadLine());
                return new Round21(new Point(x, y), radius);
            }
            catch (Exception e)
            {
                throw new ArgumentException("Incorrect input:\n", e.Message);
            }
        }
        public double Radius
        {
            get => _radius;
            set
            {
                if (value <= 0)
                    throw new ArgumentException("Radius must be > 0!");
                _radius = value;
            }
        }
        public virtual double Length
        {
            get => (2 * Math.PI * _radius);
        }
        public virtual double Area
        {
            get => (Math.PI * Math.Pow(_radius, 2));
        }
        public override string ToString() =>
            string.Format("Round characteristics:\n" +
                $"- Center: ({Center.X},{Center.Y})\n" +
                $"- Radius: {Radius}\n" +
                $"- Length: {Length}\n" +
                $"- Area: {Area}");
    }
}
