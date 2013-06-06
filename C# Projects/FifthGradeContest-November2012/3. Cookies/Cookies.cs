using System;

class Cookies
{
    static void Main()
    {
        string[] input = Console.ReadLine().Split(' ');
        byte n = byte.Parse(input[0]);
        byte k = byte.Parse(input[1]);
        if ((n - k) >= (n / 2))
        {
            Console.WriteLine(n - k);
        }
        else
        {
            Console.WriteLine(n / 2);
        }
    }
}
