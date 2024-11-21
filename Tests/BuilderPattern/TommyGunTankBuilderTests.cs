using windowsForms_client.Tanks;

namespace Tests
{
    using System;
    using NUnit.Framework;
    using windowsForms_client;
    using windowsForms_client.BuilderPattern;

    [TestFixture]
    public class TommyGunTankBuilderTests
    {
        private class TestTommyGunTankBuilder : TommyGunTankBuilder
        {
            public Tank Publictank { get => base.tank; set => base.tank = value; }
        }

        private TestTommyGunTankBuilder _testClass;

        [SetUp]
        public void SetUp()
        {
            _testClass = new TestTommyGunTankBuilder();
        }

        [Test]
        public void CanCallAddFullAutoShooting()
        {
            _testClass.Publictank = new RedTommyGunTank();
            // Act
            _testClass.AddFullAutoShooting();

            // Assert
            Assert.Fail("Create or modify test");
        }

        [Test]
        public void CanCallAddHeavyArmor()
        {
            // Act
            _testClass.AddHeavyArmor();

            // Assert
            Assert.Fail("Create or modify test");
        }

        [Test]
        public void CanCallAddSlowWheels()
        {
            _testClass.Publictank = new RedTommyGunTank();
            // Act
            _testClass.AddSlowWheels();

            // Assert
            Assert.Fail("Create or modify test");
        }

        [Test]
        public void CanCallAddSlowBullets()
        {
            _testClass.Publictank = new RedTommyGunTank();
            // Act
            _testClass.AddSlowBullets();

            // Assert
            Assert.Fail("Create or modify test");
        }

        [Test]
        public void CanCallAddTwoDirectionTurret()
        {
            _testClass.Publictank = new RedTommyGunTank();
            // Act
            _testClass.AddTwoDirectionTurret();

            // Assert
            Assert.Fail("Create or modify test");
        }

        [Test]
        public void CanCallAddGoldenHat()
        {
            // Act
            _testClass.AddGoldenHat();

            // Assert
            Assert.Fail("Create or modify test");
        }

        [Test]
        public void CanCallAddWeapons()
        {
            _testClass.Publictank = new RedTommyGunTank();
            // Act
            var result = _testClass.AddWeapons();

            // Assert
            Assert.Fail("Create or modify test");
        }

        [Test]
        public void CanCallAssembleBody()
        {
            _testClass.Publictank = new RedTommyGunTank();
            // Act
            var result = _testClass.AssembleBody();

            // Assert
            Assert.Fail("Create or modify test");
        }

        [Test]
        public void CanCallAddTurret()
        {
            _testClass.Publictank = new RedTommyGunTank();
            // Act
            var result = _testClass.AddTurret();

            // Assert
            Assert.Fail("Create or modify test");
        }

        [Test]
        public void CanCallAddDecoration()
        {
            // Act
            var result = _testClass.AddDecoration();

            // Assert
            Assert.Fail("Create or modify test");
        }
    }
}