using System;
using Xunit;

namespace VirtualPet.Tests
{
    public class RoboticPetTests
    {
        private RoboticPet testPet;

        public RoboticPetTests()
        {
            testPet = new RoboticPet();
        }

        [Fact]
        public void Pet_Constructor_Should_Instantiate_Pet_Object()
        {
            Assert.NotNull(testPet);
        }

        [Fact]
        public void Pet_Should_Have_Boredom()
        {
            testPet.Boredom = 100;
            Assert.Equal(100, testPet.Boredom);
        }

        [Fact]
        public void GetBoredom_Should_Return_Initial_Boredom_Level_Of_60()
        {
            int testPetBoredom = testPet.GetBoredom();

            Assert.Equal(60, testPetBoredom);
        }

        [Fact]
        public void Pet_Should_Have_Oil()
        {
            testPet.Oil = 100;
            Assert.Equal(100, testPet.Oil);
        }

        [Fact]
        public void GetHunger_Should_Return_Initial_Oil_Level_Of_50()
        {
            int testPetOil = testPet.GetOil();

            Assert.Equal(50, testPetOil);
        }

        [Fact]
        public void Pet_Should_Have_Performance()
        {
            testPet.Performance = 50;
            Assert.Equal(50, testPet.Performance);
        }

        [Fact]
        public void GetHunger_Should_Return_Initial_Performance_Level_Of_25()
        {
            int testPetPerformance = testPet.GetPerformance();

            Assert.Equal(25, testPetPerformance);
        }

        [Fact]
        public void TakePetToMechanic_Should_Increase_Oil_By_25()
        {
            int currentOilLevel = testPet.GetOil();
            testPet.TakePetToMechanic();
            Assert.Equal(currentOilLevel + 25, testPet.GetOil());
        }

        [Fact]
        public void TakePetToMechanic_Should_Increase_Performance_By_50()
        {
            int currentPerformanceLevel = testPet.GetPerformance();
            testPet.TakePetToMechanic();
            Assert.Equal(currentPerformanceLevel + 50, testPet.GetOil());
        }

        [Fact]
        public void AddOil_Should_Increase_By_25()
        {
            int currentOilLevel = testPet.GetOil();
            testPet.AddOil();
            Assert.Equal(currentOilLevel + 25, testPet.GetOil());
        }

        [Fact]
        public void Play_Should_Increase_Performance_By_15()
        {
            int currentPerformanceLevel = testPet.GetPerformance();
            testPet.Play();
            Assert.Equal(currentPerformanceLevel+15, testPet.GetPerformance());
        }

        [Fact]
        public void Play_Should_Decrease_Oil_By_20()
        {
            int currentOilLevel = testPet.GetOil();
            testPet.Play();
            Assert.Equal(currentOilLevel - 20, testPet.GetOil());
        }

        [Fact]
        public void Play_Should_Decrease_Boredom_By_25()
        {
            int currentBoredomLevel = testPet.GetBoredom();
            testPet.Play();
            Assert.Equal(currentBoredomLevel - 25, testPet.GetBoredom());
        }

        [Fact]
        public void Ignore_Should_Increase_Boredom()
        {
            int currentBoredomLevel = testPet.GetBoredom();
            testPet.Ignore();
            Assert.True(currentBoredomLevel < testPet.GetBoredom());
        }

        [Fact]
        public void Ignore_Should_Decrease_Oil()
        {
            int currentOilLevel = testPet.GetOil();
            testPet.Ignore();
            Assert.True(currentOilLevel > testPet.GetOil());
        }

        [Fact]
        public void Ignore_Should_Decrease_Performancel()
        {
            int currentPerformanceLevel = testPet.GetPerformance();
            testPet.Ignore();
            Assert.True(currentPerformanceLevel > testPet.GetPerformance());
        }

        [Fact]
        public void MinimizeBoredom_Should_Set_Boredom_To_Minimum()
        {
            int minimumLevel = testPet.boredomThresholdMIN;
            testPet.MinimizeBoredom();
            Assert.Equal(minimumLevel, testPet.GetBoredom());
        }

        [Fact]
        public void MaximizeBoredome_Should_Set_Boredom_To_Maximum()
        {
            int maximumLevel = testPet.boredomThresholdMAX;
            testPet.MaximizeBoredom();
            Assert.Equal(maximumLevel, testPet.GetBoredom());
        }

        [Fact]
        public void MinimizeOil_Should_Set_Oil_To_Minimum()
        {
            int minimumLevel = testPet.oilThresholdMIN;
            testPet.MinimizeOil();
            Assert.Equal(minimumLevel, testPet.GetOil());
        }

        [Fact]
        public void MaximizeOil_Should_Set_Oil_To_Maximum()
        {
            int maximumLevel = testPet.oilThresholdMAX;
            testPet.MaximizeOil();
            Assert.Equal(maximumLevel, testPet.GetOil());
        }

        [Fact]
        public void MinimizePerformance_Should_Set_Performance_To_Minimum()
        {
            int minimumLevel = testPet.performanceThresholdMIN;
            testPet.MinimizePerformance();
            Assert.Equal(minimumLevel, testPet.GetPerformance());
        }

        [Fact]
        public void MaximizePerformance_Should_Set_Performance_To_Maximum()
        {
            int maximumLevel = testPet.performanceThresholdMAX;
            testPet.MaximizePerformance();
            Assert.Equal(maximumLevel, testPet.GetPerformance());
        }

        [Fact]
        public void IsPetBored_Should_Return_True()
        {
            testPet.MaximizeBoredom();
            Assert.True(testPet.IsPetBored());
        }

        [Fact]
        public void IsOilFull_Should_Return_True()
        {
            testPet.MaximizeOil();
            Assert.True(testPet.IsOilFull());
        }

        [Fact]
        public void IsOilLow_Should_Return_True()
        {
            testPet.MinimizeOil();
            Assert.True(testPet.IsOilLow());
        }

        [Fact]
        public void IsPerformanceHigh_Should_Return_True()
        {
            testPet.MaximizePerformance();
            Assert.True(testPet.IsPerformanceHigh());
        }

        [Fact]
        public void IsPerformanceLow_Should_Return_True()
        {
            testPet.MinimizePerformance();
            Assert.True(testPet.IsPerformanceLow());
        }


    }
}
