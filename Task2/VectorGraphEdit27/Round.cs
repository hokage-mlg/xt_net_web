using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2.VectorGraphEdit27
{
    class Round : Circle
    {
        public Round(Point center, double radius) : base(center, radius) { }
        public double Area => Math.PI * Math.Pow(Radius, 2);
        public override void ShowInfo()
        {
            Console.WriteLine("Center of the round is in coordinates ({0},{1})," +
                " the outer radius is {2}, the outer length is {3}, area is {4}",
                Center.X, Center.Y, Radius, Length, Area);
        }
        public override string ToString()
        {
            return (string.Format("Center of the round is in coordinates ({0},{1})," +
                " the outer radius is {2}, the outer length is {3}, area is {4}",
                Center.X, Center.Y, Radius, Length, Area));
        }
    }
}
