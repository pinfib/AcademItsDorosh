using System.Collections.Generic;

namespace ShapesTask.Academits.Dorosh
{
    public class ShapesAreaComparer : IComparer<IShape>
    {
        public int Compare(IShape x, IShape y)
        {
            if (x.GetArea().CompareTo(y.GetArea()) != 0)
            {
                return y.GetArea().CompareTo(x.GetArea());
            }

            return 0;
        }
    }
}