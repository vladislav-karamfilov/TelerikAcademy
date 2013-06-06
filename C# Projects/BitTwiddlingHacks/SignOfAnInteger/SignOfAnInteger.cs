using System;

class SignOfAnInteger
{
    static void Main()
    {
        const int number = -2346;
        int sign = -(number >> (sizeof(int) * 8 - 1)); // Moving the value to see the leftmost bit
        Console.WriteLine(sign); // 1 means "-" and 0 means "+" or "0"
    }
}
