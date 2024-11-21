namespace Tests
{
    using System;
    using System.Drawing;
    using NSubstitute;
    using NUnit.Framework;
    using windowsForms_client;
    using windowsForms_client.Strategy;

    [TestFixture]
    public class ObstacleTests
    {
        private Obstacle _testClass;
        private int _x;
        private int _y;
        private IStrategy _strategy;

        [SetUp]
        public void SetUp()
        {
            _x = 2129535993;
            _y = 1787618385;
            _strategy = Substitute.For<IStrategy>();
            _testClass = new Obstacle(_x, _y, _strategy);
        }

        [Test]
        public void CanConstruct()
        {
            // Act
            var instance = new Obstacle(_x, _y, _strategy);

            // Assert
            Assert.That(instance, Is.Not.Null);
        }

        [Test]
        public void CannotConstructWithNullStrategy()
        {
            Assert.Throws<ArgumentNullException>(() => new Obstacle(_x, _y, default(IStrategy)));
        }

        [Test]
        public void CanCallSetTempColor()
        {
            // Arrange
            var color = Color.Orange;

            // Act
            _testClass.SetTempColor(color);

            // Assert
            Assert.Fail("Create or modify test");
        }

        [Test]
        public void CanCallSetOriginalColor()
        {
            // Arrange
            var color = Color.Magenta;

            // Act
            _testClass.SetOriginalColor(color);

            // Assert
            Assert.Fail("Create or modify test");
        }

        [Test]
        public void CanCallGetTempColor()
        {
            // Act
            var result = _testClass.GetTempColor();

            // Assert
            Assert.Fail("Create or modify test");
        }

        [Test]
        public void CanCallGetOriginalColor()
        {
            // Act
            var result = _testClass.GetOriginalColor();

            // Assert
            Assert.Fail("Create or modify test");
        }

        [Test]
        public void CanCallResetColor()
        {
            // Act
            _testClass.ResetColor();

            // Assert
            Assert.Fail("Create or modify test");
        }

        [Test]
        public void CanSetAndGetx_coordinate()
        {
            // Arrange
            var testValue = 1416393414;

            // Act
            _testClass.x_coordinate = testValue;

            // Assert
            Assert.That(_testClass.x_coordinate, Is.EqualTo(testValue));
        }

        [Test]
        public void CanSetAndGety_coordinate()
        {
            // Arrange
            var testValue = 537741042;

            // Act
            _testClass.y_coordinate = testValue;

            // Assert
            Assert.That(_testClass.y_coordinate, Is.EqualTo(testValue));
        }

        [Test]
        public void StrategyIsInitializedCorrectly()
        {
            Assert.That(_testClass.Strategy, Is.SameAs(_strategy));
        }

        [Test]
        public void CanSetAndGetStrategy()
        {
            // Arrange
            var testValue = Substitute.For<IStrategy>();

            // Act
            _testClass.Strategy = testValue;

            // Assert
            Assert.That(_testClass.Strategy, Is.SameAs(testValue));
        }

        [Test]
        public void CanSetAndGetHasBeenAffected()
        {
            // Arrange
            var testValue = true;

            // Act
            _testClass.HasBeenAffected = testValue;

            // Assert
            Assert.That(_testClass.HasBeenAffected, Is.EqualTo(testValue));
        }
    }
}