using System;
using System.Collections.Generic;

namespace ShapesTask.Academits.Dorosh
{
    public class ShapeSearch
    {
        public static void MaxShapeSearch(IShape[] shapes, IComparer<IShape> comparer, int positionNumber)
        {
            Array.Sort(shapes, comparer);

            if (positionNumber == 0)
            {
                ShapesPrint.Print(shapes[positionNumber]);

                return;
            }

            for (int i = positionNumber; i < shapes.Length; i++)
            {
                if (comparer.Compare(shapes[i], shapes[i - 1]) == 0)
                {
                    continue;
                }

                ShapesPrint.Print(shapes[i]);

                return;
            }

            ShapesPrint.Print(shapes[shapes.Length - 1]);
        }
    }
}