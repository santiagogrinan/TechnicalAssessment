using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Diagnostics.CodeAnalysis;

namespace Question2
{
    public class Game
    {
        //=====================================================================
        public Game(IDeck deck, IComparer<Card[]> comparer, bool allowTie)
        {
            m_deck = deck;
            m_comparer = comparer;
            m_allowTie = allowTie;
        }

        //=====================================================================
        public void Play(ref List<Player> player)
        {
            if (player == null || player.Count < 2) 
                throw new ArgumentException("player");

            foreach (Player p in player)
                p.AddCard(m_deck.GetCard());

            player = player.OrderBy(p => p.Cards, m_comparer).ToList();

            if (m_comparer.Compare(player[0].Cards, player[1].Cards) < 0)
                player[0].SetResult(Player.ResultEnum.Win);

            else
            {
                if (m_allowTie)
                {
                    player[0].SetResult(Player.ResultEnum.Tie);
                    for (int i = 1; i < player.Count; i++)
                    {
                        if (m_comparer.Compare(player[0].Cards, player[i].Cards) == 0)
                            player[i].SetResult(Player.ResultEnum.Tie);
                        else
                            break;
                    }
                }
                else
                {
                    while (m_comparer.Compare(player[0].Cards, player[1].Cards) == 0)
                    {
                        Card cardToPlayer0 = m_deck.GetCard();
                        for (int i = 1; i < player.Count; i++)
                        {
                            if (m_comparer.Compare(player[0].Cards, player[i].Cards) == 0)
                                player[i].AddCard(m_deck.GetCard());
                            else
                                break;
                        }
                        player[0].AddCard(cardToPlayer0);
                        player = player.OrderBy(p => p.Cards, m_comparer).ToList();
                    }

                    player[0].SetResult(Player.ResultEnum.Win);

                }
            }

            player.ForEach(p =>
            {
                if (p.Result == Player.ResultEnum.Undefined)
                    p.SetResult(Player.ResultEnum.Lose);
            });
        }

        IDeck m_deck;
        IComparer<Card[]> m_comparer;
        bool m_allowTie;
    }
}
