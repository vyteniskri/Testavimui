namespace Tests
{
    using System;
    using NSubstitute;
    using NUnit.Framework;
    using windowsForms_client.Factory;
    using windowsForms_client.Strategy;

    [TestFixture]
    public class IceCreatorTests
    {
        private IceCreator _testClass;

        [SetUp]
        public void SetUp()
        {
            _testClass = new IceCreator();
        }

        [Test]
        public void CanCallCreateObstacle()
        {
            // Arrange
            var x = 489404619;
            var y = 1000509131;
            var s = Substitute.For<IStrategy>();

            // Act
            var result = _testClass.CreateObstacle(x, y, s);

            // Assert
            Assert.Fail("Create or modify test");
        }

        [Test]
        public void CannotCallCreateObstacleWithNullS()
        {
            Assert.Throws<ArgumentNullException>(() => _testClass.CreateObstacle(755449948, 70834842, default(IStrategy)));
        }
    }
}