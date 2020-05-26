using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace VirtualPet
{
    public class Shelter
    {
        const int ShelterCapacity = 9;

        private int totalShelterPetCount { get; set; }

        public struct Cages
        {
            //public int cageNumber { get; set; }
            public bool cageClean { get; set; }
        }

        private List<Pet> pets = new List<Pet>();
        public Cages[] cages = new Cages[9];

        private string shelterName { get; set; }

        public Shelter()
        {
            shelterName = "Tiger Kings";
        }

        public void CleanCage(int index)
        {
            cages[index].cageClean = true;
        }

        public bool IsCageClean(int index)
        {
            return cages[index].cageClean;
        }

        public string GetShelterName()
        {
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
            if (IsShelterEmpty() == false)
            {
                pets.Remove(somePet);
                totalShelterPetCount = totalShelterPetCount - 1;
                return true;
            }
            else
            {
                return false;
            }
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
            try
            {
                return pets[index];
            }
            catch (Exception)
            {
                return null;
            }
        }

    }

    
}
