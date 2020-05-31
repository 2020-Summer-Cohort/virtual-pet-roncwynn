using System;
using System.Collections.Generic;
using System.Text;

namespace VirtualPet
{
    public class RoboticPet : Pet
    {
        const int InitialOilValue = 50;
        const int InitialPerformanceValue = 25;

        public int oilThresholdMIN = 10;
        public int oilThresholdMAX = 90;
        public int performanceThresholdMIN = 10;
        public int performanceThresholdMAX = 90;

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
            return $"You gave {Name} some oil.";
        }

        public bool IsOilFull()
        {
            if (Oil >= oilThresholdMAX)
            { return true; }
            else { return false; }
        }

        public bool IsOilLow()
        {
            if (Oil <= oilThresholdMIN)
            { return true; }
            else { return false; }
        }

        public bool IsPerformanceHigh()
        {
            if (Performance >= performanceThresholdMAX)
            { return true; }
            else { return false; }
        }

        public bool IsPerformanceLow()
        {
            if (Performance <= performanceThresholdMIN)
            { return true; }
            else { return false; }
        }

        public string TakePetToMechanic()
        {
            Oil = Oil + 25;
            Performance = Performance + 50;
            return $"Your took {Name} to the Mechanic.";
        }

        public override List<string> ShowPetStatus()
        {
            base.ShowPetStatus();
            Console.WriteLine($"Oil level is {Oil}.");
            Console.WriteLine($"Performance level is {Performance}.");
            List<string> messages = new List<string>();
            return messages;

        }

        public override void Ignore()
        {
            Boredom = Boredom + 5;
            Oil = Oil - 10;
            Performance = Performance - 20;
        }

        public void MinimizeOil()
        {
            Oil = oilThresholdMIN;
        }

        public void MaximizeOil()
        {
            Oil = oilThresholdMAX;
        }

        public void MinimizePerformance()
        {
            Performance = performanceThresholdMIN;
        }

        public void MaximizePerformance()
        {
            Performance = performanceThresholdMAX;
        }

        public override string CheckBoredomLevel()
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

        public string CheckOilLevel()
        {
            string message;
            if (IsOilLow())
            {
                MinimizeOil();
                message = $"Robotic pet {Name}s oil is low,  you might want to add some before they freeze up like the TIN MAN!!!";
            }
            else if (IsOilFull())
            {
                MaximizeOil();
                message = Name + " has plenty of oil.";
            }
            else
            {
                message = null;
            }
            return message;
        }

        public string CheckPerformanceLevel()
        {
            string message;
            if (IsPerformanceLow())
            {
                MinimizePerformance();
                message = $"Robotic pet {Name}s performance is low,  you might want to take {Name} to the mechanic.";
            }
            else if (IsPerformanceHigh())
            {
                MaximizePerformance();
                message = Name + " is in peak performance.";
            }
            else
            {
                message = null;
            }
            return message;
        }

        public override string CheckPetLevels()
        {
            string petBoredomeLevelMessage = CheckBoredomLevel();
            string petOilLevelMessage = CheckOilLevel();
            string petPerformanceLevelMessage = CheckPerformanceLevel();

            string returnMessage = "";

            if (petBoredomeLevelMessage != null)
            { returnMessage = petBoredomeLevelMessage; }

            if (petOilLevelMessage != null)
            { returnMessage = returnMessage + "\n" + petOilLevelMessage; }

            if (petPerformanceLevelMessage != null)
            { returnMessage = returnMessage + "\n" + petPerformanceLevelMessage; }

            return returnMessage;
        }

        public override void Tick()
        {
            base.Tick();
            Oil = Oil - 5;
            Performance = Performance - 10;
        }

    }
}
