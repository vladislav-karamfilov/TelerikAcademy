using System;

class ReverseBits
{
    static void Main()
    {
        uint number = 151512532;
        Console.WriteLine(Convert.ToString(number, 2).PadLeft(32, '0'));
        uint reversed = number;
        int bits = sizeof(uint) * 8 - 1;
        for (number >>= 1; number != 0; number >>= 1)
        {
            reversed <<= 1;
            reversed |= number & 1;
            bits--;
        }
        reversed <<= bits;
        Console.WriteLine(Convert.ToString(reversed, 2).PadLeft(32, '0'));
    }
}
