using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GameOfWar
{
    public class GameOfWar
    {
        private IList<Card> warPile;
        private int round;
        private string playerName;
        private bool interactiveMode;
        private Player playerOne;
        private Player computer;
        private Deck deck;
        private bool isWar;        

        public GameOfWar()
        {
            InitializeGame();         

            //game loop                    
            while (true)
            {
                if (!playerOne.HasCards() && !computer.HasCards())
                {
                    Console.WriteLine("\n\nBoth players ran out of cards. The game has ended in a draw!\n");
                    return;
                }
                else if (!playerOne.HasCards() && computer.HasCards())
                {
                    Console.WriteLine("\n\nComputer wins! Sorry, you ran out of cards. Try again next time :(\n");
                    return;
                }
                else if (playerOne.HasCards() && !computer.HasCards())
                {
                    Console.WriteLine("\n\nCongrats " + playerName + "! The Computer ran out of cards. You win!\n");
                    return;
                }
                else 
                {
                    if (!isWar)
                    {
                        Console.WriteLine("\nRound " + round + ":");
                        Console.WriteLine(playerName + " total cards: " + playerOne.GetCardCount());
                        Console.WriteLine("Computer total cards: " + computer.GetCardCount());
                    }

                    if (interactiveMode)
                    {
                        Console.Write("Press enter to reveal your top card.");
                        Console.ReadLine();
                    }

                    Card cardOne = playerOne.RevealCard();
                    Card cardTwo = computer.RevealCard();
                    warPile.Add(cardOne);
                    warPile.Add(cardTwo);

                    Console.WriteLine(playerName + ": " + cardOne);
                    Console.WriteLine("Computer: " + cardTwo);

                    if (cardOne.GetRank() > cardTwo.GetRank())
                    {                        
                        CompleteRound(playerOne, warPile);
                        Console.WriteLine(playerName + " wins round " + round++);                             
                    }
                    else if (cardOne.GetRank() < cardTwo.GetRank())
                    {                        
                        CompleteRound(computer, warPile);
                        Console.WriteLine("Computer wins round " + round++);                                                
                    }
                    else
                    {
                        // war      
                        isWar = true;                        

                        Console.WriteLine("War! Three cards each will be placed into the pile. " +
                            "The fourth card will be revealed!");                          

                        for (int i = 0; i < 3; i++)
                        {
                            if (playerOne.GetCardCount() == 0 || computer.GetCardCount() == 0)
                            {
                                break;
                            }
                            Card playerOneWarCard = playerOne.RevealCard();
                            Card computerWarCard = computer.RevealCard();

                            if (playerOneWarCard != null && computerWarCard != null)
                            {
                                warPile.Add(playerOneWarCard);
                                warPile.Add(computerWarCard);
                            }
                        }
                    }                        
                }                
            }
        }

        private void CompleteRound(Player player, IList<Card> warPile)
        {
            isWar = false;
            warPile.ShuffleList();
            player.AddCards(warPile);
            warPile.Clear();
        }

        private void InitializeGame()
        {
            Console.WriteLine("Welcome to the card game of War! Enter your name to play the computer.");
            playerName = Console.ReadLine();

            interactiveMode = SetInteractive();

            deck = new Deck();
            playerOne = new Player();
            computer = new Player();

            deck.ShuffleDeck();
            deck.DealCards(playerOne, computer);

            warPile = new List<Card>();
            round = 1;
            isWar = false;          
        }

        private bool SetInteractive()
        {
            while (true)
            {
                Console.WriteLine("Press '1' for interactive mode. Press '2' for auto mode");
                string input = Console.ReadLine();
                if (input == "1")
                {
                    return true;                    
                }
                else if (input == "2")
                {
                    return false;
                }
            }
        }
    }
}
