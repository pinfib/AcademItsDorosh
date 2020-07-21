using System;

namespace ShapesTask.Academits.Dorosh
{
    class ShapesProgram
    {
        static void Main()
        {
            IShape[] shapes = new IShape[] {
                new Square(10),
                new Square(10),
                new Square(20),
                new Triangle(0, 0, 3, 1, 1, 4),
                new Triangle(-1, 1, 4, 0, -2, -2),
                new Rectangle(5, 7),
                new Circle(5.5),
                new Circle(7)
            };

            foreach (IShape shape in shapes)
            {
                ShapesPrint.Print(shape);
            }

            Console.WriteLine();
            Console.WriteLine("Первая по площади фигура:");
            ShapeSearch.MaxShapeSearch(shapes, new ShapesAreaComparer(), 0);

            Console.WriteLine();
            Console.WriteLine("Вторая по периметру фигура:");
            ShapeSearch.MaxShapeSearch(shapes, new ShapesPerimeterComparer(), 1);

            Console.ReadLine();
        }
    }
}