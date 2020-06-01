using System;
using Xunit;

namespace VirtualPet.Tests
{
    public class MenuTests
    {
        private Menu testMenu;
        public MenuTests()
        {
            testMenu = new Menu();
        }
        [Fact]
        public void GetPlayChoice_Should_Return_A_Value()
        {
            //TODO: Note to Instructor.  Not sure how to test actual user input
            //string menuChoice = testMenu.GetPlayerChoice();
            //Assert.NotNull(menuChoice);
        }

        [Fact]
        public void GetYestNoResponse_Should_Return_A_Value()
        {
            //TODO: Note to Instructor.  Not sure how to test actual user input
            //string menuChoice = testMenu.GetYesNoResponse();
            //Assert.NotNull(menuChoice);
        }
    }
}
