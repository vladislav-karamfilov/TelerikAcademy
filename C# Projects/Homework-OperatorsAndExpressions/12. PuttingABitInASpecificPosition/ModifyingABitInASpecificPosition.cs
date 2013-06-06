using System;

class ModifyingABitInASpecificPosition
{
    static void Main()
    {
        string decorationLine = new string('-', 80);
        Console.Write(decorationLine);
        Console.WriteLine("***Modifying the value of a bit in a specific position of an integer number***");
        Console.Write(decorationLine);
        Console.Write("Enter an integer: ");
        int number = int.Parse(Console.ReadLine());
        Console.Write("Enter the value of the bit (0 or 1): ");
        byte bitValue = byte.Parse(Console.ReadLine());
        Console.Write("Enter the position of the bit you want to modify (max 31): ");
        byte bitPosition = byte.Parse(Console.ReadLine());
        if (bitValue == 0)
        {
            int mask = ~(1 << bitPosition);
            number &= mask;  
        }
        else
        {
            int mask = 1 << bitPosition;
            number |= mask;
        }
        Console.WriteLine("After modifying bit {0} with {1} the value of the initial integer now is: {2}.", bitPosition, bitValue, number);
    }
}
