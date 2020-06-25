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
    class Card
    {
       
        public Suits Suit { get; private set;}
        public Values Value { get; private set; }

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
        
    }
    

}
