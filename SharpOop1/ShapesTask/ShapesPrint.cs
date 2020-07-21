using System;

namespace ShapesTask.Academits.Dorosh
{
    class ShapesPrint
    {
        public static void Print(IShape shape)
        {
            Console.Write("ToString: {0, -14} ", shape.ToString());
            Console.Write("H: {0, -4:#.##} W: {1, -4:#.##} PERIMETER: {2, -8:#.##} AREA: {3, -8:#.##} ", shape.GetHeight(), shape.GetWidth(), shape.GetPerimeter(), shape.GetArea());
            Console.Write("HashCode: {0}", shape.GetHashCode());
            Console.WriteLine();
        }
    }
}