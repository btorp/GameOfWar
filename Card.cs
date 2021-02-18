using System;
using System.Collections.Generic;
using System.Text;

namespace GameOfWar
{
    public class Card
    {
        public enum Suit { Clubs, Diamonds, Hearts, Spades }
        public enum Color { Black, Red }
        public enum Rank { Two, Three, Four, Five, Six, Seven, Eight, Nine, Ten, Jack, Queen, King, Ace }

        private Suit suit;
        private Color color;
        private Rank rank;

        public Card(Suit suit, Color color, Rank rank)
        {
            this.suit = suit;
            this.color = color;
            this.rank = rank;
        }

        public Rank GetRank()
        {
            return rank;
        }

        public override string ToString()
        {
            return rank + " of " + suit;
        }
    }

    
}
