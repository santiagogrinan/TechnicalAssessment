using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Question2
{
    class Deck : IDeck
    {
        //:::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::
        #region Implement IDeck
        //:::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::
        //=====================================================================
        public Card GetCard()
        {
            if (m_availableNumber.Count == 0) throw new Exception("Not Card Available");

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
        public Deck(IGeneratorRandomInt generatorInt, int suitsNumber, int cardPerSuit, int wildCardNumber)
        {
            m_generatorInt = generatorInt;
            m_suitsNumber = suitsNumber;
            m_cardsPerSuit = cardPerSuit;
            m_availableNumber = CreateNumbersAvailable(suitsNumber, cardPerSuit, wildCardNumber);
        }

        #endregion
        //:::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::
        #region Implementation
        //:::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::        
        //=====================================================================
        Card ParseIntToCard(int number)
        {
            if (number >= m_suitsNumber * m_cardsPerSuit)
                return Card.CreateWildCard();

            int cardNumber = number % m_cardsPerSuit;
            int cardSuit = number / m_cardsPerSuit;

            return Card.CreateCard(cardNumber, cardSuit);
        }

        #endregion
        //:::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::
        #region Static Function
        //:::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::   
        //=====================================================================
        static List<int> CreateNumbersAvailable (int suitsNumber, int cardPerSuit, int wildCardAvailable)
        {
            List<int> result = new List<int>();

            int numberCards = suitsNumber * cardPerSuit + wildCardAvailable;

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
        List<int> m_availableNumber;

        #endregion
    }
}
