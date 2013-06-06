using System;

class TelerikLogo
{
    static void Main()
    {
        int x = int.Parse(Console.ReadLine());
        int z = (x + 1) / 2;
        int rows = 3 * x - 2;
        int dots = x / 2;
        int dotsBetween = 1;
        int dots1 = 3 * x - 2 * dots - 4;
        for (int i = 0; i < z; i++)
		{
            if (i == 0)
            {
                Console.Write(new string('.', dots));
                Console.Write("*");
                Console.Write(new string('.', dots1));
                Console.Write("*");
                Console.WriteLine(new string('.', dots));
                dots--;
                dots1 -= 2;
            }
            else
            {
                Console.Write(new string('.', dots));
                Console.Write("*");
                Console.Write(new string('.', dotsBetween));
                Console.Write("*");
                Console.Write(new string('.', dots1));
                Console.Write("*");
                Console.Write(new string('.', dotsBetween));
                Console.Write("*");
                Console.WriteLine(new string('.', dots));
                dots1-=2;
                dotsBetween += 2;
                dots--;
            }
		}
        while (dots1 > 0)
        {
            Console.Write(new string('.', dotsBetween));
            Console.Write("*");
            Console.Write(new string('.', dots1));
            Console.Write("*");
            Console.WriteLine(new string('.', dotsBetween));
            dots1 -= 2;
            dotsBetween++;
        }
        Console.Write(new string('.', 2 * x - z - 1));
        Console.Write("*");
        Console.WriteLine(new string('.', 2 * x - z - 1));
        dots1 = 1;
        dotsBetween--;
        for (int i = 0; i < x - 1; i++)
        {
            Console.Write(new string('.', dotsBetween));
            Console.Write("*");
            Console.Write(new string('.', dots1));
            Console.Write("*");
            Console.WriteLine(new string('.', dotsBetween));
            dots1 += 2;
            dotsBetween--;
        }
        dots1 -= 2;
        dotsBetween ++;
        for (int i = 0; i < x - 2; i++)
        {
            dotsBetween++;
            dots1 -= 2;
            Console.Write(new string('.', dotsBetween));
            Console.Write("*");
            Console.Write(new string('.', dots1));
            Console.Write("*");
            Console.WriteLine(new string('.', dotsBetween));
        }
        Console.Write(new string('.', 2 * x - z - 1));
        Console.Write("*");
        Console.WriteLine(new string('.', 2 * x - z - 1));
    }
}
