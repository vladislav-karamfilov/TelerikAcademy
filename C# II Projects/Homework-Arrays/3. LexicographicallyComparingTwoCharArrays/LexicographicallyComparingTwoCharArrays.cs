using System;

class LexicographicallyComparingTwoCharArrays
{
    static void Main()
    {
        string decorationLine = new string('-', 80);
        Console.Write(decorationLine);
        Console.WriteLine("***Reading two char arrays and comparing them lexicographically***");
        Console.Write(decorationLine);
        // Getting the length of the first array and filling it
        Console.Write("Enter how many symbols the first array has: ");
        int length1 = int.Parse(Console.ReadLine());
        char[] array1 = new char[length1];
        for (int index = 0; index < length1; index++)
        {
            Console.Write("Enter a symbol: ");
            array1[index] = char.Parse(Console.ReadLine());
        }
        // Getting the length of the second array and filling it if length1 == length2
        Console.Write("Enter how many symbols the second array has: ");
        int length2 = int.Parse(Console.ReadLine());
        if (length1 != length2)
        {
            Console.WriteLine("The arrays cannot be equal because they have different number of elements!");
            return;
        }
        char[] array2 = new char[length2];
        for (int index = 0; index < length2; index++)
        {
            Console.Write("Enter a character: ");
            array2[index] = char.Parse(Console.ReadLine());
        }
        // Comaparing the arrays
        bool equalArrays = true;
        for (int index = 0; index < length1; index++)
        {
            if (array1[index] != array2[index])
            {
                equalArrays = false;
                break;
            }
        }
        if (equalArrays)
        {
            Console.WriteLine("The arrays are lexicographically equal!");
        }
        else
        {
            Console.WriteLine("The arrays are not lexicographically equal!");
        }
    }
}
