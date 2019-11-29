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
        public Line(Point center, Point endPoint) : base(center)
        {
            EndPoint = endPoint;
        }
        public override void ShowInfo()
        {
            Console.WriteLine("Line characteristics:\n" +
                "- Start point coordinates: ({0},{1})\n" +
                "- End point coordinates: ({2},{3})",
                Center.X, Center.Y, EndPoint.X, EndPoint.Y);
        }
    }
}
