using System;
using System.Collections.Generic;
using System.Linq;

namespace Question2
{
    class Program
    {
        //=====================================================================
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            //TestDeck();
            //TestComparer();
            TestGames();
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
        static void PrintPlayer(Player player)
        {
            Console.WriteLine("//=====================================================================");
            Console.WriteLine();
            Console.WriteLine("Player : " + player.DisplayName);
            Console.WriteLine();
            Console.WriteLine("Result : " + player.Result.ToString());
            Console.WriteLine();
            Console.WriteLine("Cards : ");

            foreach (Card c in player.Cards)
                PrintCard(c);

            Console.WriteLine();
        }

        //=====================================================================
        static void PrintGameResult(string gamerName, Player[] players)
        {
            Console.WriteLine("//:::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::");
            Console.WriteLine();
            Console.WriteLine("Game : " + gamerName);
            Console.WriteLine();

            foreach (Player p in players)
                PrintPlayer(p);

            Console.WriteLine();
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

        //=====================================================================
        static void TestGames()
        {
            FactoryGame factoryGame = new FactoryGame();
            Game[] games = factoryGame.GenerateGames();

            for (int i = 0; i < games.Length; i++)
                TestGame(games[i], "Point_" + (i + 1));
        }

        //=====================================================================
        static void TestGame(Game game, string gamerName)
        {
            List<Player> players = new List<Player>
            {
                new Player("Santiago"),
                new Player("Valeria"),
                new Player("Javier"),
            };

            game.Play(ref players);

            PrintGameResult(gamerName, players.ToArray());
        }
    }
}
