namespace Tests
{
    using System;
    using System.Collections.Generic;
    using System.Drawing;
    using System.Timers;
    using NUnit.Framework;
    using windowsForms_client;

    [TestFixture]
    public class TankTests
    {
        private class TestTank : Tank
        {
            public TestTank() : base()
            {
            }

            public TestTank(string id, int x, int y, string name) : base(id, x, y, name)
            {
            }

            public string PublicTankBodyLookingDirection { get => base.TankBodyLookingDirection; set => base.TankBodyLookingDirection = value; }
            public Bullet Publicbullet { get => base.bullet; set => base.bullet = value; }
            public int PublicShootingInterval { get => base.ShootingInterval; set => base.ShootingInterval = value; }
            public System.Timers.Timer PublicShootingTimer { get => base.ShootingTimer; set => base.ShootingTimer = value; }
            public string[] PublicTankTurretLookingDirections { get => base.TankTurretLookingDirections; set => base.TankTurretLookingDirections = value; }
            public string PublicTankTurretLookingDirection { get => base.TankTurretLookingDirection; set => base.TankTurretLookingDirection = value; }

            public override void UpdateShooting(int value)
            {
            }

            public override void setTurretLookingDirections(string[] directions)
            {
            }

            public override void setShootingMechanism(int bulletSpeed)
            {
            }

            public override void ShootInADirection()
            {
            }

            public override void Shoot()
            {
            }

            public override void StartShooting()
            {
            }

            public override void StopShooting()
            {
            }
        }

        private TestTank _testClass;
        private string _id;
        private int _x;
        private int _y;
        private string _name;

        [SetUp]
        public void SetUp()
        {
            _id = "TestValue109883212";
            _x = 1532860143;
            _y = 116708507;
            _name = "TestValue479265502";
            _testClass = new TestTank(_id, _x, _y, _name);
        }

        [Test]
        public void CanConstruct()
        {
            // Act
            var instance = new TestTank();

            // Assert
            Assert.That(instance, Is.Not.Null);

            // Act
            instance = new TestTank(_id, _x, _y, _name);

            // Assert
            Assert.That(instance, Is.Not.Null);
        }

        [TestCase("")]
        [TestCase("")]
        [TestCase("   ")]
        public void CannotConstructWithInvalidId(string value)
        {
            Assert.Throws<ArgumentNullException>(() => new TestTank(value, _x, _y, _name));
        }

        [TestCase("")]
        [TestCase("")]
        [TestCase("   ")]
        public void CannotConstructWithInvalidName(string value)
        {
            Assert.Throws<ArgumentNullException>(() => new TestTank(_id, _x, _y, value));
        }

        [Test]
        public void CanCallStartFreeze()
        {
            // Act
            _testClass.StartFreeze();

            // Assert
            Assert.Fail("Create or modify test");
        }

        [Test]
        public void CanCallStartBulletFreeze()
        {
            // Act
            _testClass.StartBulletFreeze();

            // Assert
            Assert.Fail("Create or modify test");
        }

        [Test]
        public void CanCallUpdateMovement()
        {
            // Arrange
            var value = 538851688;

            // Act
            _testClass.UpdateMovement(value);

            // Assert
            Assert.Fail("Create or modify test");
        }

        [Test]
        public void CanCallGetTankSpeedX()
        {
            // Act
            var result = _testClass.GetTankSpeedX();

            // Assert
            Assert.Fail("Create or modify test");
        }

        [Test]
        public void CanCallUpdateHealth()
        {
            // Arrange
            var value = 394494205;

            // Act
            _testClass.UpdateHealth(value);

            // Assert
            Assert.Fail("Create or modify test");
        }

        [Test]
        public void CanCallUpdateShield()
        {
            // Arrange
            var value = 1588053975;

            // Act
            _testClass.UpdateShield1(value);

            // Assert
            Assert.Fail("Create or modify test");
        }

