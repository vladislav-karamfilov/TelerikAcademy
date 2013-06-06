using System;

class ClassMatrix
{
    static void Main() 
    {
        string decorationLine = new string('-', 80);
        Console.Write(decorationLine);
        Console.WriteLine("***Realizing class Matrix of integers with some functionality***");
        Console.WriteLine("---Enter two matrices and choose to add, subtract or multiply them---");
        Console.Write(decorationLine);
        // Enter the first matrix
        Console.Write("Enter how many rows the first matrix has: ");
        uint rowsMatrix1 = uint.Parse(Console.ReadLine());
        Console.Write("Enter how many columns the first matrix has: ");
        uint colsMatrix1 = uint.Parse(Console.ReadLine());
        Matrix matrix1 = new Matrix(rowsMatrix1, colsMatrix1);
        for (uint row = 0; row < rowsMatrix1; row++)
        {
            for (uint col = 0; col < colsMatrix1; col++)
            {
                Console.Write("Enter the value at row {0} column {1}: ", row + 1, col + 1);
                matrix1[row, col] = int.Parse(Console.ReadLine());
            }
        }
        // Enter the second matrix
        Console.Write("Enter how many rows the second matrix has: ");
        uint rowsMatrix2 = uint.Parse(Console.ReadLine());
        Console.Write("Enter how many columns the second matrix has: ");
        uint colsMatrix2 = uint.Parse(Console.ReadLine());
        Matrix matrix2 = new Matrix(rowsMatrix2, colsMatrix2);
        for (uint row = 0; row < rowsMatrix2; row++)
        {
            for (uint col = 0; col < colsMatrix2; col++)
            {
                Console.Write("Enter the value at row {0} column {1}: ", row + 1, col + 1);
                matrix2[row, col] = int.Parse(Console.ReadLine());
            }
        }
        // Choices
        string choice = null;
        do
        {
            Console.Write("\nEnter \"add\" or \"subtract\" or \"multiply\" to perform an operation \nor \"exit\" to exit: ");
            choice = Console.ReadLine();
            // Addition
            if (choice == "add")
            {
                Matrix addition = matrix1 + matrix2;
                Console.WriteLine("The result from the addition is: ");
                Console.WriteLine(addition.ToString());
            }
            // Subtraction
            else if (choice == "subtract")
            {
                Matrix subtraction = matrix1 - matrix2;
                Console.WriteLine("The result from the subtraction is: ");
                Console.WriteLine(subtraction.ToString());
            }
            // Multiplication
            else if (choice == "multiply")
            {
                Matrix multipliation = matrix1 * matrix2;
                Console.WriteLine("The result from the multiplication is: ");
                Console.WriteLine(multipliation.ToString());
            }
            else
            {
                Console.WriteLine("Invalid input!");
            }
        }
        while (choice != "exit");
    }
}

class Matrix
{
    // Instance fields
    private uint rows;
    private uint columns;
    private int[,] matrix;
    // Constructor
    public Matrix(uint rows, uint columns)
    {
        this.rows = rows;
        this.columns = columns;
        matrix = new int[rows, columns];
    }
    // Getters
    public uint Rows
    {
        get
        {
            return rows;
        }
    }

    public uint Columns
    {
        get
        {
            return columns;
        }
    }
    // Overloading operators +, - and *
    public static Matrix operator +(Matrix matrix1, Matrix matrix2)
    {
        if (matrix1.Rows != matrix2.Rows || matrix1.Columns != matrix2.Columns)
        {
            throw new InvalidOperationException("The rows/columns of the first matrix must be equal to the rows/columns of the second one!");
        }
        else
        {
            Matrix resultMatrix = new Matrix(matrix1.Rows, matrix1.columns);
            for (uint row = 0; row < matrix1.rows; row++)
            {
                for (uint col = 0; col < matrix1.columns; col++)
                {
                    resultMatrix[row, col] = matrix1[row, col] + matrix2[row, col];
                }
            }
            return resultMatrix;
        }
    }

    public static Matrix operator -(Matrix matrix1, Matrix matrix2)
    {
        if (matrix1.Rows != matrix2.Rows || matrix1.Columns != matrix2.Columns)
        {
            throw new InvalidOperationException("The rows/columns of the first matrix must be equal to the rows/columns of the second one!");
        }
        else
        {
            Matrix resultMatrix = new Matrix(matrix1.rows, matrix1.columns);
            for (uint row = 0; row < matrix1.rows; row++)
            {
                for (uint col = 0; col < matrix1.columns; col++)
                {
                    resultMatrix[row, col] = matrix1[row, col] - matrix2[row, col];
                }
            }
            return resultMatrix;
        }
    }

    public static Matrix operator *(Matrix matrix1, Matrix matrix2)
    {
        if (matrix1.Columns != matrix2.Rows)
        {
            throw new InvalidOperationException("The columns of the first matrix must be equal to the rows of the second one!");
        }
        Matrix resultMatrix = new Matrix(matrix1.Rows, matrix2.columns);
        for (uint rowMatrix1 = 0; rowMatrix1 < matrix1.rows; rowMatrix1++)
        {
            for (uint colMatrix2 = 0; colMatrix2 < matrix2.columns; colMatrix2++)
            {
                for (uint colMatrix1 = 0; colMatrix1 < matrix1.columns; colMatrix1++) // ColMatrix1 == RowMatrix2
                {
                    resultMatrix[rowMatrix1, colMatrix2] += matrix1[rowMatrix1, colMatrix1] * matrix2[colMatrix1, colMatrix2]; //
                }
            }
        }
        return resultMatrix;
    }
    // Overriding ToString() method for appropriate print
    public override string ToString()
    {
        string result = null;
        for (uint row = 0; row < rows; row++)
        {
            for (uint col = 0; col < columns; col++)
            {
                result += (matrix[row, col] + " ");
            }
            if (row != rows - 1)
            {
                result += "\n";
            }
        }
        return result;
    }
    // Indexer for accessing the matrix content
    public int this[uint row, uint col]
    {
        get
        {
            return matrix[row, col];
        }
        set
        {
            matrix[row, col] = value;
        }
    }
}
