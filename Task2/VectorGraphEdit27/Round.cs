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
            Console.WriteLine("Round characteristics:\n" +
                "- Center coordinates: ({0},{1})\n" +
                "- Outer radius: {2}\n" +
                "- Outer length: {3}\n" +
                "- Area: {4}",
                Center.X, Center.Y, Radius, Length, Area);
        }
    }
}
