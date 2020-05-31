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
            //base.Play();
            Boredom = Boredom - 25;
            Oil = Oil - 20;
            Performance = Performance + 15;
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

        public string TakePetToMechanic()
        {
            Oil = Oil + 25;
            Performance = Performance + 50;
            return $"Your took {Name} to the Mechanic.";
        }

        public override void ShowPetStatus()
        {
            base.ShowPetStatus();
            Console.WriteLine($"Oil level is {Oil}.");
            Console.WriteLine($"Performance level is {Performance}.");
        }

        public override void Ignore()
        {
            //base.Ignore();
            Boredom = Boredom + 5;
            Oil = Oil - 10;
            Performance = Performance - 10;
        }

        public override string CheckBoredomeLevel()
        {
            string message;
            if (IsPetBored())
            {
                MaximizeBoredom();
                message = $"Robotic pet {Name} is bored,  best to interact with {Name} before they go into SHUTDOWN mode!!!";
            }
            else if (IsPetHappy())
            {
                MinimizeBoredom();
                message = Name + " is operating efficiently.";
            }
            else
            {
                message = null;
            }
            return message;
        }




    }
}
