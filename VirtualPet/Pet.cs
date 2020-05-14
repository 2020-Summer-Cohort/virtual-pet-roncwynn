using System;
using System.Collections.Generic;
using System.Text;

namespace VirtualPet
{
    public class Pet
    {
        //private string species;

        public string Name { get; set; }

        //This way causes SetSpecies Test to Fail
        //public string Species
        //{
        //    get { return this.species; }
        //    set { this.species = Species; }
        //}

        public string Species { get; set; }
        public int Hunger { get; set; }
        public int Health { get; set; }
        public int Boredom { get; set; }


        public Pet()
        {
            // next 2 lines resolve NotNull test failures, but not sure why they are necessary???
            Name = "PetName";
            Species = "PetSpecies";
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

    }
}
