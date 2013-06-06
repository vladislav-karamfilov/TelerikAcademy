using System;

class DancingBits
{
    static void Main()
    {
        ushort k = ushort.Parse(Console.ReadLine()); // The number of identical bits == a "dancing bits" sequence
        ushort n = ushort.Parse(Console.ReadLine());
        string concatenation = null;
        uint number = 0U;
        for (ushort counter = 0; counter < n; counter++)
        {
            number = uint.Parse(Console.ReadLine());
            concatenation += Convert.ToString(number, 2);
        }
        ushort answer = 0; // The number of all "dancing bits" sequences
        ushort count = 1;
        for (int i = 0; i < concatenation.Length - 1; i++)
        {
            if (concatenation[i] == concatenation[i + 1])
            {
                count++;
            }
            else
            {
                if (count == k)
                {
                    answer++;
                }
                count = 1;
            }
        }
        if (count == k) // Checking if the last bit is in a "dancing bits" sequence
        {
            answer++;
        }
        Console.WriteLine(answer);
    }
}
