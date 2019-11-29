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
            Console.WriteLine("Line starts at a point ({0},{1}) " +
                "and ends at a point ({2},{3})",
                Center.X, Center.Y, EndPoint.X, EndPoint.Y);
        }
    }
}
