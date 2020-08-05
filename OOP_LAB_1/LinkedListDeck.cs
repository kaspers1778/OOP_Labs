using System;


namespace OOP_LAB_1
{/// <Summary>
 /// One of concrete products,that represents deck based on Linked List.
 /// </Summary>
    class LinkedListDeck : IDeck
    {
        public LinkedList Cards;

        public LinkedListDeck()
        {
            Cards = new LinkedList();
            Console.WriteLine("LinkedListDeck has created.");
        }
        public bool isHaveCard(string val, string suit)
        {
            bool result = false;
            string[] cards = Cards.ToString().Split(",");
            for (int i = 0; i < cards.Length; i++)
            {
                if (cards[i] == new Card(suit, val).ToString())
                    result = true;
            }
            return result;
        }
        public void AddCard(string val, string suit)
        {
            if (Enum.IsDefined(typeof(Values), val) && Enum.IsDefined(typeof(Suits), suit))
            {
                if(isHaveCard(val,suit))
                {
                    Console.WriteLine("This card has been added yet.");
                }
                else
                {
                    Cards.Add(new Card(suit, val));
                }

            }
            else
            {
                Console.WriteLine("Enter valid name of card");
            }
        }

        public override string ToString()
        {
            string output = "Linked List deck is :";
            string[] cards =  Cards.ToString().Split(",");
            if (!Cards.isEmpty())
            {
                for (int i = 0; i < cards.Length; i++)
                {
                    output += "\n\t" + cards[i];
                }
            }
            else
            {
                output += "Empty";
            }
            return output;
        }
    }
        
    


}
