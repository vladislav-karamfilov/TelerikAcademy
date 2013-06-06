using System;

class TenRandomNumbers
{
    static Random randomGenerator = new Random();
    static void Main()
    {
        string decorationLine = new string('-', 80);
        Console.Write(decorationLine);
        Console.WriteLine("***Generating ten random numbers in the range [100, 200]***");
        Console.Write(decorationLine);
        Console.WriteLine("The generated random numbers are: ");
        for (int count = 0; count < 10; count++)
        {
            int randomNumber = randomGenerator.Next(100, 201);
            Console.WriteLine(randomNumber);
        }
    }
}
