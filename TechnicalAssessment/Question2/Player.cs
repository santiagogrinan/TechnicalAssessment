using System;
using System.Collections.Generic;
using System.Text;

namespace Question2
{
    public class Player
    {
        public enum ResultEnum
        {
            Undefined,
            Win,
            Tie,
            Lose,
        }

        public string DisplayName { get; set; }
        public string IdName { get; private set; }
        public Card[] Cards => m_cards.ToArray();

        public ResultEnum Result { get; private set; }

        public Player(string displayName)
        {
            DisplayName = displayName;
            IdName = Guid.NewGuid().ToString();
            m_cards = new List<Card>();
            Result = ResultEnum.Undefined;
        }

        public void AddCard(Card card)
        {
            m_cards.Add(card);
        }

        public void SetResult(ResultEnum result)
        {
            if (Result != ResultEnum.Undefined)
                throw new Exception("Result only can be set once");

            Result = result;
        }

        public List<Card> m_cards;


    }
}
