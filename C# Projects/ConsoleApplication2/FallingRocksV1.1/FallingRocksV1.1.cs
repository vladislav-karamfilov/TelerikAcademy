using System;
using System.Threading;
using System.Collections.Generic;

class FallingRocks
{
    static int dwarfPosition = 0;
    static uint score = 0U;
    static bool collisionDetected = false;
    static Random randomGenerator = new Random();
    static ConsoleColor[] colors = { ConsoleColor.Blue, ConsoleColor.Cyan, ConsoleColor.DarkCyan, ConsoleColor.Yellow, ConsoleColor.White, 
                                     ConsoleColor.DarkMagenta, ConsoleColor.DarkRed, ConsoleColor.Magenta, ConsoleColor.DarkYellow };
    static char[] rockSymbols = { '^', '@', '*', '&', '+', '%', '$', '#', '!', '.', ';' };
    static string blockOfRocks = null;
    static string dwarf = "(O)";
    struct Rock
    {
        public int x;
        public int y;
        public string kind;
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
        dwarfPosition = Console.WindowWidth / 2 - 2; // Setting it at the center ("- 2" comes from the length of the dwarf)
    }

    static void DrawDwarf()
    {
        PrintAtPosition(dwarfPosition, Console.WindowHeight - 1, dwarf, ConsoleColor.Green);
    }

    static void PrintAtPosition(int x, int y, string gameObject, ConsoleColor color)
    {
        Console.SetCursorPosition(x, y);
        Console.ForegroundColor = color;
        Console.Write(gameObject);
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

    static void CreateBlockOfRocks()
    {
        int numberOfRocks = randomGenerator.Next(1, 4); 
        int kindOfRocks = randomGenerator.Next(0, rockSymbols.Length);
        blockOfRocks = new string(rockSymbols[kindOfRocks], numberOfRocks);
    }

    static void CreateRock()
    {
        Rock rock = new Rock();
        CreateBlockOfRocks();
        rock.kind = blockOfRocks;
        int randomColor = randomGenerator.Next(0, colors.Length);
        rock.color = colors[randomColor];
        rock.x = randomGenerator.Next(0, Console.WindowWidth - rock.kind.Length);
        rock.y = 0;
        rocks.Add(rock);
    }

    static void DrawRocks()
    {
        int numberOfRocksOnLine = randomGenerator.Next(1, 4);
        for (int i = 0; i < numberOfRocksOnLine; i++)
        {
            CreateRock();
        }
        foreach (Rock rock in rocks)
        {
            PrintAtPosition(rock.x, rock.y, rock.kind, rock.color);
        }
        RocksFall();
    }

    static void RocksFall()
    {
        List<Rock> newRockList = new List<Rock>();
        for (int i = 0; i < rocks.Count; i++)
        {
            Rock oldRock = rocks[i];
            Rock newRock = new Rock();
            newRock.color = oldRock.color;
            newRock.kind = oldRock.kind;
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

    static bool DetectCollision(Rock rock)
    {
        if (rock.y == Console.WindowHeight - 1)
        {
            if (rock.x >= dwarfPosition && rock.x <= dwarfPosition + 2) // "+ 2" comes from the length of the dwarf
            {
                collisionDetected = true;
                string afterCollision = new string(' ', rock.kind.Length);
                PrintAtPosition(rock.x, rock.y - 1, afterCollision, ConsoleColor.Red);
                PrintAtPosition(dwarfPosition, rock.y, "XXX", ConsoleColor.Red);
                return true;
            }
            else if (rock.x < dwarfPosition && rock.x + rock.kind.Length - 1 >= dwarfPosition)
            {
                collisionDetected = true;
                string afterCollision = new string(' ', rock.kind.Length);
                PrintAtPosition(rock.x, rock.y - 1, afterCollision, ConsoleColor.Red);
                PrintAtPosition(dwarfPosition, rock.y, "XXX", ConsoleColor.Red);
                return true;
            }
        }
        return false;
    }

    static void PrintResult()
    {
        Console.SetCursorPosition(0, 0);
        Console.WriteLine("---Game over... Your score is {0}!---", score);
    }

    static void Main()
    {
        Console.Title = "***Falling Rocks V2.0*** (---by Vladislav Karamfilov---)";
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