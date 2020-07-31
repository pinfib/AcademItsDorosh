using Academits.Dorosh.VectorTask;
using System;

namespace Academits.Dorosh.MatrixTask
{
    public class Matrix
    {
        public Vector[] Vectors { get; set; }

        public Matrix(int width, int height)
        {
            Vectors = new Vector[height];

            for (int i = 0; i < height; i++)
            {
                Vectors[i] = new Vector(width);
            }
        }

        public Matrix(double[,] array)
        {
            int height = array.GetLength(0);
            int width = array.GetLength(1);

            Vectors = new Vector[height];

            for (int i = 0; i < height; i++)
            {
                Vectors[i] = new Vector(width);

                for (int j = 0; j < width; j++)
                {
                    Vectors[i].SetComponent(j, array[i, j]);
                }
            }
        }

        public Matrix(Vector[] vectors)
        {
            int width = vectors[0].GetSize();

            foreach (Vector v in vectors)
            {
                width = Math.Max(width, v.GetSize());
            }

            Vectors = new Vector[vectors.Length];

            for (int i = 0; i < vectors.Length; i++)
            {
                Vectors[i] = new Vector(width, vectors[i].Components);
            }
        }

        public Matrix(Matrix matrix)
        {
            int m = matrix.GetHeight();

            Vectors = new Vector[m];

            for (int i = 0; i < m; i++)
            {
                Vectors[i] = new Vector(matrix.Vectors[i]);
            }
        }

        public int GetWidth()
        {
            return Vectors[0].GetSize();
        }

        public int GetHeight()
        {
            return Vectors.Length;
        }

        public Vector GetHorisontalVector(int index)
        {
            return new Vector(Vectors[index]);
        }

        public Vector GetVerticalVector(int index)
        {
            int height = GetHeight();
            double[] tmpComponents = new double[height];

            for (int i = 0; i < height; i++)
            {
                tmpComponents[i] = Vectors[i].Components[index];
            }

            return new Vector(height, tmpComponents);
        }

        public void SetHorisontalVector(int index, params double[] components)
        {
            if (GetWidth() < components.Length)
            {
                throw new ArgumentException("Количество компонент не может быть больше размерности матрицы");
            }

            Vectors[index] = new Vector(GetWidth(), components);
        }

        public void SetHorisontalVector(int index, Vector vector)
        {
            if (GetWidth() < vector.GetSize())
            {
                throw new ArgumentException("Количество компонент не может быть больше размерности матрицы");
            }

            Vectors[index] = new Vector(GetWidth(), vector.Components);
        }

        public Matrix Transpose()
        {
            int width = GetWidth();
            int height = GetHeight();

            Matrix tmpMatrix = new Matrix(height, width);

            for (int i = 0; i < width; i++)
            {
                tmpMatrix.SetHorisontalVector(i, GetVerticalVector(i));
            }

            return tmpMatrix;
        }

        public void ScalarMultiplication(double scalar)
        {
            int height = GetHeight();

            for (int i = 0; i < height; i++)
            {
                Vectors[i].ScalarMultiplication(scalar);
            }
        }

        public void AddMatrix(Matrix matrix)
        {
            if (GetHeight() != matrix.GetHeight() || GetWidth() != matrix.GetWidth())
            {
                throw new ArgumentException("Нельзя складывать матрицы разных размерностей");
            }

            int height = GetHeight();

            for (int i = 0; i < height; i++)
            {
                Vectors[i].AddVector(matrix.Vectors[i]);
            }
        }

        public void SubtractMatrix(Matrix matrix)
        {
            if (GetHeight() != matrix.GetHeight() || GetWidth() != matrix.GetWidth())
            {
                throw new ArgumentException("Нельзя вычитать матрицы разных размерностей");
            }

            int height = GetHeight();

            for (int i = 0; i < height; i++)
            {
                Vectors[i].SubtractVector(matrix.GetHorisontalVector(i));
            }
        }

        public Matrix VerticalVectorMultiplication(Vector vector)
        {
            if (GetHeight() != vector.GetSize())
            {
                throw new ArgumentException("Количество строк в матрице не совпадает с размерностью вертикального вектора");
            }

            Matrix tmpMatrix = null;

            int height = vector.GetSize();
            int width = GetWidth();

            tmpMatrix = new Matrix(1, height);

            for (int i = 0; i < height; i++)
            {
                double value = 0;

                for (int j = 0; j < width; j++)
                {
                    value += Vectors[i].GetComponent(j) * vector.GetComponent(j);
                }

                tmpMatrix.SetHorisontalVector(i, value);
            }

            return tmpMatrix;
        }

