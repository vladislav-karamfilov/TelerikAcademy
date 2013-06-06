using System;

class Marks
{
    static void Main()
    {
        string[] input1 = Console.ReadLine().Split(' ');
        byte n = byte.Parse(input1[0]);
        byte m = byte.Parse(input1[1]);
        string[] marks = new string[n];
        char[] maxMarks = new char[m];
        for (byte i = 0; i < n; i++)
        {
            marks[i] = Console.ReadLine();
        }
        bool[] champions = new bool[n];
        for (byte j = 0; j < m; j++)
        {
            for (byte i = 0; i < n; i++)
            {
                if (marks[i][j] > maxMarks[j])
                {
                    maxMarks[j] = marks[i][j];
                }
            }
            for (byte k = 0; k < n; k++)
            {
                if (marks[k][j] == maxMarks[j])
                {
                    champions[k] = true;
                }
            }
        }
        byte answer = 0;
        foreach (bool champion in champions)
        {
            if (champion == true)
            {
                answer++;
            }
        }
        Console.WriteLine(answer);
    }
}
