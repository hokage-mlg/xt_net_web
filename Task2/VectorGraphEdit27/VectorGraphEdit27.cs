using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2.VectorGraphEdit27
{
    class VectorGraphEdit27
    {
        public void CreateFigure()
        {
            var figures = new List<Figure>();
            while (true)
            {
                Console.WriteLine("Choose figure which you want to create:\n" +
                    "1. Line\n" +
                    "2. Rectangle\n" +
                    "3. Circle\n" +
                    "4. Round\n" +
                    "5. Ring\n" +
                    "6. Show\n" +
                    "0. Exit");
                Console.WriteLine("Input number:");
                var select = int.Parse(Console.ReadLine());
                switch (select)
                {
                    case 0:
                        return;
                    case 1:
                        figures.Add(CreateLine());
                        Console.Clear();
                        Console.WriteLine("Line added...");
                        Console.ReadLine();
                        break;
                    case 2:
                        figures.Add(CreateRectangle());
                        Console.Clear();
                        Console.WriteLine("Rectangle added...");
                        Console.ReadLine();
                        break;
                    case 3:
                        figures.Add(CreateCircle());
                        Console.Clear();
                        Console.WriteLine("Circle added...");
                        Console.ReadLine();
                        break;
                    case 4:
                        figures.Add(CreateRound());
                        Console.Clear();
                        Console.WriteLine("Round added...");
                        Console.ReadLine();
                        break;
                    case 5:
                        figures.Add(CreateRing());
                        Console.Clear();
                        Console.WriteLine("Ring added...");
                        Console.ReadLine();
                        break;
                    case 6:
                        Console.Clear();
                        foreach (var f in figures)
                        {
                            f.ShowInfo();
                            Console.WriteLine();
                        }
                        break;
                    default:
                        throw new ArgumentException("Incorrect input!");
                }
            }
        }
        private Point GetCoordinates()
        {
            Console.WriteLine("Input coordinates:");
            Console.WriteLine("Input x coordinate:");
            var x = int.Parse(Console.ReadLine());
            Console.WriteLine("Input y coordinate:");
            var y = int.Parse(Console.ReadLine());
            return new Point(x, y);
        }
        private Figure CreateLine()
        {
            Console.WriteLine("Line creating...");
            Console.WriteLine("Input start of the line:");
            var start = GetCoordinates();
            Console.WriteLine("Input end of the line:");
            var end = GetCoordinates();
            return new Line(start, end);
        }
        private Figure CreateRectangle()
        {
            Console.WriteLine("Rectangle creating...");
            Console.WriteLine("Input center of the rectangle:");
            var center = GetCoordinates();
            Console.WriteLine("Input sides values:");
            Console.WriteLine("Input width:");
            var w = double.Parse(Console.ReadLine());
            Console.WriteLine("Input height:");
            var h = double.Parse(Console.ReadLine());
            return new Rectangle(center, w, h);
        }
        private Figure CreateCircle()
        {
            Console.WriteLine("Circle creating...");
            Console.WriteLine("Input center of the circle:");
            var center = GetCoordinates();
            Console.WriteLine("Input radius:");
            var radius = double.Parse(Console.ReadLine());
            return new Circle(center, radius);
        }
        private Figure CreateRound()
        {
            Console.WriteLine("Round creating...");
            Console.WriteLine("Input center of the round:");
            var center = GetCoordinates();
            Console.WriteLine("Input radius:");
            var radius = double.Parse(Console.ReadLine());
            return new Round(center, radius);
        }
        private Figure CreateRing()
        {
            Console.WriteLine("Ring creating...");
            Console.WriteLine("Input center of the ring:");
            var center = GetCoordinates();
            Console.WriteLine("Input inner radius:");
            var innerRadius = double.Parse(Console.ReadLine());
            Console.WriteLine("Input outer radius:");
            var outerRadius = double.Parse(Console.ReadLine());
            return new Ring(center, innerRadius, outerRadius);
        }
    }
}
