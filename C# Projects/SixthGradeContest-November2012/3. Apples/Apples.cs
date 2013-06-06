using System;

class Apples
{
    static void Main()
    {
        string[] input = Console.ReadLine().Split(' ');
        uint y = uint.Parse(input[0]);
        uint k = uint.Parse(input[1]);
        uint n = uint.Parse(input[2]);
        uint x = 1;
        byte flag = 0;
        while (x + y <= n)
        {
            if ((x + y) % k == 0)
            {
                flag = 1;
                Console.Write(x + " ");
                x += k;
            }
            else
            {
                x++;
            }
        }
        if (flag == 0)
        {
            Console.WriteLine(-1);
        }
        else
        {
            Console.WriteLine();
        }
    }
}