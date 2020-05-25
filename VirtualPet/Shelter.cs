using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace VirtualPet
{
    public class Shelter
    {
        const int ShelterCapacity = 10;

        private int totalShelterPetCount { get; set; }

        private List<Pet> pets = new List<Pet>();
        private string shelterName { get; set; }

        public Shelter()
        {
            shelterName = "Rons";
        }

        public string GetShelterName()
        {
            //throw new NotImplementedException();
            return shelterName;
        }

        public bool IsShelterFull()
        {
            if (totalShelterPetCount >= ShelterCapacity)
                return true;
            return false;
        }

        public bool IsShelterEmpty()
        {
            //throw new NotImplementedException();
            if (totalShelterPetCount > 0)
                return false;
            else return true;
        }
        
        public int GetShelterPetCount()
        {
            return totalShelterPetCount;
        }

        public bool AddPetToShelter(Pet somePet)
        {
            if (IsShelterFull() == false)
            {
                pets.Add(somePet);
                totalShelterPetCount = totalShelterPetCount + 1;
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool RemovePetFromShelter(Pet somePet)
        {
            pets.Remove(somePet);
            totalShelterPetCount = totalShelterPetCount - 1;
            return true;
        }

        public int GetShelterCapacity()
        {
            return ShelterCapacity;
        }

        public List<Pet> GetListOfPets()
        {
            return pets;
        }

        public Pet GetPet(int index)
        {
            return pets[index];
        }

    }

    
}
