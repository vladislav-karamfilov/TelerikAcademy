using System;

class Program
{
    static void Main()
    {
        ushort member = 0;
        ulong number = 2;
        while (true)
        {
            bool prime = true;
            for (ulong i = 2; i <= Math.Sqrt(number); i++)
            {
                if (number % i == 0)
                {
                    prime = false;
                    break;
                }
            }
            if (prime)
            {
                member++;
                if (member == 10001)
                {
                    Console.WriteLine(number);
                    return;
                }
            }
            number++;
        }
    }
}
