namespace Poker
{
    using System;
    using System.Collections.Generic;

    class PokerExample
    {
        static void Main()
        {
            ICard card = new Card(CardFace.Ace, CardSuit.Clubs);
            Console.WriteLine(card);

            IHand hand = new Hand(new List<ICard>() { 
                new Card(CardFace.Ace, CardSuit.Clubs),
                new Card(CardFace.Ace, CardSuit.Diamonds),
                new Card(CardFace.King, CardSuit.Hearts),
                new Card(CardFace.King, CardSuit.Spades),
                new Card(CardFace.Seven, CardSuit.Diamonds),
            });
            Console.WriteLine(hand);

            IPokerHandsChecker checker = new PokerHandsChecker();
            Console.WriteLine(checker.IsValidHand(hand));
            Console.WriteLine(checker.IsStraight(hand));
            Console.WriteLine(checker.IsOnePair(hand));
            Console.WriteLine(checker.IsTwoPair(hand));
            Console.WriteLine(checker.IsStraightFlush(hand));
            Console.WriteLine(checker.IsFlush(hand));
            Console.WriteLine(checker.IsFourOfAKind(hand));
            Console.WriteLine(checker.IsThreeOfAKind(hand));
            Console.WriteLine(checker.IsHighCard(hand));
            Console.WriteLine(checker.IsFullHouse(hand));
        }
    }
}
