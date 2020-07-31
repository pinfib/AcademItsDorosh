using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VectorTask.Academits.Dorosh;

namespace MatrixTask.Academits.Dorosh
{
    public class Matrix
    {
        public Vector[] Vectors { get; set; }

        public int N { get; set; }

        public int M { get; set; }

        public Matrix(int n, int m)
        {
            M = m;
            N = n;

            Vectors = new Vector[M];

            for (int i = 0; i < M; i++)
            {
                Vectors[i] = new Vector(N);
            }
        }

        public Matrix(double[,] array)
        {
            M = array.GetLength(0);
            N = array.GetLength(1);

            Vectors = new Vector[M];

            for (int i = 0; i < M; i++)
            {
                Vectors[i] = new Vector(N);

                for (int j = 0; j < N; j++)
                {
                    Vectors[i].Components[j] = array[i, j];
                }
            }
        }

        public Matrix(Vector[] vectors)
        {
            int maxN = vectors[0].N;

            foreach(Vector v in vectors)
            {
                maxN = Math.Max(maxN, v.N);
            }
            
            M = vectors.Length;
            N = maxN;

            Vectors = new Vector[M];

            for(int i = 0; i < M; i++)
            {
                Vectors[i] = new Vector(N, vectors[i].Components);
            }
        }

        public Matrix(Matrix matrix)
        {
            M = matrix.M;
            N = matrix.N;

            Vectors = new Vector[M];

            for (int i = 0; i < M; i++)
            {
                Vectors[i] = new Vector(matrix.Vectors[i]);
            }
        }

        public int GetLength()
        {
            return N;
        }

        public int GeyWidth()
        {
            return M;
        }

        public Vector GetVector(int index)
        {
            return Vectors[index];
        }







        public override string ToString()
        {
            string tmpString = null;

            for(int i = 0; i < M; i++)
            {
                tmpString = tmpString + "{ ";
                
                for(int j = 0; j < N; j++)
                {
                    tmpString += Convert.ToString(Vectors[i].Components[j]);

                    if(j != N - 1)
                    {
                        tmpString += ", ";
                    }
                }

                if (i != M - 1)
                {
                    tmpString = tmpString + "}, \n";
                }
                else
                {
                    tmpString = tmpString + "} ";
                }
            }

            //tmpString = "{" + tmpString + "}";

            return tmpString;
        }

    }
}
