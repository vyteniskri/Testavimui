namespace Tests
{
    using System;
    using NSubstitute;
    using NUnit.Framework;
    using windowsForms_client.Factory;
    using windowsForms_client.Strategy;

    [TestFixture]
    public class SnowCreatorTests
    {
        private SnowCreator _testClass;

        [SetUp]
        public void SetUp()
        {
            _testClass = new SnowCreator();
        }

        [Test]
        public void CanCallCreateObstacle()
        {
            // Arrange
            var x = 1683998499;
            var y = 104312445;
            var s = Substitute.For<IStrategy>();

            // Act
            var result = _testClass.CreateObstacle(x, y, s);

            // Assert
            Assert.Fail("Create or modify test");
        }

        [Test]
        public void CannotCallCreateObstacleWithNullS()
        {
            Assert.Throws<ArgumentNullException>(() => _testClass.CreateObstacle(2112211335, 1300376320, default(IStrategy)));
        }
    }
}