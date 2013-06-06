using System;

class SmallestMiltiple
{
    static void Main()
    {
        int i = 2;
        while (true)
        {
            bool answer = true;
            for (int j = 2; j < 20; j++)
            {
                if (i % j != 0)
                {
                    answer = false;
                    break;
                }
            }
            if (answer)
            {
                Console.WriteLine(i);
                return;
            }
            i += 2;
        }
    }
}

//2520 is the smallest number that can be divided by each of the numbers from 1 to 10 without any remainder.

//What is the smallest positive number that is evenly divisible by all of the numbers from 1 to 20?

