using System;
using System.Collections.Generic;
using System.Text;

namespace DeckOfCards
{
    /// <summary>
    ///  Class to define multiple face types that are available in a normal deck
    /// </summary>
    public class CardFace
    {
        // Facename property gives the card a common name like Two or Jack
        public string FaceName { get; set; }

        // FaceValue gives an integer value to the cardface. Special cards Jack, Queen and King all have a value of 10
        public int FaceValue { get; set; }

        // SortOrder helps to sort the deck in desired order
        public int SortOrder { get; set; }

        // Constructor to initialize the properties
        public CardFace(string _faceName, int _faceValue, int _sortOrder)
        {

            FaceName = _faceName;
            FaceValue = _faceValue;
            SortOrder = _sortOrder;
        }
    }
}
