namespace Tests
{
    using System;
    using NSubstitute;
    using NUnit.Framework;
    using windowsForms_client.Factory;
    using windowsForms_client.Strategy;

    [TestFixture]
    public class MistCreatorTests
    {
        private MistCreator _testClass;

        [SetUp]
        public void SetUp()
        {
            _testClass = new MistCreator();
        }

        [Test]
        public void CanCallCreateObstacle()
        {
            // Arrange
            var x = 2070356350;
            var y = 1369962738;
            var s = Substitute.For<IStrategy>();

            // Act
            var result = _testClass.CreateObstacle(x, y, s);

            // Assert
            Assert.Fail("Create or modify test");
        }

        [Test]
        public void CannotCallCreateObstacleWithNullS()
        {
            Assert.Throws<ArgumentNullException>(() => _testClass.CreateObstacle(426951573, 343361782, default(IStrategy)));
        }
    }
}