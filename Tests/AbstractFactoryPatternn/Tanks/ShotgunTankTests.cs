namespace Tests
{
    using System;
    using System.Collections.Generic;
    using NUnit.Framework;
    using windowsForms_client;
    using windowsForms_client.Tanks;

    [TestFixture]
    public class ShotgunTankTests
    {
        private class TestShotgunTank : ShotgunTank
        {
            public string PublicTankBodyLookingDirection { get => base.TankBodyLookingDirection; set => base.TankBodyLookingDirection = value; }
            public string[] PublicTankTurretLookingDirections { get => base.TankTurretLookingDirections; set => base.TankTurretLookingDirections = value; }
            public string PublicTankTurretLookingDirection { get => base.TankTurretLookingDirection; set => base.TankTurretLookingDirection = value; }

            public TestShotgunTank() : base()
            {
            }

            public TestShotgunTank(string id, int x, int y, string name) : base(id, x, y, name)
            {
            }
        }

        private TestShotgunTank _testClass;
        private string _id;
        private int _x;
        private int _y;
        private string _name;

        [SetUp]
        public void SetUp()
        {
            _id = "TestValue1218513565";
            _x = 1000025675;
            _y = 432548050;
            _name = "TestValue499605547";
            _testClass = new TestShotgunTank(_id, _x, _y, _name);
        }

        [Test]
        public void CanConstruct()
        {
            // Act
            var instance = new TestShotgunTank();

            // Assert
            Assert.That(instance, Is.Not.Null);

            // Act
            instance = new TestShotgunTank(_id, _x, _y, _name);

            // Assert
            Assert.That(instance, Is.Not.Null);
        }

        [TestCase("")]
        [TestCase("")]
        [TestCase("   ")]
        public void CannotConstructWithInvalidId(string value)
        {
            Assert.Throws<ArgumentNullException>(() => new TestShotgunTank(value, _x, _y, _name));
        }

        [TestCase("")]
        [TestCase("")]
        [TestCase("   ")]
        public void CannotConstructWithInvalidName(string value)
        {
            Assert.Throws<ArgumentNullException>(() => new TestShotgunTank(_id, _x, _y, value));
        }

        [Test]
        public void CanCallsetShootingMechanism()
        {
            // Arrange
            var bulletSpeed = 1544703866;

            // Act
            _testClass.setShootingMechanism(bulletSpeed);

            // Assert
            Assert.Fail("Create or modify test");
        }

        [Test]
        public void CanCallsetBullets()
        {
            // Arrange
            var bullets = new List<Bullet>();

            // Act
            _testClass.setBullets(bullets);

            // Assert
            Assert.Fail("Create or modify test");
        }

        [Test]
        public void CannotCallsetBulletsWithNullBullets()
        {
            Assert.Throws<ArgumentNullException>(() => _testClass.setBullets(default(List<Bullet>)));
        }

        [Test]
        public void CanCallsetTurretLookingDirections()
        {
            // Arrange
            var directions = new[] { "TestValue1241459363", "TestValue486399536", "TestValue711775110" };

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
            _testClass.shotgunBullets = new List<Bullet>();
            _testClass.shotgunBullets.Add(new Bullet());

            // Act
            _testClass.Shoot();

            // Assert
            Assert.Fail("Create or modify test");
        }

        [Test]
        public void CanCallUpdateShooting()
        {
            // Arrange
            var value = 1828980400;
            _testClass.shotgunBullets = new List<Bullet>();
            _testClass.shotgunBullets.Add(new Bullet());
            // Act
            _testClass.UpdateShooting(value);

            // Assert
            Assert.Fail("Create or modify test");
        }
    }
}