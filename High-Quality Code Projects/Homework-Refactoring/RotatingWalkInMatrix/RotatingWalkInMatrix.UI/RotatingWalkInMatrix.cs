using System;
using RotatingWalkInMatrix.Common;

namespace RotatingWalkInMatrix.UI
{
    class RotatingWalkInMatrix
    {
        static void Main()
        {
            string decorationLine = new string('-', Console.WindowWidth);
            Console.Write(decorationLine);
            Console.WriteLine("***Rotating walk in matrix***");
            Console.Write(decorationLine);

            Console.Write("Enter the size of the matrix: ");
            int matrixSize = int.Parse(Console.ReadLine());

            Matrix matrix = new Matrix(matrixSize);
            matrix.Walk();
            Console.WriteLine(matrix);
        }
    }
}
