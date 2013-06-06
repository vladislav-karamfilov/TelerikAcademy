using System;

class TenMembersOfASequence
{
    static void Main()
    {
        string decorationLine = new string('-', 80);
        Console.Write(decorationLine);
        Console.WriteLine("***Printing the first ten members of the sequence 2, -3, 4, -5, 6, -7...***");
        Console.Write(decorationLine);
        for (int i = 2; i < 12; i++)
        {
            if (i % 2 == 0)
            {
                Console.Write("{0}\t", i);
            }
            else
            {
                Console.Write("{0}\t", i * (-1));
            }
        }
    }
}
