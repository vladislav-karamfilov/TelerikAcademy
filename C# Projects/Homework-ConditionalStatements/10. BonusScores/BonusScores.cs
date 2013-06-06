using System;

class BonusScores
{
    static void Main()
    {
        string decorationLine = new string('-', 80);
        Console.Write(decorationLine);
        Console.WriteLine("***Applying bonus scores to an entered score from 1 to 9***");
        Console.Write(decorationLine);
        Console.Write("Enter a digit from 1 to 9: ");
        byte initialScore;
        if (!byte.TryParse(Console.ReadLine(), out initialScore) || (initialScore > 9) || (initialScore < 0))
        {
            Console.WriteLine("Invalid input! The value is not a digit!");
            return;
        }
        int score = 0;
        switch (initialScore)
        {
            case 1: 
            case 2:
            case 3:
                score = initialScore * 10;
                Console.WriteLine("The score is {0}.", score);
                break;
            case 4:
            case 5:
            case 6:
                score = initialScore * 100;
                Console.WriteLine("The score is {0}.", score);
                break;
            case 7:
            case 8:
            case 9:
                score = initialScore * 1000;
                Console.WriteLine("The score is {0}.", score);
                break;
            default:
                Console.WriteLine("Error! The digit must be greater than 0!");
                break;
        }
    }
}
