using System;

class AbsoluteValue
{
    static void Main()
    {
        const int a = -17;
        int mask = a >> (sizeof(int) * 8 - 1);
        uint aAbs = (uint)((a ^ mask) - mask);
        Console.WriteLine("{0}'s absolute value is {1}", a, aAbs);
    }
}
