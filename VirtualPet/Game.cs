using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Net.Http;
using System.Reflection.PortableExecutable;
using System.Text;

namespace VirtualPet
{
    public class Game
    {
        public Game()
        {
        }

        public void BeginGame()
        {
            Shelter someShelter = new Shelter();
            AddInitalPetsToShelter(someShelter);
            PlayGame(someShelter);
        }

        private void AddInitalPetsToShelter(Shelter someShelter)
        {
            OrganicPet someOrganicPet = new OrganicPet("Ron", "Lion");
            someShelter.AddPetToShelter(someOrganicPet);
            RoboticPet someRoboticPet = new RoboticPet("Alex", "Dog");
            someShelter.AddPetToShelter(someRoboticPet);
            someOrganicPet = new OrganicPet("Rachel", "Cat");
            someShelter.AddPetToShelter(someOrganicPet);
        }

        private void ShowShelterFullMessage()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("\nSorry, the Shelter is currently at capacity.");
            Console.WriteLine("\n\nPlease try again later.");
        }

        private void ShowShelterEmptyMessage(Shelter someShelter)
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("We are very sorry but at this time the shetler is empty.");
            Console.WriteLine("\nIf you have pet that needs a new home, please feel free to donate them to the shelter.");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("\n\nPlease press ENTER to return to the main menu.");
            Console.ReadLine();
            Console.Clear();
        }

        private void CheckForAdoption(Shelter someShelter, Pet somePet)
        {
            Console.WriteLine($"Thanks for your interaction with {somePet.GetName()}.");
            Console.WriteLine($"\nWould you like to Adopt {somePet.GetName()}?");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Please enter (Y)es or (N)o.");
            string playerChoice = Console.ReadKey().KeyChar.ToString().ToLower();

            while (playerChoice != "y" && playerChoice != "n")
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"\nThat input was not a 'Y' or 'N'.  Please try again.");
                Console.ResetColor();
                playerChoice = Console.ReadKey().KeyChar.ToString().ToLower();
            }

            Console.ResetColor();
            Console.WriteLine();
            if (playerChoice == "y")
            { AdoptPet(someShelter, somePet); }
            else
            { Console.Clear(); }
        }

        private void PetOneOnOne(Shelter someShelter)
        {
            Pet selectedPet = SelectPet(someShelter);
            if (selectedPet != null)
            {
                Console.Clear();
                if (selectedPet is OrganicPet)
                {
                    OrganicPet pet = (OrganicPet)selectedPet;
                    InteractWithOrganicPet(pet); 
                }
                else if (selectedPet is RoboticPet)
                {
                    RoboticPet pet = (RoboticPet)selectedPet;
                    InteractWithRoboticPet(pet); 
                }
                Console.Clear();
                CheckForAdoption(someShelter, selectedPet);
            }
        }

        private void PlayGame(Shelter someShelter)
        {
            string playerFeedbackMessage = "";
            string selectedMenuOption = "";
            bool keepPlaying = true;
            while (keepPlaying)
            {
                ShowGameMainMenu(someShelter);
                selectedMenuOption = GetPlayerChoice();
                switch (selectedMenuOption)
                {
                    case "1":
                        ShowAllPets(someShelter);
                        break;
                    case "2":
                        if (someShelter.IsShelterEmpty())
                        { ShowShelterEmptyMessage(someShelter); }
                        else
                            { playerFeedbackMessage = FeedOrganicPets(someShelter); }
                        break;
                    case "3":
                        if (someShelter.IsShelterEmpty())
                        { ShowShelterEmptyMessage(someShelter); }
                        else
                            { playerFeedbackMessage = WaterOrganicPets(someShelter); }
                        break;
                    case "4":
                        if (someShelter.IsShelterEmpty())
                        { ShowShelterEmptyMessage(someShelter); }
                        else
                        { playerFeedbackMessage = OilRoboticPets(someShelter); }
                        break;
                    case "5":
                        if (someShelter.IsShelterEmpty())
                        { ShowShelterEmptyMessage(someShelter); }
                        else
                        { playerFeedbackMessage = PlayWithPets(someShelter); }
                        break;
                    case "6":
                        if (someShelter.IsShelterEmpty())
                        { ShowShelterEmptyMessage(someShelter); }
                        else
                        { PetOneOnOne(someShelter); }
                        break;
                    case "7":
                        AdmitPet(someShelter);
                        break;
                    case "8":
                        if (someShelter.IsShelterEmpty())
                        { ShowShelterEmptyMessage(someShelter); }
                        else
                        {
                            Pet selectedPet = SelectPet(someShelter);
                            AdoptPet(someShelter, selectedPet);
                        }
                        break;
                    case "9":
                        LeaveShelterMessage(someShelter);
                        keepPlaying = false;
                        break;
                    default:
                        Console.Clear();
                        playerFeedbackMessage = "\n\nInvalid Choice.  Please try again.";
                        break;
                }
                Console.WriteLine(playerFeedbackMessage);
                playerFeedbackMessage = "";
                Console.ResetColor();
            }
        }

        private void ShowGameMainMenu(Shelter someShelter)
        {
            //TODO:  add color???
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine($"{someShelter.GetShelterName()} Wildly Popular Pet Shelter");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\n            MAIN MENU");
            Console.WriteLine();
            Console.ResetColor();
            Console.WriteLine("1. Show all Pets in the Shelter");
            Console.WriteLine("2. Feed the Organic Pets");
            Console.WriteLine("3. Water the Organic Pets");
            Console.WriteLine("4. Oil the Robotic Pets");
            Console.WriteLine("5. Play with the Pets");
            Console.WriteLine("6. Pick a Pet for One on One");
            Console.WriteLine("7. Admit a new Pet to the Shelter");
            Console.WriteLine("8. Adopt a Pet");
            Console.WriteLine("9. Leave the Shelter");
        }

        private string GetPlayerChoice()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("\nPlease enter your selection");
            string playerGameResponse = Console.ReadKey().KeyChar.ToString().ToLower();
            Console.ResetColor();
            return playerGameResponse;
        }

        private void ShowAllPets(Shelter someShelter)
        {
            //TODO:  Break this up
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Here are all the pets currently in the shelter:");

            List<OrganicPet> organicPets = new List<OrganicPet>();
            List<RoboticPet> roboticPets = new List<RoboticPet>();
            foreach (Pet somePet in someShelter.GetListOfPets())
            {
                //if (somePet instanceof OrganicPet) { }
                if (somePet is OrganicPet) 
                {
                    OrganicPet someOrganicPet = new OrganicPet();
                    someOrganicPet = (OrganicPet)somePet;
                    organicPets.Add(someOrganicPet);
                }
                else if (somePet is RoboticPet)
                {
                    RoboticPet someRoboticPet = new RoboticPet();
                    someRoboticPet = (RoboticPet)somePet;
                    roboticPets.Add(someRoboticPet);
                }
            }

            Console.BackgroundColor = ConsoleColor.Cyan;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.WriteLine("\nPet Name   Type      Boredom | Energy | Health | Hunger |  Hydration | Irritable");
            Console.ResetColor();
            Console.WriteLine();

            foreach (OrganicPet someOrganicPet in organicPets)
            {
                Console.ForegroundColor = ConsoleColor.DarkCyan;
                Console.Write($"{someOrganicPet.GetName().PadRight(11, ' ')}");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write($"{someOrganicPet.GetSpecies().PadRight(12, ' ')}");
                Console.ResetColor();
                Console.Write($"{someOrganicPet.GetBoredom().ToString().PadRight(10, ' ')} ");
                Console.Write($"{someOrganicPet.GetEnergy().ToString().PadRight(9, ' ')}");
                Console.Write($"{someOrganicPet.GetHealth().ToString().PadRight(8, ' ')} ");
                Console.Write($"{someOrganicPet.GetHunger().ToString().PadRight(8, ' ')} ");
                Console.Write($"{someOrganicPet.GetHyrdation().ToString().PadRight(11, ' ')} ");
                Console.WriteLine($"{someOrganicPet.GetIrritable().ToString()} ");
            }

            Console.BackgroundColor = ConsoleColor.Cyan;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.WriteLine("\nPet Name   Type      | Boredom | Oil | Performance");
            Console.ResetColor();
            Console.WriteLine();

            foreach (RoboticPet someRoboticPet in roboticPets)
            {
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.Write($"{someRoboticPet.GetName().PadRight(11, ' ')}");
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write($"{someRoboticPet.GetSpecies().PadRight(12, ' ')}");
                Console.ResetColor();
                Console.Write($"{someRoboticPet.GetBoredom().ToString().PadRight(10, ' ')} ");
                Console.Write($"{someRoboticPet.GetOil().ToString().PadRight(10, ' ')} ");
                Console.WriteLine($"{someRoboticPet.GetPerformance().ToString().PadRight(10, ' ')}");
            }

            Console.WriteLine();
            Console.WriteLine("Press ENTER to return to the main menu.");
            Console.ReadLine();
            Console.Clear();
        }

        private string FeedOrganicPets(Shelter someShelter)
        {
            Console.Clear();
            foreach (Pet somePet in someShelter.GetListOfPets())
            {
                if (somePet is OrganicPet)
                {
                    OrganicPet pet;
                    pet = (OrganicPet)somePet;
                    pet.FeedPet();
                    ProcessTime(somePet);

                }
            }
            return "Thanks for feeding the Organic Pets";
        }

        private string WaterOrganicPets(Shelter someShelter)
        {
            Console.Clear();
            foreach (Pet somePet in someShelter.GetListOfPets())
            {
                if (somePet is OrganicPet)
                {
                    OrganicPet pet;
                    pet = (OrganicPet)somePet;
                    pet.Drink();
                    ProcessTime(somePet);

                }
            }
            return "Thanks for giving the Organic Pets some water to drink.";
        }

        private string OilRoboticPets(Shelter someShelter)
        {
            Console.Clear();
            foreach (Pet somePet in someShelter.GetListOfPets())
            {
                if (somePet is RoboticPet)
                {
                    RoboticPet pet;
                    pet = (RoboticPet)somePet;
                    pet.AddOil();
                    ProcessTime(somePet);
                }
            }
            return "Thanks for Oiling the Robotic Pets.";
        }

        private string PlayWithPets(Shelter someShelter)
        {
            Console.Clear();
            foreach (Pet somePet in someShelter.GetListOfPets())
            {
                somePet.Play();
                ProcessTime(somePet);
            }
            return "Thanks for playing with the Pets.";
        }

        private Pet SelectPet(Shelter someShelter)
        {
            //TODO:  maybe break this up
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("\nPlease Select a Pet from the Shelter:");
            Console.ResetColor();
            Console.WriteLine();
            
            int index = 1;
            foreach (Pet pet in someShelter.GetListOfPets())
            {
                Console.Write($"{index}.  {pet.GetName()} is ");
                if (pet is OrganicPet)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write("Organic "); 
                }
                else if (pet is RoboticPet)
                {
                    Console.ForegroundColor = ConsoleColor.DarkGray;
                    Console.Write("Robotic "); 
                }
                Console.ResetColor();
                Console.WriteLine($"{pet.GetSpecies()}.");
                index++;
            }

            Pet selectedPet = null;
            int petIndex = -1;
            while (selectedPet == null)
            {
                string selectedMenuOption = GetPlayerChoice();
                try
                {
                    petIndex = Convert.ToInt32(selectedMenuOption) - 1;
                    selectedPet = someShelter.GetPet(petIndex);
                    if (selectedPet == null)
                    { Console.WriteLine("\nInvalid Option.  Please try again."); }
                }
                catch (Exception)
                {
                    Console.WriteLine("\nInvalid Option.  Please try again.");
                }
            }
            return selectedPet;
        }

        private void AdoptPet(Shelter someShelter, Pet somePet)
        {
            //TODO:  Stretch, offer player advice for org vs rob
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"Thanks for adopting {somePet.GetName()}.  We hope you give them a good home.");
            Console.ResetColor();
            someShelter.RemovePetFromShelter(somePet);
        }

        private void LeaveShelterMessage(Shelter someShelter)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"\n\nThanks for visiting {someShelter.GetShelterName()} Wildly Popular Pet Shelter.");
            Console.WriteLine("\n\nPlease come back again soon.");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("\n\nI NEED THE MONEY FOR MY DEFENSE FUND!!!");
            Console.ResetColor();
        }

        private string AskPlayerForPetName()
        {
            string name = "";
            while (name == "")
            {
                Console.WriteLine("\nWhat is the name of the pet?");
                name = Console.ReadLine();
            }

            return name;

        }

        private string AskPlayerForPetSpecies()
        {
            string species = "";
            while (species == "")
            {
                Console.WriteLine("\nWhat species of Pet would you like to add to the Shelter?");
                species = Console.ReadLine();
            }
            return species;

        }

        private void AddOrganicPetToShelter(Shelter someShelter)
        {
            string playerPetSpeciesEntry = AskPlayerForPetSpecies();
            string playerPetNameEntry = AskPlayerForPetName();

            OrganicPet somePet = new OrganicPet(playerPetNameEntry, playerPetSpeciesEntry);
            someShelter.AddPetToShelter(somePet);
            Console.WriteLine($"\n{playerPetNameEntry} has been added to Shelter.");
        }

        private void AddRoboticPetToShelter(Shelter someShelter)
        {
            string playerPetSpeciesEntry = AskPlayerForPetSpecies();
            string playerPetNameEntry = AskPlayerForPetName();

            RoboticPet somePet = new RoboticPet(playerPetNameEntry, playerPetSpeciesEntry);
            someShelter.AddPetToShelter(somePet);
            Console.WriteLine($"\n{playerPetNameEntry} has been added to Shelter.");
        }

        private void AdmitPet(Shelter someShelter)
        {
            //TODO:  Add spacing, newlines, clear, and color to this method
            //TODO:  Possibly break it up more methods
            if (someShelter.IsShelterFull())
            {
                ShowShelterFullMessage();
            }
            else
            {
                //TODO:  Change this to a Do-while loop
                //TODO:  Also change the rest that I did like this
                string playerPetTypeEntry = "";
                while (playerPetTypeEntry == "")
                {
                    Console.WriteLine("\nEnter 1 for Organic Pet");
                    Console.WriteLine("\nEnter 2 for Robotic Pet");
                    playerPetTypeEntry = GetPlayerChoice();
                    switch (playerPetTypeEntry)
                    {
                        case "1":
                            AddOrganicPetToShelter(someShelter);
                            break;
                        case "2":
                            bool keepAdding = true;
                            do
                            {
                                AddRoboticPetToShelter(someShelter);
                                //TODO:  Write method to process Y N response
                                    Console.WriteLine("\nWould you like to add another Robotic Pet?");
                                    Console.WriteLine("Please enter (Y)es or (N)o.");
                                    string playerChoice = Console.ReadKey().KeyChar.ToString().ToLower();

                                    while (playerChoice != "y" && playerChoice != "n")
                                    {
                                        Console.ForegroundColor = ConsoleColor.Red;
                                        Console.WriteLine($"\nThat input was not a 'Y' or 'N'.  Please try again.");
                                        Console.ResetColor();
                                        playerChoice = Console.ReadKey().KeyChar.ToString().ToLower();
                                    }
                                
                                if (playerChoice == "n") 
                                { keepAdding = false; }
                                else if (someShelter.IsShelterFull())
                                {
                                    ShowShelterFullMessage();
                                    keepAdding = false;
                                }

                            } while (keepAdding);

                            break;
                        default:
                            break;
                    }
                }                    
            }
        }

        private void InteractWithOrganicPet(OrganicPet somePet)
        {
            bool keepPlaying = true;
            while (keepPlaying)
            {
                //TODO:  Will need to call Orgainic Pet Show Status and Robotic Pet Show Status???
                ShowOrganicPetStatus(somePet);
                ShowOrganicPetMenu(somePet.GetName());
                string playerChoice = GetPlayerChoice();
                string gameFeedbackToPlayer = ProcessPlayerChoiceOrganic(playerChoice, somePet);

                if (gameFeedbackToPlayer == "stop")
                { keepPlaying = false; }
                else
                {
                    Console.Clear();
                    Console.WriteLine("\n");
                    Console.WriteLine(gameFeedbackToPlayer);

                    string petFeedbacktoPlayer = ProcessTime(somePet);
                    //ProcessTime2(someShelter);
                    Console.WriteLine(petFeedbacktoPlayer);
                }
            }
        }

        private void ShowOrganicPetMenu(string petName)
        {
            //TODO:  See if this and the Robotic version can be done with OVERRIDE
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine($"\nWhat would you like to do with {petName}?");
            Console.WriteLine();
            Console.ResetColor();
            Console.WriteLine($"1. Play with {petName}.");
            Console.WriteLine($"2. Feed { petName}.");
            Console.WriteLine($"3. Give {petName} some water.");
            Console.WriteLine($"4. Take { petName} to the Vet.");
            Console.WriteLine($"5. Let {petName} outside.");
            Console.WriteLine($"6. Put {petName} to bed.");
            Console.WriteLine($"7. Do nothing with {petName}.");
            Console.WriteLine($"\n9. Stop Interacting with {petName}");
        }

        private void ShowRoboticPetMenu(string petName)
        {
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine($"\nWhat would you like to do with {petName}?");
            Console.WriteLine();
            Console.ResetColor();
            Console.WriteLine($"1. Play with {petName}.");
            Console.WriteLine($"2. Give {petName} some oil.");
            Console.WriteLine($"3. Take { petName} to the Mechanic.");
            Console.WriteLine($"4. Do nothing with {petName}.");
            Console.WriteLine($"\n9. Stop Interacting with {petName}");
        }

        private string ProcessPlayerChoiceOrganic(string playerChoice, OrganicPet somePet)
        {
            //TODO:  See if this and the Robotic version can be done with OVERRIDE

            string message = "";
            switch (playerChoice)
            {
                case "1": 
                    message = PlayWithPet(somePet);
                    return message;
                case "2": 
                    message = somePet.FeedPet();
                    return message;
                case "3":
                    message = somePet.GivePetWater();
                    return message;
                case "4":
                    message = somePet.TakePetToVet();
                    return message;
                case "5":
                    message = somePet.LetPetOutside();
                    return message;
                case "6":
                    message = somePet.LetPetSleep();
                    return message;
                case "7": 
                    message = LeavePetAlone(somePet);
                    return message;
                case "9": 
                    message = "stop";
                    return message;
                default:
                    message = "Invalid Choice.  Please try again.";
                    return message;
            }

        }

        private string ProcessPlayerChoiceRobotic(string playerChoice, RoboticPet somePet)
        {
            //TODO:  See if this and the Robotic version can be done with OVERRIDE

            string message = "";
            switch (playerChoice)
            {
                case "1": //Play
                    message = PlayWithPet(somePet);
                    return message;
                case "2"://Give Oil
                    message = somePet.AddOil();
                    return message;
                case "3"://Take to Mechanic
                    return message;
                case "4"://Do nothing
                    return message;
                case "9":
                    message = "stop";
                    return message;
                default:
                    message = "Invalid Choice.  Please try again.";
                    return message;
            }

        }

        private void ShowOrganicPetStatus(OrganicPet somePet)
        {
            //TODO:  See if this and the Robotic version can be done with OVERRIDE
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"\nHere is how {somePet.GetName()} is doing:");
            Console.ResetColor();
            Console.WriteLine($"\nHEALTH factor is {somePet.GetHealth()}.");
            Console.WriteLine($"HUNGER factor is {somePet.GetHunger()}.");
            Console.WriteLine($"THIRST factor is {somePet.GetHyrdation()}.");
            Console.WriteLine($"ENERGY factor is {somePet.GetEnergy()}.");
            Console.WriteLine($"BOREDOM factor is {somePet.GetBoredom()}.");
            Console.WriteLine($"IRRITATED factor is {somePet.GetIrritable()}.");
        }
       
        private void ShowRoboticPetStatus(RoboticPet somePet)
        {
            //TODO:  Will need a new version of this method for rob pets  Inherit
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"\nHere is how {somePet.GetName()} is doing:");
            Console.ResetColor();
            //Console.WriteLine($"\nHEALTH factor is {somePet.GetHealth()}.");
            //Console.WriteLine($"HUNGER factor is {somePet.GetHunger()}.");
            //Console.WriteLine($"THIRST factor is {somePet.GetHyrdation()}.");
            //Console.WriteLine($"ENERGY factor is {somePet.GetEnergy()}.");
            Console.WriteLine($"BOREDOM factor is {somePet.GetBoredom()}.");
            //Console.WriteLine($"IRRITATED factor is {somePet.GetIrritable()}.");
        }

        private void InteractWithRoboticPet(RoboticPet somePet)
        {
            bool keepPlaying = true;
            while (keepPlaying)
            {
                //TODO:  Will need to call Orgainic Pet Show Status and Robotic Pet Show Status???
                ShowRoboticPetStatus(somePet);
                ShowRoboticPetMenu(somePet.GetName());
                string playerChoice = GetPlayerChoice();
                string gameFeedbackToPlayer = ProcessPlayerChoiceRobotic(playerChoice, somePet);

                if (gameFeedbackToPlayer == "stop")
                { keepPlaying = false; }
                else
                {
                    Console.Clear();
                    Console.WriteLine("\n");
                    Console.WriteLine(gameFeedbackToPlayer);

                    string petFeedbacktoPlayer = ProcessTime(somePet);
                    //ProcessTime2(someShelter);
                    Console.WriteLine(petFeedbacktoPlayer);
                }
            }
        }

        private string PlayWithPet(Pet somePet)
        {
            string message = "";
            Random rand = new Random();
            int petPlayFactor = rand.Next(1, 6);
            if (petPlayFactor == 4)
            {
                message = $"{somePet.GetName()} doesn't want to play right now.";
            }
            else
            {
                somePet.Play();
                message = $"You played with {somePet.GetName()}.";
            }
            return message;
        }



        private string LeavePetAlone(Pet somePet)
        {
            string message = "";
            somePet.Ignore();
            message = $"{somePet.GetName()} is doing their own thing.";

            Random rand = new Random();
            int petFreedomFactor = rand.Next(1, 4);

            switch (petFreedomFactor)
            {
                case 1:
                    somePet.Sleep();
                    break;
                case 2:
                    //somePet.Feed();
                    break;
                case 3:
                    //somePet.Drink();
                    break;
            }
            //LivingPetProcess(somePet);
            return message;
        }

        //TODO:  Create a new version of this method for rob pets
        //private void LivingPetProcess(Pet somePet)
        //{
        //    if (somePet.IsPetHungry())
        //    { somePet.Feed(); }

        //    if (somePet.IsPetThirsty())
        //    { somePet.Drink(); }

        //    if (somePet.IsPetTired())
        //    { somePet.Sleep(); }
        //}

        //private string CheckBoredomeLevel(Pet somePet)
        //{
        //    string message;
        //    if (somePet.IsPetBored())
        //    {
        //        somePet.MaximizeBoredom();
        //        message = somePet.GetName() + " is EXTREMELY bored.  Best to play with " + somePet.GetName() + " before they start chewing on your furniture.";
        //    }
        //    else if (somePet.IsPetHappy())
        //    {
        //        somePet.MinimizeBoredom();
        //        message = somePet.GetName() + " feels very loved and appreciated.  Great Job!";
        //    }
        //    else
        //    {
        //        message = null;
        //    }
        //    return message;
        //}

        //TODO: Org only
        //private string CheckHungerLevel(Pet somePet)
        //{
        //    string message;
        //    if (somePet.IsPetHungry())
        //    {
        //        message = somePet.GetName() + " is HUNGRY.  You might want to feed " + somePet.GetName() + " .";
        //        if (somePet.GetHunger() >= somePet.hungerThresholdMAX)
        //        { somePet.MaximizeHunger(); }
        //    }
        //    else if (somePet.IsPetFullOfFood())
        //    {
        //        somePet.MinimzeHunger();
        //        message = null;
        //    }
        //    else
        //    {
        //        message = null;
        //    }
        //    return message;
        //}

        //TODO: Org only
        //private string CheckThirstLevel(Pet somePet)
        //{
        //    string message;
        //    if (somePet.IsPetThirsty())
        //    {
        //        message = somePet.GetName() + " is THIRSTY.  You might want to give " + somePet.GetName() + " some water.";
        //        if (somePet.GetHyrdation() <= somePet.hydrationThresholdMIN)
        //        { somePet.MinimizeHydration(); }
        //    }
        //    else if (somePet.IsPetFullOfWater())
        //    {
        //        somePet.MaximizeHydration();
        //        message = null;
        //    }
        //    else
        //    {
        //        message = null;
        //    }
        //    return message;
        //}

        //TODO: Org only
        //private string CheckEnergyLevel(Pet somePet)
        //{
        //    string message;
        //    if (somePet.IsPetTired())
        //    {
        //        somePet.MinimizeEnergy();
        //        message = somePet.GetName() + " is low on ENERGY.  You might want to let them rest.";
        //    }
        //    else if (somePet.IsPetEnergized())
        //    {
        //        somePet.MaximizeEnergy();
        //        message = somePet.GetName() + " is full of ENERGY.  You might want to player with them.";
        //    }
        //    else
        //    {
        //        message = null;
        //    }
        //    return message;
        //}

        //TODO: Org only
        //private string CheckHealthLevel(Pet somePet)
        //{
        //    string message;
        //    if (somePet.IsPetSick())
        //    {
        //        somePet.MinimizeHealth();
        //        message = somePet.GetName() + " is not feeling well.  You might want to take them to the vet.";
        //    }
        //    else if (somePet.IsPetHealthy())
        //    {
        //        somePet.MaximizeHealth();
        //        message = somePet.GetName() + " is completly healthy.";
        //    }
        //    else
        //    {
        //        message = null;
        //    }
        //    return message;
        //}

        //TODO: Org only
        //private string CheckIrritationLevel(Pet somePet)
        //{
        //    string message;
        //    if (somePet.IsPetIrritated())
        //    {
        //        somePet.MaximizeIrritation();
        //        message = somePet.GetName() + " is IRRITATED.  You might want to take " + somePet.GetName() + " outside before they have an accident.";
        //        return message;
        //    }
        //    else if (somePet.IsPetContent())
        //    {
        //        somePet.MinimizeIrritation();
        //        message = null;
        //    }
        //    {
        //        message = null;
        //        return message;
        //    }
        //}

        private string CheckPetLevels(Pet somePet)
        {
            //TODO:  This method will need to be re-worked

            //string petBoredomeLevelMessage = CheckBoredomeLevel(somePet);
            string petBoredomeLevelMessage = somePet.CheckBoredomeLevel();
            //string petIrritatedLevelMessage = CheckIrritationLevel(somePet);
            //string petHungerLevelMessage = CheckHungerLevel(somePet);
            //string petThirstLevelMessage = CheckThirstLevel(somePet);
            //string petEnergyLevelMessage = CheckEnergyLevel(somePet);
            ///string petHealthLevelMessage = CheckHealthLevel(somePet);

            string returnMessage = "";

            if (petBoredomeLevelMessage != null)
            { returnMessage = petBoredomeLevelMessage; }

            //if (petIrritatedLevelMessage != null)
            //{ returnMessage = returnMessage + "\n" + petIrritatedLevelMessage; }

            //if (petHungerLevelMessage != null)
            //{ returnMessage = returnMessage + "\n" + petHungerLevelMessage; }

            //if (petThirstLevelMessage != null)
            //{ returnMessage = returnMessage + "\n" + petThirstLevelMessage; }

            //if (petEnergyLevelMessage != null)
            //{ returnMessage = returnMessage + "\n" + petEnergyLevelMessage; }

            //if (petHealthLevelMessage != null)
            //{ returnMessage = returnMessage + "\n" + petHealthLevelMessage; }

            return returnMessage;
        }

        private string ProcessTime(Pet somePet)
        {
            //TODO:  Need to ensure both types of pets get tick method called
            somePet.Tick();                                  
            return CheckPetLevels(somePet).ToString();
        }

        private void ProcessTime2(Shelter someShelter)
        {
            foreach (Pet pet in someShelter.GetListOfPets())
            {
                if (pet.GetType() == typeof(OrganicPet))
                {
                    OrganicPet someOrganicPet = new OrganicPet();
                    someOrganicPet = (OrganicPet)pet;
                    someOrganicPet.Tick();
                    

                }
                else if (pet.GetType() == typeof(RoboticPet))
                { }
            }
        }

    }
}
