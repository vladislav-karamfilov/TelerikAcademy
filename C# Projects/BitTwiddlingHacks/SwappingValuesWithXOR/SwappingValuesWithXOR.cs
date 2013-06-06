using System;

class SwappingValuesWithXOR
{
    static void Main()
    {
        int a = 312;
        int b = 232;
        Console.WriteLine("Initial a: " + Convert.ToString(a, 2).PadLeft(32, '0'));
        Console.WriteLine("Initial b: " + Convert.ToString(b, 2).PadLeft(32, '0'));
        a ^= b;
        Console.WriteLine(Convert.ToString(a, 2).PadLeft(32, '0'));
        b ^= a;
        Console.WriteLine(Convert.ToString(b, 2).PadLeft(32, '0'));
        a ^= b;
        Console.WriteLine(Convert.ToString(a, 2).PadLeft(32, '0'));
        Console.WriteLine(a + " " + b);
    }
}
