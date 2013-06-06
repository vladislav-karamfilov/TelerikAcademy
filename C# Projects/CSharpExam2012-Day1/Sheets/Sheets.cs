using System;

class Sheets
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        int[] aTens = { 1024, 512, 256, 128, 64, 32, 16, 8, 4, 2, 1 };
        bool[] usedSheets = new bool[11];
        if (n > 1024)
        {
            n -= aTens[0];
            usedSheets[0] = true;
        }
        int index = 0;
        while (n > 0)
        {
            while (n - aTens[index] < 0)
            {
                index++;
            }
            n -= aTens[index];
            usedSheets[index] = true;
        }
        for (int i = 0; i < usedSheets.Length; i++)
        {
            if (!usedSheets[i])
            {
                Console.WriteLine("A" + i);
            }
        }
    }
}
