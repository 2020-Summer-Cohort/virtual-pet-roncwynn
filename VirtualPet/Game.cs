using System;
using System.Collections.Generic;
using System.Text;

namespace VirtualPet
{
    public class  Game
    {
        public Game()
        {

        }

        public  void PlayWithPet(Pet somePet)
        {
            Random rand = new Random();
            int petPlayFactor = rand.Next(1, 6);
            if (petPlayFactor == 4)
            {
                Console.WriteLine($"{somePet.GetName()} doesn't want to play right now.");
            }
            else
            {
                somePet.Play();
                Console.WriteLine($"You played with {somePet.GetName()}.");
            }
        }

        public void FeedPet(Pet somePet)
        {
            if (somePet.GetHunger() > somePet.hungerThresholdMIN)
            {
                somePet.Feed();
                Console.WriteLine($"You fed {somePet.GetName()}.");
            }
            else
            {
                Console.WriteLine($"{somePet.GetName()} isn't hungry right now, maybe try something else.");
            }
        }

        public void GivePetWater(Pet somePet)
        {
            if (somePet.GetHyrdation() < somePet.hydrationThresholdMAX)
            {
                somePet.Drink();
                Console.WriteLine($"You gave {somePet.GetName()} some water to drink.");
            }
            else
            {
                Console.WriteLine($"{somePet.GetName()} is fully hydrated.  Act quick before {somePet.GetName()} has an accident!");
            }
        }

        public void TakePetToVet(Pet somePet)
        {
            if (somePet.GetHealth() < somePet.healthThresholdMAX)
            {
                somePet.SeeDoctor();
                Console.WriteLine($"You took {somePet.GetName()} to the vet and all is well.");
            }
            else
            {
                Console.WriteLine($"{somePet.GetName()} is as healthy as can be.  Save your money.");
            }
        }

        public void LetPetOutside(Pet somePet)
        {
            if (somePet.GetIrritable() > somePet.irritabaleThresholdMIN)
            {
                somePet.Relieve();
                Console.WriteLine($"You let {somePet.GetName()} relieve themself.");
            }
            else
            {
                Console.WriteLine($"{somePet.GetName()} is being stubborn and won't go outside right now.");
            }
        }

        public void LetPetSleep(Pet somePet)
        {
            if (somePet.IsPetTired())
            {
                Console.WriteLine($"{somePet.GetName()} is sleeping soundly.");
                somePet.Sleep();
            }
            else if (somePet.IsPetEnergized())
            {
                Console.WriteLine($"{somePet.GetName()} is full of energy right now and refuses to sleep.");
            }
            else
            {
                somePet.Sleep();
            }
        }

        public void LeavePetAlone(Pet somePet)
        {
            Console.WriteLine($"{somePet.GetName()} is doing their own thing.");
            somePet.Ignore();

            Random rand = new Random();
            int petFreedomFactor = rand.Next(1, 4);

            switch (petFreedomFactor)
            {
                case 1:
                    somePet.Sleep();
                    break;
                case 2:
                    somePet.Feed();
                    break;
                case 3:
                    somePet.Drink();
                    break;
            }
            LivingPetProcess(somePet);
        }

        public void LivingPetProcess(Pet somePet)
        {
            if (somePet.IsPetHungry())
            { somePet.Feed(); }

            if (somePet.IsPetThirsty())
            { somePet.Drink(); }

            if (somePet.IsPetTired())
            { somePet.Sleep(); }
        }

