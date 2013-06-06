namespace Poker
{
    using System;

    public class Card : ICard
    {
        public CardFace Face { get; private set; }
        public CardSuit Suit { get; private set; }

        public Card(CardFace face, CardSuit suit)
        {
            this.Face = face;
            this.Suit = suit;
        }

        public override string ToString()
        {
            string face = string.Empty;
            if ((int)this.Face <= 10)
            {
                face = ((int)this.Face).ToString();
            }
            else
            {
                char firstLetterOfFace = this.Face.ToString()[0];
                face = firstLetterOfFace.ToString();
            }

            switch (this.Suit)
            {
                case CardSuit.Clubs:
                    return face + "♣";
                case CardSuit.Diamonds:
                    return face + "♦";
                case CardSuit.Hearts:
                    return face + "♥";
                case CardSuit.Spades:
                    return face + "♠";
                default: throw new InvalidOperationException("Invalid card suit: " + this.Suit);
            }
        }
    }
}
