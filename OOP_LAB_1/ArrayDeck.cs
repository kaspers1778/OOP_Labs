using System;


namespace OOP_LAB_1
{/// <Summary>
 /// One of concrete products,that represents deck based on array.
 /// </Summary>
    class ArrayDeck : IDeck
    {
        public Card[] Cards;

        public ArrayDeck()
        {
            Cards = new Card[] { };
        }

        public bool isHaveCard(string val, string suit)
        {
            bool result = false;
            for(int i = 0; i < Cards.Length; i++)
            {
                if (Cards[i].Equals(new Card(suit, val)))
                    result = true;
            }
            return result;
        }

        public void AddCard(string val, string suit)
        {
            if (Enum.IsDefined(typeof(Values), val) && Enum.IsDefined(typeof(Suits), suit))
            {
                if (isHaveCard(val, suit))
                {
                    Console.WriteLine("This card has been added yet.");
                }
                else
                {
                    Array.Resize(ref Cards, Cards.Length + 1);
                    Cards[Cards.Length - 1] = new Card(suit, val);
                }
            }
            else
            {
                Console.WriteLine("Enter valid name of card");
            }

        }

        public override string ToString()
        {
            string output = "Array deck is :";
            if (Cards.Length > 0)
            {
                for (int i = 0; i < Cards.Length; i++)
                {
                    output += "\n\t" + Cards[i].ToString();
                }
            }
            else
            {
                output += " Empty";
            }
            return output;
        }
    }
        
    


}
