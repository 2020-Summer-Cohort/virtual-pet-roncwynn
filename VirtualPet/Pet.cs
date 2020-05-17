using System;
using System.Collections.Generic;
using System.Text;

namespace VirtualPet
{
    public class Pet
    {
        //TODO:  Change these to CONST???
        private int initialHungerValue = 50;
        private int initialBoredomValue = 60;
        private int initialHealthValue = 30;
        private int initialHydrationValue = 30;
        private int initialIritableValue = 25;
        private int initialEnergyValue = 100;

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

        //TODO:  Create an Enum for Pet Species, and add more types of pets
        //public enum petSpecies { Cat, Dog, Tiger }

        public string Name { get; set; }

        //TODO:  This way causes SetSpecies Test to Fail

        public string Species { get; set; }
        public int Hunger { get; set; }
        public int Health { get; set; }
        public int Boredom { get; set; }
        public int Hydration { get; set; }
        public int Energy { get; set; }
        public int Irritated { get; set; }

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

        private void SetInitialPetValues()
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
            Hydration = Hydration - 10;
            Irritated = Irritated + 10;
            Health = Health - 10;
        }

        public void SeeDoctor()
        {
            Health = Health + 30;
        }

        public void Play()
        {
            Hunger = Hunger + 10;
            Health = Health + 10;
            Boredom = Boredom - 20;
            Hydration = Hydration - 20;
            Irritated = Irritated - 10;
            Energy = Energy - 50;
        }

        public void Sleep()
        {
            Energy = Energy + 20;
            Boredom = Boredom + 10;
            Hunger = Hunger + 20;
            Hydration = Hydration - 10;
            Health = Health + 5;
            Irritated = Irritated + 30;
        }
        
        public void Relieve()
        {
            Irritated = 0;
            Hydration = Hydration - 20;
        }

        public void Drink()
        {
            Hydration = Hydration + 20;
            Irritated = Irritated + 10;
        }

        public void Ignore()
        {
            Boredom = Boredom + 20;
            Irritated = Irritated + 10;
            Energy = Energy - 10;
            LivingPetProcess();
        }

        private bool IsPetHungry()
        {
            if (Hunger < hungerThresholdMAX) 
                return true; 
            else  return false; 
        }

        private bool IsPetThirsty()
        {
            if (Hydration < hydrationThresholdMAX)
             return true; 
            else return false;
        }

        private bool IsPetIrritated()
        {
            if (Irritated >= irritabaleThresholdMAX)
                return true;
            else return false;
        }

        public void LivingPetProcess()
        {
            if (IsPetHungry()) 
            { Feed(); }

            if (IsPetThirsty())
            { Drink(); }

            if (IsPetIrritated())
            { Relieve(); }
        }
       
        public void Tick()
        {
            Hunger = Hunger + 5;
            Health = Health - 5;
            Boredom = Boredom + 5;
            Hydration = Hydration + 5;
            Irritated = Irritated + 5;
            Energy = Energy - 5; 
        }

        public void ResetPetBoredome()
        {
            Boredom = initialBoredomValue;
        }

        public void MaximizeBoredome()
        {
            Boredom = boredomeThresholdMAX;
        }

        public bool IsPetBored()
        {
            if (GetBoredom() >= boredomeThresholdMAX)
            { return true; }
            else 
            { return false; }
        }

        public bool IsPetHappy()
        {
            if (GetBoredom() <= boredomeThresholdMIN)
            { return true; }
            else
            { return false; }
        }
    }
}
