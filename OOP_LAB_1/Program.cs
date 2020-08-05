using System;
namespace OOP_LAB_1
{
    class Program
    { 
        static void Main(string[] args)
        {
              Realization real; //initialisation of Factory class

              real = ChooseRealisation(); //picking a creator's type

              IDeck deck = real.Create(); //Creating concrete product by 
                                          // general interface

              AddCardLoop(deck);          //Working with concrete product

        }
        /// <Summary>
        /// Function to choose realisation between Array deck and Linked list deck.
        /// </Summary>
        public static Realization ChooseRealisation()
        {
            Console.WriteLine("What type of deck you want to create?");
            Console.WriteLine("\ta - Array deck");
            Console.WriteLine("\tl - Linked list deck");
            switch (Console.ReadLine())
            {
                case "a":
                    return new ArrayRealization();
                case "l":
                    return new LinkedListRealization();
                default:
                    Console.WriteLine("There is no such option. Press any key to try again.");
                    Console.ReadKey();
                    Console.Clear();
                    return ChooseRealisation();
            }
        }
        /// <Summary>
        /// Function to add Card in Deck as long as user wants.
        /// </Summary>
        public static void AddCardLoop(IDeck deck)
        {
            Console.Clear();
            Console.WriteLine(deck.ToString());
            Console.WriteLine("Do you want to add new card to a deck?");
            Console.WriteLine("\ty - Yes");
            Console.WriteLine("\tn - No");
            switch (Console.ReadLine())
            {
                case "y":
                    Console.Clear();
                    Console.WriteLine("Write the value of new card");
                    string value = Console.ReadLine();
                    Console.WriteLine("Write the suit of new card");
                    string suit = Console.ReadLine();
                    deck.AddCard(value, suit);
                    Console.WriteLine("Press any key to continue");
                    Console.ReadKey();
                    Console.Clear();
                    AddCardLoop(deck);
                    break;
                case "n":
                    Console.Clear();
                    Console.WriteLine(deck.ToString());
                    Console.WriteLine("Press any key to quit");
                    Console.ReadKey();
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("There is no such option. Press any key to try again.");
                    Console.ReadKey();
                    Console.Clear();
                    AddCardLoop(deck);
                    break;
            }

        }

    }
}
