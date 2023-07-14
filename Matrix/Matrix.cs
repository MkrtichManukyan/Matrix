using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Matrix
{
    internal class Matrix
    {
        public int Rows { get; }
        public int Columns { get; }
        public int[,] Data { get; }

        public Matrix(int rows, int columns, int[,] data)
        {
            Rows = rows;
            Columns = columns;
            Data = data;
        }

        public Matrix Add(Matrix matrix)
        {
            if (Rows != matrix.Rows || Columns != matrix.Columns)
            {
                throw new ArgumentException("Մատրիցները պետք է ունենան նույն չափերը ավելացնելու համար");
            }

            int[,] result = new int[Rows, Columns];
            for (int i = 0; i < Rows; i++)
            {
                for (int j = 0; j < Columns; j++)
                {
                    result[i, j] = Data[i, j] + matrix.Data[i, j];
                }
            }

            return new Matrix(Rows, Columns, result);
        }

        public Matrix Subtract(Matrix matrix)
        {
            if (Rows != matrix.Rows || Columns != matrix.Columns)
            {
                throw new ArgumentException("Մատրիցները պետք է ունենան նույն չափերը հանելու համար:");
            }

            int[,] result = new int[Rows, Columns];
            for (int i = 0; i < Rows; i++)
            {
                for (int j = 0; j < Columns; j++)
                {
                    result[i, j] = Data[i, j] - matrix.Data[i, j];
                }
            }

            return new Matrix(Rows, Columns, result);
        }

        public Matrix Multiply(Matrix matrix)
        {
            if (Columns != matrix.Rows)
            {
                throw new ArgumentException("Բազմապատկման համար առաջին մատրիցում սյունակների թիվը պետք է հավասար լինի երկրորդ մատրիցի տողերի թվին:");
            }

            int[,] result = new int[Rows, matrix.Columns];
            for (int i = 0; i < Rows; i++)
            {
                for (int j = 0; j < matrix.Columns; j++)
                {
                    int sum = 0;
                    for (int k = 0; k < Columns; k++)
                    {
                        sum += Data[i, k] * matrix.Data[k, j];
                    }
                    result[i, j] = sum;
                }
            }

            return new Matrix(Rows, matrix.Columns, result);
        }

        public static Matrix operator +(Matrix matrix1, Matrix matrix2)
        {
            return matrix1.Add(matrix2);
        }

        public static Matrix operator -(Matrix matrix1, Matrix matrix2)
        {
            return matrix1.Subtract(matrix2);
        }

        public static Matrix operator *(Matrix matrix1, Matrix matrix2)
        {
            return matrix1.Multiply(matrix2);
        }
    }
}
