using windowsForms_client.Tanks;

namespace Tests
{
    using System;
    using NUnit.Framework;
    using windowsForms_client;
    using windowsForms_client.Adapter;

    [TestFixture]
    public class KeyboardControlAdapterTests
    {
        private KeyboardControlAdapter _testClass;
        private Tank _tank;

        [SetUp]
        public void SetUp()
        {
            _tank = new RedPistolTank();
            _testClass = new KeyboardControlAdapter(_tank);
        }

        [Test]
        public void CanConstruct()
        {
            // Act
            var instance = new KeyboardControlAdapter(_tank);

            // Assert
            Assert.That(instance, Is.Not.Null);
        }

        [Test]
        public void CannotConstructWithNullTank()
        {
            Assert.Throws<ArgumentNullException>(() => new KeyboardControlAdapter(default(Tank)));
        }

        [Test]
        public void CanCallMoveUp()
        {
            // Act
            _testClass.MoveUp();

            // Assert
            Assert.Fail("Create or modify test");
        }

        [Test]
        public void CanCallMoveDown()
        {
            // Act
            _testClass.MoveDown();

            // Assert
            Assert.Fail("Create or modify test");
        }

        [Test]
        public void CanCallMoveLeft()
        {
            // Act
            _testClass.MoveLeft();

            // Assert
            Assert.Fail("Create or modify test");
        }

        [Test]
        public void CanCallMoveRight()
        {
            // Act
            _testClass.MoveRight();

            // Assert
            Assert.Fail("Create or modify test");
        }

        [Test]
        public void CanCallShoot()
        {
            // Act
            _testClass.Shoot();

            // Assert
            Assert.Fail("Create or modify test");
        }

        [Test]
        public void CanCallStopMovement()
        {
            // Act
            _testClass.StopMovement();

            // Assert
            Assert.Fail("Create or modify test");
        }

        [Test]
        public void CanCallStopShooting()
        {
            // Act
            _testClass.StopShooting();

            // Assert
            Assert.Fail("Create or modify test");
        }

        [Test]
        public void CanCallStopMovementY()
        {
            // Act
            _testClass.StopMovementY();

            // Assert
            Assert.Fail("Create or modify test");
        }

        [Test]
        public void CanCallStopMovementX()
        {
            // Act
            _testClass.StopMovementX();

            // Assert
            Assert.Fail("Create or modify test");
        }
    }
}