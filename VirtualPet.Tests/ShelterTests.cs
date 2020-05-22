using System;
using Xunit;

namespace VirtualPet.Tests
{
    public class ShelterTests
    {
        private Shelter testShelter;

        Pet testPet = new Pet();

        public ShelterTests()
        {
            testShelter = new Shelter();
        }

        [Fact]
        public void Shelter_Constructor_Should_Instantiate_Shelter_Object()
        {
            Assert.NotNull(testShelter);
        }

        [Fact]
        public void GetShelterPetCount_should_return_2()
        {
            Assert.Equal(2, testShelter.GetShelterPetCount());
        }

        [Fact]
        public void RemovePetFromShelter_Should_Decrease_Total_Pets_By_1()
        {
            int currentShelterPetCount = testShelter.GetShelterPetCount();
            bool petAdded = testShelter.RemovePetFromShelter(testPet);
            Assert.Equal(currentShelterPetCount - 1, testShelter.GetShelterPetCount());
        }
        
        [Fact]
        public void AddPetToShelter_Should_Increase_Total_Pets_By_1()
        {
            int currentShelterPetCount = testShelter.GetShelterPetCount();
            bool petAdded = testShelter.AddPetToShelter(testPet);
            Assert.Equal(currentShelterPetCount + 1, testShelter.GetShelterPetCount());

        }

        [Fact]
        public void GetShelterCapacity_Should_Return_10()
        {
            Assert.Equal(10, testShelter.GetShelterCapacity());
        }

        [Fact]
        public void IsShelterFull_Should_Return_True_If_Full()
        {
            int shelterMAX = testShelter.GetShelterCapacity();
            for (int i = 1;i <= shelterMAX;i++)
            {
                testShelter.AddPetToShelter(testPet);
            }
            Assert.Equal(shelterMAX, testShelter.GetShelterPetCount());
        }

        //[Fact]
        //public void AddPetToCage_Should_Increase_PetsInCage_by_1()
        //{
        //    //int currentPetsInCage = testShelter.GetPetsInCage(testCage);
        //}
    }
}
