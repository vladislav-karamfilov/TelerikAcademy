using System;

class UKFlag
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        int dotsBetween = (n - 3) / 2;
        for (int i = 0; i < n / 2; i++)
        {
            Console.Write(new string('.', i));
            Console.Write(new string('\\', 1));
            Console.Write(new string('.', dotsBetween));
            Console.Write(new string('|', 1));
            Console.Write(new string('.', dotsBetween));
            Console.Write(new string('/', 1));
            Console.WriteLine(new string('.', i));
            dotsBetween--;
        }
        Console.Write(new string('-', n / 2));
        Console.Write("*");
        Console.WriteLine(new string('-', n / 2));
        dotsBetween = 0;
        for (int i = n / 2 - 1; i >= 0; i--)
        {
            Console.Write(new string('.', i));
            Console.Write(new string('/', 1));
            Console.Write(new string('.', dotsBetween));
            Console.Write(new string('|', 1));
            Console.Write(new string('.', dotsBetween));
            Console.Write(new string('\\', 1));
            Console.WriteLine(new string('.', i));
            dotsBetween++;
        }
    }
}
