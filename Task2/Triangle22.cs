using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2
{
    public class Triangle22
    {
        private double _a, _b, _c;
        public Triangle22(double _a, double _b, double _c)
        {
            A = Check(_a, _b, _c);
            B = Check(_b, _a, _c);
            C = Check(_c, _a, _b);
        }
        public static Triangle22 InputTriangle()
        {
            Console.WriteLine("Input A:");
            double a = double.Parse(Console.ReadLine());
            Console.WriteLine("Input B:");
            double b = double.Parse(Console.ReadLine());
            Console.WriteLine("Input C:");
            double c = double.Parse(Console.ReadLine());
            return new Triangle22(a, b, c);
        }
        public double Check(double side1, double side2, double side3)
        {
            if (side1 > side2 + side3)
                throw new ArgumentException("Error! Triangle does not exist!");
            else
                return side1;
        }
        public double A
        {
            get { return _a; }
            set
            {
                if (value <= 0 && _b + _c > value)
                    throw new ArgumentException("Error! Check \'A\' argument");
                _a = value;
            }
        }
        public double B
        {
            get { return _b; }
            set
            {
                if (value <= 0 && _a + _c > value)
                    throw new ArgumentException("Error! Check \'B\' argument");
                _b = value;
            }
        }
        public double C
        {
            get { return _c; }
            set
            {
                if (value <= 0 && _a + _b > value)
                    throw new ArgumentException("Error! Check \'C\' argument");
                _c = value;
            }
        }
        public double Perimeter
        {
            get { return (_a + _b + _c); }
        }
        public double Area
        {
            get
            {
                double PerimeterHalf = Perimeter / 2;
                return (Math.Sqrt(PerimeterHalf * (PerimeterHalf - _a) *
                    (PerimeterHalf - _b) * (PerimeterHalf - _c)));
            }
        }
        public override string ToString()
        {
            return (string.Format("Triangle characteristics:\n" +
                "- A: {0}\n" +
                "- B: {1}\n" +
                "- C: {2}\n" +
                "- Perimeter: {3}\n" +
                "- Area: {4}", _a, _b, _c, Perimeter, Area));
        }
    }
}
