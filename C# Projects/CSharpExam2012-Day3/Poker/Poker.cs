using System;

class Poker
{
    static void Main()
    {
        int[] cards = new int[5];
        for (int i = 0; i < 5; i++)
        {
            string card = Console.ReadLine();
            if (card == "J")
            {
                cards[i] = 11;
            }
            else if (card == "Q")
            {
                cards[i] = 12;
            }
            else if (card == "K")
            {
                cards[i] = 13;
            }
            else if (card == "A")
            {
                cards[i] = 14;
            }
            else
	        {
                cards[i] = int.Parse(card);
        	}
        }
        Array.Sort(cards);
        if (cards[0] == cards[1] && cards[1] == cards[2] && cards[2] == cards[3] && cards[3] == cards[4])
        {
            Console.WriteLine("Impossible");
            return;
        }
        if ((cards[1] == cards[2] && cards[2] == cards[3] && cards[3] == cards[4]) || // The condition for one card being different is 
            (cards[0] == cards[1] && cards[1] == cards[2] && cards[2] == cards[3]))   // covered by the case above
        {
            Console.WriteLine("Four of a Kind");
            return;
        }
        if ((cards[0] == cards[1] && cards[1] == cards[2] && cards[3] == cards[4]) || // The condition for having two different pairs is
            (cards[0] == cards[1] && cards[2] == cards[3] && cards[3] == cards[4]))   // covered by the first case
        {
            Console.WriteLine("Full House");
            return;
        }
        if ((cards[0] == cards[1] && cards[1] == cards[2]) ||       // The condition for the other cards to be different 
            (cards[1] == cards[2] && cards[2] == cards[3]) ||       // is not necessary because the cases above excludes it
            (cards[2] == cards[3] && cards[3] == cards[4]))         // (if the other two are equal or the five are equal are above)
        {
            Console.WriteLine("Three of a Kind");
            return;
        }
        if ((cards[0] == cards[1] && cards[2] == cards[3]) ||       // The condition the pairs are not equal is covered by the cases above.
            (cards[1] == cards[2] && cards[3] == cards[4]) ||       // The condition the one left card is not in a "Three of a Kind" is also
            (cards[0] == cards[1] && cards[3] == cards[4]))         // covered by the case above
        {
            Console.WriteLine("Two Pairs");
            return;
        }
        if ((cards[0] == cards[1]) || (cards[1] == cards[2]) ||     // The other conditions are covered by the cases above
            (cards[2] == cards[3]) || (cards[3] == cards[4]))
        {
            Console.WriteLine("One Pair");
            return;
        }
        if ((cards[1] == cards[0] + 1 && cards[2] == cards[0] + 2 && cards[3] == cards[0] + 3 && cards[4] == cards[0] + 4) ||//Four consecutive
            (cards[0] == 2 && cards[1] == 3 && cards[2] == 4 && cards[3] == 5 && cards[4] == 14))      // The case A-2-3-4-5
        {
            Console.WriteLine("Straight");
            return;
        }
        Console.WriteLine("Nothing");
    }
}
