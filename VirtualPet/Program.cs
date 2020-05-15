using System;
using System.Net.NetworkInformation;

namespace VirtualPet
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello! Welcome to Virtual Pets");
            Console.WriteLine("\nVirtual Pets is a game whereby which you, the Player, can create an imaginary pet inside the computer.");
            Console.WriteLine("\nYou will be able interact with this pet for a short or as long as you like");

            Console.WriteLine("\nWould you like to play the Virtual Pet game now?  Please press Y or N");
            //TODO:  Change this to a single character input
            string playerGameResponse = Console.ReadLine();

            //Console.WriteLine($"\nuser entered = {playerGameResponse}");

            while (playerGameResponse.ToLower() != "y" && playerGameResponse.ToLower() != "n")
            {
                Console.WriteLine($"\n{playerGameResponse} is not a Y or N.  Please try again.");
                 playerGameResponse = Console.ReadLine();
            }
            if (playerGameResponse.ToLower() == "y")
            {
                PlayGame();
            }
            else 
            {
                Console.WriteLine("\nPlease come back another time.");
            }
        }

        static void PlayGame()
        {
            Console.Clear();
            Console.WriteLine("\nGREAT.  Glad to want to play.");

            //Create Pet with Name and Species selection
            Pet playersPet = CreatePet();

            //Show Current Pet Status
            //TODO:  Create Method to show Pet Status
            Console.WriteLine("\n CONGRATULATIONS");
            Console.WriteLine($"\nYou have created a new pet {playersPet.Species} named {playersPet.Name}.");
            Console.WriteLine($"\nYour pet has the following initial settings.");
            Console.WriteLine($"\n{playersPet.Name}'s HEALTH factor is {playersPet.Health}.");
            Console.WriteLine($"Their HUNGER factor is {playersPet.Hunger}.");
            Console.WriteLine($"And their BOREDOM factor is {playersPet.Boredom}.");

            Console.WriteLine("\nAs you play the game these settings will change dependant on your actions.\nGood Luck!");

            //Game Loop
            //TODO:  Create Method for Game Loop
            bool keepPlaying = true;
            while (keepPlaying)
            {
                Console.WriteLine($"\nWhat would you like to do with {playersPet.Name}?");
                Console.WriteLine();
                Console.WriteLine("1. Play");
                Console.WriteLine("2. Feed");
                Console.WriteLine("3. Quit");

                string playerChoice = Console.ReadLine().ToLower();

                //TODO:  Create Methods for game actions
                switch (playerChoice)
                {
                    case "1":
                        break;
                    case "2":
                        break;
                    case "3":
                        keepPlaying = false;
                        break;
                    default:
                        break;
                }
            }
        }

        public static Pet CreatePet()
        {
            Console.WriteLine("\nWhat kind of Pet would you like?");
            string playerPetSpeciesEntry = Console.ReadLine();
            Console.WriteLine("\nWhat would you like to name your pet?");
            string playerPetNameEntry = Console.ReadLine();

            Pet somePet = new Pet(playerPetNameEntry, playerPetSpeciesEntry);

            return somePet;
        }
    }
}
