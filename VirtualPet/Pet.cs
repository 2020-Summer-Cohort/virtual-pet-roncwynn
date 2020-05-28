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

        private string Name { get; set; }
        private string Species { get; set; }

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

        public virtual void SetInitialPetValues()
        {
            //Hunger = InitialHungerValue;
            Boredom = InitialBoredomValue;
            //Health = InitialHealthValue;
            //Hydration = InitialHydrationValue;
            //Energy = InitialEnergyValue;
            //Irritated = InitialIritableValue;
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

        //TODO: Organic only
        public int GetHunger()
        {
            return Hunger;
        }

        public int GetBoredom()
        {
            return Boredom;
        }

        //TODO: Organic only
        public int GetHealth()
        {
            return Health;
        }

        //TODO: Organic only
        public int GetHyrdation()
        {
            return Hydration;
        }

        //TODO: Organic only
        public int GetEnergy()
        {
            return Energy;
        }

        //TODO: Organic only
        public int GetIrritable()
        {
            return Irritated;
        }

        //TODO: Organic only
        public void Feed()
        {
            Hunger = Hunger - 40;
        }

        //TODO: Organic only
        public void Drink()
        {
            Hydration = Hydration + 40;
        }

        //TODO: Organic only
        public void Relieve()
        {
            Irritated = irritabaleThresholdMIN;
        }

        //TODO: Organic only
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
        
        public void MinimizeBoredom()
        {
            Boredom = boredomThresholdMIN;
        }

        public void MaximizeBoredom()
        {
            Boredom = boredomThresholdMAX;
        }

        //TODO: Organic only
        public void MinimizeIrritation()
        {
            Irritated = irritabaleThresholdMIN;
        }

        //TODO: Organic only
        public void MaximizeIrritation()
        {
            Irritated = irritabaleThresholdMAX;
        }

        //TODO: Organic only
        public void MinimzeHunger()
        {
            Hunger = hungerThresholdMIN;
        }

        //TODO: Organic only
        public void MaximizeHunger()
        {
            Hunger = hungerThresholdMAX;
        }

        //TODO: Organic only
        public void MinimizeHydration()
        {
            Hydration = hydrationThresholdMIN;
        }

        //TODO: Organic only
        public void MaximizeHydration()
        {
            Hydration = hydrationThresholdMAX;
        }

        //TODO: Organic only
        public void MinimizeEnergy()
        {
            Energy = energyThresholdMIN;
        }

        //TODO: Organic only
        public void MaximizeEnergy()
        {
            Energy = energyThresholdMAX;
        }

        //TODO: Organic only
        public void MinimizeHealth()
        {
            Health = healthThresholdMIN;
        }

        //TODO: Organic only
        public void MaximizeHealth()
        {
            Health = healthThresholdMAX;
        }

        //TODO: Organic only
        public bool IsPetHungry()
        {
            if (Hunger >= hungerThresholdMAX) 
                return true; 
            else  return false; 
        }

        //TODO: Organic only
        public bool IsPetFullOfFood()
        {
            if (Hunger <= hungerThresholdMIN)
                return true;
            else return false;
        }

        //TODO: Organic only
        public bool IsPetThirsty()
        {
            if (Hydration <= hydrationThresholdMIN)
             return true; 
            else return false;
        }

        //TODO: Organic only
        public bool IsPetFullOfWater()
        {
            if (Hydration >= hydrationThresholdMAX)
                return true;
            else return false;
        }

        //TODO: Organic only
        public bool IsPetIrritated()
        {
            if (Irritated >= irritabaleThresholdMAX)
                return true;
            else return false;
        }

        //TODO: Organic only
        public bool IsPetContent()
        {
            if (Irritated <= irritabaleThresholdMIN)
                return true;
            else return false;
        }

        //TODO: Organic only
        public bool IsPetSick()
        {
            if (GetHealth() <= healthThresholdMIN)
                return true; 
            else return false; 
        }

        //TODO: Organic only
        public bool IsPetHealthy()
        {
            if (Health >= healthThresholdMAX)
                return true;
            else return false;
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

        //TODO: Organic only
        public bool IsPetEnergized()
        {
            if (GetEnergy() >= energyThresholdMAX)
                return true;
            else return false;
        }

        //TODO: Organic only
        public bool IsPetTired()
        {
            if (GetEnergy() <= energyThresholdMIN)
                return true;
            else return false; 
        }

        public void Tick()
        {
            Hunger = Hunger + 5;
            Health = Health - 5;
            Boredom = Boredom + 5;
            Hydration = Hydration - 5;
            Irritated = Irritated + 5;
            Energy = Energy - 5;
        }

    }
}
