namespace ShapesTask.Academits.Dorosh
{
    class Rectangle : IShape
    {
        public double SideHeight { get; set; }

        public double SideWidth { get; set; }

        public Rectangle(double sideHeight, double sideWidth)
        {
            SideHeight = sideHeight;
            SideWidth = sideWidth;
        }

        public double GetArea()
        {
            return SideHeight * SideWidth;
        }

        public double GetHeight()
        {
            return SideHeight;
        }

        public double GetPerimeter()
        {
            return 2 * (SideHeight * SideWidth);
        }

        public double GetWidth()
        {
            return SideWidth;
        }

        public override string ToString()
        {
            return "Прямоугольник";
        }

        public override int GetHashCode()
        {
            int prime = 13;
            int hash = 1;

            hash = prime * hash + SideHeight.GetHashCode();
            hash = prime * hash + SideWidth.GetHashCode();

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

            return SideHeight == ((Rectangle)obj).SideHeight && SideWidth == ((Rectangle)obj).SideWidth;
        }
    }
}