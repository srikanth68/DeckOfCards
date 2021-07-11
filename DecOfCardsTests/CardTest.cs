using DeckOfCards;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DecOfCardsTests
{
    [TestClass]
    public class CardTest
    {
        [TestMethod]
        public void CheckCorrectCardIsCreated()
        {


            Card card = new Card(Suit.Diamonds, new CardFace("Two", 2, 1));
            Assert.AreEqual(card.CardSuit, Suit.Diamonds);
            

        }
         [TestMethod]
        public void CheckFaceCardsHasValue10()
        {
            Card card = new Card(Suit.Spades, new CardFace("King", 10, 4));
            Assert.AreEqual(card.CardFace.FaceValue, 10);
            Assert.AreEqual(card.CardFace.FaceName, "King");

        }


    }
}
