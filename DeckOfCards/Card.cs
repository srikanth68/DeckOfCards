using System;
using System.Collections.Generic;
using System.Text;

namespace DeckOfCards
{
    /// <summary>
    ///  Class defind a card in the deck with properties like Suit and Cardface to identify the card
    /// </summary>
    public class Card
    {

        // Each card needs a SUIT which can be given through this enum property
        public Suit CardSuit { get; }
        // Each card needs a face value, either a number(2-10) or a face like Ace, Jack, Queen, King
        public CardFace CardFace { get; }

        // Constructor to instantiate each card
        public Card(Suit _suit, CardFace _face)
        {
            CardSuit = _suit;
            CardFace = _face;

        }

    }

    // Enum to distinguish the Suit of the card
    public enum Suit { Spades = 1, Clubs = 2, Diamonds = 3, Hearts = 4 }
}
