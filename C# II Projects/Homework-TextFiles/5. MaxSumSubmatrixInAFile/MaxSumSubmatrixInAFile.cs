using System;
using System.Text;
using System.IO;

class MaxSumSubmatrixInAFile
{
    static int[,] matrix;

    static void Main()
    {
        string decorationLine = new string('-', 80);
        Console.Write(decorationLine);
        Console.Write("***Reading a file containing a square matrix and finding the maximal sum \nof area of size 2 x 2 in it. ");
        Console.WriteLine("The result is written in a new file.***");
        Console.Write(decorationLine);
        // All files are in bin\Debug directory of the project
        try
        {
            string inputFile = "Matrix.txt";
            string resultFile = "Result.txt";
            Console.WriteLine("The matrix is in the file '{0}'.", inputFile);
            GetMatrixFromFile(inputFile);
            int maxSum = FindMaxSum();
            PrintResultInFile(resultFile, maxSum);
            Console.WriteLine("You can find the maximal sum in file '{0}'.",resultFile);            
        }
        catch (FileNotFoundException fileException)
        {
            Console.WriteLine("File '{0}' cannot be found.", fileException.FileName);
        }
        catch (ArgumentException argException)
        {
            Console.WriteLine(argException.Message);
        }
        catch
        {
            Console.WriteLine("Fatal error occured!");
        }
    }

    static void GetMatrixFromFile(string inputFile)
    {
        StreamReader reader = new StreamReader(inputFile, Encoding.GetEncoding("UTF-8"));
        using (reader)
        {
            int n = int.Parse(reader.ReadLine()); // n -> number of rows and columns
            matrix = new int[n, n];
            for (int row = 0; row < n; row++)
            {
                string[] rowNumbers = reader.ReadLine().Split(' ');
                for (int col = 0; col < n; col++)
                {
                    matrix[row, col] = int.Parse(rowNumbers[col]);
                }
            }
        }
    }

    static int FindMaxSum()
    {
        int maxSum = int.MinValue;
        for (int row = 0; row < matrix.GetLength(0) - 1; row++)
        {
            for (int col = 0; col < matrix.GetLength(1) - 1; col++)
            {
                int currentSum = matrix[row, col] + matrix[row, col + 1] + matrix[row + 1, col] + matrix[row + 1, col + 1];
                if (currentSum > maxSum)
                {
                    maxSum = currentSum;
                }
            }
        }
        return maxSum;
    }

    static void PrintResultInFile(string resultFile, int maxSum)
    {
        StreamWriter writer = new StreamWriter(resultFile, false, Encoding.GetEncoding("UTF-8"));
        using (writer)
        {
            writer.WriteLine(maxSum);
        }
    }
}
