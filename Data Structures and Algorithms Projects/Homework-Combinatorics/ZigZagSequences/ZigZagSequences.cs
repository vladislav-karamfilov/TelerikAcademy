using System;

class ZigZagSequences
{
    static int n;
    static int k;
    static bool[] used;
    static int zigZagSequencesCount;
    
    static void Main()
    {
        string[] nAndK = Console.ReadLine().Split(' ');
        n = int.Parse(nAndK[0]);
        k = int.Parse(nAndK[1]);

        used = new bool[n];

        PutBigger(0, -1);

        Console.WriteLine(zigZagSequencesCount);
    }

    static void PutBigger(int index, int current)
    {
        if (index == k)
        {
            zigZagSequencesCount++;
            return;
        }

        if (current == n - 1)
        {
            return;
        }

        for (int i = current + 1; i < n; i++)
        {
            if (!used[i])
            {
                used[i] = true;
                PutSmaller(index + 1, i);
                used[i] = false;
            }
        }
    }

    static void PutSmaller(int index, int current)
    {
        if (index == k)
        {
            zigZagSequencesCount++;
            return;
        }

        if (current == 0)
        {
            return;
        }

        for (int i = current - 1; i >= 0; i--)
        {
            if (!used[i])
            {
                used[i] = true;
                PutBigger(index + 1, i);
                used[i] = false;
            }
        }
    }
}
