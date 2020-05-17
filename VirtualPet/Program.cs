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
                //Branch Test

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
            ShowPetStatus(playersPet);

            Console.WriteLine("\nAs you play the game these settings will change dependant on your actions.\nGood Luck!");
            PlayGame(playersPet);
        }

        public static void PlayWithPet(Pet somePet)
        {
            Random rand = new Random();
            int petPlayFactor = rand.Next(1, 6);
            if (petPlayFactor == 4)
            {
                Console.WriteLine($"{somePet.Name} doesn't want to play right now.");
            }
            else
            {
                somePet.Play();
                Console.WriteLine($"You played with {somePet.Name}.");
            }
        }

        public static void FeedPet(Pet somePet)
        {
            if (somePet.GetHunger() > somePet.hungerThresholdMIN)
            {
                somePet.Feed();
                Console.WriteLine($"You fed {somePet.Name}.");
            }
            else
            {
                Console.WriteLine($"{somePet.Name} isn't hungry right now, maybe try something else.");
            }
        }

        public static void GivePetWater(Pet somePet)
        {
            if (somePet.GetHyrdation() < somePet.hydrationThresholdMAX)
            {
                somePet.Drink();
                Console.WriteLine($"You gave {somePet.Name} some water to drink.");
            }
            else
            {
                Console.WriteLine($"{somePet.Name} is fully hydrated.  Act quick before {somePet.Name} has an accident!");
            }
        }

        public static void TakePetToVet(Pet somePet)
        {
            if (somePet.GetHealth() < somePet.healthThresholdMAX)
            {
                somePet.SeeDoctor();
                Console.WriteLine($"You took {somePet.Name} to the vet and all is well.");
            }
            else
            {
                Console.WriteLine($"{somePet.Name} is as healthy as can be.  Save your money.");
            }
        }

        public static void LetPetOutside(Pet somePet)
        {
            if (somePet.GetIrritable() > somePet.irritabaleThresholdMIN)
            {
                somePet.Relieve();
                Console.WriteLine($"You let {somePet.Name} relieve themself.");
            }
            else
            {
                Console.WriteLine($"{somePet.Name} is being stubborn and won't go outside right now.");
            }
        }

        public static void LetPetSleep(Pet somePet)
        {
            if (somePet.IsPetTired())
            {
                Console.WriteLine($"{somePet.Name} is sleeping soundly.");
                somePet.Sleep();
            }
            else if (somePet.IsPetEnergized())
            {
                Console.WriteLine($"{somePet.Name} is full of energy right now and refuses to sleep.");
            }
            else
            {
                somePet.Sleep();
            }
        }

        public static void LeavePetAlone(Pet somePet)
        {
            Console.WriteLine($"{somePet.Name} is doing their own thing.");
            somePet.Ignore();

            Random rand = new Random();
            int petFreedomFactor = rand.Next(1, 4);

            switch (petFreedomFactor)
            {
                case 1:
                    somePet.Sleep();
                    break;
                case 2:
                    somePet.Feed();
                    break;
                case 3:
                    somePet.Drink();
                    break;
            }
            somePet.LivingPetProcess();
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
                Console.WriteLine($"3. Give {somePet.Name} some water.");
                Console.WriteLine($"4. Take {somePet.Name} to the Vet.");
                Console.WriteLine($"5. Let {somePet.Name} outside to do thier business.");
                Console.WriteLine($"6. Put {somePet.Name} to bed.");
                Console.WriteLine($"7. Do nothing with {somePet.Name}.");
                Console.WriteLine("\n9. Quit the Game");

                string playerChoice = Console.ReadLine().ToLower();

                Console.Clear();
                Console.WriteLine("\n\n");
                //TODO:  Create Classes/Methods for game actions
                switch (playerChoice)
                {
                    case "1": //Play with Pet
                        PlayWithPet(somePet);
                        break;
                    case "2": //Feed Pet
                        FeedPet(somePet);
                        break;
                    case "3": //Give Water
                        GivePetWater(somePet);
                         break;
                    case "4": //Take to Vet
                        TakePetToVet(somePet);
                        break;
                    case "5": //Let outside
                        LetPetOutside(somePet);
                        break;
                    case "6": //Sleep
                        LetPetSleep(somePet);
                        break;
                    case "7": //Do Nothing
                        LeavePetAlone(somePet);
                        break;
                    case "9": //Quit the Game
                        {
                            keepPlaying = false;
                            break;
                        }
                    default:
                        break; 
                }
                if (keepPlaying)
                {
                    ProcessTime(somePet);
                    ShowPetStatus(somePet);
                }
            }
        }

        public static void ProcessTime(Pet somePet)
        {
            somePet.Tick();
            CheckPetLevels(somePet);
        }

        public static string CheckBoredomeLevel(Pet somePet)
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
        public static string CheckHungerLevel(Pet somePet)
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
        public static string CheckThirstLevel(Pet somePet)
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
        public static string CheckEnergyLevel(Pet somePet)
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
        public static string CheckHealthLevel(Pet somePet)
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
        public static string CheckIrritationLevel(Pet somePet)
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

        public static void CheckPetLevels(Pet somePet)
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

        public static Pet CreatePet()
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

        public static void ShowPetStatus(Pet somePet)
        {
            Console.WriteLine($"\nHere is how {somePet.Name} is doing:");
            Console.WriteLine($"HEALTH factor is {somePet.Health}.");
            Console.WriteLine($"HUNGER factor is {somePet.Hunger}.");
            Console.WriteLine($"THIRST factor is {somePet.Hydration}.");
            Console.WriteLine($"ENERGY factor is {somePet.Energy}.");
            Console.WriteLine($"BOREDOM factor is {somePet.Boredom}.");
            Console.WriteLine($"IRRITATED factor is {somePet.Irritated}.");
        }
    }
}
