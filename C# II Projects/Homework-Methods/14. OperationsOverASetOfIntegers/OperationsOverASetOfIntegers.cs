using System;
using System.Numerics;

class OperationsOverASetOfIntegers
{
    static void Main()
    {
        string decorationLine = new string('-', 80);
        Console.Write(decorationLine);
        Console.WriteLine("***Calculating minimum, maximum, average, sum and product of a given \nset of integers***");
        Console.Write(decorationLine);
        Console.WriteLine("The used set is {-1, 421, 214, -2, 66, -12, -3, -13}. You can change it \nfrom the source code!\n");
        Console.WriteLine("Minimum: " + Minimum(-1, 421, 214, -2, 66, -12, -3, -13));
        Console.WriteLine("Maximum: " + Maximum(-1, 421, 214, -2, 66, -12, -3, -13));
        Console.WriteLine("Average: " + Average(-1, 421, 214, -2, 66, -12, -3, -13));
        Console.WriteLine("Sum: " + Sum(-1, 421, 214, -2, 66, -12, -3, -13));
        Console.WriteLine("Product: " + Product(-1, 421, 214, -2, 66, -12, -3, -13));
    }

    static int Minimum(params int[] set)
    {
        int min = int.MaxValue;
        foreach (int element in set)
        {
            if (min > element)
            {
                min = element;
            }
        }
        return min;
    }

    static int Maximum(params int[] set)
    {
        int max = int.MinValue;
        foreach (int element in set)
        {
            if (element > max)
            {
                max = element;
            }
        }
        return max;
    }

    static double Average(params int[] set)
    {
        int elements = set.GetLength(0);
        long sum = Sum(set);
        return (double)sum / elements;
    }

    static long Sum(params int[] set)
    {
        long sum = 0;
        foreach (int element in set)
        {
            sum += element;
        }
        return sum;
    }

    static BigInteger Product(params int[] set)
    {
        BigInteger product = 1;
        foreach (int element in set)
        {
            product *= element;
        }
        return product;
    }
}
