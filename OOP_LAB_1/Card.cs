using System;
namespace OOP_LAB_1

{
    enum Suits
    {
        Hearts,Diamonds,Clubs,Spades
    }

    enum Values
    {
        Six,Seven,Eight,Nine,Ten,Jack,Queen,King,Ace
    }

    /// <Summary>
    /// Class,objects of which represent's game cards with Suit and Value.
    /// </Summary>
    class Card
    {
        
        public Suits Suit { get; private set;}
        public Values Value { get; private set; }
        /// <Summary>
        /// Constructor of card.
        /// </Summary>
        public Card(string suit,string value)
        {
            if (Enum.IsDefined(typeof(Values), value) && Enum.IsDefined(typeof(Suits), suit))
            {
                this.Suit = (Suits)Enum.Parse(typeof(Suits), suit);
                this.Value = (Values)Enum.Parse(typeof(Values), value);

            }
            else
            {
                Console.WriteLine("Enter valid name of card");
            }
        }
        /// <Summary>
        /// Function for useful outputting in console.
        /// </Summary>
        public override string ToString()
        {
            return Value + " of " + Suit;
        }
        /// <Summary>
        /// Function to compare objects of this type.
        /// </Summary>
        public bool Equals(Card card2)
        {
            return (Suit == card2.Suit
                        && Value == card2.Value);
        }
    }
    

}
