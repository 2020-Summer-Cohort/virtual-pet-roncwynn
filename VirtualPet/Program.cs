using System;
using System.Net.NetworkInformation;

//DEBUG ByPass Hardcoding Start
//DEBUG ByPass Hardcoding End
//DEBUG ByPass Normal Code Start
//DEBUG ByPass Normal Code End

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
            //DEBUG ByPass Hardcoding Start
            string playerGameResponse = "y";
            //DEBUG ByPass Hardcoding End
            //DEBUG ByPass Normal Code Start
            //string playerGameResponse = Console.ReadLine();
            //DEBUG ByPass Normal Code End


            while (playerGameResponse.ToLower() != "y" && playerGameResponse.ToLower() != "n")
            {
                Console.WriteLine($"\n{playerGameResponse} is not a Y or N.  Please try again.");
                 playerGameResponse = Console.ReadLine();
            }
            if (playerGameResponse.ToLower() == "y")
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
            Console.WriteLine("\nGREAT.  Glad to want to play.");

            Pet playersPet = CreatePet();
            Console.WriteLine("\n CONGRATULATIONS");
            Console.WriteLine($"\nYou have created a new pet {playersPet.Species} named {playersPet.Name}.");
            Console.WriteLine($"\nYour pet has the following initial settings.");
            ShowPetStatus(playersPet);

            Console.WriteLine("\nAs you play the game these settings will change dependant on your actions.\nGood Luck!");

            PlayGame(playersPet);
        }

        public static void PlayGame(Pet somePet)
        {
            bool keepPlaying = true;
            while (keepPlaying)
            {
                Console.WriteLine($"\nWhat would you like to do with {somePet.Name}?");
                Console.WriteLine();
                Console.WriteLine($"1. Play with {somePet.Name}");
                Console.WriteLine($"2. Feed {somePet.Name}");
                Console.WriteLine("3. Quit the Game");

                string playerChoice = Console.ReadLine().ToLower();

                //TODO:  ???Create Methods for game actions???
                switch (playerChoice)
                {
                    case "1": //Play with Pet
                        somePet.Play();
                        Console.WriteLine($"You played with {somePet.Name}.");
                        break;
                    case "2": //Feed Pet
                        somePet.Feed();
                        Console.WriteLine($"You fed {somePet.Name}.");
                        break;
                    case "3": //Quit the Game
                        keepPlaying = false;
                        break;
                    default:
                        break;
                }
                somePet.Tick();
                ShowPetStatus(somePet);
            }

        }

        public static Pet CreatePet()
        {
            //DEBUG ByPass Hardcoding Start
            string playerPetSpeciesEntry = "tiger";
            string playerPetNameEntry = "ron";
            //DEBUG ByPass Hardcoding End
            //DEBUG ByPass Normal Code Start
            //Console.WriteLine("\nWhat kind of Pet would you like?");
            //string playerPetSpeciesEntry = Console.ReadLine();
            //Console.WriteLine("\nWhat would you like to name your pet?");
            //string playerPetNameEntry = Console.ReadLine();
            //DEBUG ByPass Normal Code End

            Pet somePet = new Pet(playerPetNameEntry, playerPetSpeciesEntry);

            return somePet;
        }

        public static void ShowPetStatus(Pet somePet)
        {
            Console.WriteLine($"\n{somePet.Name}'s HEALTH factor is {somePet.Health}.");
            Console.WriteLine($"HUNGER factor is {somePet.Hunger}.");
            Console.WriteLine($"THIRST factor is {somePet.Thirsty}.");
            Console.WriteLine($"ENERGY factor is {somePet.Energy}.");
            Console.WriteLine($"BOREDOM factor is {somePet.Boredom}.");
            Console.WriteLine($"IRRITATED factor is {somePet.Irritated}.");
        }
    }
}
