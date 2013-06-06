using System;

class Advertisement
{
    static void Main()
    {
        byte a = 0;
        byte t = 0;
        for (byte i = 0; i < 3; i++)
        {
            string input = Console.ReadLine();
            foreach (char symbol in input)
            {
                if (symbol == 'A')
                {
                    a++;
                }
                if (symbol == 'T')
                {
                    t++;
                }
            }
        }
        if (a >= 1 && t >= 2)
        {
            byte answer = 0;
            while (a > 0 && t > 1)
            {
                answer++;
                a--;
                t -= 2;
            }
            Console.WriteLine(answer);
        }
        else
        {
            Console.WriteLine(0);
        }
    }
}
