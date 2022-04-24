using System;
using System.Collections.Generic;

namespace Question2
{
    class Program
    {
        //=====================================================================
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            TestDeck();
            //TestComparer();
        }

        //=====================================================================
        static void PrintCard(Card card)
        {
            string toPrnt = "Card : ";

            if (card.IsWildCard)
                toPrnt += "WILD CARD";
            else
                toPrnt += "Number : " + card.Number + " | Suit : " + card.Suit;

            Console.WriteLine(toPrnt);
        }

        //=====================================================================
        static void TestDeck()
        {
            try
            {
                IDeck deck = new Deck(new Generator(), 2, 2, 1, 2);

                while (true)
                    PrintCard(deck.GetCard());
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        //=====================================================================
        static void TestComparer()
        {
            Card[] card_1 = new Card[]
            {
                Card.CreateWildCard(),
                Card.CreateCard(2, 2),
            };

            Card[] card_2 = new Card[]
            {
                Card.CreateWildCard(),
                Card.CreateCard(3, 0),
            };


            IComparer<Card> comparerSingle = new HighCardCompare(false);
            IComparer<Card[]> comparerMultiple = new HighCardMultipleCompare(comparerSingle);

            if (comparerMultiple.Compare(card_1, card_2) > 0)
                Console.WriteLine("Ok");
            else
                Console.WriteLine("Error");
        }
    }
}
