namespace Poker.Tests
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Poker;

    [TestClass]
    public class CardTests
    {
        [TestMethod]
        public void ToStringOfCardTwoDiamondsTest()
        {
            CardFace face = CardFace.Two;
            CardSuit suit = CardSuit.Diamonds;

            Card card = new Card(face, suit);
            string expected = "2♦";
            string actual = card.ToString();

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ToStringOfCardTenSpadesTest()
        {
            CardFace face = CardFace.Ten;
            CardSuit suit = CardSuit.Spades;

            Card card = new Card(face, suit); 
            string expected = "10♠";
            string actual = card.ToString();

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ToStringOfCardAceClubsTest()
        {
            CardFace face = CardFace.Ace;
            CardSuit suit = CardSuit.Clubs;

            Card card = new Card(face, suit);
            string expected = "A♣";
            string actual = card.ToString();

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ToStringOfCardSevenHeartsTest()
        {
            CardFace face = CardFace.Seven;
            CardSuit suit = CardSuit.Hearts;
            
            Card card = new Card(face, suit);
            string expected = "7♥";
            string actual = card.ToString();

            Assert.AreEqual(expected, actual);
        }
    }
}
