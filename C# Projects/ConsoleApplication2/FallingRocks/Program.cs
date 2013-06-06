using System;
using System.Threading;
using System.Collections.Generic;

class FallingRocks
{
    static int dwarfPosition = 0;
    static uint score = 0U;
    static bool collisionDetected = false;
    static Random randomGenerator = new Random();
    static ConsoleColor[] colors = { ConsoleColor.Blue, ConsoleColor.Cyan, ConsoleColor.DarkCyan, ConsoleColor.DarkYellow, ConsoleColor.DarkGreen, 
                                     ConsoleColor.DarkMagenta, ConsoleColor.DarkRed, ConsoleColor.Magenta, ConsoleColor.White, ConsoleColor.Yellow };
    static char[] rockSymbols = { '^', '@', '*', '&', '+', '%', '$', '#', '!', '.', ';' };
    struct Rock
    {
        public int x;
        public int y;
        public char symbol;
        public ConsoleColor color;
    }
    static List<Rock> rocks = new List<Rock>();
    
    static void RemoveScrollBars()
    {
        Console.BufferHeight = Console.WindowHeight;
        Console.BufferWidth = Console.WindowWidth;
    }

    static void SetInitialDwarfPosition()
    {
        dwarfPosition = Console.WindowWidth / 2 - 2; //Setting it at the center ("- 2" comes from the length of the dwarf)
    }

    static void DrawDwarf()
    {
        PrintAtPosition(dwarfPosition, Console.WindowHeight - 1, '(', ConsoleColor.Green);
        PrintAtPosition(dwarfPosition + 1, Console.WindowHeight - 1, 'O', ConsoleColor.Green);
        PrintAtPosition(dwarfPosition + 2, Console.WindowHeight - 1, ')', ConsoleColor.Green);
    }

    static void MoveDwarfRight()
    {
        if (dwarfPosition < Console.WindowWidth - 4) // "- 4" comes from the length of the dwarf
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

    static void PrintAtPosition(int x, int y, char symbol, ConsoleColor color)
    {
        Console.SetCursorPosition(x, y);
        Console.ForegroundColor = color;
        Console.Write(symbol);
    }

    static void CreateRock()
    {
        Rock newRock = new Rock();
        int randomColor = randomGenerator.Next(0, colors.Length);
        newRock.color = colors[randomColor];
        newRock.x = randomGenerator.Next(0, Console.WindowWidth - 1);
        newRock.y = 0;
        int randomSymbol = randomGenerator.Next(0, colors.Length);
        newRock.symbol = rockSymbols[randomSymbol];
        rocks.Add(newRock);
    }

    static void DrawRocks()
    {
        int numberOfRocksOnLine = randomGenerator.Next(1, 6);
        for (int i = 0; i < numberOfRocksOnLine; i++)
        {
            CreateRock();
        }  
        foreach (Rock rock in rocks)
        {
            PrintAtPosition(rock.x, rock.y, rock.symbol, rock.color);
        }
        RocksFall();
    }

    static bool DetectCollision(Rock rock)
    {
        if (rock.y == Console.WindowHeight - 1 && rock.x >= dwarfPosition && rock.x <= dwarfPosition + 2) //"+ 2" comes from the length of the dwarf
        {
            collisionDetected = true;
            PrintAtPosition(rock.x, rock.y - 1, ' ', ConsoleColor.Red);
            PrintAtPosition(rock.x, rock.y, 'X', ConsoleColor.Red);
            return true;
        }
        return false;
    }

    static void RocksFall()
    {
        List<Rock> newRockList = new List<Rock>();
        for (int i = 0; i < rocks.Count; i++)
        {
            Rock oldRock = rocks[i];
            Rock newRock = new Rock();
            newRock.color = oldRock.color;
            newRock.symbol = oldRock.symbol;
            newRock.x = oldRock.x;
            newRock.y = oldRock.y + 1;
            if (DetectCollision(newRock) == true)
            {
                return;
            }
            else
            {
                if (newRock.y < Console.WindowHeight)
                {
                    newRockList.Add(newRock);
                }
                else
                {
                    score += 5;
                }
            }
        }
        rocks = newRockList;
    }

    static void PrintResult()
    {
        Console.SetCursorPosition(0, 0);
        Console.WriteLine("---Game over... Your score is {0}!---", score);
    }

    static void Main()
    {
        Console.Title = "***Falling Rocks V1.0*** (---by Vladislav Karamfilov---)";
        RemoveScrollBars();
        SetInitialDwarfPosition();
        while (true)
        {
            if (Console.KeyAvailable == true)
            {
                ConsoleKeyInfo keyPressed = Console.ReadKey();
                while (Console.KeyAvailable)
                {
                    Console.ReadKey(true);
                }
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
            if (collisionDetected == true)
            {
                PrintResult();
                Console.ReadLine();
                return;
            }
            Thread.Sleep(150);
        }
    }
}