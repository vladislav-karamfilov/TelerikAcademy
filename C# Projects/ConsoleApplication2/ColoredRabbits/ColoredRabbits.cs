using System;
// Doesn't work...
class ColoredRabbits
{
    static void Main()
    {
        byte n = byte.Parse(Console.ReadLine());
        int[] rabbits = new int[n];
        for (byte i = 0; i < n; i++)
        {
            rabbits[i] = int.Parse(Console.ReadLine());
        }
        int answer = 0;
        byte sorts = 1;
        Array.Sort(rabbits);
        bool flag = false;
        for (int i = 0; i < n - 1; i++)
        {
            if (rabbits[i] != rabbits[i + 1])
            {
                sorts++;
            }
            if (rabbits[i] == 1)
            {
                flag = true;
            }
            answer += rabbits[i];
        }
        answer += rabbits[n - 1];
        if (flag)
        {
            answer++;
        }
        if (n == 1)
        {
            Console.WriteLine(1);
        }
        else
        {
            Console.WriteLine(answer - sorts);
        }
    }
}
