using System;

class BitOneInAPositionOfAnInteger
{
    static void Main()
    {
        string decorationLine = new string('-', 80);
        Console.Write(decorationLine);
        Console.WriteLine("***Checking if the bit of an integer in a chosen\nposition (counting from 0) has a value 1***");
        Console.Write(decorationLine);
        Console.Write("Enter an integer: ");
        int number = int.Parse(Console.ReadLine());
        Console.Write("Enter in which position you want to test the bit: ");
        byte bitPosition = byte.Parse(Console.ReadLine());
        int mask = 1 << bitPosition;
        bool bitOne = ((number & mask) != 0);
        Console.WriteLine("The bit is 1? -> {0}.", bitOne);
    }
}
