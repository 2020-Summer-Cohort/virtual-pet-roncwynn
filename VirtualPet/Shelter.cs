using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace VirtualPet
{
    public class Shelter
    {
        const int ShelterCapacity = 10;

        public int totalShelterPetCount { get; set; }

        public List<Pet> pets = new List<Pet>();

        public Shelter()
        {
            //TODO:  Setup initial Shelter with some Pets
            Pet somePet1 = new Pet();
            somePet1.SetName("Ron");
            somePet1.SetSpecies("Tiger");
            pets.Add(somePet1);
            Pet somePet2 = new Pet();
            somePet2.SetName("Rachel");
            somePet2.SetSpecies("Wife");
            pets.Add(somePet2);

            totalShelterPetCount = 2;
        }

        public bool IsShelterFull()
        {
            //throw new NotImplementedException();
            if (totalShelterPetCount == ShelterCapacity)
                return true;
            return false;
        }
        public int GetShelterPetCount()
        {
            //throw new NotImplementedException();
            return totalShelterPetCount;
        }

        public bool AddPetToShelter(Pet somePet)
        {
            //throw new NotImplementedException();
            pets.Add(somePet);
            totalShelterPetCount = totalShelterPetCount + 1;
            return true;
        }

        public bool RemovePetFromShelter(Pet somePet)
        {
            //throw new NotImplementedException();
            pets.Remove(somePet);
            totalShelterPetCount = totalShelterPetCount - 1;
            return true;
        }

        public int GetShelterCapacity()
        {
            //throw new NotImplementedException();
            Console.WriteLine($"SHelter cap = {ShelterCapacity}");
            return ShelterCapacity;
        }


    }

    
}
