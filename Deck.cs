using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GameOfWar
{
    public class Deck
    {
        private IList<Card> deck;
   
        public Deck()
        {
            deck = new List<Card>();
            foreach (Card.Rank rank in Enum.GetValues(typeof(Card.Rank)))
            {
                deck.Add(new Card(Card.Suit.Clubs, Card.Color.Black, rank));
                deck.Add(new Card(Card.Suit.Hearts, Card.Color.Red, rank));
                deck.Add(new Card(Card.Suit.Diamonds, Card.Color.Red, rank));
                deck.Add(new Card(Card.Suit.Spades, Card.Color.Black, rank));
            }
        }
        
        public int GetCount()
        {
            return deck.Count;
        }

        public void ShuffleDeck()
        {
            deck.ShuffleList();
        }

        public void DealCards(params Player[] players) 
        {
            int count = 0;
            while (count < deck.Count)
            {
                foreach (Player player in players)
                {
                    if (count >= deck.Count) break;
                    player.AddCard(deck[count++]);
                }
            }
            deck.Clear();
        }

        public void PrintDeck()
        {
            foreach (Card c in deck)
            {
                Console.WriteLine(c);
            }
        }

    }
}
