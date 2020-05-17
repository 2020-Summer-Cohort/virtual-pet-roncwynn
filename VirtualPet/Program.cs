using System;
using System.Net.Mail;
using System.Net.NetworkInformation;

//TODO:  De-Coulpe Start and Play game methods
//TODO:  Create Game Class
//TODO:  Decide best place for CreatePet and ShowStatus methods
//TODO:  Add color to ouput

//TODO:  Add prioritization in things pets does on its own
//TODO:  Add changes in values to PetStatus message

//TODO:  Add pet uncooperative actions (Random number???)
//TODO:  Favorite foods for pet and different reactions
//TODO:  Visual representation of pet

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
                //PlayGame
                //EndGame
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
                Console.WriteLine($"3. Give {somePet.Name} some water.");
                Console.WriteLine($"4. Take {somePet.Name} to the Vet.");
                Console.WriteLine($"5. Let {somePet.Name} outside to do thier business.");
                Console.WriteLine($"6. Do nothing with {somePet.Name}.");
                Console.WriteLine("9. Quit the Game");

                string playerChoice = Console.ReadLine().ToLower();

                Console.Clear();
                Console.WriteLine();
                Console.WriteLine();
                //TODO:  ???Create Classes/Methods for game actions???
                switch (playerChoice)
                {
                    case "1": //Play with Pet
                        {
                            Random rand = new Random();
                            int petPlayFactor = rand.Next(1, 6);
                            if (petPlayFactor != 4)
                                {
                                    somePet.Play();
                                    Console.WriteLine($"You played with {somePet.Name}.");
                                }
                            else
                            {
                                Console.WriteLine($"{somePet.Name} doesn't want to play right now.");
                            }
                        }
                        break;
                    case "2": //Feed Pet
                        {
                            if (somePet.GetHunger() <= somePet.hungerThresholdMAX)
                            {
                                somePet.Feed();
                                Console.WriteLine($"You fed {somePet.Name}.");
                            }
                            else
                            {
                                Console.WriteLine($"{somePet.Name} isn't hungry right now, maybe try something else.");
                            }
                            break;
                        }
                    case "3": //Give Water
                       {
                            if (somePet.GetHyrdation() <= somePet.healthThresholdMIN)
                            {
                                somePet.Drink();
                                Console.WriteLine($"You gave {somePet.Name} some water to drink.");
                            }
                            else
                            {
                                Console.WriteLine($"{somePet.Name} is fully hydrated.  Act quick before {somePet.Name} has an accident!");
                            }
                            break;
                        }
                    case "4": //Take to Vet
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
                            break;
                        }
                    case "5": //Let outside
                        {
                            if (somePet.GetIrritable() > somePet.irritabaleThresholdMIN)
                            { 
                                somePet.Relieve(); 
                                Console.WriteLine($"You let {somePet.Name} relieve themself and {somePet.Name} is happy!");
                            }
                            else
                            {
                                Console.WriteLine($"{somePet.Name} is being stubborn and won't go outside right now.");
                            }
                            break;
                        }
                    case "6": //Do Nothing
                        {
                            Console.WriteLine($"{somePet.Name} is doing their own thing.");
                            somePet.Ignore();
                            somePet.LivingPetProcess();
                            break;
                        }
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
                return message;
            }
            else if (somePet.IsPetHappy())
            {
                somePet.ResetPetBoredome();
                message = somePet.Name + " feels very loved and appreciated.  Great Job!";
                return message;
            }
            else
            {
                message = null;
                return message;
            }
        }

        public static void CheckPetLevels(Pet somePet)
        {
            string petBoredomeLevel = CheckBoredomeLevel(somePet);
            if (petBoredomeLevel != null)
            { Console.WriteLine(petBoredomeLevel); }

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
            Console.WriteLine($"THIRST factor is {somePet.Hydration}.");
            Console.WriteLine($"ENERGY factor is {somePet.Energy}.");
            Console.WriteLine($"BOREDOM factor is {somePet.Boredom}.");
            Console.WriteLine($"IRRITATED factor is {somePet.Irritated}.");
        }
    }
}
