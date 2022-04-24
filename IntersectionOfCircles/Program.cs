using System;
using System.Linq;

namespace IntersectionOfCircles
{
    internal class Program
    {
        static void Main()
        {
            var firstLine = Console.ReadLine().Split().Select(int.Parse).ToArray();
            var secondLine = Console.ReadLine().Split().Select(int.Parse).ToArray();

            Circle first = ReadCircle(firstLine[0], firstLine[1], firstLine[2]);
            Circle second = ReadCircle(secondLine[0], secondLine[1], secondLine[2]);

            bool intersect = Intersect(first, second);

            Console.WriteLine(intersect ? "Yes" : "No");
        }
        static bool Intersect(Circle first, Circle second)
        {
            bool intersect = false;
            double distance = CalcDistance(first.X, first.Y, second.X, second.Y);
            if (distance <= first.Radius + second.Radius)
            {
                return intersect = true;
            }
            return intersect;
        }
        static double CalcDistance(double x1, double y1, double x2, double y2)
        {
            var sideA = x1 - x2;
            var sideB = y1 - y2;

            return Math.Sqrt(Math.Pow(sideA, 2) + Math.Pow(sideB, 2));
        }

        static Circle ReadCircle(int x, int y, int radius)
        {
            return new Circle { Radius = radius, X = x, Y = y };
        }
    }
    class Circle
    {
        public int X { get; set; }
        public int Y { get; set; }
        public int Radius { get; set; }
        public double Diameter
        {
            get
            {
                return Radius * 2;
            }
        }
    }
}
