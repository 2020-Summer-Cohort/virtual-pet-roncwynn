using System;
using Xunit;

namespace VirtualPet.Tests
{
    public class PetTests
    {
        private Pet testPet;
      
        public PetTests()
        {
            testPet = new Pet();
        }

        [Fact]
        public void Pet_Constructor_Should_Instantiate_Pet_Object()
        {
            Assert.NotNull(testPet);
        }
        
        // INSTRUCTIONS:
        // Uncomment code in the test body one test at a time
        // Add source code to eliminate the build errors (red squiggle) and pass the test
        
        [Fact]
        public void Pet_Should_Have_Name()
        {
            testPet.Name = "Pet Name";
            Assert.Equal("Pet Name",testPet.Name);
        }

        [Fact]
        public void SetName_Should_Assign_Pet_Name_Property()
        {
            testPet.SetName("Fluffy");

            Assert.Equal("Fluffy", testPet.Name);

        }

        [Fact]
        public void GetName_Should_Get_Pet_Name_Value()
        {
            testPet.SetName("Fido");

            string testPetName = testPet.GetName();

            Assert.Equal("Fido", testPetName);
        }

        [Fact]
        public void Pet_Should_Have_Species()
        {
            testPet.Species = "Pet Species";
             Assert.Equal("Pet Species",testPet.Species);
        }

        [Fact]
        public void SetSpecies_Should_Assign_Pet_Species_Property()
        {
            testPet.SetSpecies("Cat");

            Assert.Equal("Cat", testPet.Species);
        }

        [Fact]
        public void GetSpecies_Should_Get_Pet_Species_Value()
        {
            testPet.SetSpecies("Dog");

            string testPetSpecies = testPet.GetSpecies();

            Assert.Equal("Dog", testPetSpecies);
        }

        [Fact]
        public void Pet_Should_Have_Hunger()
        {
            testPet.Hunger = 100;
            Assert.Equal(100,testPet.Hunger);
        }

        [Fact]
        public void GetHunger_Should_Return_Initial_Hunger_Level_Of_50()
        {
            int testPetHunger = testPet.GetHunger();

             Assert.Equal(50, testPetHunger);
        }

        [Fact]
        public void Pet_Should_Have_Boredom()
        {
            testPet.Boredom = 100;
             Assert.Equal(100,testPet.Boredom);
        }

        [Fact]
        public void GetBoredom_Should_Return_Initial_Boredom_Level_Of_60()
        {
             int testPetBoredom = testPet.GetBoredom();

             Assert.Equal(60, testPetBoredom);
        }

        [Fact]
        public void Pet_Should_Have_Health()
        {
            testPet.Health = 100;
             Assert.Equal(100,testPet.Health);
        }
                
        [Fact]
        public void GetHealth_Should_Return_Initial_Health_Level_Of_30()
        {
             int testPetHealth = testPet.GetHealth();
            
             Assert.Equal(30, testPetHealth);
        }

        [Fact]
        public void Pet_Should_Have_Hydration()
        {
            testPet.Hydration = 100;
            Assert.Equal(100, testPet.Hydration);
        }

        [Fact]
        public void GetHydration_Should_Return_Initial_Level_Of_30()
        {
            int testPetHydration = testPet.GetHyrdation();
            Assert.Equal(30, testPetHydration);
        }
        [Fact]
        public void Pet_Should_Have_Irritable()
        {
            testPet.Irritated = 100;
            Assert.Equal(100, testPet.Irritated);
        }

        [Fact]
        public void GetIrritable_Should_Return_Initial_Level_25()
        {
            int testPerIrritation = testPet.GetIrritable();
            Assert.Equal(25, testPerIrritation);
        }

        [Fact]
        public void Pet_Should_Have_Energy()
        {
            testPet.Energy = 100;
            Assert.Equal(100, testPet.Energy);
        }

        [Fact]
        public void GetEnergy_Should_Return_Initial_Level_100()
        {
            int testEnergy = testPet.GetEnergy();
            Assert.Equal(100, testEnergy);
        }

        [Fact]
        public void Feed_Should_Decrease_Hunger_By_40()
        {
             testPet.Feed();

             Assert.Equal(10, testPet.GetHunger());
        }

