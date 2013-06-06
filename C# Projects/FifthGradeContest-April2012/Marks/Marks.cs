using System;

class Marks
{
    static void Main()
    {
        byte n = byte.Parse(Console.ReadLine());
        string[] stringMarks = Console.ReadLine().Split(' ');
        byte[] marks = new byte[n];
        byte minMark = byte.MaxValue;
        byte maxMark = byte.MinValue;
        decimal sum = 0;
        for (byte i = 0; i < n; i++)
        {
            marks[i] = byte.Parse(stringMarks[i]);
            if (marks[i] > maxMark)
            {
                maxMark = marks[i];
            }
            if (marks[i] < minMark)
            {
                minMark = marks[i];
            }
            sum += marks[i];
        }
        Console.WriteLine(Math.Round((sum - maxMark - minMark) / (n - 2)));
    }
}