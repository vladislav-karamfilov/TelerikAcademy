using System;

class CardNamesFromAStandardDeck
{
    static void Main()
    {
        string decorationLine = new string('-', 80);
        Console.Write(decorationLine);
        Console.WriteLine("***Printing all card names from a standard deck of 52 cards (without jokers)***");
        Console.Write(decorationLine);
        string[] suits = { "Clubs", "Diamonds", "Hearts", "Spades" };
        foreach (string suit in suits)
        {
            for (int card = 0; card < 13; card++)
            {
                switch (card)
                {
                    case 1:
                        Console.WriteLine("2 of {0}", suit);
                        break;
                    case 2:
                        Console.WriteLine("3 of {0}", suit);
                        break;
                    case 3:
                        Console.WriteLine("4 of {0}", suit);
                        break;
                    case 4:
                        Console.WriteLine("5 of {0}", suit);
                        break;
                    case 5:
                        Console.WriteLine("6 of {0}", suit);
                        break;
                    case 6:
                        Console.WriteLine("7 of {0}", suit);
                        break;
                    case 7:
                        Console.WriteLine("8 of {0}", suit);
                        break;
                    case 8:
                        Console.WriteLine("9 of {0}", suit);
                        break;
                    case 9:
                        Console.WriteLine("10 of {0}", suit);
                        break;
                    case 10:
                        Console.WriteLine("Jack of {0}", suit);
                        break;
                    case 11:
                        Console.WriteLine("Queen of {0}", suit);
                        break;
                    case 12:
                        Console.WriteLine("King of {0}", suit);
                        break;                    
                    default:
                        Console.WriteLine("Ace of {0}", suit);
                        break;
                }
            }
            Console.WriteLine();
        }
    }
}
