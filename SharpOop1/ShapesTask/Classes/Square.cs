using System;

namespace ShapesTask.Academits.Dorosh
{
    class Square : IShape
    {
        public double SideLength { get; set; }

        public Square(double sideLength)
        {
            SideLength = sideLength;
        }
        public double GetArea()
        {
            return Math.Pow(SideLength, 2);
        }

        public double GetHeight()
        {
            return SideLength;
        }

        public double GetPerimeter()
        {
            return SideLength * 4;
        }

        public double GetWidth()
        {
            return SideLength;
        }

        public override string ToString()
        {
            return "Квадрат";
        }

        public override int GetHashCode()
        {
            int prime = 13;
            int hash = 1;

            hash = prime * hash + SideLength.GetHashCode();

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

            return SideLength == ((Square)obj).SideLength;
        }
    }
}