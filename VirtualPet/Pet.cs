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
        public Pet()
        {

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
