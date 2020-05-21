using System;
using System.Collections.Generic;
using System.Text;

namespace VirtualPet
{
    public class Shelter
    {
        const int ShelterCapacity = 10;

        public int totalShelterPetCount { get; set; }

        public Shelter()
        {

        }

        public bool IsShelterFull()
        {
            throw new NotImplementedException();
        }
        public int GetShelterPetCount()
        {
            throw new NotImplementedException();
        }

        public bool AddPetToShelter(Pet somePet)
        {
            throw new NotImplementedException();
        }

        public bool RemovePetFromShelter(Pet somePet)
        {
            throw new NotImplementedException();
        }

        public int GetShelterCapacity()
        {
            throw new NotImplementedException();
        }


    }

    
}
