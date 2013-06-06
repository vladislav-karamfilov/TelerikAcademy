using System;

class Carpets
{
    static void Main()
    {
        byte n = byte.Parse(Console.ReadLine());
        int slashesInside = -1;
        byte between = 0;
        for (int i = 1; i <= n / 2; i++)
        {
            Console.Write(new string('.', n / 2 - i));
            Console.Write("/");
            if (i % 2 == 1)
            {
                slashesInside++;
                for (int j = slashesInside; j > 0; j--)
                {
                    Console.Write(" ");
                    Console.Write("/");
                }
                for (int j = 0; j < slashesInside; j++)
                {
                    Console.Write("\\");
                    Console.Write(" ");
                }
            }
            else
            {
                int temp = between / 2;
                while (temp > 0)
                {
                    if (temp % 2 == 1)
                    {
                        Console.Write(" ");
                    }
                    else
                    {
                        Console.Write("/");
                    }
                    temp--;
                }
                temp = between / 2;
                while (temp > 0)
                {
                    if (temp % 2 == 0)
                    {
                        Console.Write("\\");
                    }
                    else
                    {
                        Console.Write(" ");
                    }
                    temp--;
                }
            }
            Console.Write("\\");
            Console.WriteLine(new string('.', n / 2 - i));
            between += 2;
        }
        between -= 2;
        for (int i = n / 2; i >= 1; i--)
        {
            Console.Write(new string('.', n / 2 - i));
            Console.Write("\\");
            if (i % 2 == 1)
            {
                for (int j = slashesInside; j > 0; j--)
                {
                    Console.Write(" ");
                    Console.Write("\\");
                }
                for (int j = 0; j < slashesInside; j++)
                {
                    Console.Write("/");
                    Console.Write(" ");
                }
                slashesInside--;
            }
            else
            {
                int temp = between / 2;
                while (temp > 0)
                {
                    if (temp % 2 == 1)
                    {
                        Console.Write(" ");
                    }
                    else
                    {
                        Console.Write("\\");
                    }
                    temp--;
                }
                temp = between / 2;
                while (temp > 0)
                {
                    if (temp % 2 == 0)
                    {
                        Console.Write("/");
                    }
                    else
                    {
                        Console.Write(" ");
                    }
                    temp--;
                }
            }
            Console.Write("/");
            Console.WriteLine(new string('.', n / 2 - i));
            between -= 2;
        }
    }
}
// ...../\.....
// ..../  \....
// .../ /\ \...
// ../ /  \ \..
// ./ / /\ \ \.
// / / /  \ \ \
// \ \ \  / / /
// .\ \ \/ / /.
// ..\ \  / /..
// ...\ \/ /...
// ....\  /....
// .....\/.....
