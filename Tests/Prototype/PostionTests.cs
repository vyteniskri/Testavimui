namespace Tests
{
    using System;
    using NUnit.Framework;
    using windowsForms_client.Prototype;

    [TestFixture]
    public class PositionTests
    {
        private Position _testClass;
        private int _x;
        private int _y;

        [SetUp]
        public void SetUp()
        {
            _x = 230626134;
            _y = 512746230;
            _testClass = new Position(_x, _y);
        }

        [Test]
        public void CanConstruct()
        {
            // Act
            var instance = new Position(_x, _y);

            // Assert
            Assert.That(instance, Is.Not.Null);
        }

        [Test]
        public void XIsInitializedCorrectly()
        {
            Assert.That(_testClass.X, Is.EqualTo(_x));
        }

        [Test]
        public void CanSetAndGetX()
        {
            // Arrange
            var testValue = 162200730;

            // Act
            _testClass.X = testValue;

            // Assert
            Assert.That(_testClass.X, Is.EqualTo(testValue));
        }

        [Test]
        public void YIsInitializedCorrectly()
        {
            Assert.That(_testClass.Y, Is.EqualTo(_y));
        }

        [Test]
        public void CanSetAndGetY()
        {
            // Arrange
            var testValue = 326633760;

            // Act
            _testClass.Y = testValue;

            // Assert
            Assert.That(_testClass.Y, Is.EqualTo(testValue));
        }
    }
}