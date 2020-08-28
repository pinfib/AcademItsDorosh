using Academits.Dorosh.VectorTask;
using System;

namespace Academits.Dorosh.MatrixTask
{
    class MatrixProgram
    {
        static void Main()
        {
            try
            {
                Vector[] vectors =
                {
                    new Vector(1.0),
                    new Vector(1.0, 1.0),
                    new Vector(1.0, 1.0, 1.0),
                    new Vector(1.0, 1.0, 1.0, 1.0)
                };

                double[,] array =
                {
                    {1, 1, 1, 1 },
                    {0, 1, 1, 1 },
                    {0, 0, 1, 1 },
                    {0, 0, 0, 1 },

                };

                Matrix matrix1 = new Matrix(vectors);
                Matrix matrix2 = new Matrix(array);

                //Console.WriteLine(matrix2.GetRow(4));
                //Console.WriteLine(matrix2.GetColumn(3));

                Console.WriteLine("Матрица 1:");
                Console.WriteLine(matrix1);
                Console.WriteLine();

                Console.WriteLine("Матрица 2:");
                Console.WriteLine(matrix2);
                Console.WriteLine();

                Matrix matrix3 = new Matrix(matrix1);
                Matrix matrix4 = new Matrix(matrix1);

                Console.WriteLine("=== Умножение (статический): ===");
                Console.WriteLine(Matrix.GetMultiplication(matrix1, matrix2));
                Console.WriteLine();

                Console.WriteLine("=== Сложение (статический): ===");
                Console.WriteLine(Matrix.GetSum(matrix1, matrix2));
                Console.WriteLine();

                Console.WriteLine("=== Вычитание (статический): ===");
                Console.WriteLine(Matrix.GetDifference(matrix1, matrix2));
                Console.WriteLine();

                Console.WriteLine("=== Сложение (не статический): ===");
                matrix3.Add(matrix2);
                Console.WriteLine(matrix3);
                Console.WriteLine();

                Console.WriteLine("=== Вычитание (не статический): ===");
                matrix4.Subtract(matrix2);
                Console.WriteLine(matrix4);
                Console.WriteLine();

                Vector vector = new Vector(2.0, 2.0, 2.0, 2.0);

                Console.WriteLine("=== Умножение на вертикальный вектор: ===");
                Console.WriteLine(matrix1.GetMultiplicationByVector(vector));
                Console.WriteLine();

                Console.WriteLine("=== Умножение на скаляр: ===");
                matrix1.MultiplyByNumber(10);
                Console.WriteLine(matrix1);

                Console.WriteLine("=== Транспонирование матрицы: ===");

                double[,] array3 =
                {
                    {1, 0, 0 },
                    {1, 1, 0 },
                    {1, 1, 1 },
                    {2, 3, 4 }
                };

                Matrix matrix5 = new Matrix(array3);
                Console.WriteLine("Исходная");
                Console.WriteLine(matrix5);
                Console.WriteLine("Транспонированная");
                matrix5.Transpose();
                Console.WriteLine(matrix5);

                Console.WriteLine("=== Вычисление определителя матрицы: ===");

                double[,] array4 =
                {
                    {1, 2, 3, 4 },
                    {5, 6, 7, 8 },
                    {1, 9, 5, 1 },
                    {2, 4, 8, 0 }
                };

                Matrix matrix6 = new Matrix(array4);

                Console.WriteLine("Матрица:");
                Console.WriteLine(matrix6);
                Console.WriteLine("Определитель: {0}", matrix6.GetDeterminant()); //определитель = -576
                
            }
            catch (Exception e)
            {
                Console.WriteLine();
                Console.WriteLine(e.Message);
                Console.WriteLine();
            }

            Console.ReadKey();
        }
    }
}