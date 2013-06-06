namespace Poker.Tests
{
    using System;
    using System.Collections.Generic;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class HandTests
    {
        [TestMethod]
        public void ToStringTest()
        {
            IList<ICard> cards = new List<ICard>()
            {
                new Card(CardFace.Seven, CardSuit.Hearts),
                new Card(CardFace.Ten, CardSuit.Clubs),
                new Card(CardFace.King, CardSuit.Spades),
                new Card(CardFace.Ace, CardSuit.Diamonds),
                new Card(CardFace.Two, CardSuit.Hearts)
            };

            Hand hand = new Hand(cards);
            string expected = "7♥10♣K♠A♦2♥";
            string actual = hand.ToString();

            Assert.AreEqual(expected, actual);
        }
    }
}