        [Fact]
        public void SeeDoctor_Should_Increase_Health_By_30()
        {
             testPet.SeeDoctor();
             Assert.Equal(60, testPet.GetHealth());
        }

        [Fact]
        public void Drink_Should_Increase_By_40()
        {
            int currentDrinkLevel = testPet.GetHyrdation();
            testPet.Drink();
            Assert.Equal(currentDrinkLevel + 40, testPet.GetHyrdation());
        }

        [Fact]
        public void Play_Should_Increase_Hunger_By_10()
        {
             testPet.Play();

             Assert.Equal(60, testPet.GetHunger());
        }

        [Fact]
        public void Play_Should_Decrease_Boredom_By_40()
        {
            int currentBoredomeLevel = testPet.GetBoredom(); 
            testPet.Play();
             Assert.Equal(currentBoredomeLevel- 40, testPet.GetBoredom());
        }

        [Fact]
        public void Play_Should_Increase_Health_By_10()
        {
             testPet.Play();

             Assert.Equal(40, testPet.GetHealth());
        }

        [Fact]
        public void Play_Should_Decrease_Hydration_By_20()
        {
            int currentHydration = testPet.GetHyrdation();
            testPet.Play();
            Assert.Equal(currentHydration-20, testPet.GetHyrdation());
        }

        [Fact]
        public void Play_Should_Decrease_Energy_By_50()
        {
            int currentEnergy = testPet.GetEnergy();
            testPet.Play();
            Assert.Equal(currentEnergy-50, testPet.GetEnergy());
        }

        [Fact]
        public void Play_Should_Decrease_Irritable_By_10()
        {
            int currentIrritable = testPet.GetIrritable();
            testPet.Play();
            Assert.Equal(currentIrritable-10, testPet.GetIrritable());
        }

        [Fact]
        public void Relieve_Should_Set_Irritable_To_10()
        {
            testPet.Relieve();
            Assert.Equal(10, testPet.GetIrritable());
        }

        [Fact]
        public void Ignore_Should_Increase_Boredome()
        {
            int currentBoresomeLevel = testPet.GetBoredom();
            testPet.Ignore();
            Assert.True(currentBoresomeLevel < testPet.GetBoredom());
        }

        [Fact]
        public void Ignore_Should_Increase_Irriatable()
        {
            int currentIrritable = testPet.GetIrritable();
            testPet.Ignore();
            Assert.True(currentIrritable < testPet.GetIrritable());
        }

        [Fact]
        public void Ignore_Should_Decrease_Engergy()
        {
            int currentEnergy = testPet.GetEnergy();
            testPet.Ignore();
            Assert.True(currentEnergy > testPet.GetEnergy());
        }

        [Fact]
        public void Sleep_Should_Increase_Energy()
        {
            int currentEnergy = testPet.GetEnergy();
            testPet.Sleep();
            Assert.True(currentEnergy < testPet.GetEnergy());
        }

        [Fact]
        public void Sleep_Should_Increase_Boredome()
        {
            int currentBoredome = testPet.GetBoredom();
            testPet.Sleep();
            Assert.True(currentBoredome < testPet.GetBoredom());
        }
        [Fact]
        public void Sleep_Should_Increase_Hunger()
        {
            int currentHunger = testPet.GetHunger();
            testPet.Sleep();
            Assert.True(currentHunger < testPet.GetHunger());
        }
        [Fact]
        public void Sleep_Should_Increase_Health()
        {
            int currentHealth = testPet.GetHealth();
            testPet.Sleep();
            Assert.True(currentHealth < testPet.GetHealth());
        }
        [Fact]
        public void Sleep_Should_Increase_Irritation()
        {
            int currentIrritation = testPet.GetIrritable();
            testPet.Sleep();
            Assert.True(currentIrritation < testPet.GetIrritable());
        }
        [Fact]
        public void Sleep_Should_Decrease_Hydration()
        {
            int currentHydration = testPet.GetHyrdation();
            testPet.Sleep();
            Assert.True(currentHydration > testPet.GetHyrdation());
        }

    }
}
