using windowsForms_client.Tanks;

namespace Tests
{
    using System;
    using NUnit.Framework;
    using windowsForms_client;
    using windowsForms_client.Strategy;

    [TestFixture]
    public class SlowStrategyTests
    {
        private SlowStrategy _testClass;

        [SetUp]
        public void SetUp()
        {
            _testClass = new SlowStrategy();
        }

        [Test]
        public void CanCallApplyStrategy()
        {
            // Arrange
            var tank = new RedPistolTank();
            tank.MovementSpeedX = 6;
            // Act
            _testClass.ApplyStrategy(tank);

            // Assert
            Assert.Fail("Create or modify test");
        }

        [Test]
        public void CannotCallApplyStrategyWithNullTank()
        {
            Assert.Throws<ArgumentNullException>(() => _testClass.ApplyStrategy(default(Tank)));
        }
    }
}