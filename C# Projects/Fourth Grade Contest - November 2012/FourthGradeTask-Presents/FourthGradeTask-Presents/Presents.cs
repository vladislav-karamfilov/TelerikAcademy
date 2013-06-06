using System;

class Presents
{
    static void Main()
    {
        string[] input = Console.ReadLine().Split(' ');
        int m = int.Parse(input[0]);
        int c = int.Parse(input[1]);
        int k = int.Parse(input[2]);
        m *= k;
        c *= k;
        int p = c / 100;
        if (p != 0)
        {
            m += p;
            c -= p * 100;
        }
        Console.WriteLine(m + " " + c);
    }
}
