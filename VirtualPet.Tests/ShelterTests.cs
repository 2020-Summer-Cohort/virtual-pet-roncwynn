﻿using System;
using System.Collections.Generic;
using Xunit;

namespace VirtualPet.Tests
{
    public class ShelterTests
    {
        private Shelter testShelter;

        Pet testOrganicPet = new OrganicPet();
        Pet testRoboticPet = new RoboticPet();

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
        public void RemovePetFromShelter_Should_Decrease_Total_Pets_By_1()
        {
            testShelter.AddPetToShelter(testOrganicPet);
            int currentShelterPetCount = testShelter.GetShelterPetCount();
            bool petAdded = testShelter.RemovePetFromShelter(testOrganicPet);
            Assert.Equal(currentShelterPetCount - 1, testShelter.GetShelterPetCount());
        }
        
        [Fact]
        public void AddPetToShelter_Should_Increase_Total_Pets_By_1()
        {
            int currentShelterPetCount = testShelter.GetShelterPetCount();
            bool petAdded = testShelter.AddPetToShelter(testOrganicPet);
            Assert.Equal(currentShelterPetCount + 1, testShelter.GetShelterPetCount());

        }

        [Fact]
        public void GetShelterCapacity_Should_Return_9()
        {
            Assert.Equal(9, testShelter.GetShelterCapacity());
        }

        [Fact]
        public void IsShelterFull_Should_Return_True_If_Full()
        {
            int shelterMAX = testShelter.GetShelterCapacity();
            for (int i = 1;i <= shelterMAX;i++)
            {
                testShelter.AddPetToShelter(testOrganicPet);
            }
            Assert.True(testShelter.IsShelterFull());
        }

        [Fact]
        public void IsShelterEmpty_Should_Return_True_If_Empty()
        {
            int shelterPetCount = testShelter.GetShelterPetCount();
            for (int i=shelterPetCount; i >0;i--)
            {
                testShelter.RemovePetFromShelter(testOrganicPet);
            }
            Assert.True(testShelter.IsShelterEmpty());
        }

        [Fact]
        public void GetShelterName_Returns_a_string_value()
        {
            string shelterName = testShelter.GetShelterName();
            Assert.True(shelterName.Length > 0);
        }

        [Fact]
        public void GetShelterPetCount_Should_Return_1()
        {
            testShelter.AddPetToShelter(testOrganicPet);
            Assert.Equal(1, testShelter.GetShelterPetCount());
        }

        [Fact]
        public void GetPet_Should_Return_A_Pet()
        {
            OrganicPet newPet = new OrganicPet("Name");
            testShelter.AddPetToShelter(newPet);
            newPet = (OrganicPet)testShelter.GetPet(0);
            Assert.NotNull(newPet);
        }

        [Fact]
        public void GetListOfPets_Should_Return_A_List()
        {
            List<Pet> testPets;
            testPets = testShelter.GetListOfPets();
            Assert.NotNull(testPets);
        }
    }
}
