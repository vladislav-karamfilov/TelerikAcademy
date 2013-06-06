using System;
using System.Collections.Generic;
using System.Text;

class GenomeDecoder
{
    static void Main()
    {
        string[] format = Console.ReadLine().Split(' ');
        int n = int.Parse(format[0]);
        int m = int.Parse(format[1]);
        string encodedGenome = Console.ReadLine();
        List<string> decodedGenome = new List<string>();
        StringBuilder genomeLine = new StringBuilder();
        StringBuilder repeatTimes = new StringBuilder();
        int lines = 1;
        foreach (char symbol in encodedGenome)
        {
            if (char.IsDigit(symbol))
            {
                repeatTimes.Append(symbol);
            }
            else
            {
                int repeat = 1;
                if (repeatTimes.Length != 0)
                {
                    repeat = int.Parse(repeatTimes.ToString());
                    repeatTimes.Clear();
                }
                while (repeat != 0)
                {
                    if (genomeLine.Length == n)
                    {
                        genomeLine.Append('\n');
                        decodedGenome.Add(genomeLine.ToString());
                        genomeLine.Clear();
                        lines++;
                    }
                    genomeLine.Append(symbol);
                    repeat--;
                }
            }
        }
        // Check if there's something left in the buffer
        if (genomeLine.Length != 0)
        {
            decodedGenome.Add(genomeLine.ToString());
        }
        int biggestLineDigits = lines.ToString().Length; // Needed for formatting the output
        lines = 1;
        foreach (var item in decodedGenome)
        {
            StringBuilder genomeFullLine = new StringBuilder();
            genomeFullLine.Append(new string(' ', (biggestLineDigits - lines.ToString().Length)) + lines++ + " ");
            for (int i = 0; i < item.Length; i++)
            {
                if (i != 0 && i % m == 0 && item[i] != '\n') // Skipping the last and the first symbols
                {
                    genomeFullLine.Append(' ');
                }
                genomeFullLine.Append(item[i]);
            }
            Console.Write(genomeFullLine);
        }
        Console.WriteLine();
    }
}
