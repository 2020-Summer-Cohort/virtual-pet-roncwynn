using System;
using System.Collections.Generic;
using System.Text;

namespace VirtualPet
{
    public class Pet
    {
        //TODO:  Change CONST names to PascalCase
        const int initialHungerValue = 50;
        const int initialBoredomValue = 60;
        const int initialHealthValue = 30;
        const int initialHydrationValue = 30;
        const int initialIritableValue = 25;
        const int initialEnergyValue = 100;

        public int hungerThresholdMIN = 10;
        public int hungerThresholdMAX = 100;
        public int boredomeThresholdMIN = 10;
        public int boredomeThresholdMAX = 100;
        public int healthThresholdMIN = 10;
        public int healthThresholdMAX = 100;
        public int irritabaleThresholdMIN = 10;
        public int irritabaleThresholdMAX = 100;
        public int hydrationThresholdMIN = 10;
        public int hydrationThresholdMAX = 100;
        public int energyThresholdMIN = 10;
        public int energyThresholdMAX = 100;

        //TODO:  Question for me: Do these 2 need to be public?  Does SetGet later on do the same thing?
        public  string Name { get; set; }
        public  string Species { get; set; }

        //TODO:  Question for me:  Should these be private instead of public?
        public  int Hunger { get; set; }
        public  int Health { get; set; }
        public  int Boredom { get; set; }
        public  int Hydration { get; set; }
        public  int Energy { get; set; }
        public  int Irritated { get; set; }

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

        private  void SetInitialPetValues()
        {
            Hunger = initialHungerValue;
            Boredom = initialBoredomValue;
            Health = initialHealthValue;
            Hydration = initialHydrationValue;
            Energy = initialEnergyValue;
            Irritated = initialIritableValue;
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

        public int GetHunger()
        {
            return Hunger;
        }

        public int GetBoredom()
        {
            return Boredom;
        }

        public int GetHealth()
        {
            return Health;
        }

        public int GetHyrdation()
        {
            return Hydration;
        }

        public int GetEnergy()
        {
            return Energy;
        }

        public int GetIrritable()
        {
            return Irritated;
        }
        
        public void Feed()
        {
            Hunger = Hunger - 40;
        }

        public void Drink()
        {
            Hydration = Hydration + 40;
        }

        public void Relieve()
        {
            Irritated = irritabaleThresholdMIN;
        }

        public void SeeDoctor()
        {
            Health = Health + 30;
        }
        
        public void Play()
        {
            Hunger = Hunger + 10;
            Health = Health + 10;
            Boredom = Boredom - 40;
            Hydration = Hydration - 20;
            Irritated = Irritated - 10;
            Energy = Energy - 50;
        }

        public void Sleep()
        {
            Energy = Energy + 40;
            Boredom = Boredom + 10;
            Hunger = Hunger + 20;
            Hydration = Hydration - 10;
            Health = Health + 5;
            Irritated = Irritated + 30;
        }
         
        public void Ignore()
        {
            Boredom = Boredom + 20;
            Irritated = Irritated + 10;
            Energy = Energy - 10;
        }
        
        public void MinimizePetBoredome()
        {
            Boredom = initialBoredomValue;
        }

        public void MaximizeBoredome()
        {
            Boredom = boredomeThresholdMAX;
        }

        public void MinimizeIrritation()
        {
            Irritated = irritabaleThresholdMIN;
        }

        public void MaximizeIrritation()
        {
            Irritated = irritabaleThresholdMAX;
        }

        public void MinimzeHunger()
        {
            Hunger = hungerThresholdMIN;
        }

        public void MaximizeHunger()
        {
            Hunger = hungerThresholdMAX;
        }

        public void MinimizeHydration()
        {
            Hydration = hydrationThresholdMIN;
        }

        public void MaximizeHydration()
        {
            Hydration = hydrationThresholdMAX;
        }

        public void MinimizeEnergy()
        {
            Energy = energyThresholdMIN;
        }

        public void MaximizeEnergy()
        {
            Energy = energyThresholdMAX;
        }

        public void MinimizeHealth()
        {
            Health = healthThresholdMIN;
        }

        public void MaximizeHealth()
        {
            Health = healthThresholdMAX;
        }

        public bool IsPetHungry()
        {
            if (Hunger >= hungerThresholdMAX) 
                return true; 
            else  return false; 
        }

        public bool IsPetFullOfFood()
        {
            if (Hunger <= hungerThresholdMIN)
                return true;
            else return false;
        }

        public bool IsPetThirsty()
        {
            if (Hydration <= hydrationThresholdMIN)
             return true; 
            else return false;
        }

        public bool IsPetFullOfWater()
        {
            if (Hydration >= hydrationThresholdMAX)
                return true;
            else return false;
        }

        public bool IsPetIrritated()
        {
            if (Irritated >= irritabaleThresholdMAX)
                return true;
            else return false;
        }

        public bool IsPetContent()
        {
            if (Irritated <= irritabaleThresholdMIN)
                return true;
            else return false;
        }

        public bool IsPetSick()
        {
            if (GetHealth() <= healthThresholdMIN)
                return true; 
            else return false; 
        }

        public bool IsPetHealthy()
        {
            if (Health >= healthThresholdMAX)
                return true;
            else return false;
        }

        public bool IsPetBored()
        {
            if (GetBoredom() >= boredomeThresholdMAX)
                return true; 
            else return false; 
        }

        public bool IsPetHappy()
        {
            if (GetBoredom() <= boredomeThresholdMIN)
                return true; 
            else return false;
        }

        public bool IsPetEnergized()
        {
            if (GetEnergy() >= energyThresholdMAX)
                return true;
            else return false;
        }

        public bool IsPetTired()
        {
            if (GetEnergy() <= energyThresholdMIN)
                return true;
            else return false; 
        }
    }
}
