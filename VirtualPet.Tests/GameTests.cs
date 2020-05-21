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

        Pet testPet = new Pet();

        [Fact]
        public void Game_Constructor_Should_Instantiate_Game_Object()
        {
            Assert.NotNull(testGame);
        }

        [Fact]
        public void Tick_Should_Increase_Boredom_By_5()
        {
            testGame.Tick(testPet);

            Assert.Equal(65, testPet.GetBoredom());
        }

        [Fact]
        public void Tick_Should_Decrease_Health_By_5()
        {
            testGame.Tick(testPet);

            Assert.Equal(25, testPet.GetHealth());
        }

        [Fact]
        public void Tick_Should_Decrease_Hydration_By_5()
        {

            int currentHydration = testPet.GetHyrdation();
            testGame.Tick(testPet);
            Assert.Equal(currentHydration - 5, testPet.GetHyrdation());
        }

        [Fact]
        public void Tick_Should_Increase_Irritable_By_5()
        {

            int currentIrritable = testPet.GetIrritable();
            testGame.Tick(testPet);
            Assert.Equal(currentIrritable + 5, testPet.GetIrritable());
        }

        [Fact]
        public void Tick_Should_Decrease_Energy_By_5()
        {

            int currentEnergy = testPet.GetEnergy();
            testGame.Tick(testPet);
            Assert.Equal(currentEnergy - 5, testPet.GetEnergy());
        }

        [Fact]
        public void Tick_Should_Increase_Hunger_By_5()
        {

            testGame.Tick(testPet);

            Assert.Equal(55, testPet.GetHunger());
        }

    }
}
