using System;

class MergeBitsFrom2ValuesAccordingToMask
{
    static void Main()
    {
        uint a = 144;
        uint b = 254;
        uint mask = 15;
        uint result = a ^ ((a ^ b) & mask);
        Console.WriteLine(Convert.ToString(a, 2));
        Console.WriteLine(Convert.ToString(b, 2));
        Console.WriteLine(Convert.ToString(mask, 2));
        Console.WriteLine(Convert.ToString(result, 2) + "  " + result);
    }
}
