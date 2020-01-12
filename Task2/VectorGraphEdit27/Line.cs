using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2.VectorGraphEdit27
{
    class Line : Figure
    {
        public Point EndPoint { get; set; }
        public Line(Point Center, Point EndPoint) : base(Center)
        {
            this.EndPoint = EndPoint;
        }
        public override void ShowInfo()
        {
            Console.WriteLine("Line characteristics:\n" +
                $"- Start point coordinates: ({Center.X},{Center.Y})\n" +
                $"- End point coordinates: ({EndPoint.X},{EndPoint.Y})");
        }
    }
}
