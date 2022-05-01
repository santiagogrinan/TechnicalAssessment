using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Question2
{
    public class Deck : IDeck
    {
        //:::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::
        #region Implement IDeck
        //:::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::
        //=====================================================================
        public Card GetCard()
        {
            if (m_availableNumber.Count == 0) throw new NoCardAvailableExpection();

            int randomNumber = m_generatorInt.GenerateInt(0, m_availableNumber.Count);
            int realityNumber = m_availableNumber[randomNumber];
            m_availableNumber.RemoveAt(randomNumber);
            
            return ParseIntToCard(realityNumber);
        }

        #endregion
        //:::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::
        #region Public
        //:::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::
        //=====================================================================
        public Deck(IGeneratorRandomInt generatorInt, int suitsNumber, int cardPerSuit, int wildCardNumber, int deckNumber = 1)
        {
            m_generatorInt = generatorInt;
            m_suitsNumber = suitsNumber;
            m_cardsPerSuit = cardPerSuit;
            m_wildCard = wildCardNumber;
            m_deckNumber = deckNumber;

            m_availableNumber = CreateNumbersAvailable();
        }

        #endregion
        //:::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::
        #region Implementation
        //:::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::        
        //=====================================================================
        Card ParseIntToCard(int number)
        {
            int deckNumber = ParseMultipleDeskToOneDesk(number);

            if (deckNumber >= m_suitsNumber * m_cardsPerSuit)
                return Card.CreateWildCard();

            int cardNumber = deckNumber % m_cardsPerSuit;
            int cardSuit = deckNumber / m_cardsPerSuit;

            return Card.CreateCard(cardNumber, cardSuit);
        }

        //=====================================================================
        int ParseMultipleDeskToOneDesk(int number)
        {
            return number % CardPerDeck;
        }

        //=====================================================================
        int CardPerDeck => m_suitsNumber * m_cardsPerSuit + m_wildCard;

        //=====================================================================
        int CardCount => CardPerDeck * m_deckNumber;

        //=====================================================================
        List<int> CreateNumbersAvailable()
        {
            List<int> result = new List<int>();

            int numberCards = CardCount;

            for (int i = 0; i < numberCards; i++)
                result.Add(i);

            return result;
        }

        #endregion
        //:::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::
        #region Fields
        //:::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::
        IGeneratorRandomInt m_generatorInt;
        int m_suitsNumber;
        int m_cardsPerSuit;
        int m_wildCard;
        int m_deckNumber;
        List<int> m_availableNumber;

        #endregion
    }
}
