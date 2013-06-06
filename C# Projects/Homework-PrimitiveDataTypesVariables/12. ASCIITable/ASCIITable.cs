using System;
using System.Text;

class ASCIITable
{
    static void Main()
    {
        Console.OutputEncoding = Encoding.Unicode;
        string decorationLine = new string('-', 80);
        Console.Write(decorationLine);
        Console.WriteLine("***Printing the extended ASCII table of characters with their decimal codes***");
        Console.Write(decorationLine);
        for (int i = 0; i < 256; i++)
        {
            Console.WriteLine("Code {0}: {1}", i, (char)i);
        }
    }
}