        [Test]
        public void CanCallgetNameOfTank()
        {
            // Act
            var result = _testClass.getNameOfTank();

            // Assert
            Assert.Fail("Create or modify test");
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
        public void CanCallUpdatePosition()
        {
            // Arrange
            var screenWidth = 700210346;
            var screenHeight = 1821453934;

            // Act
            _testClass.UpdatePosition(screenWidth, screenHeight);

            // Assert
            Assert.Fail("Create or modify test");
        }

        [Test]
        public void CanCallsetMovementSpeed()
        {
            // Arrange
            var speedX = 1479720353;
            var speedY = 564415937;

            // Act
            _testClass.setMovementSpeed(speedX, speedY);

            // Assert
            Assert.Fail("Create or modify test");
        }

        [Test]
        public void CanCallsetBulletsWithInt()
        {
            // Arrange
            var bulletSpeed = 1160763225;

            // Act
            _testClass.setBullets(bulletSpeed);

            // Assert
            Assert.Fail("Create or modify test");
        }

        [Test]
        public void CanCallsetBulletsWithBulets()
        {
            // Arrange
            var bulets = new List<Bullet>();

            // Act
            _testClass.setBullets(bulets);

            // Assert
            Assert.Fail("Create or modify test");
        }

        [Test]
        public void CannotCallsetBulletsWithBuletsWithNullBulets()
        {
            Assert.Throws<ArgumentNullException>(() => _testClass.setBullets(default(List<Bullet>)));
        }

        [Test]
        public void CanSetAndGetplayerId()
        {
            // Arrange
            var testValue = "TestValue1511582702";

            // Act
            _testClass.playerId = testValue;

            // Assert
            Assert.That(_testClass.playerId, Is.EqualTo(testValue));
        }

        [Test]
        public void CanSetAndGetx_coordinate()
        {
            // Arrange
            var testValue = 240123177;

            // Act
            _testClass.x_coordinate = testValue;

            // Assert
            Assert.That(_testClass.x_coordinate, Is.EqualTo(testValue));
        }

        [Test]
        public void CanSetAndGety_coordinate()
        {
            // Arrange
            var testValue = 362623677;

            // Act
            _testClass.y_coordinate = testValue;

            // Assert
            Assert.That(_testClass.y_coordinate, Is.EqualTo(testValue));
        }

        [Test]
        public void CanSetAndGetMovementSpeedX()
        {
            // Arrange
            var testValue = 1732242879;

            // Act
            _testClass.MovementSpeedX = testValue;

            // Assert
            Assert.That(_testClass.MovementSpeedX, Is.EqualTo(testValue));
        }

        [Test]
        public void CanSetAndGetMovementSpeedY()
        {
            // Arrange
            var testValue = 861033512;

            // Act
            _testClass.MovementSpeedY = testValue;

            // Assert
            Assert.That(_testClass.MovementSpeedY, Is.EqualTo(testValue));
        }

        [Test]
        public void CanSetAndGetPublicTankBodyLookingDirection()
        {
            // Arrange
            var testValue = "TestValue856157514";

            // Act
            _testClass.PublicTankBodyLookingDirection = testValue;

            // Assert
            Assert.That(_testClass.PublicTankBodyLookingDirection, Is.EqualTo(testValue));
        }

        [Test]
        public void CanSetAndGetbullets()
        {
            // Arrange
            var testValue = new List<Bullet>();

            // Act
            _testClass.bullets = testValue;

            // Assert
            Assert.That(_testClass.bullets, Is.SameAs(testValue));
        }

        [Test]
        public void CanSetAndGetPublicbullet()
        {
            // Arrange
            var testValue = new Bullet();

            // Act
            _testClass.Publicbullet = testValue;

            // Assert
            Assert.That(_testClass.Publicbullet, Is.SameAs(testValue));
        }

        [Test]
        public void CanSetAndGetPublicShootingInterval()
        {
            // Arrange
            var testValue = 1737572054;

            // Act
            _testClass.PublicShootingInterval = testValue;

            // Assert
            Assert.That(_testClass.PublicShootingInterval, Is.EqualTo(testValue));
        }

        [Test]
        public void CanSetAndGetPublicShootingTimer()
        {
            // Arrange
            var testValue = new System.Timers.Timer();

            // Act
            _testClass.PublicShootingTimer = testValue;

            // Assert
            Assert.That(_testClass.PublicShootingTimer, Is.SameAs(testValue));
        }

        [Test]
        public void CanSetAndGetPublicTankTurretLookingDirections()
        {
            // Arrange
            var testValue = new[] { "TestValue1809242873", "TestValue418411232", "TestValue14370252" };

            // Act
            _testClass.PublicTankTurretLookingDirections = testValue;

            // Assert
            Assert.That(_testClass.PublicTankTurretLookingDirections, Is.SameAs(testValue));
        }

        [Test]
        public void CanSetAndGetPublicTankTurretLookingDirection()
        {
            // Arrange
            var testValue = "TestValue728124914";

            // Act
            _testClass.PublicTankTurretLookingDirection = testValue;

            // Assert
            Assert.That(_testClass.PublicTankTurretLookingDirection, Is.EqualTo(testValue));
        }

        [Test]
        public void CanGetTankType()
        {
            // Assert
            Assert.That(_testClass.TankType, Is.InstanceOf<string>());

            Assert.Fail("Create or modify test");
        }

        [Test]
        public void CanSetAndGetColor()
        {
            // Arrange
            var testValue = Color.Orange;

            // Act
            //_testClass.Color = testValue;

            // Assert
            Assert.That(_testClass.Color, Is.EqualTo(testValue));
        }

        [Test]
        public void CanCallOnFreezeTimerElapsed()
        {
            // Arrange
            var sender = new object();
            //var e = new ElapsedEventArgs();

            // Act
            _testClass.OnFreezeTimerElapsed(sender, null);

            // Assert
            Assert.Fail("Create or modify test");
        }

        [Test]
        public void CannotCallOnFreezeTimerElapsedWithNullSender()
        {
            Assert.Throws<ArgumentNullException>(() => _testClass.OnFreezeTimerElapsed(default(object), null));
        }

        [Test]
        public void CannotCallOnFreezeTimerElapsedWithNullE()
        {
            Assert.Throws<ArgumentNullException>(() => _testClass.OnFreezeTimerElapsed(new object(), default(ElapsedEventArgs)));
        }

        [Test]
        public void CanCallOnFreezeBulletTimerElapsed()
        {
            // Arrange
            var sender = new object();
            //var e = new ElapsedEventArgs();

            // Act
            _testClass.OnFreezeBulletTimerElapsed(sender, null);

            // Assert
            Assert.Fail("Create or modify test");
        }

        [Test]
        public void CannotCallOnFreezeBulletTimerElapsedWithNullSender()
        {
            Assert.Throws<ArgumentNullException>(() => _testClass.OnFreezeBulletTimerElapsed(default(object), null));
        }

        [Test]
        public void CannotCallOnFreezeBulletTimerElapsedWithNullE()
        {
            Assert.Throws<ArgumentNullException>(() => _testClass.OnFreezeBulletTimerElapsed(new object(), default(ElapsedEventArgs)));
        }

        [Test]
        public void CanSetAndGethealth()
        {
            // Arrange
            var testValue = 899089184;

            // Act
            _testClass.health = testValue;

            // Assert
            Assert.That(_testClass.health, Is.EqualTo(testValue));
        }
    }
}