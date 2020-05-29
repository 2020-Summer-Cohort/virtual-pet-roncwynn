using System;
using System.Collections.Generic;
using System.Text;

namespace VirtualPet
{
    public class RoboticPet : Pet
    {
        const int InitialOilValue = 50;
        const int InitialPerformanceValue = 25;

        public int Oil { get; set; }
        public int Performance { get; set; }

        public int GetOil()
        {
            return Oil;
        }

        public int GetPerformance()
        {
            return Performance;
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

        public override void Play()
        {
            base.Play();
            Oil = Oil - 20;
            Performance = Performance - 15;
        }

        public override void SetInitialPetValues()
        {
            Oil = InitialOilValue;
            Performance = InitialPerformanceValue;
        }

        public string AddOil()
        {
            Oil = Oil + 25;
            //TODO:  Put checks and balances in for Robotic pet values
            return $"You gave {Name} some oil.";

        }



    }
}
