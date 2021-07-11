using System;

namespace DeckOfCards.RunnerConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Creating a new deck");
            // Instantiating and creating a new deck.
            Deck deck = Deck.CreateDeckofCards();
            foreach (var card in deck.Cards)
            {

                Console.WriteLine("Card is " + card.CardSuit.ToString() + " " + card.CardFace.FaceName);


            }
            Console.ReadLine();
        }
    }
}
