using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
// TODO: Implement!!!
class ConsoleJustification
{
    static void Main()
    {
        int lines = int.Parse(Console.ReadLine());
        int width = int.Parse(Console.ReadLine());
        StringBuilder allWords = new StringBuilder();
        string[] currentLineWords = null;
        char[] separator = { ' ' };
        for (int i = 0; i < lines; i++)
        {
            currentLineWords = Console.ReadLine().Split(separator, StringSplitOptions.RemoveEmptyEntries);
            foreach (string word in currentLineWords)
            {
                allWords.Append(word);
            }
        }
        //foreach (var item in allWords)
        //{
        //    Console.WriteLine("'{0}'", item);
        //}
        StringBuilder justifiedText = new StringBuilder(Justify(allWords.ToString(), width));
        Console.WriteLine(justifiedText);
    }


    static String Justify(String s, Int32 count)
    {
        if (count <= 0)
            return s;

        Int32 middle = s.Length / 2;
        Dictionary<Int32, Int32> spaceOffsetsToParts = new Dictionary<Int32, Int32>();
        String[] parts = s.Split(' ');
        for (Int32 partIndex = 0, offset = 0; partIndex < parts.Length; partIndex++)
        {
            spaceOffsetsToParts.Add(offset, partIndex);
            offset += parts[partIndex].Length + 1; // +1 to count space that was removed by Split
        }
        foreach (var pair in spaceOffsetsToParts.OrderBy(entry => Math.Abs(middle - entry.Key)))
        {
            count--;
            if (count < 0)
                break;
            parts[pair.Value] += ' ';
        }
        return String.Join(" ", parts);
    }
}
