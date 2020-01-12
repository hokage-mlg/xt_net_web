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
        public Rectangle(Point Center, double Width, double Height) : base(Center)
        {
            if (Width < 0 || Height < 0)
                throw new ArgumentException("Value must be > 0!");
            this.Width = Width;
            this.Height = Height;
        }
        public double Perimetr => 2 * (Width * Height);
        public double Area => Width * Height;
        public override void ShowInfo()
        {
            Console.WriteLine("Rectangle characteristics:\n" +
                $"- Center coordinates: ({Center.X},{Center.Y})\n" +
                $"- Width: {Width}\n" +
                $"- Height: {Height}");
        }
    }
}
