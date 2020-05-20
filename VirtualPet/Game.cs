using System;
using System.Collections.Generic;
using System.Text;

namespace VirtualPet
{
    public class  Game
    {
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
