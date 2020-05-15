using System;
using System.Collections.Generic;
using System.Text;

namespace VirtualPet
{
    public class Pet
    {
        //private string species;

        private int initialHungerValue = 50;
        private int initialBoredomValue = 60;
        private int initialHealthValue = 30;

        //TODO:  Create an Enum for Pet Species, and add more types of pets
        //public enum petSpecies { Cat, Dog, Tiger }

        public string Name { get; set; }

        //TODO:  This way causes SetSpecies Test to Fail
        //public string Species
        //{
        //    get { return this.species; }
        //    set { this.species = Species; }
        //}

        public string Species { get; set; }
        public int Hunger { get; set; }
        public int Health { get; set; }
        public int Boredom { get; set; }
        public int Thirsty { get; set; }
        public int Energy { get; set; }
        public int Irritated { get; set; }



        public Pet()
        {
            //TODO:  next 2 lines resolve NotNull test failures, but not sure why they are necessary???
            //Name = "PetName";
            Species = "PetSpecies";
            Hunger = initialHungerValue;
            Boredom = initialBoredomValue;
            Health = initialHealthValue;
        }

        public Pet(string name)
        {
            Name = name;
            //Name = "My Pet Name";
        }

        public Pet(string name, string species)
        {
            Name = name;
            Species = species;
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

        public int GetThirst()
        {
            return Thirsty;
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
            Thirsty = Thirsty + 10;
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
            Thirsty = Thirsty + 10;
            Irritated = Irritated - 10;
            Energy = Energy - 20;
        }

        public void Sleep()
        {
            Energy = Energy + 20;
            Boredom = Boredom + 10;
            Hunger = Hunger + 20;
            Thirsty = Thirsty + 10;
            Health = Health + 5;
            Irritated = Irritated + 30;
        }
        public void Relieve()
        {
            Irritated = 0;
        }

        public void Drink()
        {
            Thirsty = Thirsty - 20;
            Irritated = Irritated + 10;
            Health = Health - 5;
        }
        public void Tick()
        {
            Hunger = Hunger + 5;
            Thirsty = Thirsty + 5;
            Health = Health - 15;
            Boredom = Boredom + 5;
            Energy = Energy - 5; 
            Irritated = Irritated + 5;
        }

    }
}
