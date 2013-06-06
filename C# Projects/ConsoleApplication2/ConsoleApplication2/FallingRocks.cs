using System;
using System.Threading;

class FallingRocks
{
    static int dwarfPosition = 0;
    static int rockPositionX = 0;
    static int rockPositionY = 0;
    static int points = 0;
    static Random randomGenerator = new Random();
    static char[] rocks = {'^', '@', '*', '&', '+', '%', '$', '#', '!', '.', ';'};

    static void RemoveScrollBars()
    {
        Console.BufferHeight = Console.WindowHeight;
        Console.BufferWidth = Console.WindowWidth;
    }

    static void SetInitialPositions()
    {
        dwarfPosition = Console.WindowWidth / 2 - 4;
    }

    static void DrawDwarf()
    {
        PrintAtPosition(dwarfPosition, Console.WindowHeight - 1, '(');
        PrintAtPosition(dwarfPosition + 1, Console.WindowHeight - 1, '-');
        PrintAtPosition(dwarfPosition + 2, Console.WindowHeight - 1, 'O');
        PrintAtPosition(dwarfPosition + 3, Console.WindowHeight - 1, '-');
        PrintAtPosition(dwarfPosition + 4, Console.WindowHeight - 1, ')');
    }

    static void PrintAtPosition(int x, int y, char symbol)
    {
        Console.SetCursorPosition(x, y);
        Console.Write(symbol);
    }

    static void GenerateFallingRocksAndDensity()
    {
        int kindOfRock = randomGenerator.Next(0, 11);
        int numberOfFallingRocks = randomGenerator.Next(1, 6);
        int densityOfFallingRocks = randomGenerator.Next(0, 80);
        for (int i = 0; i < densityOfFallingRocks; i++)
            {
                PrintRocksAtPosition(rockPositionX + i, rockPositionY, rocks[kindOfRock], i);
            }
    }

    static void PrintRocksAtPosition(int x, int y, char symbol, int densityOfRocks)
    {
        Console.SetCursorPosition(x, y);
        for (int spaces = 0; spaces < densityOfRocks; spaces++)
        {
            Console.Write(" ");
        }
        Console.Write(symbol);
    }

    static void RocksFall()
    {
        if (rockPositionY < Console.WindowHeight - 1)
        {
            rockPositionY++;
        }
    }

    static void DrawRocks()
    {
        GenerateFallingRocksAndDensity();
        //RocksFall();
    }

    static void MoveDwarfRight()
    {
        if (dwarfPosition < Console.WindowWidth - 6)
	    {
            dwarfPosition++;
        }
    }

    static void MoveDwarfLeft()
    {
        if (dwarfPosition > 0)
        {
            dwarfPosition--;
        }
    }

    static void PrintResult()
    {
        Console.SetCursorPosition(0, 0);
        Console.Write("---Game over... Your score is {0}!---", points);
    }

    static void Main()
    {
        RemoveScrollBars();
        SetInitialPositions();
        while (true)
        {
            if (Console.KeyAvailable == true)
            {
                ConsoleKeyInfo keyPressed = Console.ReadKey();
                if (keyPressed.Key == ConsoleKey.LeftArrow)
                {
                    MoveDwarfLeft();
                }
                if (keyPressed.Key == ConsoleKey.RightArrow)
                {
                    MoveDwarfRight();
                }
            }
            Console.Clear();
            DrawDwarf();
            DrawRocks();
            //PrintResult();
            Thread.Sleep(500);
        }
    }
}