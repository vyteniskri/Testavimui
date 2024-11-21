using Timer = System.Timers.Timer;

namespace Tests
{
    using System;
    using System.Threading;
    using NUnit.Framework;
    using windowsForms_client;
    using windowsForms_client.Tanks;

    [TestFixture]
    public class TommyGunTankTests
    {
        private class TestTommyGunTank : TommyGunTank
        {
            public System.Timers.Timer PublicShootingTimer { get => base.ShootingTimer; set => base.ShootingTimer = value; }
            public Bullet Publicbullet { get => base.bullet; set => base.bullet = value; }
            public string PublicTankBodyLookingDirection { get => base.TankBodyLookingDirection; set => base.TankBodyLookingDirection = value; }
            public string[] PublicTankTurretLookingDirections { get => base.TankTurretLookingDirections; set => base.TankTurretLookingDirections = value; }
            public string PublicTankTurretLookingDirection { get => base.TankTurretLookingDirection; set => base.TankTurretLookingDirection = value; }

            public TestTommyGunTank() : base()
            {
            }

            public TestTommyGunTank(string id, int x, int y, string name) : base(id, x, y, name)
            {
            }
        }

        private TestTommyGunTank _testClass;
        private string _id;
        private int _x;
        private int _y;
        private string _name;

        [SetUp]
        public void SetUp()
        {
            _id = "TestValue1054059172";
            _x = 1967354245;
            _y = 112722648;
            _name = "TestValue1973263115";
            _testClass = new TestTommyGunTank(_id, _x, _y, _name);
        }

        [Test]
        public void CanConstruct()
        {
            // Act
            var instance = new TestTommyGunTank();

            // Assert
            Assert.That(instance, Is.Not.Null);

            // Act
            instance = new TestTommyGunTank(_id, _x, _y, _name);

            // Assert
            Assert.That(instance, Is.Not.Null);
        }

        [TestCase("")]
        [TestCase("")]
        [TestCase("   ")]
        public void CannotConstructWithInvalidId(string value)
        {
            Assert.Throws<ArgumentNullException>(() => new TestTommyGunTank(value, _x, _y, _name));
        }

        [TestCase("")]
        [TestCase("")]
        [TestCase("   ")]
        public void CannotConstructWithInvalidName(string value)
        {
            Assert.Throws<ArgumentNullException>(() => new TestTommyGunTank(_id, _x, _y, value));
        }

        [Test]
        public void CanCallSetShootingMechanism_ElapsedEvent()
        {
            // Arrange
            _testClass.Publicbullet = new Bullet();
            _testClass.Publicbullet.Direction = "";

            // Flag to check if Shoot method was called
            bool shootCalled = false;

            // Override the Shoot method to set the flag when called
            _testClass.Shoot();
            shootCalled = true;

            // Set the shooting mechanism with a fire rate (e.g., 100ms)
            var fireRate = 100; // 100 ms for quick testing
            _testClass.setShootingMechanism(fireRate);

            // Create a delegate for the Elapsed event and invoke it
            EventHandler elapsedHandler = (sender, e) => _testClass.Shoot();
            elapsedHandler.Invoke(_testClass.PublicShootingTimer, EventArgs.Empty);

            // Assert
            Assert.That(shootCalled, "The Shoot method was not called when the timer elapsed.");
        }





        [Test]
        public void CanCallsetBullets()
        {
            // Arrange
            var bulletSpeed = 814406738;

            // Act
            _testClass.setBullets(bulletSpeed);

            // Assert
            Assert.Fail("Create or modify test");
        }

        [Test]
        public void CanCallsetTurretLookingDirections()
        {
            // Arrange
            var directions = new[] { "TestValue2143549413", "TestValue1823376085", "TestValue78597420" };

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
            _testClass.PublicShootingTimer = new System.Timers.Timer();
            // Act
            _testClass.StartShooting();

            // Assert
            Assert.Fail("Create or modify test");
        }

        [Test]
        public void CanCallStopShooting()
        {
            _testClass.PublicShootingTimer = new System.Timers.Timer();
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
            var value = 1280864657;
            _testClass.Publicbullet = new Bullet();
            // Act
            _testClass.UpdateShooting(value);

            // Assert
            Assert.Fail("Create or modify test");
        }
    }
}