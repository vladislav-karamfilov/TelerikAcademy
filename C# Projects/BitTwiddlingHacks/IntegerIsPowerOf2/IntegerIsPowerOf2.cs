using System;

class IntegerIsPowerOf2
{
    static void Main()
    {
        uint a = 8192;
        bool check = (a & (a - 1)) == 0;
        Console.WriteLine(check);
    }
}
