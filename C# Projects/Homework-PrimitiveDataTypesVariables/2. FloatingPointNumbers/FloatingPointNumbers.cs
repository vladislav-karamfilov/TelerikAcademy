using System;

class FloatingPointNumbers
{
    static void Main()
    {
        string decorationLine = new string('-', 80);
        Console.Write(decorationLine);
        Console.WriteLine("***Assigning floating-point numbers to the appropriate data type***");
        Console.Write(decorationLine);
        double doubleNumber1 = 34.567839023;
        float floatNumber1 = 12.345f;
        double doubleNumber2 = 8923.1234857;
        float floatNumber2 = 3456.091f;
        Console.WriteLine("Doubles are {0} and {1}.", doubleNumber1, doubleNumber2);
        Console.WriteLine("Floats are {0} and {1}.", floatNumber1, floatNumber2);
    }
}