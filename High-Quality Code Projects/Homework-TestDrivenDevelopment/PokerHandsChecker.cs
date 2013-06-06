namespace Poker
{
    using System;
    using System.Linq;
    using System.Collections.Generic;

    public class PokerHandsChecker : IPokerHandsChecker
    {
        private const int CardsInAHand = 5;

        public bool IsValidHand(IHand hand)
        {
            if (hand == null)
            {
                return false;
            }

            if (hand.Cards.Count != CardsInAHand)
            {
                return false;
            }

            for (int i = 0; i < CardsInAHand - 1; i++)
            {
                for (int j = i + 1; j < CardsInAHand; j++)
                {
                    if (hand.Cards[i].Face.Equals(hand.Cards[j].Face) &&
                        hand.Cards[i].Suit.Equals(hand.Cards[j].Suit))
                    {
                        return false;
                    }
                }
            }

            return true;
        }

        public bool IsStraightFlush(IHand hand)
        {
            if (IsValidHand(hand))
            {
                return IsStraight(hand) && IsFlush(hand);
            }
            else
            {
                throw new InvalidOperationException("Cannot test invalid hand!");
            }
        }

        public bool IsFourOfAKind(IHand hand)
        {
            if (IsValidHand(hand))
            {
                return CheckForSameCardFaces(hand.Cards, 4);
            }
            else
            {
                throw new InvalidOperationException("Cannot test invalid hand!");
            }
        }

        public bool IsFullHouse(IHand hand)
        {
            if (IsValidHand(hand))
            {
                IList<ICard> cards = hand.Cards.OrderBy(card => (int)card.Face).ToList();

                if (cards[0].Face == cards[2].Face)
                {
                    return CheckForTwoCardFaceSets(cards, 3);
                }
                else
                {
                    return CheckForTwoCardFaceSets(cards, 2);
                }
            }
            else
            {
                throw new InvalidOperationException("Cannot test invalid hand!");
            }
        }

        public bool IsFlush(IHand hand)
        {
            if (IsValidHand(hand))
            {
                for (int i = 0; i < CardsInAHand - 1; i++)
                {
                    if (hand.Cards[i].Suit != hand.Cards[i + 1].Suit)
                    {
                        return false;
                    }
                }

                return true;
            }
            else
            {
                throw new InvalidOperationException("Cannot test invalid hand!");
            }
        }

        public bool IsStraight(IHand hand)
        {
            if (IsValidHand(hand))
            {
                IList<ICard> cards = hand.Cards.OrderBy(card => (int)card.Face).ToList();

                if (cards[CardsInAHand - 1].Face == CardFace.Ace)
                {
                    if (cards[0].Face == CardFace.Two)
                    {
                        return cards[1].Face == CardFace.Three &&
                               cards[2].Face == CardFace.Four &&
                               cards[3].Face == CardFace.Five;
                    }
                }

                return AreConsecutiveCards(cards);
            }
            else
            {
                throw new InvalidOperationException("Cannot test invalid hand!");
            }
        }

        public bool IsThreeOfAKind(IHand hand)
        {
            if (IsValidHand(hand))
            {
                return CheckForSameCardFaces(hand.Cards, 3);
            }
            else
            {
                throw new InvalidOperationException("Cannot test invalid hand!");
            }
        }

        public bool IsTwoPair(IHand hand)
        {
            if (IsValidHand(hand))
            {
                if (!IsFullHouse(hand))
                {
                    IList<ICard> cards = hand.Cards.OrderBy(card => (int)card.Face).ToList();

                    if (cards[0].Face == cards[1].Face && cards[2].Face == cards[3].Face)
                    {
                        return true;
                    }

                    if (cards[0].Face == cards[1].Face && cards[3].Face == cards[4].Face)
                    {
                        return true;
                    }

                    if (cards[1].Face == cards[2].Face && cards[3].Face == cards[4].Face)
                    {
                        return true;
                    }

                    return false;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                throw new InvalidOperationException("Cannot test invalid hand!");
            }
        }

        public bool IsOnePair(IHand hand)
        {
            if (IsValidHand(hand))
            {
                if (!IsFullHouse(hand) && !IsStraight(hand) &&
                    !IsFourOfAKind(hand) && !IsThreeOfAKind(hand) &&
                    !IsStraightFlush(hand) && !IsTwoPair(hand))
                {
                    IList<ICard> cards = hand.Cards.OrderBy(card => (int)card.Face).ToList();
                    for (int i = 0; i < cards.Count - 1; i++)
                    {
                        if (cards[i].Face == cards[i + 1].Face)
                        {
                            return true;
                        }
                    }
                }

                return false;
            }
            else
            {
                throw new InvalidOperationException("Cannot test invalid hand!");
            }
        }

        public bool IsHighCard(IHand hand)
        {
            if (IsValidHand(hand))
            {
                if (IsFlush(hand) || IsFourOfAKind(hand) ||
                    IsFullHouse(hand) || IsOnePair(hand) ||
                    IsStraight(hand) || IsStraightFlush(hand) ||
                    IsThreeOfAKind(hand) || IsTwoPair(hand))
                {
                    return false;
                }

                return true;
            }
            else
            {
                throw new InvalidOperationException("Cannot test invalid hand!");
            }
        }

        public int CompareHands(IHand firstHand, IHand secondHand)
        {
            throw new NotImplementedException();
        }

        private bool CheckForTwoCardFaceSets(IList<ICard> cards, int pivotIndex)
        {
            for (int i = 0; i < pivotIndex - 1; i++)
            {
                if (cards[i].Face != cards[i + 1].Face)
                {
                    return false;
                }
            }

            for (int i = pivotIndex; i < CardsInAHand - 1; i++)
            {
                if (cards[i].Face != cards[i + 1].Face)
                {
                    return false;
                }
            }

            return true;
        }

        private bool CheckForSameCardFaces(IList<ICard> cards, int requiredSameCardFaces)
        {
            for (int i = 0; i < cards.Count - 1; i++)
            {
                int sameCardFaces = 1;
                for (int j = i + 1; j < cards.Count; j++)
                {
                    if (cards[i].Face == cards[j].Face)
                    {
                        sameCardFaces++;

                        if (sameCardFaces == requiredSameCardFaces)
                        {
                            return true;
                        }
                    }
                }
            }

            return false;
        }

        private bool AreConsecutiveCards(IList<ICard> cards)
        {
            for (int i = 0; i < cards.Count - 1; i++)
            {
                int currentCardFace = (int)cards[i].Face;
                int nextCardFace = (int)cards[i + 1].Face;
                if ((currentCardFace + 1) != nextCardFace)
                {
                    return false;
                }
            }

            return true;
        }
    }
}
