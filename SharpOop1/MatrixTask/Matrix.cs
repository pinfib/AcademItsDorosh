using Academits.Dorosh.VectorTask;
using System;
using System.Text;

namespace Academits.Dorosh.MatrixTask
{
    public class Matrix
    {
        private Vector[] vectors;

        public Matrix(int width, int height)
        {
            vectors = new Vector[height];

            for (int i = 0; i < height; i++)
            {
                vectors[i] = new Vector(width);
            }
        }

        public Matrix(double[,] array)
        {
            int height = array.GetLength(0);
            int width = array.GetLength(1);

            vectors = new Vector[height];

            for (int i = 0; i < height; i++)
            {
                vectors[i] = new Vector(width);

                for (int j = 0; j < width; j++)
                {
                    vectors[i].SetComponent(j, array[i, j]);
                }
            }
        }

        public Matrix(Vector[] vectors)
        {
            int width = vectors[0].GetSize();           //поиск максимальной длины вектора

            foreach (Vector v in vectors)
            {
                width = Math.Max(width, v.GetSize());
            }

            this.vectors = new Vector[vectors.Length];

            for (int i = 0; i < vectors.Length; i++)
            {
                this.vectors[i] = new Vector(width);    //все вектора матрицы объявить максимальной длины

                int size = vectors[i].GetSize();

                for (int j = 0; j < size; j++)          //заполнить вектор-строку, ограничение по длине исходного вектора
                {
                    this.vectors[i].SetComponent(j, vectors[i].GetComponent(j));
                }
            }
        }

        public Matrix(Matrix matrix)
        {
            int height = matrix.GetHeight();

            vectors = new Vector[height];

            for (int i = 0; i < height; i++)
            {
                vectors[i] = new Vector(matrix.vectors[i]);
            }
        }

        public int GetWidth()
        {
            return vectors[0].GetSize();
        }

        public int GetHeight()
        {
            return vectors.Length;
        }

        public Vector GetHorisontalVector(int index)
        {
            return new Vector(vectors[index]);
        }

        public Vector GetVerticalVector(int index)
        {
            int height = GetHeight();
            double[] tmpComponents = new double[height];

            for (int i = 0; i < height; i++)
            {
                tmpComponents[i] = vectors[i].GetComponent(index);
            }

            return new Vector(height, tmpComponents);
        }

        public void SetHorisontalVector(int index, Vector vector)
        {
            if (vector.GetSize() != GetWidth())
            {
                int width = GetWidth();

                double[] components = new double[width];

                int size = vector.GetSize();

                for (int i = 0; i < size && i < width; i++)
                {
                    components[i] = vector.GetComponent(i);
                }

                vectors[index] = new Vector(width, components);

                return;
            }

            vectors[index] = new Vector(vector);
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

        public void MultiplyByNumber(double number)
        {
            int height = GetHeight();

            for (int i = 0; i < height; i++)
            {
                vectors[i].MultiplyByNumber(number);
            }
        }

        public void Add(Matrix matrix)
        {
            int width1 = GetWidth();
            int width2 = matrix.GetWidth();

            int height1 = GetHeight();
            int height2 = matrix.GetHeight();

            if (height1 != height2 || width1 != width2)
            {
                throw new ArgumentException(String.Format("Размеры текущей матрицы: {0}x{1}, входящей: {2}x{3}.\n Нельзя складывать или вычитать матрицы разных размерностей", width1, height1, width2, height2));
            }
            else
            {
                for (int i = 0; i < height1; i++)
                {
                    vectors[i].Add(matrix.vectors[i]);
                }
            }
        }

        public void Subtract(Matrix matrix)
        {
            Matrix tmpMatrix = new Matrix(matrix);

            tmpMatrix.MultiplyByNumber(-1);

            Add(tmpMatrix);
        }

        public Matrix VerticalVectorMultiplication(Vector vector)
        {
            int size = vector.GetSize();
            int width = GetWidth();
            int height = GetHeight();

            if (GetHeight() != vector.GetSize())
            {
                throw new ArgumentException(String.Format("Размеры текущей матрицы: {0}x{1}, размерность вектора: {2}\nКоличество строк в матрице и размерность вертикального вектора должны совпадать", width, height, size));
            }
            else
            {
                Matrix tmpMatrix = null;

                tmpMatrix = new Matrix(1, size);

                for (int i = 0; i < size; i++)
                {
                    double value = 0;

                    for (int j = 0; j < width; j++)
                    {
                        value += vectors[i].GetComponent(j) * vector.GetComponent(j);
                    }

                    tmpMatrix.SetHorisontalVector(i, new Vector(value));
                }

                return tmpMatrix;
            }
        }

        public double GetDeterminant()
        {
            int width = GetWidth();
            int height = GetHeight();

            if (width != height)
            {
                throw new ArgumentException(string.Format("Размеры матрицы: {0}x{1}\nОпределитель можно найти только для квадратной матрицы", width, height));
            }
            else
            {
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
                        Vector tmpVector = tmpMatrix.vectors[i];

                        for (int j = i; j < height; j++)
                        {
                            if (tmpMatrix.vectors[j].GetComponent(i) == 0)
                            {
                                continue;
                            }

                            tmpMatrix.vectors[i] = tmpMatrix.vectors[j];
                            tmpMatrix.vectors[j] = tmpVector;

                            determinant *= -1;

                            break;
                        }
                    }

                    for (int j = i + 1; j < height; j++)
                    {
                        if (tmpMatrix.vectors[j].GetComponent(i) != 0) //Если текущий элемент не 0, приводим матрицу к верхнетреугольному виду
                        {
                            Vector tmpVector = new Vector(tmpMatrix.vectors[i]);
                            tmpVector.MultiplyByNumber(tmpMatrix.vectors[j].GetComponent(i) / tmpMatrix.vectors[i].GetComponent(i));

                            tmpMatrix.vectors[j].Subtract(tmpVector);
                        }
                    }
                }

                for (int i = 0; i < height; i++)
                {
                    determinant *= tmpMatrix.vectors[i].GetComponent(i);
                }

                return determinant;
            }
        }

        public static Matrix Add(Matrix matrix1, Matrix matrix2)
        {
            Matrix newMatrix = new Matrix(matrix1);
            newMatrix.Add(matrix2);

            return newMatrix;
        }

        public static Matrix Subtract(Matrix matrix1, Matrix matrix2)
        {
            Matrix newMatrix = new Matrix(matrix1);

            newMatrix.Subtract(matrix2);

            return newMatrix;
        }

        public static Matrix MatrixMultiplication(Matrix matrix1, Matrix matrix2)
        {
            int newHeight = matrix1.GetHeight();
            int newWidth = matrix2.GetWidth();

            if (newWidth != newHeight)
            {
                throw new ArgumentException(string.Format("Размеры матрицы 1: {0}x{1} , размеры матрицы 2: {2}x{3} \nКоличество строк должно быть равно количеству столбцов", matrix1.GetWidth(), newHeight, newWidth, matrix2.GetHeight()));
            }
            else
            {
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
        }

        public override string ToString()
        {
            StringBuilder tmpString = new StringBuilder();

            tmpString.Append("{\n");

            int height = GetHeight();

            for (int i = 0; i < height; i++)
            {
                tmpString.Append(vectors[i].ToString());

                if (i != height - 1)
                {
                    tmpString.Append(", \n");
                }
            }

            tmpString.Append("\n}");

            return tmpString.ToString();
        }
    }
}