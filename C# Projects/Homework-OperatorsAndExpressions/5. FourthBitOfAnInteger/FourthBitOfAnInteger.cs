using System;

class FourthBitOfAnInteger
{
    static void Main()
    {
        string decorationLine = new string('-', 80);
        Console.Write(decorationLine);
        Console.WriteLine("***Checking the fourth bit (bit 3 counting from 0) of an integer***");
        Console.Write(decorationLine);
        Console.Write("Enter an integer: ");
        int intNumber = int.Parse(Console.ReadLine());
        int mask = 8;
        bool zeroBit = ((intNumber & mask) == 0); 
        if (zeroBit == false)
        {
            Console.WriteLine("Fourth bit of {0} is 1.", intNumber);
        }
        else
        {
            Console.WriteLine("Fourth bit of {0} is 0.", intNumber);
        }
    }
}

