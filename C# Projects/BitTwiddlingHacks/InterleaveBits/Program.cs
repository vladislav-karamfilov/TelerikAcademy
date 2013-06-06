using System;

class Program
{
    static void Main()
    {
        ushort x = 37; // x = 100101  =  1 0 0 1 0 1
        ushort y = 21; // y = 010101  = 0 1 0 1 0 1
        uint interleaved = 0; // interleaved = 011000110011
        for (int i = 0; i < sizeof(ushort) * 8; i++)
        {
            interleaved |= (x & 1U << i) << i | (y & 1U << i) << (i + 1);
        }
        Console.WriteLine(interleaved);
    }
}
