using System;
using System.Collections.Concurrent;
using System.Net.Mail;
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
            string playerGameResponse = Console.ReadLine();

            while (playerGameResponse.ToLower() != "y" && playerGameResponse.ToLower() != "n")
            {
                Console.WriteLine($"\n{playerGameResponse} is not a Y or N.  Please try again.");
                 playerGameResponse = Console.ReadLine();
            }
            if (playerGameResponse.ToLower() == "y")
            {
                StartGame();
                //TODO:  Create Game Class, for Starting, Playing, Ending.  Figure best class for all Methods
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
            Console.WriteLine($"\nYou have created a new pet {playersPet.Species} named {playersPet.Name}.");
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
                ProcessTime(somePet);
                ShowPetStatus(somePet);
                ShowGameMenu(somePet.Name);
                string playerChoice = Console.ReadLine().ToLower();
                keepPlaying = ProcessPlayerChoice(playerChoice, someGame, somePet);
                Console.Clear();
                Console.WriteLine("\n");

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

        static bool ProcessPlayerChoice(string playerChoice, Game someGame, Pet somePet)
        {
            switch (playerChoice)
            {
                case "1": //Play with Pet
                    someGame.PlayWithPet(somePet);
                    return true;
                case "2": //Feed Pet
                    someGame.FeedPet(somePet);
                    return true;
                case "3": //Give Water
                    someGame.GivePetWater(somePet);
                    return true;
                case "4": //Take to Vet
                    someGame.TakePetToVet(somePet);
                    return true;
                case "5": //Let outside
                    someGame.LetPetOutside(somePet);
                    return true;
                case "6": //Sleep
                    someGame.LetPetSleep(somePet);
                    return true;
                case "7": //Do Nothing
                    someGame.LeavePetAlone(somePet);
                    return true;
                case "9": //Quit the Game
                        return  false;
                default:
                    return true;
            }

        }

        static void ProcessTime(Pet somePet)
        {
            somePet.Tick();
            CheckPetLevels(somePet);
        }

        static string CheckBoredomeLevel(Pet somePet)
        {
            string message;
            if (somePet.IsPetBored())
            {
                somePet.MaximizeBoredome();
                message = somePet.Name + " is EXTREMELY bored.  Best to play with " + somePet.Name + " before they start chewing on your furniture.";
            }
            else if (somePet.IsPetHappy())
            {
                somePet.ResetPetBoredome();
                message = somePet.Name + " feels very loved and appreciated.  Great Job!";
            }
            else
            {
                message = null;
            }
            return message;
        }
        static string CheckHungerLevel(Pet somePet)
        {
            string message;
            if (somePet.IsPetHungry())
            {
                message = somePet.Name + " is HUNGRY.  You might want to feed " + somePet.Name + " .";
                if (somePet.Hunger >= somePet.hungerThresholdMAX)
                { somePet.MaximizeHunger(); }
            }
            else if (somePet.IsPetFullOfFood())
            {
                somePet.MinimzeHunger();
                message = null;
            }
            else
            {
                message = null;
            }
            return message;
        }
        static string CheckThirstLevel(Pet somePet)
        {
            string message;
            if (somePet.IsPetThirsty())
            {
                message = somePet.Name + " is THIRSTY.  You might want to give " + somePet.Name + " some water.";
                if (somePet.Hydration <= somePet.hydrationThresholdMIN)
                { somePet.MinimizeHydration(); }
            }
            else if (somePet.IsPetFullOfWater())
            {
                somePet.MaximizeHydration();
                message = null;
            }
            else
            {
                message = null;
            }
            return message;
        }
        static string CheckEnergyLevel(Pet somePet)
        {
            string message;
            if (somePet.IsPetTired())
            {
                somePet.MinimizeEnergy();
                message = somePet.Name + " is low on ENERGY.  You might want to let them rest.";
            }
            else if (somePet.IsPetEnergized())
            {
                somePet.MaximizeEnergy();
                message = somePet.Name + " is full of ENERGY.  You might want to player with them.";
            }
            else
            {
                message = null;
            }
            return message;
        }
        static string CheckHealthLevel(Pet somePet)
        {
            string message;
            if (somePet.IsPetSick())
            {
                somePet.MinimizeHealth();
                message = somePet.Name + " is not feeling well.  You might want to take them to the vet.";
            }
            else if (somePet.IsPetHealthy())
            {
                somePet.MaximizeHealth();
                message = somePet.Name + " is completly healthy.";
            }
            else
            {
                message = null;
            }
            return message;
        }
        static string CheckIrritationLevel(Pet somePet)
        {
            string message;
            if (somePet.IsPetIrritated())
            {
                somePet.MaximizeIrritation();
                message = somePet.Name + " is IRRITATED.  You might want to take " + somePet.Name + " outside before they have an accident.";
                return message;
            }
            else if (somePet.IsPetContent())
            {
                somePet.MinimizeIrritation();
                message = null;
            }
            {
                message = null;
                return message;
            }
        }

        static void CheckPetLevels(Pet somePet)
        {
            string petBoredomeLevelMessage = CheckBoredomeLevel(somePet);
            string petIrritatedLevelMessage = CheckIrritationLevel(somePet);
            string petHungerLevelMessage = CheckHungerLevel(somePet);
            string petThirstLevelMessage = CheckThirstLevel(somePet);
            string petEnergyLevelMessage = CheckEnergyLevel(somePet);
            string petHealthLevelMessage = CheckHealthLevel(somePet);

            if (petBoredomeLevelMessage != null)
            { Console.WriteLine(petBoredomeLevelMessage); }

            if (petIrritatedLevelMessage != null)
            { Console.WriteLine(petIrritatedLevelMessage); }

            if (petHungerLevelMessage != null)
            { Console.WriteLine(petHungerLevelMessage); }

            if (petThirstLevelMessage != null)
            { Console.WriteLine(petThirstLevelMessage); }

            if (petEnergyLevelMessage != null)
            { Console.WriteLine(petEnergyLevelMessage); }

            if (petHealthLevelMessage != null)
            { Console.WriteLine(petHealthLevelMessage); }

        }
        static void ShowPetStatus(Pet somePet)
        {
            Console.WriteLine($"\nHere is how {somePet.Name} is doing:");
            Console.WriteLine($"\nHEALTH factor is {somePet.Health}.");
            Console.WriteLine($"HUNGER factor is {somePet.Hunger}.");
            Console.WriteLine($"THIRST factor is {somePet.Hydration}.");
            Console.WriteLine($"ENERGY factor is {somePet.Energy}.");
            Console.WriteLine($"BOREDOM factor is {somePet.Boredom}.");
            Console.WriteLine($"IRRITATED factor is {somePet.Irritated}.");
        }
    }
}
