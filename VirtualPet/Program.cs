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
            PlayGame(playersGame, playersPet);
        }

        static void PlayGame(Game someGame, Pet somePet)
        {
            bool keepPlaying = true;
            while (keepPlaying)
            {
                ShowPetStatus(somePet);
                ShowGameMenu(somePet.GetName());
                string playerChoice = Console.ReadLine().ToLower();
                //TODO:  better variable name here
                string gameFeedbackToPlayer = ProcessPlayerChoice(playerChoice, someGame, somePet);

                Console.Clear();
                Console.WriteLine("\n");
                Console.WriteLine(gameFeedbackToPlayer);

                //TODO:  better variable name here
                string petFeedbacktoPlayer = someGame.ProcessTime(somePet);
                Console.WriteLine(petFeedbacktoPlayer);

                //TODO:  Find beter way to do this
                if (gameFeedbackToPlayer == "QuitGame")
                    keepPlaying = false;

            }
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
        
        static void ShowGameMenu(string petName)
        {
            Console.WriteLine($"\nWhat would you like to do with {petName}?");
            Console.WriteLine();
            Console.WriteLine($"1. Play with {petName}                2.Feed { petName}");
            Console.WriteLine($"3. Give {petName} some water.         4.Take { petName} to the Vet.");
            Console.WriteLine($"5. Let {petName} outside.             6. Put {petName} to bed.");
            Console.WriteLine($"7. Do nothing with {petName}.");
            Console.WriteLine("\n9. Quit the Game");
        }

        static string ProcessPlayerChoice(string playerChoice, Game someGame, Pet somePet)
        {
            string message = "";
            switch (playerChoice)
            {
                case "1": //Play with Pet
                    message = someGame.PlayWithPet(somePet);
                    return message;
                case "2": //Feed Pet
                    message = someGame.FeedPet(somePet);
                    return message;
                case "3": //Give Water
                    message = someGame.GivePetWater(somePet);
                    return message;
                case "4": //Take to Vet
                    message = someGame.TakePetToVet(somePet);
                    return message;
                case "5": //Let outside
                    message = someGame.LetPetOutside(somePet);
                    return message;
                case "6": //Sleep
                    message = someGame.LetPetSleep(somePet);
                    return message;
                case "7": //Do Nothing
                    message = someGame.LeavePetAlone(somePet);
                    return message;
                case "9": //Quit the Game
                    message = "QuitGame";
                    return message;
                default:
                    message = "Invalid Choice.  Please try again.";
                    return message;
            }

        }

        static void ShowPetStatus(Pet somePet)
        {
            Console.WriteLine($"\nHere is how {somePet.GetName()} is doing:");
            Console.WriteLine($"\nHEALTH factor is {somePet.GetHealth()}.");
            Console.WriteLine($"HUNGER factor is {somePet.GetHunger()}.");
            Console.WriteLine($"THIRST factor is {somePet.GetHyrdation()}.");
            Console.WriteLine($"ENERGY factor is {somePet.GetEnergy()}.");
            Console.WriteLine($"BOREDOM factor is {somePet.GetBoredom()}.");
            Console.WriteLine($"IRRITATED factor is {somePet.GetIrritable()}.");
        }
    }
}
