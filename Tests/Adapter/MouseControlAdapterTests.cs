using windowsForms_client.Tanks;

namespace Tests
{
    using System;
    using System.Drawing;
    using NUnit.Framework;
    using windowsForms_client;
    using windowsForms_client.Adapter;

    [TestFixture]
    public class MouseControlAdapterTests
    {
        private class TestMouseTank : RedPistolTank
        {
            public Bullet PublicBullet { get => base.bullet; set => base.bullet = value; }
            
        }
        private MouseControlAdapter _testClass;
        private TestMouseTank _tank;

        [SetUp]
        public void SetUp()
        {
            _tank = new TestMouseTank();
            _testClass = new MouseControlAdapter(_tank);
        }

        [Test]
        public void CanConstruct()
        {
            // Act
            var instance = new MouseControlAdapter(_tank);

            // Assert
            Assert.That(instance, Is.Not.Null);
        }

        [Test]
        public void CannotConstructWithNullTank()
        {
            Assert.Throws<ArgumentNullException>(() => new MouseControlAdapter(default(Tank)));
        }

        [Test]
        public void CanCallMoveUp()
        {
            _tank.y_coordinate = 5;
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
            _tank.x_coordinate = 5;
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
            _tank.PublicBullet = new Bullet();
            _tank.PublicBullet.Direction = "";
            _tank.bullets = new List<Bullet>();
            // Act
            _testClass.Shoot();
           
            // Assert
            Assert.Fail("Create or modify test");
        }

        [Test]
        public void CanCallUpdateTankPosition()
        {
            // Arrange
            var mousePosition = new Point();

            // Act
            _testClass.UpdateTankPosition(mousePosition);

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

        [Test]
        public void CanCallStopShooting()
        {
            // Act
            _testClass.StopShooting();

            // Assert
            Assert.Fail("Create or modify test");
        }
    }
}