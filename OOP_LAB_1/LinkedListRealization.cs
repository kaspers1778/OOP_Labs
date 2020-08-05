namespace OOP_LAB_1
{
    /// <Summary>
    /// Creator Class of Linked List-type Deck.
    /// </Summary>
    class LinkedListRealization : Realization
    {
        public override IDeck Create()
        {
            return new LinkedListDeck();
        }
    }
}
