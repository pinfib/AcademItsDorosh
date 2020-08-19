using Academits.Dorosh.VectorTask;
using System;
using System.Text;

namespace Academits.Dorosh.MatrixTask
{
    public class Matrix
    {
        private Vector[] lines;

        public Matrix(int columns, int rows)
        {
            if (columns <= 0 || rows <= 0)
            {
                throw new ArgumentException(string.Format("Передано: количество строк [{0}], количество столбцов [{1}]. Количество строк и столбцов матрицы должно быть больше нуля.", rows, columns));
            }

            lines = new Vector[rows];

            for (int i = 0; i < rows; i++)
            {
                lines[i] = new Vector(columns);
            }
        }

        public Matrix(double[,] array)
        {
            if (array.Length == 0)
            {
                throw new ArgumentException("Передан пустой массив double, нельзя создать пустую матрицу.", nameof(array));
            }

            int rows = array.GetLength(0);
            int columns = array.GetLength(1);

            lines = new Vector[rows];

            for (int i = 0; i < rows; i++)
            {
                lines[i] = new Vector(columns);

                for (int j = 0; j < columns; j++)
                {
                    lines[i].SetComponent(j, array[i, j]);
                }
            }
        }

        public Matrix(Vector[] vectors)
        {
            if (vectors.Length == 0)
            {
                throw new ArgumentException("Передан пустой массив vectors, нельзя создать пустую матрицу.", nameof(vectors));
            }

            int columns = vectors[0].GetSize();           // поиск максимальной длины вектора

            foreach (Vector v in vectors)
            {
                columns = Math.Max(columns, v.GetSize());
            }

            lines = new Vector[vectors.Length];

            for (int i = 0; i < vectors.Length; i++)
            {
                lines[i] = new Vector(columns);         // все вектора матрицы объявить максимальной длины

                int size = vectors[i].GetSize();

                for (int j = 0; j < size; j++)          // заполнить вектор-строку, ограничение по длине исходного вектора
                {
                    lines[i].SetComponent(j, vectors[i].GetComponent(j));
                }
            }
        }

        public Matrix(Matrix matrix)
        {
            int rows = matrix.GetRowsCount();

            lines = new Vector[rows];

            for (int i = 0; i < rows; i++)
            {
                lines[i] = new Vector(matrix.lines[i]);
            }
        }

        public int GetColumnsCount()
        {
            return lines[0].GetSize();
        }

        public int GetRowsCount()
        {
            return lines.Length;
        }

        public Vector GetLine(int index)
        {
            int columns = GetColumnsCount();

            if (index < 0 || index >= columns)
            {
                throw new ArgumentException(string.Format("Передан индекс [{0}]. Допустимое значение индекса от 0 до {1}.", index, columns - 1), nameof(index));
            }

            return new Vector(lines[index]);
        }

        public Vector GetColumn(int index)
        {
            int rows = GetRowsCount();

            if (index < 0 || index >= rows)
            {
                throw new ArgumentException(string.Format("Передан индекс [{0}]. Допустимое значение индекса от 0 до {1}.", index, rows - 1), nameof(index));
            }

            Vector tmpVector = new Vector(rows);

            for (int i = 0; i < rows; i++)
            {
                tmpVector.SetComponent(i, lines[i].GetComponent(index));
            }

            return tmpVector;
        }

        public void SetLine(int index, Vector vector)
        {
            int size = vector.GetSize();
            int columns = GetColumnsCount();

            if (size != columns)
            {
                throw new ArgumentException(string.Format("Передан вектор размерности [{0}], количество столбцов в текущей матрице [{1}]. Размерности не совпадают.", size, columns), nameof(vector));
            }

            int rows = GetRowsCount();

            if (index < 0 || index >= rows)
            {
                throw new ArgumentException(string.Format("Передан индекс [{0}]. Допустимое значение индекса от 0 до {1}.", index, rows - 1), nameof(index));
            }

            lines[index] = new Vector(vector);
        }

        public void Transpose()
        {
            int columns = GetColumnsCount();
            int rows = GetRowsCount();

            Matrix tmpMatrix = new Matrix(rows, columns);

            for (int i = 0; i < columns; i++)
            {
                tmpMatrix.SetLine(i, GetColumn(i));
            }

            lines = tmpMatrix.lines;
        }

        public void MultiplyByNumber(double number)
        {
            int rows = GetRowsCount();

            foreach (Vector v in lines)
            {
                v.MultiplyByNumber(number);
            }
        }

        public void Add(Matrix matrix)
        {
            int columns1 = GetColumnsCount();
            int columns2 = matrix.GetColumnsCount();

            int rows1 = GetRowsCount();
            int rows2 = matrix.GetRowsCount();

            if (rows1 != rows2 || columns1 != columns2)
            {
                throw new ArgumentException(string.Format("Размеры текущей матрицы: {0}x{1}, входящей: {2}x{3}. Нельзя складывать или вычитать матрицы разных размерностей.", columns1, rows1, columns2, rows2));
            }

            for (int i = 0; i < rows1; i++)
            {
                lines[i].Add(matrix.lines[i]);
            }
        }

