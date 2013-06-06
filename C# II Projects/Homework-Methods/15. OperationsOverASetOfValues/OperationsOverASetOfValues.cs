using System;

class OperationsOverASetOfValues
{
    static void Main()
    {
        string decorationLine = new string('-', 80);
        Console.Write(decorationLine);
        Console.WriteLine("***Calculating minimum, maximum, average, sum and product of a given set \nof values of any number type***");
        Console.Write(decorationLine);
        Console.WriteLine("The example set is from real numbers {-12.23, 5, 64.43, 21.27, -11.1}.");
        Console.WriteLine("You can change it from the source code!");
        Console.WriteLine("Minimum: " + Minimum(-12.23, 5, 64.43, 21.27, -11.1));
        Console.WriteLine("Maximum: " + Maximum(-12.23, 5, 64.43, 21.27, -11.1));
        Console.WriteLine("Average: " + Average(-12.23, 5, 64.43, 21.27, -11.1));
        Console.WriteLine("Sum: " + Sum(-12.23, 5, 64.43, 21.27, -11.1));
        Console.WriteLine("Product: " + Product(-12.23, 5, 64.43, 21.27, -11.1));
    }

    static T Minimum<T>(params T[] set)
    {
        dynamic min = set[0];
        for (int index = 1; index < set.GetLength(0); index++)
        {
            if (min > set[index])
            {
                min = set[index];
            }
        }
        return min;
    }

    static T Maximum<T>(params T[] set)
    {
        dynamic max = set[0];
        for (int index = 1; index < set.GetLength(0); index++)
        {
            if (set[index] > max)
            {
                max = set[index];
            }
        }
        return max;
    }

    static T Average<T>(params T[] set)
    {
        int elements = set.GetLength(0);
        dynamic sum = Sum(set);
        return sum / elements;
    }

    static T Sum<T>(params T[] set)
    {
        dynamic sum = set[0];
        for (int index = 1; index < set.GetLength(0); index++)
        {
            sum += set[index];
        }
        return sum;
    }

    static T Product<T>(params T[] set)
    {
        dynamic product = set[0];
        for (int index = 1; index < set.GetLength(0); index++)
        {
            product *= set[index];
        }
        return product;
    }
}
