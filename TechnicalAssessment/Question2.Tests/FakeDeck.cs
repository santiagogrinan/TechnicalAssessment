using System;
using System.Collections.Generic;
using System.Text;
using Question2;

namespace Question2.Tests
{
    internal class FakeDeck : IDeck
    {
        //:::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::
        #region Implement IDeck
        //:::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::
        //=====================================================================
        public Card GetCard()
        {
            if (m_cards.Count == 0) throw new NoCardAvailableExpection();

            Card result = m_cards[0];

            m_cards.Remove(result);

            return result;
        }

        #endregion
        //:::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::
        #region Public
        //:::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::
        //=====================================================================
        public FakeDeck(List<Card> Cards)
        {
            m_cards = Cards;
        }

        #endregion
        //:::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::
        #region Fields
        //:::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::
        List<Card> m_cards;

        #endregion
    }
}
