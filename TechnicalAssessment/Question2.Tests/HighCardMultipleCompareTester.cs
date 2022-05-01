using Microsoft.VisualStudio.TestTools.UnitTesting;
using Question2;
using System;

namespace Question2.Tests
{
    [TestClass]
    public class HighCardMultipleCompareTester
    {
        //:::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::
        #region Test
        //:::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::
        //=====================================================================
        [TestMethod]
        [DataRow(2, 1, ExpectedResult.Win)]
        [DataRow(1, 1, ExpectedResult.Tie)]
        [DataRow(1, 2, ExpectedResult.Lose)]
        public void TestSecondCard(int number_1, int number_2, ExpectedResult expectedResult)
        {
            HighCardMultipleCompare compare = new HighCardMultipleCompare(new HighCardCompare(false));

            int numberEqueal = 1;
            int site = 0;

            Card[] cards_1 = new Card[]
            {
                Card.CreateCard(numberEqueal, site),
                Card.CreateCard(number_1, site),
            };

            Card[] cards_2 = new Card[]
            {
                Card.CreateCard(numberEqueal, site),
                Card.CreateCard(number_2, site),
            };

            Assert.IsTrue(GetResult(compare, cards_1, cards_2, expectedResult));
        }

        #endregion
        //:::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::
        #region Static Functions
        //:::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::
        //=====================================================================
        static bool GetResult(HighCardMultipleCompare compare, Card[] x, Card[] y, ExpectedResult expectedResult)
        {
            switch (expectedResult)
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