        public void Subtract(Matrix matrix)
        {
            int columns1 = GetColumnsCount();
            int columns2 = matrix.GetColumnsCount();

            int rows1 = GetRowsCount();
            int rows2 = matrix.GetRowsCount();

            if (rows1 != rows2 || columns1 != columns2)
            {
                throw new ArgumentException(string.Format("Размеры текущей матрицы: {0}x{1}, входящей: {2}x{3}. Нельзя складывать или вычитать матрицы разных размерностей.", columns1, rows1, columns2, rows2));
            }

            for (int i = 0; i < rows1; i++)
            {
                lines[i].Subtract(matrix.lines[i]);
            }
        }

        public Vector GetMultiplicationByVector(Vector vector)
        {
            int size = vector.GetSize();
            int columns = GetColumnsCount();
            int rows = GetRowsCount();

            if (rows != size)
            {
                throw new ArgumentException(string.Format("Размеры текущей матрицы: {0}x{1}, размерность вектора: {2}. Количество строк в матрице и размерность вертикального вектора должны совпадать.", columns, rows, size));
            }

            Vector tmpVector = new Vector(size);

            for (int i = 0; i < size; i++)
            {
                double value = Vector.GetScalarMultiplication(lines[i], vector);

                tmpVector.SetComponent(i, value);
            }

            return tmpVector;
        }

        public double GetDeterminant()
        {
            int columns = GetColumnsCount();
            int rows = GetRowsCount();

            if (columns != rows)
            {
                throw new ArgumentException(string.Format("Размеры матрицы: {0}x{1}. Определитель можно найти только для квадратной матрицы.", columns, rows));
            }

            if (rows == 1)
            {
                return lines[0].GetComponent(0);
            }

            Matrix tmpMatrix = new Matrix(this);

            double determinant = 1;

            for (int i = 0; i < rows; i++)
            {
                if (tmpMatrix.GetLine(i).GetComponent(i) == 0) // Если текущий элемент 0, меняем местами текущую строку со следующий, где текущей элемент не 0
                {
                    Vector tmpVector = tmpMatrix.lines[i];

                    for (int j = i; j < rows; j++)
                    {
                        if (tmpMatrix.lines[j].GetComponent(i) == 0)
                        {
                            continue;
                        }

                        tmpMatrix.lines[i] = tmpMatrix.lines[j];
                        tmpMatrix.lines[j] = tmpVector;

                        determinant *= -1;

                        break;
                    }
                }

                for (int j = i + 1; j < rows; j++)
                {
                    if (tmpMatrix.lines[j].GetComponent(i) != 0) // Если текущий элемент не 0, приводим матрицу к верхнетреугольному виду
                    {
                        Vector tmpVector = new Vector(tmpMatrix.lines[i]);
                        tmpVector.MultiplyByNumber(tmpMatrix.lines[j].GetComponent(i) / tmpMatrix.lines[i].GetComponent(i));

                        tmpMatrix.lines[j].Subtract(tmpVector);
                    }
                }
            }

            for (int i = 0; i < rows; i++)
            {
                determinant *= tmpMatrix.lines[i].GetComponent(i);
            }

            return determinant;
        }

        public static Matrix GetSum(Matrix matrix1, Matrix matrix2)
        {
            Matrix newMatrix = new Matrix(matrix1);
            newMatrix.Add(matrix2);

            return newMatrix;
        }

        public static Matrix GetDifference(Matrix matrix1, Matrix matrix2)
        {
            Matrix newMatrix = new Matrix(matrix1);
            newMatrix.Subtract(matrix2);

            return newMatrix;
        }

        public static Matrix GetMultiplication(Matrix matrix1, Matrix matrix2)
        {
            int newRows = matrix1.GetRowsCount();
            int newColumns = matrix2.GetColumnsCount();

            if (newColumns != newRows)
            {
                throw new ArgumentException(string.Format("Размеры матрицы 1: {0}x{1}, размеры матрицы 2: {2}x{3}. Количество строк должно быть равно количеству столбцов.", matrix1.GetColumnsCount(), newRows, newColumns, matrix2.GetRowsCount()));
            }

            Matrix newMatrix = new Matrix(newColumns, newRows);

            int rows = matrix2.GetRowsCount();

            for (int i = 0; i < newRows; i++)
            {
                Vector newVector = new Vector(newColumns);

                for (int j = 0; j < newColumns; j++)
                {
                    Vector vector1 = matrix1.GetLine(i);
                    Vector vector2 = matrix2.GetColumn(j);

                    double value = 0;

                    for (int k = 0; k < rows; k++)
                    {
                        value += vector1.GetComponent(k) * vector2.GetComponent(k);
                    }

                    newVector.SetComponent(j, value);
                }

                newMatrix.SetLine(i, newVector);
            }

            return newMatrix;
        }

        public override string ToString()
        {
            StringBuilder tmpString = new StringBuilder();

            tmpString.AppendLine("{");

            int rows = GetRowsCount();

            for (int i = 0; i < rows; i++)
            {
                tmpString.Append(lines[i].ToString());

                if (i != rows - 1)
                {
                    tmpString.AppendLine(", ");
                }
            }

            tmpString.AppendLine();
            tmpString.AppendLine("}");

            return tmpString.ToString();
        }
    }
}