using Academits.Dorosh.VectorTask;
using System;

namespace Academits.Dorosh.MatrixTask
{
    class MatrixProgram
    {
        static void Main(string[] args)
        {
            Vector[] vectors =
            {
                new Vector(1.0),
                new Vector(1.0, 1.0),
                new Vector(1.0, 1.0, 1.0),
                new Vector(1.0, 1.0, 1.0, 1.0)
            };

            Matrix matrix1 = new Matrix(vectors);
            Matrix matrix2 = new Matrix(matrix1.Transpose());

            Console.WriteLine("Матрица 1:");
            Console.WriteLine(matrix1.ToString());
            Console.WriteLine();

            Console.WriteLine("Матрица 2:");
            Console.WriteLine(matrix2.ToString());
            Console.WriteLine();

            Console.WriteLine("=== Умножение (статический): ===");
            Console.WriteLine(Matrix.MatrixMultiplication(matrix1, matrix2));
            Console.WriteLine();

            Console.WriteLine("=== Сложение (статический): ===");
            Console.WriteLine(Matrix.AddMatrices(matrix1, matrix2));
            Console.WriteLine();

            Console.WriteLine("=== Вычитание (статический): ===");
            Console.WriteLine(Matrix.SubtractMatrices(matrix1, matrix2));
            Console.WriteLine();

            Console.WriteLine("=== Умножение на вертикальный вектор: ===");
            Vector vector = new Vector(2.0, 2.0, 2.0, 2.0);
            Console.WriteLine(matrix1.VerticalVectorMultiplication(vector).ToString());

            Console.WriteLine("=== Сложение (не статический): ===");
            Matrix matrix3 = new Matrix(matrix1);
            matrix3.AddMatrix(matrix2);
            Console.WriteLine(matrix3.ToString());
            Console.WriteLine();

            Console.WriteLine("=== Вычитание (не статический): ===");
            Matrix matrix4 = new Matrix(matrix1);
            matrix4.SubtractMatrix(matrix2);
            Console.WriteLine(matrix4.ToString());
            Console.WriteLine();

            Console.WriteLine("Определитель матрицы 2: {0}", matrix1.GetDeterminant());
            


            //Vector vector = new Vector(-11.0, -11);
            //matrix2.SetHorisontalVector(1, vector);
            //Console.WriteLine(matrix2.ToString());

            Console.WriteLine("Умножение на скаляр:");
            matrix1.ScalarMultiplication(10);
            Console.WriteLine(matrix1.ToString());

            Console.WriteLine("Определитель матрицы 1: {0}", matrix1.GetDeterminant());

            Console.ReadKey();
        }
    }
}
