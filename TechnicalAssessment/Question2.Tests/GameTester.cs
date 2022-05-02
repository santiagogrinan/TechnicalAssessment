using Microsoft.VisualStudio.TestTools.UnitTesting;
using Question2;
using System;
using System.Collections.Generic;

namespace Question2.Tests
{
    [TestClass]
    public class GameTester
    {
        //:::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::
        #region Test
        //:::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::
        //=====================================================================
        [TestMethod]
        public void TestTiesNumberEqual()
        {
            FakeDeck deck = new FakeDeck(new List<Card>()
            {
                Card.CreateCard(5, 5),
                Card.CreateCard(5, 0),
            });

            IComparer<Card[]> comparer = new HighCardMultipleCompare(new HighCardCompare(false));

            Game game = new Game(deck, comparer, true);

            game.Play(ref m_players);

            Assert.IsTrue(m_players[0].Result == Player.ResultEnum.Tie);
            Assert.IsTrue(m_players[1].Result == Player.ResultEnum.Tie);
        }

        //=====================================================================
        [TestMethod]
        public void TestDifferentSite()
        {
            FakeDeck deck = new FakeDeck(new List<Card>()
            {
                Card.CreateCard(5, 0),
                Card.CreateCard(5, 5),
            });

            IComparer<Card[]> comparer = new HighCardMultipleCompare(new HighCardCompare(true));

            Game game = new Game(deck, comparer, false);

            game.Play(ref m_players);

            Assert.IsTrue(m_players[0].Result == Player.ResultEnum.Win);
            Assert.IsTrue(m_players[0].DisplayName == PLAYER_NAME_1);
            Assert.IsTrue(m_players[1].Result == Player.ResultEnum.Lose);
        }

        //=====================================================================
        [TestMethod]
        public void TestNeverEndTie()
        {
            FakeDeck deck = new FakeDeck(new List<Card>()
            {
                Card.CreateCard(5, 5),
                Card.CreateCard(5, 5),
                Card.CreateCard(6, 5),
                Card.CreateCard(6, 5),
                Card.CreateWildCard(),
                Card.CreateWildCard(),
                Card.CreateWildCard(),
                Card.CreateCard(2, 5),
            });

            IComparer<Card[]> comparer = new HighCardMultipleCompare(new HighCardCompare(false));

            Game game = new Game(deck, comparer, false);

            game.Play(ref m_players);

            Assert.IsTrue(m_players[0].Result == Player.ResultEnum.Win);
            Assert.IsTrue(m_players[0].DisplayName == PLAYER_NAME_1);
            Assert.IsTrue(m_players[0].Cards.Length == 4);
            Assert.IsTrue(m_players[1].Result == Player.ResultEnum.Lose);
            Assert.IsTrue(m_players[1].Cards.Length == 4);
        }

        #endregion
        //:::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::
        #region Test
        //:::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::
        public GameTester()
        {
            m_players = new List<Player>()
            {
                new Player(PLAYER_NAME_1),
                new Player("Valeria"),
            };
        }

        #endregion
        //:::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::
        #region Fields
        //:::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::
        List<Player> m_players;
        const string PLAYER_NAME_1 = "Santiago";


        #endregion
    }
}
