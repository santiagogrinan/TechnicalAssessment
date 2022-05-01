using Microsoft.VisualStudio.TestTools.UnitTesting;
using Question2;
using System;

namespace Question2.Tests
{
    [TestClass]
    public class HighCardCompareTester
    {
        //:::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::
        #region Test
        //:::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::
        //=====================================================================
        [TestMethod]
        [DataRow(5, 0, ExpectedResult.Win)]
        [DataRow(5, 5, ExpectedResult.Tie)]
        [DataRow(5, 7, ExpectedResult.Lose)]
        public void TestSameSite(int number_1, int number_2, ExpectedResult expectedResult)
        {
            HighCardCompare compare = new HighCardCompare(false);

            int site = 0;
            Card card_1 = Card.CreateCard(number_1, site);
            Card card_2 = Card.CreateCard(number_2, site);

            Assert.IsTrue(GetResult(compare, card_1, card_2, expectedResult));
        }

        //=====================================================================
        [TestMethod]
        [DataRow(true, 0, 0, ExpectedResult.Tie)]
        [DataRow(false, 0, 1, ExpectedResult.Tie)]
        [DataRow(true, 0, 1, ExpectedResult.Win)]
        [DataRow(true, 1, 0, ExpectedResult.Lose)]
        public void TestDifferentSite(bool allowSiteDecision, int site_1, int site_2, ExpectedResult expectedResult)
        {
            HighCardCompare compare = new HighCardCompare(allowSiteDecision);

            int number = 5;
            Card card_1 = Card.CreateCard(number, site_1);
            Card card_2 = Card.CreateCard(number, site_2);

            Assert.IsTrue(GetResult(compare, card_1, card_2, expectedResult));
        }

        //=====================================================================
        [TestMethod]
        [DataRow(true, false, ExpectedResult.Win)]
        [DataRow(true, true, ExpectedResult.Tie)]
        [DataRow(false, true, ExpectedResult.Lose)]
        public void TestWildCard(bool isWildCardFirst, bool isWildCardSeond, ExpectedResult expectedResult)
        {
            HighCardCompare compare = new HighCardCompare(false);

            Card card_1 = isWildCardFirst ? Card.CreateWildCard() : Card.CreateCard(10, 0);
            Card card_2 = isWildCardSeond ? Card.CreateWildCard() : Card.CreateCard(10, 0);

            Assert.IsTrue(GetResult(compare, card_1, card_2, expectedResult));
        }

        #endregion
        //:::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::
        #region Static Functions
        //:::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::
        //=====================================================================
        static bool GetResult(HighCardCompare compare, Card x, Card y, ExpectedResult expectedResult)
        {
            switch(expectedResult)
            {
                case ExpectedResult.Win: return compare.Compare(x, y) < 0;
                case ExpectedResult.Tie: return compare.Compare(x, y) == 0;
                case ExpectedResult.Lose: return compare.Compare(x, y) > 0;
                default: throw new NotImplementedException();
            }
        }

        #endregion
        //:::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::
        #region Fields
        //:::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::
        public enum ExpectedResult
        {
            Win,
            Lose,
            Tie,
        }

        #endregion
    }
}
