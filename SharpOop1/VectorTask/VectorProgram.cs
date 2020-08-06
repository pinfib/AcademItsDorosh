﻿using System;

namespace Academits.Dorosh.VectorTask
{
    class VectorProgram
    {
        static void Main()
        {
            Console.WriteLine();
            Console.WriteLine("Введите вектор 1");
            Vector vector1 = VectorCreation.GetVector();

            Console.WriteLine();
            Console.WriteLine("Введите вектор 2");
            Vector vector2 = VectorCreation.GetVector();

            //Vector vector1 = new Vector(4, 1, 1, 1, 1);
            //Vector vector2 = new Vector(4, 1, 1, 1, 1);

            Console.WriteLine();
            Console.Write("Векторы равны? ");
            Console.WriteLine(vector1.Equals(vector2) ? "Да" : "Нет");

            Console.WriteLine();
            Console.WriteLine("=== Методы, вызываемые от текущего объекта ===");
            VectorsTest.ObjectMethodsTest(vector1, vector2);

            Console.WriteLine();
            Console.WriteLine("=== Методы, вызываемые от класса ===");
            VectorsTest.StaticMethodsTest(vector1, vector2);

            Console.WriteLine();
            Console.WriteLine("=== Методы, работающие с одним объектом ===");
            VectorsTest.SelfMethodsTest(vector1, 10);
            VectorsTest.SelfMethodsTest(vector2, 10);

            Console.ReadKey();
        }
    }
}