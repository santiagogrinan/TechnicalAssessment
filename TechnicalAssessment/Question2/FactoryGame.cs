using System;
using System.Collections.Generic;
using System.Text;

namespace Question2
{
    class FactoryGame
    {
        //:::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::
        #region Public
        //:::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::
        //=====================================================================
        public Game[] GenerateGames()
        {
            return new Game[]
            {
                Point_1(),
                Point_2(),
                Point_3(),
                Point_4(),
                Point_5(),
                Point_6(),
            };
        }

        //=====================================================================
        public Game Point_1()
        {
            int suitNumber = 4;
            int cardPertSuit = 13;
            bool useWildCard = false;
            bool suitDecide = false;
            bool allowTies = true;

            return CreateGame(suitNumber, cardPertSuit, useWildCard, suitDecide, allowTies); 
        }

        //=====================================================================
        public Game Point_2()
        {
            int suitNumber = 4;
            int cardPertSuit = 13;
            bool useWildCard = false;
            bool suitDecide = true;
            bool allowTies = true;

            return CreateGame(suitNumber, cardPertSuit, useWildCard, suitDecide, allowTies);
        }

        //=====================================================================
        public Game Point_3()
        {
            int suitNumber = 4;
            int cardPertSuit = 13;
            bool useWildCard = false;
            bool suitDecide = true;
            bool allowTies = true;

            return CreateGame(suitNumber, cardPertSuit, useWildCard, suitDecide, allowTies, 5);
        }

        //=====================================================================
        public Game Point_4()
        {
            int suitNumber = 4;
            int cardPertSuit = 13;
            bool useWildCard = false;
            bool suitDecide = true;
            bool allowTies = false;

            return CreateGame(suitNumber, cardPertSuit, useWildCard, suitDecide, allowTies);
        }

        //=====================================================================
        public Game Point_5()
        {
            int suitNumber = 4;
            int cardPertSuit = 13;
            bool useWildCard = true;
            bool suitDecide = true;
            bool allowTies = false;

            return CreateGame(suitNumber, cardPertSuit, useWildCard, suitDecide, allowTies);
        }

        //=====================================================================
        public Game Point_6()
        {
            int suitNumber = 4;
            int cardPertSuit = 20;
            bool useWildCard = true;
            bool suitDecide = true;
            bool allowTies = false;

            return CreateGame(suitNumber, cardPertSuit, useWildCard, suitDecide, allowTies);
        }

        #endregion
        //:::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::
        #region Static Functions
        //:::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::

        //=====================================================================
        static Game CreateGame(int suitNumber, int cardPerSuit, bool useWildCard, bool suitDecide, bool allowTie, int deckNumber = 1)
        {
            IGeneratorRandomInt randomGenerate = new Generator();
            IDeck deck = new Deck(randomGenerate, suitNumber, cardPerSuit, useWildCard ? 1 : 0, deckNumber);

            IComparer<Card> singleComparer = new HighCardCompare(suitDecide);
            IComparer<Card[]> multipleComparer = new HighCardMultipleCompare(singleComparer);

            return new Game(deck, multipleComparer, allowTie);

        }
        #endregion
    }
}
