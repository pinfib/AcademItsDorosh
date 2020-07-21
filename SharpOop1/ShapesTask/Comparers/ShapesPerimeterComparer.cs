using System.Collections.Generic;

namespace ShapesTask.Academits.Dorosh
{
    public class ShapesPerimeterComparer : IComparer<IShape>
    {
        public int Compare(IShape x, IShape y)
        {
            if (x.GetPerimeter().CompareTo(y.GetPerimeter()) != 0)
            {
                return y.GetPerimeter().CompareTo(x.GetPerimeter());
            }

            return 0;
        }
    }
}