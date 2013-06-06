using System;

class BinaryDigitsCount
{
    static void Main()
    {
        byte b = byte.Parse(Console.ReadLine()); // The binary digit (0 or 1) which we want to count
        ushort n = ushort.Parse(Console.ReadLine()); // Numbers we want to test
        uint number = new uint();
        byte[] bBits = new byte[n];
        uint mask = 0;
        uint temp = 0;
        for (ushort index = 0; index < n; index++)
        {
            number = uint.Parse(Console.ReadLine()); // Enter the number we want to test
            temp = number;
            // Finding the number of bits that the entered number has
            byte numberOfBits = new byte();
            while (temp != 0)
            {
                numberOfBits++;
                temp /= 2;
            }
            for (byte bit = 0; bit < numberOfBits; bit++)
            {
                mask = 1U << bit; // Setting "1" to specific position
                if ((mask & number) != 0 && b == 1) // The bit is "1"
                {
                    bBits[index]++;
                }
                else if ((mask & number) == 0 && b == 0) // The bit is "0"
                {
                    bBits[index]++;
                }
            }
        }
        for (ushort index = 0; index < n; index++)
        {
            Console.WriteLine(bBits[index]);
        }
    }
}
