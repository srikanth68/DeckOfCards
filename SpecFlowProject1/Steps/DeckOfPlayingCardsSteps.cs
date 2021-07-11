using System;
using TechTalk.SpecFlow;
using FluentAssertions;
using System.Linq;
using DeckOfCards;
using System.Collections.Generic;
using static DeckOfCards.Card;

namespace DeckOfCardsSpecFlow.Steps
{
    [Binding]
    public class DeckOfPlayingCardsSteps
    {
        private Deck deck;
        private int count;

        [Given(@"a deck of cards")]
        public void GivenADeckOfCards()
        {
            // Creating a full deck
            deck = Deck.CreateDeckofCards();
        }

        [When(@"I count each card")]
        public void WhenICountEachCard()
        {    // Getting the count of the deck
            count = deck.Cards.Count();
        }

        [When(@"I check for suits")]
        public void WhenICheckForSuits()
        {
            // Getting distinct suits in a deck
            List<Suit> suitsinDeck = GetDistinctSuitsInDeck();


        }

        private List<Suit> GetDistinctSuitsInDeck()
        {
            return deck.Cards.Select(x => x.CardSuit).Distinct().ToList();

        }
        private bool IsSuitValid(Suit suit)
        {
            // Checking if the given suit is valid
            switch (suit)
            {
                case Suit.Spades: return true;
                case Suit.Clubs: return true;
                case Suit.Diamonds: return true;
                case Suit.Hearts: return true;
                default: return false;

            }
        }

        [When(@"I count all the cards in a single suit")]
        public void WhenICountAllTheCardsInASingleSuit()
        {

        }

        [When(@"I have a card with (.*)")]
        public void WhenIHaveACardWith(string p0)
        {

        }

        [Then(@"I have a total of (.*) cards")]
        public void ThenIHaveATotalOfCards(int p0)
        {
            count.Should().Be(p0);
        }

        [Then(@"I see hearts, clubs, spades, and diamonds")]
        public void ThenISeeHeartsClubsSpadesAndDiamonds()
        {
            // checking the given suits are valid
            List<Suit> suitsInDeck = GetDistinctSuitsInDeck();
            foreach (Suit suit in suitsInDeck)
            {
                IsSuitValid(suit).Should().BeTrue();
            }
        }

        [Then(@"I have (.*) cards: ace, (.*), (.*), (.*), (.*), (.*), (.*), (.*), (.*), (.*), Jack, Queen, King")]
        public void ThenIHaveCardsAceJackQueenKing(int p0, int p1, int p2, int p3, int p4, int p5, int p6, int p7, int p8, int p9)
        {
            // checking the card count for a given Suit
            var cardCount = deck.Cards.Where(x => x.CardSuit == Suit.Diamonds).Count();
            cardCount.Should().Be(p0);
        }

        [Then(@"the card is worth (.*)")]
        public void ThenTheCardIsWorth(string p0, Table table)
        {
            List<string> FaceCards = new List<string>() { "ace", "Jack", "Queen", "King" };

            foreach (TableRow row in table.Rows)
            {

                foreach (var card in deck.Cards)
                {
                    if (FaceCards.Contains(row["<face_value>"]) && row["<face_value>"].Equals(card.CardFace.FaceName.ToString(), StringComparison.OrdinalIgnoreCase))
                    {
                        // checking the value of a face card
                        card.CardFace.FaceValue.ToString().Should().Be(row["<point_value>"]);

                    }
                    else
                    {

                        if (row["<face_value>"].Equals(card.CardFace.FaceValue.ToString()))
                        {
                            // checking the value of a number card
                            card.CardFace.FaceValue.ToString().Should().Be(row["<point_value>"]);
                        }

                    }

                }



            }

        }

        [Then(@"the face cards are ordered Jack, Queen, King")]
        public void ThenTheFaceCardsAreOrderedJackQueenKing()
        {
            Deck sortedDeck = deck;
            sortedDeck.SortFaceCards();
            // checking the order of the face cards and queen coming after king, Jack coming before queen scenarios
            sortedDeck.Cards[51].CardFace.FaceName.Should().Be("King");
            sortedDeck.Cards[50].CardFace.FaceName.Should().Be("Queen");
            sortedDeck.Cards[10].CardFace.FaceName.Should().Be("Jack");
        }


    }
}
