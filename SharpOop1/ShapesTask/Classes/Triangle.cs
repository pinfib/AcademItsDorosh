using System;
using System.Linq;

namespace ShapesTask.Academits.Dorosh
{
    class Triangle : IShape
    {
        public double[] X { get; set; }

        public double[] Y { get; set; }

        public double SideAB { get; set; }

        public double SideBC { get; set; }

        public double SideAC { get; set; }

        public Triangle(double x1, double y1, double x2, double y2, double x3, double y3)
        {
            X = new double[] { x1, x2, x3 };
            Y = new double[] { y1, y2, y3 };

            SideAB = GetTriangleSideLength(X[0], Y[0], X[1], Y[1]);
            SideBC = GetTriangleSideLength(X[1], Y[1], X[2], Y[2]);
            SideAC = GetTriangleSideLength(X[0], Y[0], X[2], Y[2]);
        }

        public static double GetTriangleSideLength(double x1, double y1, double x2, double y2)
        {
            return Math.Sqrt(Math.Pow(x2 - x1, 2) + Math.Pow(y2 - y1, 2));
        }

        public double GetArea()
        {
            double semiPerimeter = GetPerimeter() / 2;
            double triangleArea = Math.Sqrt(semiPerimeter * ((semiPerimeter - SideAB) * (semiPerimeter - SideBC) * (semiPerimeter - SideAC)));

            return triangleArea;
        }

        public double GetHeight()
        {
            return Y.Max() - Y.Min();
        }

        public double GetPerimeter()
        {
            return SideAB + SideBC + SideAC;
        }

        public double GetWidth()
        {
            return X.Max() - X.Min();
        }

        public override string ToString()
        {
            return "Треугольник";
        }

        public override int GetHashCode()
        {
            int prime = 13;
            int hash = 1;

            hash = prime * hash + SideAB.GetHashCode();
            hash = prime * hash + SideBC.GetHashCode();
            hash = prime * hash + SideAC.GetHashCode();

            return hash;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(obj, this))
            {
                return true;
            }

            if (ReferenceEquals(obj, null) || obj.GetType() != GetType())
            {
                return false;
            }

            return SideAB == ((Triangle)obj).SideAB && SideBC == ((Triangle)obj).SideBC && SideAC == ((Triangle)obj).SideAC;
        }
    }
}