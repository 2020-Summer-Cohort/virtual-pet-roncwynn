using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace VirtualPet
{
    public class Menu
    {
        public void ShowGameMainMenu(Shelter someShelter)
        {
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

        public string GetPlayerChoice()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("\nPlease enter your selection");
            string playerGameResponse = Console.ReadKey().KeyChar.ToString().ToLower();
            Console.ResetColor();
            return playerGameResponse;
        }

        public void ShowOrganicPetMenu(string petName)
        {
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

        public void ShowRoboticPetMenu(string petName)
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

        public void ShowPetTypeMenu()
        {
            var petTypes = System.Reflection.Assembly.GetExecutingAssembly().GetTypes().Where(x => x.BaseType == typeof(Pet));
            int index = 1;
            foreach(var petType in petTypes)
            {
                Console.WriteLine($"Enter {index} for {petType.Name.Substring(0, petType.Name.Length-3)} Pet");
                index++;
            }
        }

        public string GetYesNoResponse()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Please enter (Y)es or (N)o.");
            Console.ResetColor();
            string playerChoice = Console.ReadKey().KeyChar.ToString().ToLower();
            Console.WriteLine();
            while (playerChoice != "y" && playerChoice != "n")
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"\nThat input was not a 'Y' or 'N'.  Please try again.");
                Console.ResetColor();
                playerChoice = Console.ReadKey().KeyChar.ToString().ToLower();
            }
            Console.ResetColor();
            Console.WriteLine();
            return playerChoice;
        }

    }
}
