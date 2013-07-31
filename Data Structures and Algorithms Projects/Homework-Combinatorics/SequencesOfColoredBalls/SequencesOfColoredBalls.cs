using System;
using System.Collections.Generic;
using System.Numerics;

class SequencesOfColoredBalls
{
    static void Main()
    {
        string inputLine = Console.ReadLine();
        Dictionary<char, int> coloredBalls = new Dictionary<char, int>();
        foreach (char symbol in inputLine)
        {
            if (coloredBalls.ContainsKey(symbol))
            {
                coloredBalls[symbol]++;
            }
            else
            {
                coloredBalls[symbol] = 1;
            }
        }

        BigInteger nominatorFactorial = GetFactorial(inputLine.Length);
        BigInteger denominatorFactorial = 1;
        foreach (var coloredBall in coloredBalls)
        {
            denominatorFactorial *= GetFactorial(coloredBall.Value);
        }

        Console.WriteLine(nominatorFactorial / denominatorFactorial);
    }

    static BigInteger GetFactorial(int number)
    {
        BigInteger factorial = 1;
        for (int i = 1; i <= number; i++)
        {
            factorial *= i;
        }

        return factorial;
    }
}