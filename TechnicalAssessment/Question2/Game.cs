using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Diagnostics.CodeAnalysis;

namespace Question2
{
    class Game
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

            player.OrderBy(p => p.Cards, m_comparer);

            if (m_comparer.Compare(player[0].Cards, player[1].Cards) > 0)
                player[0].SetResult(Player.ResultEnum.Win);

            else
            {
                if (m_allowTie)
                {
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
                        for (int i = 1; i < player.Count; i++)
                        {
                            if (m_comparer.Compare(player[0].Cards, player[i].Cards) == 0)
                                player[i].AddCard(m_deck.GetCard());
                            else
                            {
                                player.OrderBy(p => p.Cards, m_comparer);
                                break;
                            }

                        }
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
