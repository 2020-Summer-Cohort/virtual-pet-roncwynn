using System;
using System.Collections.Generic;
using System.Text;

namespace VirtualPet
{
    public class Pet
    {
        //TODO:  Organic specific values = Hunger, Health, Hydration, Iritable, Energy
        //TODO:  Shared values = Boredom
        //const int InitialHungerValue = 50;
        const int InitialBoredomValue = 60;
        //const int InitialHealthValue = 30;
        //const int InitialHydrationValue = 30;
        //const int InitialIritableValue = 25;
        //const int InitialEnergyValue = 90;

        //TODO:  Note to instructor.  I Attempted to make this const but it caused other errors.  Would like feedback on this.
        public int hungerThresholdMIN = 10;
        public int hungerThresholdMAX = 90;
        public int boredomThresholdMIN = 10;
        public int boredomThresholdMAX = 90;
        public int healthThresholdMIN = 10;
        public int healthThresholdMAX = 90;
        public int irritabaleThresholdMIN = 10;
        public int irritabaleThresholdMAX = 90;
        public int hydrationThresholdMIN = 10;
        public int hydrationThresholdMAX = 90;
        public int energyThresholdMIN = 10;
        public int energyThresholdMAX = 90;

        public string Name { get; set; }
        private string Species { get; set; }

        public int Boredom { get; set; }

        public Pet()
        {
            SetInitialPetValues();
        }

        public Pet(string name)
        {
            Name = name;
            SetInitialPetValues();
        }

        public Pet(string name, string species)
        {
            Name = name;
            Species = species;
            SetInitialPetValues();
        }

        public virtual void SetInitialPetValues()
        {
            Boredom = InitialBoredomValue;
        }

        public void SetName(string name)
        {
            Name = name;
        }

        public string GetName()
        {
            return Name;
        }

        public void SetSpecies(string species)
        {
            Species = species;
        }

        public string GetSpecies()
        {
            return Species;
        }

        public int GetBoredom()
        {
            return Boredom;
        }
        
        public virtual void Play()
        {
            Boredom = Boredom - 40;
        }

        public virtual void Sleep()
        {
            Boredom = Boredom + 10;
        }
         
        public virtual void Ignore()
        {
            Boredom = Boredom + 20;
        }
        
        public void MinimizeBoredom()
        {
            Boredom = boredomThresholdMIN;
        }

        public void MaximizeBoredom()
        {
            Boredom = boredomThresholdMAX;
        }

        public bool IsPetBored()
        {
            if (GetBoredom() >= boredomThresholdMAX)
                return true; 
            else return false; 
        }

        public bool IsPetHappy()
        {
            if (GetBoredom() <= boredomThresholdMIN)
                return true; 
            else return false;
        }

        public virtual void Tick()
        {
            Boredom = Boredom + 5;
        }

        public virtual void ShowPetStatus()
        {
            //Will need a new version of this method for rob pets
            //TODO:  Change this so it directly get property values instead of through "Gets"
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"\nHere is how {GetName()} is doing:");
            Console.ResetColor();
            Console.WriteLine($"BOREDOM factor is {GetBoredom()}.");

            //Console.WriteLine($"\nHEALTH factor is {somePet.GetHealth()}.");
            //Console.WriteLine($"HUNGER factor is {somePet.GetHunger()}.");
            //Console.WriteLine($"THIRST factor is {somePet.GetHyrdation()}.");
            //Console.WriteLine($"ENERGY factor is {somePet.GetEnergy()}.");
            //Console.WriteLine($"IRRITATED factor is {somePet.GetIrritable()}.");
        }

        public string CheckBoredomeLevel()
        {
            string message;
            if (IsPetBored())
            {
                MaximizeBoredom();
                message = Name + " is EXTREMELY bored.  Best to play with " + Name + " before they start chewing on your furniture.";
            }
            else if (IsPetHappy())
            {
                MinimizeBoredom();
                message = Name + " feels very loved and appreciated.  Great Job!";
            }
            else
            {
                message = null;
            }
            return message;
        }

    }
}
