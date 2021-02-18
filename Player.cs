using System;
using System.Collections.Generic;
using System.Text;

namespace GameOfWar
{
    public class Player
    {
        private LinkedList<Card> cards;        

        public Player()
        {
            cards = new LinkedList<Card>();
        }        

        public int GetCardCount()
        {
            return cards.Count;
        }

        public bool HasCards()
        {
            return cards.Count > 0;
        }

        public void AddCard(Card card)
        {
            cards.AddLast(card);            
        }

        public void AddCards(IEnumerable<Card> cards)
        {
            foreach (Card c in cards)
            {
                this.cards.AddLast(c);
            }            
        }        

        public Card RevealCard()
        {
            if (cards.Count == 0) return null;

            Card card = cards.First.Value;
            cards.RemoveFirst();
            return card;
        }

    }
}
