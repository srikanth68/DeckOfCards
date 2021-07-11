using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace DeckOfCards
{
    /// <summary>
    ///  Class defining a Deck of cards, creatig a deck and sorting a deck
    /// </summary>
    public class Deck
    {
        // List to hold all the cards in the deck
        public List<Card> Cards;

        // List to apply card faces and values to each card
        public List<CardFace> CardFaces;

        // Constructor instantiating the properties
        private Deck()
        {
            // instantiating an empty list of cards
            Cards = new List<Card>();
            // Creating card faces and its values and sort orders
            CardFaces = new List<CardFace>{
                                    new CardFace("ace", 1,1),
                                    new CardFace("Two", 2,1),
                                    new CardFace("Three", 3,1),
                                    new CardFace("Four", 4,1),
                                    new CardFace("Five", 5,1),
                                    new CardFace("Six", 6,1),
                                    new CardFace("Seven", 7,1),
                                    new CardFace("Eight", 8,1),
                                    new CardFace("Nine", 9,1),
                                    new CardFace("Ten", 10,1),
                                    new CardFace("Jack", 10,2),
                                    new CardFace("Queen", 10,3),
                                    new CardFace("King", 10,4)
            };
        }

        // Static Create method to create the deck of cards
        public static Deck CreateDeckofCards()
        {
            Deck deck = new Deck();

            // Iterating through all the Suits. total 4 suits
            foreach (var suit in Enum.GetValues(typeof(Suit)))
            {
                // Iterating through all the cardfaces, total 13 card faces
                foreach (CardFace face in deck.CardFaces)
                {
                    deck.Cards.Add(new Card((Suit)suit, face));
                }

            }
            return deck;
        }

        // Sord method which sorts the cards based on sort order
        public void SortFaceCards()
        {
            Cards.GroupBy(x => x.CardSuit).OrderByDescending(y => y.Count()).SelectMany(z => z.OrderBy(c => c.CardFace.SortOrder));

        }
    }
}
