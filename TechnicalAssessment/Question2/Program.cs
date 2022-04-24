using System;

namespace Question2
{
    class Program
    {
        //=====================================================================
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            TestDeck();
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
                IDeck deck = new Deck(new Generator(), 2, 6, 5);

                while (true)
                    PrintCard(deck.GetCard());
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
