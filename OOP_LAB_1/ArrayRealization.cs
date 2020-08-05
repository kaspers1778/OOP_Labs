namespace OOP_LAB_1
{    /// <Summary>
     /// Creator Class of Array-type Deck.
     /// </Summary>
    class ArrayRealization : Realization
    { 
        public override IDeck Create()
        {
           return new ArrayDeck();
        }
    }

}
