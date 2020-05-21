using System;
using System.Collections.Generic;
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
