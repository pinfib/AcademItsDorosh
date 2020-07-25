using System;

namespace VectorTask.Academits.Dorosh
{
    public class Vector
    {
        public int N { get; set; }

        public double[] Components { get; set; }

        public Vector(int n)
        {
            if (n <= 0)
            {
                throw new ArgumentException("Размерность не может быть меньше или равна 0");
            }

            N = n;
            Components = new double[n];
        }

        public Vector(Vector vector)
        {
            N = vector.N;

            Components = new double[vector.N];
            vector.Components.CopyTo(Components, 0);
        }

        public Vector(params double[] components)
        {
            N = components.Length;

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

            N = n;

            Components = new double[N];
            components.CopyTo(Components, 0);
        }

        public override string ToString()
        {
            return "Размерность: " + N.ToString().PadRight(3, ' ') + "{ " + String.Join("; ", Components) + " }";
        }

        public void AddVector(Vector vector)
        {
            if (N < vector.N)
            {
                N = vector.N;

                double[] tmpComponents = new double[N];
                Components.CopyTo(tmpComponents, 0);

                Components = tmpComponents;
            }

            for (int i = 0; i < vector.N; i++)
            {
                Components[i] += vector.Components[i];
            }

            return;
        }

        public void SubtractVector(Vector vector)
        {
            if (N < vector.N)
            {
                N = vector.N;

                double[] tmpComponents = new double[vector.N];
                Components.CopyTo(tmpComponents, 0);

                Components = tmpComponents;
            }

            for (int i = 0; i < vector.N; i++)
            {
                Components[i] -= vector.Components[i];
            }

            return;
        }

        public void MultiplyVector(double scalar)
        {
            for (int i = 0; i < N; i++)
            {
                Components[i] *= scalar;
            }
        }

        public void Negate()
        {
            for (int i = 0; i < N; i++)
            {
                Components[i] *= -1;
            }
        }

        public double GetLength()
        {
            if (N == 0)
            {
                return 0;
            }

            double length = 0;

            for (int i = 0; i < N; i++)
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
            Vector newVector = new Vector(Math.Max(vector1.N, vector2.N));

            int length = Math.Min(vector1.N, vector2.N);

            for (int i = 0; i < length; i++)
            {
                newVector.Components[i] = vector1.Components[i] + vector2.Components[i];
            }

            if (vector1.N < vector2.N)
            {
                for (int i = length; i < newVector.N; i++)
                {
                    newVector.SetComponent(i, vector2.Components[i]);
                }
            }

            if (vector1.N > vector2.N)
            {
                for (int i = length; i < newVector.N; i++)
                {
                    newVector.SetComponent(i, vector1.Components[i]);
                }
            }

            return newVector;
        }

        public static Vector SubtractVectors(Vector vector1, Vector vector2)
        {
            Vector newVector = new Vector(Math.Max(vector1.N, vector2.N));

            int length = Math.Min(vector1.N, vector2.N);

            for (int i = 0; i < length; i++)
            {
                newVector.Components[i] = vector1.Components[i] - vector2.Components[i];
            }

            if (vector1.N < vector2.N)
            {
                for (int i = length; i < newVector.N; i++)
                {
                    newVector.SetComponent(i, vector2.Components[i]);
                }
            }

            if (vector1.N > vector2.N)
            {
                for (int i = length; i < newVector.N; i++)
                {
                    newVector.SetComponent(i, vector1.Components[i]);
                }
            }

            return newVector;
        }

        public static Vector MultiplyVectors(Vector vector1, Vector vector2)
        {
            Vector newVector = new Vector(Math.Max(vector1.N, vector2.N));

            int length = Math.Min(vector1.N, vector2.N);

            for (int i = 0; i < length; i++)
            {
                newVector.Components[i] = vector1.Components[i] * vector2.Components[i];
            }

            if (vector1.N < vector2.N)
            {
                for (int i = length; i < newVector.N; i++)
                {
                    newVector.SetComponent(i, vector2.Components[i]);
                }
            }

            if (vector1.N > vector2.N)
            {
                for (int i = length; i < newVector.N; i++)
                {
                    newVector.SetComponent(i, vector1.Components[i]);
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

            if (N != ((Vector)obj).N)
            {
                return false;
            }

            for (int i = 0; i < N; i++)
            {
                if (Components[i] != ((Vector)obj).Components[i])
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

            hash = prime * hash + N;

            foreach (double e in Components)
            {
                hash = prime * hash + e.GetHashCode();
            }

            return hash;
        }
    }
}