        public  string CheckBoredomeLevel(Pet somePet)
        {
            string message;
            if (somePet.IsPetBored())
            {
                somePet.MaximizeBoredome();
                message = somePet.GetName() + " is EXTREMELY bored.  Best to play with " + somePet.GetName() + " before they start chewing on your furniture.";
            }
            else if (somePet.IsPetHappy())
            {
                somePet.MinimizePetBoredome();
                message = somePet.GetName() + " feels very loved and appreciated.  Great Job!";
            }
            else
            {
                message = null;
            }
            return message;
        }
        public string CheckHungerLevel(Pet somePet)
        {
            string message;
            if (somePet.IsPetHungry())
            {
                message = somePet.GetName() + " is HUNGRY.  You might want to feed " + somePet.GetName() + " .";
                if (somePet.GetHunger() >= somePet.hungerThresholdMAX)
                { somePet.MaximizeHunger(); }
            }
            else if (somePet.IsPetFullOfFood())
            {
                somePet.MinimzeHunger();
                message = null;
            }
            else
            {
                message = null;
            }
            return message;
        }
        public string CheckThirstLevel(Pet somePet)
        {
            string message;
            if (somePet.IsPetThirsty())
            {
                message = somePet.GetName() + " is THIRSTY.  You might want to give " + somePet.GetName() + " some water.";
                if (somePet.GetHyrdation() <= somePet.hydrationThresholdMIN)
                { somePet.MinimizeHydration(); }
            }
            else if (somePet.IsPetFullOfWater())
            {
                somePet.MaximizeHydration();
                message = null;
            }
            else
            {
                message = null;
            }
            return message;
        }
        public string CheckEnergyLevel(Pet somePet)
        {
            string message;
            if (somePet.IsPetTired())
            {
                somePet.MinimizeEnergy();
                message = somePet.GetName() + " is low on ENERGY.  You might want to let them rest.";
            }
            else if (somePet.IsPetEnergized())
            {
                somePet.MaximizeEnergy();
                message = somePet.GetName() + " is full of ENERGY.  You might want to player with them.";
            }
            else
            {
                message = null;
            }
            return message;
        }
        public string CheckHealthLevel(Pet somePet)
        {
            string message;
            if (somePet.IsPetSick())
            {
                somePet.MinimizeHealth();
                message = somePet.GetName() + " is not feeling well.  You might want to take them to the vet.";
            }
            else if (somePet.IsPetHealthy())
            {
                somePet.MaximizeHealth();
                message = somePet.GetName() + " is completly healthy.";
            }
            else
            {
                message = null;
            }
            return message;
        }
        public string CheckIrritationLevel(Pet somePet)
        {
            string message;
            if (somePet.IsPetIrritated())
            {
                somePet.MaximizeIrritation();
                message = somePet.GetName() + " is IRRITATED.  You might want to take " + somePet.GetName() + " outside before they have an accident.";
                return message;
            }
            else if (somePet.IsPetContent())
            {
                somePet.MinimizeIrritation();
                message = null;
            }
            {
                message = null;
                return message;
            }
        }

        public void CheckPetLevels(Pet somePet)
        {
            string petBoredomeLevelMessage = CheckBoredomeLevel(somePet);
            string petIrritatedLevelMessage = CheckIrritationLevel(somePet);
            string petHungerLevelMessage = CheckHungerLevel(somePet);
            string petThirstLevelMessage = CheckThirstLevel(somePet);
            string petEnergyLevelMessage = CheckEnergyLevel(somePet);
            string petHealthLevelMessage = CheckHealthLevel(somePet);

            if (petBoredomeLevelMessage != null)
            { Console.WriteLine(petBoredomeLevelMessage); }

            if (petIrritatedLevelMessage != null)
            { Console.WriteLine(petIrritatedLevelMessage); }

            if (petHungerLevelMessage != null)
            { Console.WriteLine(petHungerLevelMessage); }

            if (petThirstLevelMessage != null)
            { Console.WriteLine(petThirstLevelMessage); }

            if (petEnergyLevelMessage != null)
            { Console.WriteLine(petEnergyLevelMessage); }

            if (petHealthLevelMessage != null)
            { Console.WriteLine(petHealthLevelMessage); }
        }

        public void ProcessTime(Pet somePet)
        {
            Tick(somePet);
            CheckPetLevels(somePet);
        }

        public void Tick(Pet somePet)
        {
            somePet.Hunger = somePet.Hunger + 5;
            somePet.Health = somePet.Health - 5;
            somePet.Boredom = somePet.Boredom + 5;
            somePet.Hydration = somePet.Hydration - 5;
            somePet.Irritated = somePet.Irritated + 5;
            somePet.Energy = somePet.Energy - 5;
        }


    }
}
