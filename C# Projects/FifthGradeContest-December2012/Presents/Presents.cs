using System;

class Presents
{
    static void Main()
    {
        string[] input1 = Console.ReadLine().Split(' ');
        byte a = byte.Parse(input1[0]);
        byte b = byte.Parse(input1[1]);
        byte x = byte.Parse(input1[2]);
        byte y = byte.Parse(input1[3]);
        byte min1 = Math.Min(a, b);
        byte min2 = Math.Min(x, y);
        byte max1 = Math.Max(a, b);
        byte max2 = Math.Max(x, y);
         
    }
}
