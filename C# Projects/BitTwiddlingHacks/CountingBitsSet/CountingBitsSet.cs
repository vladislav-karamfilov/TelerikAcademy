using System;
// This is counting the bits with value 1
class CountingBitsSet
{
    static void Main()
    {
        uint number = 255;
        uint totalBitsSet;
        for (totalBitsSet = 0; number != 0; totalBitsSet++)
        {
            number &= number - 1; // Clear the least significant bit set
        }
        Console.WriteLine(totalBitsSet);
    }
}

