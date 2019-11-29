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
            List<Figure> figures = new List<Figure>();
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
                int select = int.Parse(Console.ReadLine());
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
                        foreach (Figure f in figures)
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
            int x = int.Parse(Console.ReadLine());
            Console.WriteLine("Input y coordinate:");
            int y = int.Parse(Console.ReadLine());
            return new Point(x, y);
        }
        private Figure CreateLine()
        {
            Console.WriteLine("Line creating...");
            Console.WriteLine("Input start of the line:");
            Point start = GetCoordinates();
            Console.WriteLine("Input end of the line:");
            Point end = GetCoordinates();
            return new Line(start, end);
        }
        private Figure CreateRectangle()
        {
            Console.WriteLine("Rectangle creating...");
            Console.WriteLine("Input center of the rectangle:");
            var center = GetCoordinates();
            Console.WriteLine("Input sides values:");
            Console.WriteLine("Input width:");
            double w = double.Parse(Console.ReadLine());
            Console.WriteLine("Input height:");
            double h = double.Parse(Console.ReadLine());
            return new Rectangle(center, w, h);
        }
        private Figure CreateCircle()
        {
            Console.WriteLine("Circle creating...");
            Console.WriteLine("Input center of the circle:");
            Point center = GetCoordinates();
            Console.WriteLine("Input radius:");
            double radius = double.Parse(Console.ReadLine());
            return new Circle(center, radius);
        }
        private Figure CreateRound()
        {
            Console.WriteLine("Round creating...");
            Console.WriteLine("Input center of the round:");
            Point center = GetCoordinates();
            Console.WriteLine("Input radius:");
            double radius = double.Parse(Console.ReadLine());
            return new Round(center, radius);
        }
        private Figure CreateRing()
        {
            Console.WriteLine("Ring creating...");
            Console.WriteLine("Input center of the ring:");
            Point center = GetCoordinates();
            Console.WriteLine("Input inner radius:");
            double innerRadius = double.Parse(Console.ReadLine());
            Console.WriteLine("Input outer radius:");
            double outerRadius = double.Parse(Console.ReadLine());
            return new Ring(center, innerRadius, outerRadius);
        }
    }
}
