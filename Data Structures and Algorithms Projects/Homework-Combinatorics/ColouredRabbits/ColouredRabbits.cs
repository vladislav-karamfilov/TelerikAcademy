using System;
using System.Collections.Generic;

class ColouredRabbits
{
    static Dictionary<int, int> answers = new Dictionary<int, int>();

    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        int count = 0;
        for (int i = 0; i < n; i++)
        {
            int current = int.Parse(Console.ReadLine());
            if (answers.ContainsKey(current))
            {
                answers[current]++;
            }
            else
            {
                answers.Add(current, 1);
            }

            if (answers[current] == current + 1)
            {
                count += answers[current];
                answers[current] = 0;
            }
        }

        foreach (var answer in answers)
        {
            if (answer.Value != 0)
            {
                count += answer.Key + 1;
            }
        }

        Console.WriteLine(count);
    }
}
