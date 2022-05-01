using Microsoft.VisualStudio.TestTools.UnitTesting;
using Question2;
using System;
using System.Collections.Generic;

namespace Question2.Tests
{
    [TestClass]
    public class DeckTester
    {
        //:::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::
        #region Test
        //:::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::
        //=====================================================================
        [TestMethod]   
        [Timeout(1000)]
        [DataRow(4, 13, 2)]
        public void TestDeck(int numberSuit, int cardPerSuit, int wildCardNumber)
        {
            IGeneratorRandomInt generator = new Generator();
            IDeck deck = new Deck(generator, numberSuit, cardPerSuit, wildCardNumber);
            Assert.ThrowsException<NoCardAvailableExpection>(() => EmptyDeck(deck, wildCardNumber));
        }

        //=====================================================================
        public void EmptyDeck(IDeck deck, int wildCardNumber)
        {
            IComparer<Card> comparer = new HighCardCompare(true);
            List<Card> cards = new List<Card>();
            int currentWildCardNumber = 0;

            while (true)
            {
                Card card = deck.GetCard();
                AddIfNotRepeat(comparer, cards, card, wildCardNumber, ref currentWildCardNumber);
            }
        }

        //=====================================================================
        public void AddIfNotRepeat(IComparer<Card> compare, List<Card> cards, Card card, int wildCardNumber, ref int currentWildCardNumber)
        {
            if (card.IsWildCard)
            {
                if (wildCardNumber == currentWildCardNumber)
                    throw new Exception("Card Is Repeat. Card : WildCard. Number of Wild Card Found: " + currentWildCardNumber);
                currentWildCardNumber++;
            }
            else
            {
                foreach (Card c in cards)
                    if (compare.Compare(c, card) == 0)
                        throw new Exception("Card Is Repeat. Card : " + card.Number + " | " + card.Suit);
            }

            cards.Add(card);            
        }

        #endregion
    }
}
