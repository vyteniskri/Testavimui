using System.Runtime.CompilerServices;
using windowsForms_client;

namespace Tests
{
    using System;
    using NUnit.Framework;
    using windowsForms_client.Tanks;

    [TestFixture]
    public class PistolTankTests
    {
        private class TestPistolTank : PistolTank
        {
            public string PublicTankBodyLookingDirection { get => base.TankBodyLookingDirection; set => base.TankBodyLookingDirection = value; }
            public Bullet Publicbullet { get => base.bullet; set => base.bullet = value; }
            public string[] PublicTankTurretLookingDirections { get => base.TankTurretLookingDirections; set => base.TankTurretLookingDirections = value; }
            public string PublicTankTurretLookingDirection { get => base.TankTurretLookingDirection; set => base.TankTurretLookingDirection = value; }

            public TestPistolTank() : base()
            {
            }

            public TestPistolTank(string id, int x, int y, string name) : base(id, x, y, name)
            {
            }

            
        }


        private TestPistolTank _testClass;
        private string _id;
        private int _x;
        private int _y;
        private string _name;

        [SetUp]
        public void SetUp()
        {
            _id = "TestValue832859313";
            _x = 424435352;
            _y = 584650713;
            _name = "TestValue1492179796";
            _testClass = new TestPistolTank(_id, _x, _y, _name);
        }

        [Test]
        public void CanConstruct()
        {
            // Act
            var instance = new TestPistolTank();

            // Assert
            Assert.That(instance, Is.Not.Null);

            // Act
            instance = new TestPistolTank(_id, _x, _y, _name);

            // Assert
            Assert.That(instance, Is.Not.Null);
        }

        [TestCase("")]
        [TestCase("")]
        [TestCase("   ")]
        public void CannotConstructWithInvalidId(string value)
        {
            Assert.Throws<ArgumentNullException>(() => new TestPistolTank(value, _x, _y, _name));
        }

        [TestCase("")]
        [TestCase("")]
        [TestCase("   ")]
        public void CannotConstructWithInvalidName(string value)
        {
            Assert.Throws<ArgumentNullException>(() => new TestPistolTank(_id, _x, _y, value));
        }

        [Test]
        public void CanCallsetShootingMechanism()
        {
            // Arrange
            var bulletSpeed = 1592370103;

            // Act
            _testClass.setShootingMechanism(bulletSpeed);

            // Assert
            Assert.Fail("Create or modify test");
        }

        [Test]
        public void CanCallsetBullets()
        {
            // Arrange
            var bulletSpeed = 1191956461;

            // Act
            _testClass.setBullets(bulletSpeed);

            // Assert
            Assert.Fail("Create or modify test");
        }

        [Test]
        public void CanCallsetTurretLookingDirections()
        {
            // Arrange
            var directions = new[] { "TestValue1880248854", "TestValue500196974", "TestValue1387068552" };

            // Act
            _testClass.setTurretLookingDirections(directions);

            // Assert
            Assert.Fail("Create or modify test");
        }

        [Test]
        public void CannotCallsetTurretLookingDirectionsWithNullDirections()
        {
            Assert.Throws<ArgumentNullException>(() => _testClass.setTurretLookingDirections(default(string[])));
        }

        [Test]
        public void CanCallStartShooting()
        {
            _testClass.Publicbullet = new Bullet();
            _testClass.Publicbullet.Direction = "";
            // Act
            _testClass.StartShooting();

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
        public void CanCallShootInADirection_Left()
        {
            _testClass.PublicTankBodyLookingDirection = "Left";
            _testClass.PublicTankTurretLookingDirections = new[] { "Left", "Right", "Up", "Down" };
            _testClass.PublicTankTurretLookingDirection = "";
            // Act
            _testClass.ShootInADirection();

            // Assert
            Assert.Fail("Create or modify test");
        }

        [Test]
        public void CanCallShootInADirection_Right()
        {
            _testClass.PublicTankBodyLookingDirection = "Right";
            _testClass.PublicTankTurretLookingDirections = new[] { "Left", "Right", "Up", "Down" };
            _testClass.PublicTankTurretLookingDirection = "";
            // Act
            _testClass.ShootInADirection();

            // Assert
            Assert.Fail("Create or modify test");
        }

        [Test]
        public void CanCallShootInADirection_Up()
        {
            _testClass.PublicTankBodyLookingDirection = "Up";
            _testClass.PublicTankTurretLookingDirections = new[] { "Left", "Right", "Up", "Down" };
            _testClass.PublicTankTurretLookingDirection = "";
            // Act
            _testClass.ShootInADirection();

            // Assert
            Assert.Fail("Create or modify test");
        }


        [Test]
        public void CanCallShootInADirection_Down()
        {
            _testClass.PublicTankBodyLookingDirection = "Down";
            _testClass.PublicTankTurretLookingDirections = new[] { "Left", "Right", "Up", "Down" };
            _testClass.PublicTankTurretLookingDirection = "";
            // Act
            _testClass.ShootInADirection();

            // Assert
            Assert.Fail("Create or modify test");
        }

        [Test]
        public void CanCallShoot()
        {
            _testClass.Publicbullet = new Bullet();
            _testClass.Publicbullet.Direction = "";
            // Act
            _testClass.Shoot();

            // Assert
            Assert.Fail("Create or modify test");
        }

        [Test]
        public void CanCallUpdateShooting()
        {
            // Arrange
            var value = 1110379849;

            _testClass.Publicbullet = new Bullet();

            // Act
            _testClass.UpdateShooting(value);

            // Assert
            Assert.Fail("Create or modify test");
        }
    }
}