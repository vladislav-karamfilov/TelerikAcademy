namespace Poker.Tests
{
    using System;
    using System.Collections.Generic;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class PokerHandsCheckerTests
    {
        private static IPokerHandsChecker handsChecker;

        [ClassInitialize]
        public static void InitializeHandsChecker(TestContext testContext)
        {
            handsChecker = new PokerHandsChecker();
        }

        #region Valid hand tests
        [TestMethod]
        public void ValidHandTest()
        {
            IList<ICard> cards = new List<ICard>()
            {
                new Card(CardFace.King, CardSuit.Hearts),
                new Card(CardFace.Queen, CardSuit.Spades),
                new Card(CardFace.Six, CardSuit.Diamonds),
                new Card(CardFace.Jack, CardSuit.Clubs),
                new Card(CardFace.Three, CardSuit.Hearts)
            };
            Hand hand = new Hand(cards);

            bool result = handsChecker.IsValidHand(hand);
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void NotValidHandTest()
        {
            IList<ICard> cards = new List<ICard>()
            {
                new Card(CardFace.King, CardSuit.Hearts),
                new Card(CardFace.Queen, CardSuit.Spades),
                new Card(CardFace.Six, CardSuit.Diamonds),
                new Card(CardFace.Queen, CardSuit.Spades),
                new Card(CardFace.Three, CardSuit.Hearts)
            };
            Hand hand = new Hand(cards);

            bool result = handsChecker.IsValidHand(hand);
            Assert.IsFalse(result);
        }
        #endregion

        #region Flush tests
        [TestMethod]
        public void IsFlushTest()
        {
            IList<ICard> cards = new List<ICard>()
            {
                new Card(CardFace.King, CardSuit.Hearts),
                new Card(CardFace.Queen, CardSuit.Hearts),
                new Card(CardFace.Six, CardSuit.Hearts),
                new Card(CardFace.Seven, CardSuit.Hearts),
                new Card(CardFace.Three, CardSuit.Hearts)
            };
            Hand hand = new Hand(cards);

            bool result = handsChecker.IsFlush(hand);
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void IsNotFlushTest()
        {
            IList<ICard> cards = new List<ICard>()
            {
                new Card(CardFace.King, CardSuit.Diamonds),
                new Card(CardFace.Queen, CardSuit.Diamonds),
                new Card(CardFace.Six, CardSuit.Diamonds),
                new Card(CardFace.Queen, CardSuit.Spades),
                new Card(CardFace.Three, CardSuit.Diamonds)
            };
            Hand hand = new Hand(cards);

            bool result = handsChecker.IsFlush(hand);
            Assert.IsFalse(result);
        }
        #endregion

        #region Straight tests
        [TestMethod]
        public void IsStraightTestOne()
        {
            IList<ICard> cards = new List<ICard>()
            {
                new Card(CardFace.Ten, CardSuit.Diamonds),
                new Card(CardFace.Jack, CardSuit.Diamonds),
                new Card(CardFace.Queen, CardSuit.Hearts),
                new Card(CardFace.King, CardSuit.Spades),
                new Card(CardFace.Ace, CardSuit.Clubs)
            };
            Hand hand = new Hand(cards);

            bool result = handsChecker.IsStraight(hand);
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void IsStraightTestTwo()
        {
            IList<ICard> cards = new List<ICard>()
            {
                new Card(CardFace.Four, CardSuit.Spades),
                new Card(CardFace.Ace, CardSuit.Diamonds),
                new Card(CardFace.Two, CardSuit.Diamonds),
                new Card(CardFace.Five, CardSuit.Hearts),
                new Card(CardFace.Three, CardSuit.Diamonds)                
            };
            Hand hand = new Hand(cards);

            bool result = handsChecker.IsStraight(hand);
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void IsStraightTestThree()
        {
            IList<ICard> cards = new List<ICard>()
            {
                new Card(CardFace.Seven, CardSuit.Diamonds),
                new Card(CardFace.Eight, CardSuit.Hearts),
                new Card(CardFace.Nine, CardSuit.Diamonds),
                new Card(CardFace.Ten, CardSuit.Spades),
                new Card(CardFace.Jack, CardSuit.Diamonds)
            };
            Hand hand = new Hand(cards);

            bool result = handsChecker.IsStraight(hand);
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void IsNotStraightTestOne()
        {
            IList<ICard> cards = new List<ICard>()
            {
                new Card(CardFace.King, CardSuit.Diamonds),
                new Card(CardFace.Queen, CardSuit.Diamonds),
                new Card(CardFace.Jack, CardSuit.Diamonds),
                new Card(CardFace.Ten, CardSuit.Spades),
                new Card(CardFace.Eight, CardSuit.Diamonds)
            };
            Hand hand = new Hand(cards);

            bool result = handsChecker.IsStraight(hand);
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void IsNotStraightTestTwo()
        {
            IList<ICard> cards = new List<ICard>()
            {
                new Card(CardFace.Jack, CardSuit.Diamonds),
                new Card(CardFace.Queen, CardSuit.Diamonds),
                new Card(CardFace.King, CardSuit.Diamonds),
                new Card(CardFace.Ace, CardSuit.Spades),
                new Card(CardFace.Two, CardSuit.Diamonds)
            };
            Hand hand = new Hand(cards);

            bool result = handsChecker.IsStraight(hand);
            Assert.IsFalse(result);
        }
        #endregion

        #region Straight Flush tests
        [TestMethod]
        public void IsStraightFlushTestOne()
        {
            IList<ICard> cards = new List<ICard>()
            {
                new Card(CardFace.Four, CardSuit.Diamonds),
                new Card(CardFace.Five, CardSuit.Diamonds),
                new Card(CardFace.Three, CardSuit.Diamonds),
                new Card(CardFace.Ace, CardSuit.Diamonds),
                new Card(CardFace.Two, CardSuit.Diamonds)
            };
            Hand hand = new Hand(cards);

            bool result = handsChecker.IsStraightFlush(hand);
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void IsStraightFlushTestTwo()
        {
            IList<ICard> cards = new List<ICard>()
            {
                new Card(CardFace.Six, CardSuit.Spades),
                new Card(CardFace.Nine, CardSuit.Spades),
                new Card(CardFace.Seven, CardSuit.Spades),
                new Card(CardFace.Eight, CardSuit.Spades),
                new Card(CardFace.Ten, CardSuit.Spades)
            };
            Hand hand = new Hand(cards);

            bool result = handsChecker.IsStraightFlush(hand);
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void IsNotStraightFlushTestOne()
        {
            IList<ICard> cards = new List<ICard>()
            {
                new Card(CardFace.Ace, CardSuit.Diamonds),
                new Card(CardFace.Queen, CardSuit.Diamonds),
                new Card(CardFace.King, CardSuit.Diamonds),
                new Card(CardFace.Jack, CardSuit.Spades),
                new Card(CardFace.Ten, CardSuit.Diamonds)
            };
            Hand hand = new Hand(cards);

            bool result = handsChecker.IsStraightFlush(hand);
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void IsNotStraightFlushTestTwo()
        {
            IList<ICard> cards = new List<ICard>()
            {
                new Card(CardFace.Jack, CardSuit.Clubs),
                new Card(CardFace.Queen, CardSuit.Clubs),
                new Card(CardFace.Three, CardSuit.Clubs),
                new Card(CardFace.Ace, CardSuit.Clubs),
                new Card(CardFace.Two, CardSuit.Clubs)
            };
            Hand hand = new Hand(cards);

            bool result = handsChecker.IsStraightFlush(hand);
            Assert.IsFalse(result);
        }
        #endregion

        #region Four Of A Kind tests
        [TestMethod]
        public void IsFourOfAKindTestOne()
        {
            IList<ICard> cards = new List<ICard>()
            {
                new Card(CardFace.Ace, CardSuit.Diamonds),
                new Card(CardFace.Ace, CardSuit.Spades),
                new Card(CardFace.Ten, CardSuit.Diamonds),
                new Card(CardFace.Ace, CardSuit.Clubs),
                new Card(CardFace.Ace, CardSuit.Hearts)
            };
            Hand hand = new Hand(cards);

            bool result = handsChecker.IsFourOfAKind(hand);
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void IsFourOfAKindTestTwo()
        {
            IList<ICard> cards = new List<ICard>()
            {
                new Card(CardFace.Ten, CardSuit.Clubs),
                new Card(CardFace.Ten, CardSuit.Hearts),
                new Card(CardFace.Ten, CardSuit.Spades),
                new Card(CardFace.Ten, CardSuit.Diamonds),
                new Card(CardFace.Two, CardSuit.Diamonds)
            };
            Hand hand = new Hand(cards);

            bool result = handsChecker.IsFourOfAKind(hand);
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void IsNotFourOfAKindTest()
        {
            IList<ICard> cards = new List<ICard>()
            {
                new Card(CardFace.King, CardSuit.Hearts),
                new Card(CardFace.King, CardSuit.Diamonds),
                new Card(CardFace.Three, CardSuit.Spades),
                new Card(CardFace.King, CardSuit.Clubs),
                new Card(CardFace.Two, CardSuit.Spades)
            };
            Hand hand = new Hand(cards);

            bool result = handsChecker.IsFourOfAKind(hand);
            Assert.IsFalse(result);
        }
        #endregion

        #region Three Of A Kind tests
        [TestMethod]
        public void IsThreeOfAKindTestOne()
        {
            IList<ICard> cards = new List<ICard>()
            {
                new Card(CardFace.Ace, CardSuit.Diamonds),
                new Card(CardFace.Ace, CardSuit.Spades),
                new Card(CardFace.Ten, CardSuit.Diamonds),
                new Card(CardFace.Two, CardSuit.Clubs),
                new Card(CardFace.Ace, CardSuit.Hearts)
            };
            Hand hand = new Hand(cards);

            bool result = handsChecker.IsThreeOfAKind(hand);
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void IsThreeOfAKindTestTwo()
        {
            IList<ICard> cards = new List<ICard>()
            {
                new Card(CardFace.Ten, CardSuit.Clubs),
                new Card(CardFace.Jack, CardSuit.Hearts),
                new Card(CardFace.Ten, CardSuit.Spades),
                new Card(CardFace.Ten, CardSuit.Diamonds),
                new Card(CardFace.Two, CardSuit.Diamonds)
            };
            Hand hand = new Hand(cards);

            bool result = handsChecker.IsThreeOfAKind(hand);
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void IsNotThreeOfAKindTest()
        {
            IList<ICard> cards = new List<ICard>()
            {
                new Card(CardFace.Queen, CardSuit.Hearts),
                new Card(CardFace.King, CardSuit.Diamonds),
                new Card(CardFace.Three, CardSuit.Spades),
                new Card(CardFace.King, CardSuit.Hearts),
                new Card(CardFace.Two, CardSuit.Clubs)
            };
            Hand hand = new Hand(cards);

            bool result = handsChecker.IsThreeOfAKind(hand);
            Assert.IsFalse(result);
        }
        #endregion

        #region Full House tests
        [TestMethod]
        public void IsFullHouseTestOne()
        {
            IList<ICard> cards = new List<ICard>()
            {
                new Card(CardFace.Ace, CardSuit.Diamonds),
                new Card(CardFace.Ace, CardSuit.Spades),
                new Card(CardFace.Jack, CardSuit.Diamonds),
                new Card(CardFace.Jack, CardSuit.Clubs),
                new Card(CardFace.Ace, CardSuit.Hearts)
            };
            Hand hand = new Hand(cards);

            bool result = handsChecker.IsFullHouse(hand);
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void IsFullHouseTestTwo()
        {
            IList<ICard> cards = new List<ICard>()
            {
                new Card(CardFace.Ten, CardSuit.Clubs),
                new Card(CardFace.Two, CardSuit.Hearts),
                new Card(CardFace.Ten, CardSuit.Spades),
                new Card(CardFace.Ten, CardSuit.Diamonds),
                new Card(CardFace.Two, CardSuit.Diamonds)
            };
            Hand hand = new Hand(cards);

            bool result = handsChecker.IsFullHouse(hand);
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void IsNotFullHouseTestOne()
        {
            IList<ICard> cards = new List<ICard>()
            {
                new Card(CardFace.Queen, CardSuit.Hearts),
                new Card(CardFace.King, CardSuit.Diamonds),
                new Card(CardFace.Queen, CardSuit.Spades),
                new Card(CardFace.King, CardSuit.Hearts),
                new Card(CardFace.Two, CardSuit.Clubs)
            };
            Hand hand = new Hand(cards);

            bool result = handsChecker.IsFullHouse(hand);
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void IsNotFullHouseTestTwo()
        {
            IList<ICard> cards = new List<ICard>()
            {
                new Card(CardFace.Queen, CardSuit.Hearts),
                new Card(CardFace.Three, CardSuit.Diamonds),
                new Card(CardFace.Three, CardSuit.Spades),
                new Card(CardFace.King, CardSuit.Hearts),
                new Card(CardFace.Three, CardSuit.Clubs)
            };
            Hand hand = new Hand(cards);

            bool result = handsChecker.IsFullHouse(hand);
            Assert.IsFalse(result);
        }
        #endregion

        #region Two Pairs tests
        [TestMethod]
        public void IsTwoPairTestOne()
        {
            IList<ICard> cards = new List<ICard>()
            {
                new Card(CardFace.Ace, CardSuit.Diamonds),
                new Card(CardFace.Ace, CardSuit.Spades),
                new Card(CardFace.Jack, CardSuit.Diamonds),
                new Card(CardFace.Jack, CardSuit.Clubs),
                new Card(CardFace.Two, CardSuit.Hearts)
            };
            Hand hand = new Hand(cards);

            bool result = handsChecker.IsTwoPair(hand);
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void IsTwoPairTestTwo()
        {
            IList<ICard> cards = new List<ICard>()
            {
                new Card(CardFace.Jack, CardSuit.Clubs),
                new Card(CardFace.Four, CardSuit.Hearts),
                new Card(CardFace.Ten, CardSuit.Spades),
                new Card(CardFace.Jack, CardSuit.Diamonds),
                new Card(CardFace.Four, CardSuit.Diamonds)
            };
            Hand hand = new Hand(cards);

            bool result = handsChecker.IsTwoPair(hand);
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void IsNotTwoPairTestOne()
        {
            IList<ICard> cards = new List<ICard>()
            {
                new Card(CardFace.Queen, CardSuit.Hearts),
                new Card(CardFace.King, CardSuit.Diamonds),
                new Card(CardFace.Three, CardSuit.Spades),
                new Card(CardFace.King, CardSuit.Hearts),
                new Card(CardFace.Two, CardSuit.Clubs)
            };
            Hand hand = new Hand(cards);

            bool result = handsChecker.IsTwoPair(hand);
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void IsNotTwoPairTestTwo()
        {
            IList<ICard> cards = new List<ICard>()
            {
                new Card(CardFace.Four, CardSuit.Hearts),
                new Card(CardFace.Three, CardSuit.Diamonds),
                new Card(CardFace.Four, CardSuit.Spades),
                new Card(CardFace.Three, CardSuit.Hearts),
                new Card(CardFace.Three, CardSuit.Clubs)
            };
            Hand hand = new Hand(cards);

            bool result = handsChecker.IsTwoPair(hand);
            Assert.IsFalse(result);
        }
        #endregion

        #region One Pair tests
        [TestMethod]
        public void IsOnePairTestOne()
        {
            IList<ICard> cards = new List<ICard>()
            {
                new Card(CardFace.Ace, CardSuit.Diamonds),
                new Card(CardFace.Ace, CardSuit.Spades),
                new Card(CardFace.Six, CardSuit.Diamonds),
                new Card(CardFace.Jack, CardSuit.Clubs),
                new Card(CardFace.Two, CardSuit.Hearts)
            };
            Hand hand = new Hand(cards);

            bool result = handsChecker.IsOnePair(hand);
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void IsOnePairTestTwo()
        {
            IList<ICard> cards = new List<ICard>()
            {
                new Card(CardFace.Jack, CardSuit.Clubs),
                new Card(CardFace.Queen, CardSuit.Hearts),
                new Card(CardFace.Ten, CardSuit.Spades),
                new Card(CardFace.Jack, CardSuit.Diamonds),
                new Card(CardFace.Four, CardSuit.Diamonds)
            };
            Hand hand = new Hand(cards);

            bool result = handsChecker.IsOnePair(hand);
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void IsNotOnePairTestOne()
        {
            IList<ICard> cards = new List<ICard>()
            {
                new Card(CardFace.Queen, CardSuit.Hearts),
                new Card(CardFace.King, CardSuit.Diamonds),
                new Card(CardFace.Queen, CardSuit.Spades),
                new Card(CardFace.King, CardSuit.Hearts),
                new Card(CardFace.Queen, CardSuit.Clubs)
            };
            Hand hand = new Hand(cards);

            bool result = handsChecker.IsOnePair(hand);
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void IsNotOnePairTestTwo()
        {
            IList<ICard> cards = new List<ICard>()
            {
                new Card(CardFace.Four, CardSuit.Hearts),
                new Card(CardFace.Three, CardSuit.Diamonds),
                new Card(CardFace.Four, CardSuit.Spades),
                new Card(CardFace.Three, CardSuit.Hearts),
                new Card(CardFace.Three, CardSuit.Clubs)
            };
            Hand hand = new Hand(cards);

            bool result = handsChecker.IsOnePair(hand);
            Assert.IsFalse(result);
        }
        #endregion

        #region High Card Tests
        [TestMethod]
        public void IsHighCardTest()
        {
            IList<ICard> cards = new List<ICard>()
            {
                new Card(CardFace.Ace, CardSuit.Diamonds),
                new Card(CardFace.Ten, CardSuit.Spades),
                new Card(CardFace.Nine, CardSuit.Diamonds),
                new Card(CardFace.Five, CardSuit.Clubs),
                new Card(CardFace.Two, CardSuit.Hearts)
            };
            Hand hand = new Hand(cards);

            bool result = handsChecker.IsHighCard(hand);
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void IsNotHighCard()
        {
            IList<ICard> cards = new List<ICard>()
            {
                new Card(CardFace.Queen, CardSuit.Hearts),
                new Card(CardFace.King, CardSuit.Diamonds),
                new Card(CardFace.Queen, CardSuit.Spades),
                new Card(CardFace.King, CardSuit.Hearts),
                new Card(CardFace.Two, CardSuit.Clubs)
            };
            Hand hand = new Hand(cards);

            bool result = handsChecker.IsHighCard(hand);
            Assert.IsFalse(result);
        }
        #endregion
    }
}
