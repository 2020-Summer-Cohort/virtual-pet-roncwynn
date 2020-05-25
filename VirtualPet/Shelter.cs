using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace VirtualPet
{
    public class Shelter
    {
        const int ShelterCapacity = 10;

        //TODO:  this sould be private
        public int totalShelterPetCount { get; set; }

        private List<Pet> pets = new List<Pet>();

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
