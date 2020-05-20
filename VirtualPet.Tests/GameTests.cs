using System;
using Xunit;

namespace VirtualPet.Tests
{
    public class GameTests
    {
        private Game testGame;
        public GameTests()
        {
            testGame = new Game();
        }

        //TODO:  Figure out why declaring testPet fails here, and not in each test
        //private Pet testPet;
        //public PetTests()
        //{
        //    testPet = new Pet();
        //}

        [Fact]
        public void Tick_Should_Increase_Boredom_By_5()
        {
            //testPet.Tick();
            Pet testPet = new Pet();
            testGame.Tick(testPet);

            Assert.Equal(65, testPet.GetBoredom());
        }

        [Fact]
        public void Tick_Should_Decrease_Health_By_5()
        {
            //testPet.Tick();
            Pet testPet = new Pet();
            testGame.Tick(testPet);

            Assert.Equal(25, testPet.GetHealth());
        }

        [Fact]
        public void Tick_Should_Decrease_Hydration_By_5()
        {
            Pet testPet = new Pet();

            int currentHydration = testPet.GetHyrdation();
            //testPet.Tick();
            testGame.Tick(testPet);
            Assert.Equal(currentHydration - 5, testPet.GetHyrdation());
        }

        [Fact]
        public void Tick_Should_Increase_Irritable_By_5()
        {
            Pet testPet = new Pet();

            int currentIrritable = testPet.GetIrritable();
            //testPet.Tick();
            testGame.Tick(testPet);
            Assert.Equal(currentIrritable + 5, testPet.GetIrritable());
        }

        [Fact]
        public void Tick_Should_Decrease_Energy_By_5()
        {
            Pet testPet = new Pet();

            int currentEnergy = testPet.GetEnergy();
            //testPet.Tick();
            testGame.Tick(testPet);
            Assert.Equal(currentEnergy - 5, testPet.GetEnergy());
        }

        [Fact]
        public void Tick_Should_Increase_Hunger_By_5()
        {
            //testPet.Tick();
            Pet testPet = new Pet();

            testGame.Tick(testPet);

            Assert.Equal(55, testPet.GetHunger());
        }

    }
}
