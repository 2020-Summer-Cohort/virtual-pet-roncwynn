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



    }
}
