using System;

class NNestedLoops
{
    static int[] currentLoopConfiguration;
    static int n;

    static void Main()
    {
        string decorationLine = new string('-', Console.WindowWidth);
        Console.Write(decorationLine);
        Console.WriteLine("***Simulating execution of N nested loops from 1 to N***");
        Console.Write(decorationLine);

        Console.Write("Enter N: ");
        n = int.Parse(Console.ReadLine());
        currentLoopConfiguration = new int[n];
        
        GenerateLoopConfigurations(n - 1);
    }

    static void GenerateLoopConfigurations(int current)
    {
        if (current == -1)
        {
            PrintCurrentLoopConfiguration(currentLoopConfiguration);
        }
        else
        {
            for (int i = 1; i <= n; i++)
            {
                currentLoopConfiguration[current] = i;
                GenerateLoopConfigurations(current - 1);
            }
        }
    }

    static void PrintCurrentLoopConfiguration(int[] currentLoopConfiguration)
    {
        for (int i = 0; i < n; i++)
        {
            Console.Write("{0} ", currentLoopConfiguration[i]);
        }

        Console.WriteLine();
    }
}
