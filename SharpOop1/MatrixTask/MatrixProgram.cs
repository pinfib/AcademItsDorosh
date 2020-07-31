using Academits.Dorosh.VectorTask;
using System;

namespace Academits.Dorosh.MatrixTask
{
    class MatrixProgram
    {
        static void Main(string[] args)
        {
            double[,] array1 = new double[,]
            {
                {1, 0, 0, 0 },
                {1, 1, 0, 0 },
                {1, 1, 1, 0 },
                {1, 1, 1, 1 }
            };

            double[,] array2 = new double[,]
            {
                {1, 1, 1, 1 },
                {0, 1, 1, 1 },
                {0, 0, 1, 1 },
                {0, 0, 0, 1 }
            };

            Matrix matrix1 = new Matrix(array1);
            Matrix matrix2 = new Matrix(array2);

            Console.WriteLine("Матрица 1:");
            Console.WriteLine(matrix1.ToString());
            Console.WriteLine();

            Console.WriteLine("Матрица 2:");
            Console.WriteLine(matrix2.ToString());
            Console.WriteLine();

            if (matrix1.GetWidth() == matrix2.GetHeight())
            {
                Console.WriteLine("=== Умножение (статический): ===");
                Console.WriteLine(Matrix.MatrixMultiplication(matrix1, matrix2));
                Console.WriteLine();
            }
            else
            {
                Console.WriteLine("Эти матрицы нельзя перемножить");
            }

            if (matrix1.GetHeight() == matrix2.GetHeight() || matrix1.GetWidth() == matrix2.GetWidth())
            {
                Console.WriteLine("=== Сложение (статический): ===");
                Console.WriteLine(Matrix.AddMatrices(matrix1, matrix2));
                Console.WriteLine();

                Console.WriteLine("=== Вычитание (статический): ===");
                Console.WriteLine(Matrix.SubtractMatrices(matrix1, matrix2));
                Console.WriteLine();

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
            }
            else
            {
                Console.WriteLine("Эти матрицы нельзя сложить или вычесть");
            }

            Vector vector = new Vector(2.0, 2.0, 2.0, 2.0);

            if (vector.GetSize() == matrix1.GetHeight())
            {
                Console.WriteLine("=== Умножение на вертикальный вектор: ===");
                Console.WriteLine(matrix1.VerticalVectorMultiplication(vector).ToString());
            }
            else
            {
                Console.WriteLine("Размерность матрицы 1 и вектора не совпадают, их нельзя перемножить");
            }

            Console.WriteLine("=== Умножение на скаляр: ===");
            matrix1.ScalarMultiplication(10);
            Console.WriteLine(matrix1.ToString());

            Console.WriteLine("=== Транспонирование матрицы: ===");

            double[,] array3 = new double[,]
            {
                {1, 0, 0 },
                {1, 1, 0 },
                {1, 1, 1 }
            };

            Matrix matrix5 = new Matrix(array3);
            Console.WriteLine("Исходная");
            Console.WriteLine(matrix5.ToString());
            Console.WriteLine("Транспонированная");
            Console.WriteLine(matrix5.Transpose().ToString());

            Console.WriteLine("=== Вычисление определителя матрицы: ===");

            double[,] array4 = new double[,]
            {
                {1, 2, 3, 4 },
                {5, 6, 7, 8 },
                {1, 9, 5, 1 },
                {2, 4, 8, 0 }
            };

            Matrix matrix6 = new Matrix(array4);

            Console.WriteLine("Матрица:");
            Console.WriteLine(matrix6.ToString());
            Console.WriteLine("Определитель: {0}", matrix6.GetDeterminant());

            Console.ReadKey();
        }
    }
}