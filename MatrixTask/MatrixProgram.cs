using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VectorTask.Academits.Dorosh;

namespace MatrixTask.Academits.Dorosh
{
    class MatrixProgram
    {
        static void Main(string[] args)
        {
            /*double[,] array =   {
                                    { 1, 2, 3},
                                    { 4, 5, 6},
                                    { 7, 8, 9},
                                    { 10, 11, 12}
                                };

            Matrix matrix = new Matrix(array);
            */

            Vector vector1 = new Vector(6.3);

            Vector[] vectors = new Vector[]
            {
                new Vector(1.1, 2.2),
                new Vector(3.3, 4.4),
                new Vector(5.5, 6.6),
                vector1
            };

            Matrix matrix = new Matrix(vectors);

            Matrix matrix1 = new Matrix(matrix);

            //vector1.SetComponent(0, 0);
            //vector1.SetComponent(1, 0);

            Console.Write(matrix1.ToString());

            Console.ReadKey();
        }
    }
}
