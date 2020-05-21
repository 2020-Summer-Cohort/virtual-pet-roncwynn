using System;
using System.Collections.Concurrent;
using System.Net.Mail;
using System.Net.NetworkInformation;
using System.Runtime.CompilerServices;

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

            string playerGameResponse = Console.ReadKey().KeyChar.ToString().ToLower();
            while (playerGameResponse != "y" && playerGameResponse != "n")
            {
                Console.WriteLine($"\nThat input was not a 'Y' or 'N'.  Please try again.");
                playerGameResponse = Console.ReadKey().KeyChar.ToString().ToLower();
            }
            if (playerGameResponse == "y")
            {
                StartGame();
            }
            else 
            {
                Console.WriteLine("\nPlease come back another time.");
            }
        }

        static void StartGame()
        {
            Console.Clear();
            Console.WriteLine("\nGREAT.  Glad you want to play.");

            Pet playersPet = CreatePet();

            Console.WriteLine("\n CONGRATULATIONS");
            Console.WriteLine($"\nYou have created a new pet {playersPet.GetSpecies()} named {playersPet.GetName()}.");
            Console.WriteLine($"\nIn this game pets have attributes that will change dependant on your actions.");
            Console.WriteLine("\nPress ENTER when ready to being playing the game.");
            Console.ReadLine();

            Console.Clear();

            Game playersGame = new Game();
            playersGame.PlayGame(playersPet);
        }

        static Pet CreatePet()
        {
            string playerPetSpeciesEntry = "";
            while (playerPetSpeciesEntry == "")
            { 
                Console.WriteLine("\nWhat kind of Pet would you like?");
                playerPetSpeciesEntry = Console.ReadLine();
            }

            string playerPetNameEntry = "";
            while (playerPetNameEntry == "")
            {
                Console.WriteLine("\nWhat would you like to name your pet?");
                playerPetNameEntry = Console.ReadLine();
            }

            Pet somePet = new Pet(playerPetNameEntry, playerPetSpeciesEntry);
            Console.WriteLine($"Energy = {somePet.GetEnergy()}");
            return somePet;
        }
        

    }
}
