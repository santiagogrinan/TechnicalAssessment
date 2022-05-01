using System;
using System.Collections.Generic;
using System.Text;

namespace Question2
{
    public class Card
    {

        public static Card CreateWildCard()
        {
            return new Card()
            {
                IsWildCard = true,
            };
        }

        public static Card CreateCard(int number, int suit)
        {
            return new Card()
            {
                Number = number,
                Suit = suit,
            };
        }

        public bool IsWildCard { get; private set; }
        public int Number { get; private set; }
        public int Suit { get; private set; }
    }
}
