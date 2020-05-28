using System;
using System.Collections.Generic;
using System.Text;

namespace VirtualPet
{
    public class OrganicPet : Pet
    {
        const int InitialHungerValue = 50;
        const int InitialHealthValue = 30;
        const int InitialHydrationValue = 30;
        const int InitialIritableValue = 25;
        const int InitialEnergyValue = 90;

        public OrganicPet()
        {
            base.SetInitialPetValues();
            SetInitialPetValues();
        }
        public OrganicPet(string name)
        {
            base.SetName(name);
            base.SetInitialPetValues();
            SetInitialPetValues();
        }

        public OrganicPet(string name, string species)
        {
            base.SetName(name);
            base.SetSpecies(species);
            base.SetInitialPetValues();
            SetInitialPetValues();
        }


        public override void SetInitialPetValues()
        {
            Hunger = InitialHungerValue;
            //Boredom = InitialBoredomValue;
            Health = InitialHealthValue;
            Hydration = InitialHydrationValue;
            Energy = InitialEnergyValue;
            Irritated = InitialIritableValue;
        }

    }
}
