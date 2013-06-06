using System;

class DeclaringVariables
{
    static void Main()
    {
        string decorationLine = new string('-', 80);
        Console.Write(decorationLine);
        Console.WriteLine("***Declaring 5 variables and assigning them with some values***");
        Console.Write(decorationLine);
        ushort number1 = 52130;
        sbyte number2 = -115;
        int number3 = 4825932;
        byte number4 = 97;
        short number5 = -10000;
        Console.WriteLine("All the numbers are {0}, {1}, {2}, {3}, {4}.", number1, number2, number3, number4, number5);
    }
}
