using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2
{
    public class Triangle22
    {
        public double a, b, c;
        public Triangle22()
        {
            Console.WriteLine("Input A:");
            double a = double.Parse(Console.ReadLine());
            Console.WriteLine("Input B:");
            double b = double.Parse(Console.ReadLine());
            Console.WriteLine("Input C:");
            double c = double.Parse(Console.ReadLine());
            this.A = Check(a, b, c);
            this.B = Check(b, a, c);
            this.C = Check(c, a, b);
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
            get { return a; }
            set
            {
                if (value <= 0 && this.b + this.c > value)
                    throw new ArgumentException("Error! Check \'A\' argument");
                a = value;
            }
        }
        public double B
        {
            get { return b; }
            set
            {
                if (value <= 0 && a + c > value)
                    throw new ArgumentException("Error! Check \'B\' argument");
                b = value;
            }
        }
        public double C
        {
            get { return c; }
            set
            {
                if (value <= 0 && a + b > value)
                    throw new ArgumentException("Error! Check \'C\' argument");
                c = value;
            }
        }
        public double Perimeter
        {
            get { return (a + b + c); }
        }
        public double Area
        {
            get { return (Math.Sqrt(Perimeter / 2 * (Perimeter / 2 - a) * (Perimeter / 2 - b) * (Perimeter / 2 - c))); }
        }
        public override string ToString()
        {
            return (string.Format("Triangle characteristics:\n" +
                "- A: {0}\n" +
                "- B: {1}\n" +
                "- C: {2}\n" +
                "- Perimeter: {3}\n" +
                "- Area: {4}", a, b, c, Perimeter, Area));
        }
    }
}
