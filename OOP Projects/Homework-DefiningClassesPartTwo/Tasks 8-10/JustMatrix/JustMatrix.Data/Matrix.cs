using System;
using System.Text;

namespace JustMatrix.Data
{
    public class Matrix<T>
        where T : struct, IComparable, IFormattable, IConvertible, IComparable<T>, IEquatable<T>
    {
        #region Instance fields
        private T[,] matrix;
        private int rows;
        private int columns;
        #endregion

        #region Properties
        public int Rows
        {
            get { return this.rows; }
        }
        public int Columns
        {
            get { return this.columns; }
        }        
        #endregion

        #region Indexer
        public T this[int row, int column]
        {
            get { return this.matrix[row, column]; }
            set { this.matrix[row, column] = value; }
        }
        #endregion

        #region Constructors
        public Matrix(int rows, int columns)
        {
            if (rows <= 0 || columns <= 0)
            {
                throw new ArgumentOutOfRangeException("Matrix rows and columns must be positive numbers!");
            }
            this.rows = rows;
            this.columns = columns;
            this.matrix = new T[rows, columns];
        }
        #endregion

        #region Methods
        public static Matrix<T> operator +(Matrix<T> matrix1, Matrix<T> matrix2)
        {
            if (matrix1.rows != matrix2.rows || matrix1.columns != matrix2.columns)
            {
                throw new InvalidOperationException("The rows/columns of the first matrix must be equal to the rows/columns of the second one!");
            }
            Matrix<T> resultMatrix = new Matrix<T>(matrix1.rows, matrix1.columns);
            for (int row = 0; row < matrix1.rows; row++)
            {
                for (int col = 0; col < matrix1.columns; col++)
                {
                    resultMatrix[row, col] = (dynamic)matrix1[row, col] + matrix2[row, col];
                }
            }
            return resultMatrix;
        }
        public static Matrix<T> operator -(Matrix<T> matrix1, Matrix<T> matrix2)
        {
            if (matrix1.rows != matrix2.rows || matrix1.columns != matrix2.columns)
            {
                throw new InvalidOperationException("The rows/columns of the first matrix must be equal to the rows/columns of the second one!");
            }
            else
            {
                Matrix<T> resultMatrix = new Matrix<T>(matrix1.rows, matrix1.columns);
                for (int row = 0; row < matrix1.rows; row++)
                {
                    for (int col = 0; col < matrix1.columns; col++)
                    {
                        resultMatrix[row, col] = (dynamic)matrix1[row, col] - matrix2[row, col];
                    }
                }
                return resultMatrix;
            }
        }
        public static Matrix<T> operator *(Matrix<T> matrix1, Matrix<T> matrix2)
        {
            if (matrix1.columns != matrix2.rows)
            {
                throw new InvalidOperationException("The columns of the first matrix must be equal to the rows of the second one!");
            }
            Matrix<T> resultMatrix = new Matrix<T>(matrix1.rows, matrix2.columns);
            for (int rowMatrix1 = 0; rowMatrix1 < matrix1.rows; rowMatrix1++)
            {
                for (int colMatrix2 = 0; colMatrix2 < matrix2.columns; colMatrix2++)
                {
                    for (int colMatrix1 = 0; colMatrix1 < matrix1.columns; colMatrix1++) // ColMatrix1 == RowMatrix2
                    {
                        resultMatrix[rowMatrix1, colMatrix2] += (dynamic)matrix1[rowMatrix1, colMatrix1] * matrix2[colMatrix1, colMatrix2];
                    }
                }
            }
            return resultMatrix;
        }
        public static bool operator true(Matrix<T> matrix)
        {
            for (int row = 0; row < matrix.rows; row++)
            {
                for (int col = 0; col < matrix.columns; col++)
                {
                    if (matrix[row, col].Equals(default(T)))
                    {
                        return false;
                    }
                }
            }
            return true;
        }
        public static bool operator false(Matrix<T> matrix)
        {
            for (int row = 0; row < matrix.rows; row++)
            {
                for (int col = 0; col < matrix.columns; col++)
                {
                    if (matrix[row, col].Equals(default(T)))
                    {
                        return true;
                    }
                }
            }
            return false;
        }
        public static bool operator !(Matrix<T> matrix)
        {
            if (matrix)
            {
                return false;
            }
            return true;
        }
        public override string ToString()
        {
            StringBuilder result = new StringBuilder();
            for (int row = 0; row < this.rows; row++)
            {
                for (int col = 0; col < this.columns; col++)
                {
                    result.Append(this.matrix[row, col] + " ");
                }
                result.Append(Environment.NewLine);
            }
            result.Remove(result.Length - 1, 1);
            return result.ToString();
        }
        #endregion
    }
}
