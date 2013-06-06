using System;

class BitValueInAPositionOfAnInteger
{
    static void Main()
    {
        string decorationLine = new string('-', 80);
        Console.Write(decorationLine);
        Console.WriteLine("***Checking the bit of an integer in a chosen position (counting from 0)***");
        Console.Write(decorationLine);
        Console.Write("Enter an integer: ");
        int number = int.Parse(Console.ReadLine());
        Console.Write("Enter in which position you want to see the bit (max 31): ");
        byte bitPosition = byte.Parse(Console.ReadLine());
        int mask = 1 << bitPosition;
        if ((mask & number) == 0)
        {
            Console.WriteLine("The bit in position {0} of the number {1} is 0.", bitPosition, number);
        }
        else
        {
            Console.WriteLine("The bit in position {0} of the number {1} is 1.", bitPosition, number);
        }
    }
}