using System;
using System.Collections.Generic;

class FirstFiftyElementsOfASequence
{
    static void Main()
    {
        string decorationLine = new string('-', Console.WindowWidth);
        Console.Write(decorationLine);
        Console.WriteLine("***Printing the first 50 members of the sequence S1 = N; S2 = S1 + 1;");
        Console.WriteLine("S3 = 2*S1 + 1; S4 = S1 + 2; S5 = S2 + 1; S6 = 2*S2 + 1; S7 = S2 + 2***");
        Console.Write(decorationLine);

        Console.Write("Enter N: ");
        double n = double.Parse(Console.ReadLine());

        const int MembersCount = 50;

        Queue<double> queue = new Queue<double>();
        queue.Enqueue(n);

        Console.Write("The first 50 members of the sequence are: ");
        for (int i = 0; i < MembersCount; i++)
        {
            double currentMember = queue.Dequeue();
            Console.Write(currentMember + " ");

            queue.Enqueue(currentMember + 1);
            queue.Enqueue(2 * currentMember + 1);
            queue.Enqueue(currentMember + 2);
        }

        Console.WriteLine();
    }
}
