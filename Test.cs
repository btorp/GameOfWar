using System;
using System.Collections.Generic;
using System.Text;

namespace GameOfWar
{
    public class Test
    {
        public void TestShuffle()
        {
            IList<int> cards = new List<int>();
            for (int i = 1; i < 10; i++)
            {
                cards.Add(i);
            }
            foreach (int i in cards) { Console.WriteLine(i); }
            cards.ShuffleList<int>();
            Console.WriteLine("Shuffled cards:");
            foreach (int i in cards) { Console.WriteLine(i); }
        }

        public void TestDeck()
        {
            Deck deck = new Deck();
            Console.WriteLine("Deck has " + deck.GetCount() + " cards");
            deck.PrintDeck();
            Console.WriteLine("\nShuffled deck:");
            deck.ShuffleDeck();
            deck.PrintDeck();
        }
    }
}
