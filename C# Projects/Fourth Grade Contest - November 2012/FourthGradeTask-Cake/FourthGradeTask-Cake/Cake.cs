using System;

class Cake
{
    static void Main()
    {
        string[] input = Console.ReadLine().Split(' ');
        int n = int.Parse(input[0]);
        int m = int.Parse(input[1]);
        int cakes = n / m;
        if (n % m != 0)
        {
            cakes++;
        }
        Console.WriteLine(cakes);
    }
}
