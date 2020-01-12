using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2.VectorGraphEdit27
{
    class Round : Circle
    {
        public Round(Point Center, double Radius) : base(Center, Radius) { }
        public double Area => Math.PI * Math.Pow(Radius, 2);
        public override void ShowInfo()
        {
            Console.WriteLine("Round characteristics:\n" +
                $"- Center coordinates: ({Center.X},{Center.Y})\n" +
                $"- Outer radius: {Radius}\n" +
                $"- Outer length: {Length}\n" +
                $"- Area: {Area}");
        }
    }
}