        public double GetDeterminant()
        {
            int width = GetWidth();
            int height = GetHeight();

            if (width != height)
            {
                throw new ArgumentException("Определитель можно найти только для квадратной матрицы");
            }

            if (height == 1)
            {
                return 1;
            }

            Matrix tmpMatrix = new Matrix(this);

            double determinant = 1;

            for (int i = 0; i < height; i++)
            {
                if (tmpMatrix.GetHorisontalVector(i).GetComponent(i) == 0) //Если текущий элемент 0, меняем местами текущую строку со следующий, где текущей элемент не 0
                {
                    Vector tmpVector = tmpMatrix.Vectors[i];

                    for (int j = i; j < height; j++)
                    {
                        if (tmpMatrix.Vectors[j].Components[i] == 0)
                        {
                            continue;
                        }

                        tmpMatrix.Vectors[i] = tmpMatrix.Vectors[j];
                        tmpMatrix.Vectors[j] = tmpVector;

                        determinant *= -1;

                        break;
                    }
                }

                for (int j = i + 1; j < height; j++)
                {
                    if (tmpMatrix.Vectors[j].GetComponent(i) != 0) //Если текущий элемент не 0, приводим матрицу к верхнетреугольному виду
                    {
                        Vector tmpVector = new Vector(tmpMatrix.Vectors[i]);
                        tmpVector.ScalarMultiplication(tmpMatrix.Vectors[j].Components[i] / tmpMatrix.Vectors[i].Components[i]);

                        tmpMatrix.Vectors[j].SubtractVector(tmpVector);
                    }
                }
            }

            for (int i = 0; i < height; i++)
            {
                determinant *= tmpMatrix.Vectors[i].GetComponent(i);
            }

            return determinant;
        }

        public static Matrix AddMatrices(Matrix matrix1, Matrix matrix2)
        {
            if (matrix1.GetHeight() != matrix2.GetHeight() || matrix1.GetWidth() != matrix2.GetWidth())
            {
                throw new ArgumentException("Нельзя складывать матрицы разных размерностей");
            }

            Matrix newMatrix = new Matrix(matrix1);

            int height = newMatrix.GetHeight();

            for (int i = 0; i < height; i++)
            {
                newMatrix.Vectors[i].AddVector(matrix2.Vectors[i]);
            }

            return newMatrix;
        }

        public static Matrix SubtractMatrices(Matrix matrix1, Matrix matrix2)
        {
            if (matrix1.GetHeight() != matrix2.GetHeight() || matrix1.GetWidth() != matrix2.GetWidth())
            {
                throw new ArgumentException("Нельзя вычитать матрицы разных размерностей");
            }

            Matrix newMatrix = new Matrix(matrix1);

            int height = newMatrix.GetHeight();

            for (int i = 0; i < height; i++)
            {
                newMatrix.Vectors[i].SubtractVector(matrix2.Vectors[i]);
            }

            return newMatrix;
        }

        public static Matrix MatrixMultiplication(Matrix matrix1, Matrix matrix2)
        {
            if (matrix1.GetWidth() != matrix2.GetHeight())
            {
                throw new ArgumentException("Количество строк должно быть равно количеству столбцов");
            }

            int newHeight = matrix1.GetHeight();
            int newWidth = matrix2.GetWidth();

            Matrix newMatrix = new Matrix(newWidth, newHeight);

            int height = matrix2.GetHeight();

            for (int i = 0; i < newHeight; i++)
            {
                Vector newVector = new Vector(newWidth);

                for (int j = 0; j < newWidth; j++)
                {
                    Vector vector1 = matrix1.GetHorisontalVector(i);
                    Vector vector2 = matrix2.GetVerticalVector(j);

                    double value = 0;

                    for (int k = 0; k < height; k++)
                    {
                        value += vector1.GetComponent(k) * vector2.GetComponent(k);
                    }

                    newVector.SetComponent(j, value);
                }

                newMatrix.SetHorisontalVector(i, newVector);
            }

            return newMatrix;
        }

        public override string ToString()
        {
            string tmpString = null;

            int height = GetHeight();

            for (int i = 0; i < height; i++)
            {
                tmpString += Vectors[i].ToString();

                if (i != height - 1)
                {
                    tmpString += ", \n";
                }
            }

            tmpString = "{\n" + tmpString + "\n}";

            return tmpString;
        }
    }
}