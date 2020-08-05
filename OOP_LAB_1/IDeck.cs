namespace OOP_LAB_1
{
    /// <Summary>
    /// General Interface for concrete products. 
    /// </Summary>
    interface IDeck
    {
        /// <Summary>
        /// Function to add a card to some type of deck.
        /// </Summary>
        void AddCard(string val, string suit);
        /// <Summary>
        /// Function to check if card is in the deck.
        /// </Summary>
        bool isHaveCard(string val, string suit);
        /// <Summary>
        /// Function for useful outputting in console.
        /// </Summary>
        

    }
}
