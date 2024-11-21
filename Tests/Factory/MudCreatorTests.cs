namespace Tests
{
    using System;
    using NSubstitute;
    using NUnit.Framework;
    using windowsForms_client.Factory;
    using windowsForms_client.Strategy;

    [TestFixture]
    public class MudCreatorTests
    {
        private MudCreator _testClass;

        [SetUp]
        public void SetUp()
        {
            _testClass = new MudCreator();
        }

        [Test]
        public void CanCallCreateObstacle()
        {
            // Arrange
            var x = 1725875627;
            var y = 600140653;
            var s = Substitute.For<IStrategy>();

            // Act
            var result = _testClass.CreateObstacle(x, y, s);

            // Assert
            Assert.Fail("Create or modify test");
        }

        [Test]
        public void CannotCallCreateObstacleWithNullS()
        {
            Assert.Throws<ArgumentNullException>(() => _testClass.CreateObstacle(1270581922, 532694612, default(IStrategy)));
        }
    }
}