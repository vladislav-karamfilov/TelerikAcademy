using System;
using System.Threading;
using System.Globalization;

class ComparingTwoArrays
{
    static void Main()
    {
        Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;
        string decorationLine = new string('-', 80);
        Console.Write(decorationLine);
        Console.WriteLine("***Reading two arrays of numbers and comparing them element by element***");
        Console.Write(decorationLine);
        // Getting the length of the arrays
        Console.Write("Enter how many elements the two arrays have: ");
        int length = int.Parse(Console.ReadLine());
        // Filling the arrays
        Console.WriteLine("---The elements of the first array---");
        double[] array1 = new double[length];
        for (int index = 0; index < length; index++)
        {
            Console.Write("Enter a number: ");
            array1[index] = double.Parse(Console.ReadLine().Replace(',', '.'));
        }
        Console.WriteLine("---The elements of the second array---");
        double[] array2 = new double[length];
        for (int index = 0; index < length; index++)
        {
            Console.Write("Enter a number: ");
            array2[index] = double.Parse(Console.ReadLine().Replace(',', '.'));
        }
        // Sorting the arrays
        Array.Sort(array1);
        Array.Sort(array2);
        // Comparing the arrays
        for (int index = 0; index < length; index++)
        {
            if (array1[index] != array2[index])
            {
                Console.WriteLine("The arrays are not equal!");
                return;
            }
        }
        Console.WriteLine("The arrays are equal!");
    }
}
