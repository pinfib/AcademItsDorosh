using System;

namespace Academits.Dorosh.VectorTask
{
    public class Vector
    {
        public double[] Components { get; set; }

        public Vector(int n)
        {
            if (n <= 0)
            {
                throw new ArgumentException("Размерность не может быть меньше или равна 0");
            }

            Components = new double[n];
        }

        public Vector(Vector vector)
        {
            Components = new double[vector.GetSize()];
            vector.Components.CopyTo(Components, 0);
        }

        public Vector(params double[] components)
        {
            Components = new double[components.Length];
            components.CopyTo(Components, 0);
        }

        public Vector(int n, params double[] components)
        {
            if (n <= 0)
            {
                throw new ArgumentException("Размерность не может быть меньше или равна 0");
            }

            if (n < components.Length)
            {
                throw new ArgumentException("Количество компонент не может быть больше размерности");
            }

            Components = new double[n];
            components.CopyTo(Components, 0);
        }

        public int GetSize()
        {
            return Components.Length;
        }

        public override string ToString()
        {
            string tmpString = null;

            int size = GetSize();

            for(int i = 0; i < size; i ++)
            {
                tmpString += string.Format("{0, -4:0.##}", Components[i]);

                if (i != size-1)
                {
                    tmpString += "; ";
                }
            }

            return " { " + tmpString + " }";
        }

        public void AddVector(Vector vector)
        {
            int size = vector.GetSize();

            if (GetSize() < size)
            {
                double[] tmpComponents = new double[size];

                Components.CopyTo(tmpComponents, 0);
                Components = tmpComponents;
            }

            for (int i = 0; i < size; i++)
            {
                Components[i] += vector.Components[i];
            }

            return;
        }

        public void SubtractVector(Vector vector)
        {
            int size = vector.GetSize();

            if (GetSize() < size)
            {
                double[] tmpComponents = new double[size];

                Components.CopyTo(tmpComponents, 0);
                Components = tmpComponents;
            }

            for (int i = 0; i < size; i++)
            {
                Components[i] -= vector.Components[i];
            }

            return;
        }

        public void ScalarMultiplication(double scalar)
        {
            int size = GetSize();
            
            for (int i = 0; i < size; i++)
            {
                Components[i] *= scalar;
            }
        }

        public void Negate()
        {
            int size = GetSize();

            for (int i = 0; i < size; i++)
            {
                Components[i] *= -1;
            }
        }

        public double GetLength()
        {
            int size = GetSize();
            double length = 0;

            for (int i = 0; i < size; i++)
            {
                length += Math.Pow(Components[i], 2);
            }

            return Math.Sqrt(length);
        }

        public double GetComponent(int index)
        {
            return Components[index];
        }

        public void SetComponent(int index, double value)
        {
            Components[index] = value;
        }

        public static Vector AddVectors(Vector vector1, Vector vector2)
        {
            int size1 = vector1.GetSize();
            int size2 = vector2.GetSize();

            Vector newVector = new Vector(Math.Max(size1, size2));

            int size3 = newVector.GetSize();

            for (int i = 0; i < size3; i++)
            {
                if(i < size1)
                {
                    newVector.Components[i] = vector1.Components[i];
                }

                if(i < size2)
                {
                    newVector.Components[i] += vector2.Components[i];
                }
            }

            return newVector;
        }

        public static Vector SubtractVectors(Vector vector1, Vector vector2)
        {
            int size1 = vector1.GetSize();
            int size2 = vector2.GetSize();

            Vector newVector = new Vector(Math.Max(size1, size2));

            int size3 = newVector.GetSize();

            for (int i = 0; i < size3; i++)
            {
                if (i < size1)
                {
                    newVector.Components[i] = vector1.Components[i];
                }

                if (i < size2)
                {
                    newVector.Components[i] -= vector2.Components[i];
                }
            }

            return newVector;
        }

        public static Vector MultiplyVectors(Vector vector1, Vector vector2)
        {
            int size1 = vector1.GetSize();
            int size2 = vector2.GetSize();

            Vector newVector = new Vector(Math.Max(size1, size2));

            int size3 = newVector.GetSize();

            for (int i = 0; i < size3; i++)
            {
                if (i < size1)
                {
                    newVector.Components[i] = vector1.Components[i];
                }

                if (i < size2)
                {
                    newVector.Components[i] *= vector2.Components[i];
                }
            }

            return newVector;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(obj, this))
            {
                return true;
            }

            if (ReferenceEquals(obj, null) || obj.GetType() != GetType())
            {
                return false;
            }

            Vector tmpVector = (Vector)obj;
            int size = GetSize();

            if (size != tmpVector.GetSize())
            {
                return false;
            }

            for (int i = 0; i < size; i++)
            {
                if (Components[i] != tmpVector.Components[i])
                {
                    return false;
                }
            }

            return true;
        }

        public override int GetHashCode()
        {
            int prime = 13;
            int hash = 1;

            foreach (double e in Components)
            {
                hash = prime * hash + e.GetHashCode();
            }

            return hash;
        }
    }
}