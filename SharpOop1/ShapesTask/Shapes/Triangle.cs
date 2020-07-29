using System;

namespace Academits.Dorosh.ShapesTask.Shapes
{
    class Triangle : IShape
    {
        public double[] PointA { get; set; }

        public double[] PointB { get; set; }

        public double[] PointC { get; set; }

        public Triangle(double x1, double y1, double x2, double y2, double x3, double y3)
        {
            PointA = new double[] { x1, y1 };
            PointB = new double[] { x2, y2 };
            PointC = new double[] { x3, y3 };
        }

        public static double GetSideLength(double x1, double y1, double x2, double y2)
        {
            return Math.Sqrt(Math.Pow(x2 - x1, 2) + Math.Pow(y2 - y1, 2));
        }

        public double GetWidth()
        {
            return Math.Max(Math.Max(PointA[0], PointB[0]), PointC[0]) - Math.Min(Math.Min(PointA[0], PointB[0]), PointC[0]);
        }

        public double GetHeight()
        {
            return Math.Max(Math.Max(PointA[1], PointB[1]), PointC[1]) - Math.Min(Math.Min(PointA[1], PointB[1]), PointC[1]);
        }

        public double GetArea()
        {
            double SideAB = GetSideLength(PointA[0], PointA[1], PointB[0], PointB[1]);
            double SideBC = GetSideLength(PointB[0], PointB[1], PointC[0], PointC[1]);
            double SideAC = GetSideLength(PointA[0], PointA[1], PointC[0], PointC[1]);
            double semiPerimeter = GetPerimeter() / 2;

            return Math.Sqrt(semiPerimeter * ((semiPerimeter - SideAB) * (semiPerimeter - SideBC) * (semiPerimeter - SideAC)));
        }

        public double GetPerimeter()
        {
            double SideAB = GetSideLength(PointA[0], PointA[1], PointB[0], PointB[1]);
            double SideBC = GetSideLength(PointB[0], PointB[1], PointC[0], PointC[1]);
            double SideAC = GetSideLength(PointA[0], PointA[1], PointC[0], PointC[1]);

            return SideAB + SideBC + SideAC;
        }

        public override string ToString()
        {
            return string.Format("Треугольник (А({0};{1}), B({2},{3}), C({4},{5}))", PointA[0], PointA[1], PointB[0], PointB[1], PointC[0], PointC[1]);
        }

        public override int GetHashCode()
        {
            int prime = 13;
            int hash = 1;

            for (int i = 0; i < PointA.Length; i++)
            {
                hash = prime * hash + PointA[i].GetHashCode();
                hash = prime * hash + PointB[i].GetHashCode();
                hash = prime * hash + PointC[i].GetHashCode();
            }

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

            Triangle tmpTriangle = (Triangle)obj;

            for (int i = 0; i < PointA.Length; i++)
            {
                if (tmpTriangle.PointA[i] != PointA[i] || tmpTriangle.PointB[i] != PointB[i] || tmpTriangle.PointC[i] != PointC[i])
                {
                    return false;
                }
            }

            return true;
        }
    }
}