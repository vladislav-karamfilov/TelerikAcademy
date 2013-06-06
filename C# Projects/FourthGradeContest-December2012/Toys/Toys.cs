using System;

class Toys
{
    static void Main()
    {
        string[] input = Console.ReadLine().Split(' ');
        ushort s = ushort.Parse(input[0]);
        ushort s1 = ushort.Parse(input[1]);
        ushort s2 = ushort.Parse(input[2]);
        ushort s3 = ushort.Parse(input[3]);
        ushort temp = Math.Min(s1, s2);
        ushort min = Math.Min(temp, s3);
        Console.WriteLine(s / min);
    }
}
