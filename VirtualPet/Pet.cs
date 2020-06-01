using System;
using System.Collections.Generic;
using System.Text;

namespace VirtualPet
{
    public abstract class Pet
    {
        const int InitialBoredomValue = 60;

        //TODO:  Note to instructor.  I Attempted to make this const but it caused other errors.  Would like feedback on this.
        public int boredomThresholdMIN = 10;
        public int boredomThresholdMAX = 90;

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

        public abstract void Play();

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
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"\nHere is how {Name} is doing:");
            Console.ResetColor();
            Console.WriteLine($"BOREDOM factor is {Boredom}.");
        }

        public abstract string CheckBoredomLevel();

        public abstract string CheckPetLevels();       

    }
}
