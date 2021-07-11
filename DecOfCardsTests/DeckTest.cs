using DeckOfCards;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace DecOfCardsTests
{
    [TestClass]
    public class DeckTest
    {

        private Deck deck;

        [TestInitialize]
        public void InitializeTest()
        {

            deck = Deck.CreateDeckofCards();
        }

        [TestMethod]
        public void CheckIfFullDeckIsCreated()
        {
            int totalSizeOfDeck = 52;
             Assert.AreEqual(deck.Cards.Count(), totalSizeOfDeck);
            
        }

        [TestMethod]
        public void CheckIfDeckHasOnlyFourSuits()
        {
            int numOfSuits = 4;
            Assert.AreEqual(deck.Cards.Select(x=>x.CardSuit).Distinct().Count(), numOfSuits);

        }

        [TestMethod]
        public void CheckIfAGivenSuitHas13CardsOnly()
        {
            int numOfCardsInASuit = 13;
            Assert.AreEqual(deck.Cards.Where(x=>x.CardSuit==Suit.Clubs).Count(), numOfCardsInASuit);

        }

        [TestMethod]
        public void CheckIfDeckHasNoDuplicateCards()
        {
            int count = deck.Cards.Count();
            int distinctCount = deck.Cards.Distinct().Count();

            Assert.AreEqual(count,distinctCount);

        }

       
        [TestMethod]
        public void IsDeckSortedCorrectly()
        {
            deck.SortFaceCards();

            Card firstCard = deck.Cards.Where(x => x.CardSuit == Suit.Diamonds && x.CardFace.FaceName.Equals("Two")).FirstOrDefault();
            Card secondCard = deck.Cards.Where(x => x.CardSuit == Suit.Diamonds && x.CardFace.FaceName.Equals("King")).FirstOrDefault();
            Assert.IsTrue(deck.Cards.IndexOf(firstCard) < deck.Cards.IndexOf(secondCard));
        }
    }
}
