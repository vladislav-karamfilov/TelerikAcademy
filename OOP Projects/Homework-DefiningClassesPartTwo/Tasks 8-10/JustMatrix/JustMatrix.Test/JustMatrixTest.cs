using System;
using JustMatrix.Data;

namespace JustMatrix.Test
{
    class JustMatrixTest
    {
        static readonly Random randomGenerator = new Random();

        static void Main()
        {
            string decorationLine = new string('-', 80);
            Console.Write(decorationLine);
            Console.WriteLine("***Performing some operations over matrices of numbers***");
            Console.Write(decorationLine);

            Console.WriteLine("---Creating and filling a matrix with integer numbers---");
            Matrix<int> matrix1 = new Matrix<int>(3, 5);
            for (int row = 0; row < matrix1.Rows; row++)
            {
                for (int col = 0; col < matrix1.Columns; col++)
                {
                    matrix1[row, col] = randomGenerator.Next(0, 1000);
                }
            }
            Console.WriteLine(matrix1.ToString());

            Console.WriteLine("\n---Accessing some elements in the matrix with their indices---");
            Console.WriteLine("The element at row 2 column 1 is: " + matrix1[2, 1]);
            Console.WriteLine("The element at row 0 column 4 is: " + matrix1[0, 4]);

            Console.WriteLine("\n---Creating and filling a second matrix with integer numbers---");
            Matrix<int> matrix2 = new Matrix<int>(3, 5);
            for (int row = 0; row < matrix2.Rows; row++)
            {
                for (int col = 0; col < matrix2.Columns; col++)
                {
                    matrix2[row, col] = randomGenerator.Next(0, 100);
                }
            }
            Console.WriteLine(matrix2.ToString());

            Console.WriteLine("\n---Adding the two matrices---");
            Matrix<int> additionResult = matrix1 + matrix2;
            Console.WriteLine(additionResult.ToString());

            Console.WriteLine("\n---Subtracting the two matrices---");
            Matrix<int> subtractionResult = matrix1 - matrix2;
            Console.WriteLine(subtractionResult.ToString());

            // If we multiply matrix1 and matrix2 we will get exception
            //Console.WriteLine((matrix1 * matrix2).ToString());

            Console.WriteLine("\n---Multiplication of matrices---");
            Console.WriteLine("First generating a valid matrix to be multiplied with the first one");
            Matrix<int> matrix3 = new Matrix<int>(5, 4);
            for (int row = 0; row < matrix3.Rows; row++)
            {
                for (int col = 0; col < matrix3.Columns; col++)
                {
                    matrix3[row, col] = randomGenerator.Next(0, 100);
                }
            }
            Console.WriteLine(matrix3.ToString());
            Console.WriteLine("Now printing the result of the multiplication:\n" + (matrix1 * matrix3).ToString());

            //matrix2 = new Matrix<int>(3, 5); // Making all elements of matrix2 zeroes

            Console.WriteLine("\n---Checking if the second matrix contains non-zero elements---");
            if (matrix2)
            {
                Console.WriteLine("The matrix contains non-zero elements!");
            }
            else
            {
                Console.WriteLine("The matrix doesn't contain non-zero elements!");
            }
        }
    }
}