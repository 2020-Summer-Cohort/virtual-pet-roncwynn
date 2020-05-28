using System;
using System.Collections.Generic;
using System.Text;

namespace VirtualPet
{
    public class RoboticPet : Pet
    {
        const int InitialOilValue = 50;

        public int Oil { get; set; }

        public int GetOil()
        {
            return Oil;
        }

        public RoboticPet()
        {
            base.SetInitialPetValues();
            SetInitialPetValues();
        }
        public RoboticPet(string name)
        {
            base.SetName(name);
            base.SetInitialPetValues();
            SetInitialPetValues();
        }

        public RoboticPet(string name, string species)
        {
            base.SetName(name);
            base.SetSpecies(species);
            base.SetInitialPetValues();
            SetInitialPetValues();
        }

        public override void SetInitialPetValues()
        {
            Oil = InitialOilValue;
        }


    }
}
