using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2.VectorGraphEdit27
{
    class Rectangle : Figure
    {
        public double Width { get; set; }
        public double Height { get; set; }
        public Rectangle(Point center, double width, double height) : base(center)
        {
            if (width < 0 || height < 0)
                throw new ArgumentException("Value must be > 0!");
            Width = width;
            Height = height;
        }
        public double Perimetr => 2 * (Width * Height);
        public double Area => Width * Height;
        public override void ShowInfo()
        {
            Console.WriteLine("Rectangle characteristics:\n" +
                "- Center coordinates: ({0},{1})\n" +
                "- Width: {2}\n" +
                "- Height: {3}",
                Center.X, Center.Y, Width, Height);
        }
    }
}
