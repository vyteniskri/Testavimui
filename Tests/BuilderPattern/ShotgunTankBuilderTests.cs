using windowsForms_client;
using windowsForms_client.Tanks;

namespace Tests
{
    using System;
    using NUnit.Framework;
    using windowsForms_client.BuilderPattern;

    [TestFixture]
    public class ShotgunTankBuilderTests
    {
        private class TestShotgunTankBuilder : ShotgunTankBuilder
        {
            public Tank PublicTank { get => base.tank; set => base.tank = value; }
        }

        private TestShotgunTankBuilder _testClass;

        [SetUp]
        public void SetUp()
        {
            _testClass = new TestShotgunTankBuilder();
        }

        [Test]
        public void CanCallAddMediumArmor()
        {
            // Act
            _testClass.AddMediumArmor();

            // Assert
            Assert.Fail("Create or modify test");
        }

        [Test]
        public void CanCallAddMediumBulletsMagazine()
        {
            _testClass.PublicTank = new RedShotgunTank();
            // Act
            _testClass.AddMediumBulletsMagazine();

            // Assert
            Assert.Fail("Create or modify test");
        }

        [Test]
        public void CanCallAddMediumWheels()
        {
            _testClass.PublicTank = new RedShotgunTank();
            // Act
            _testClass.AddMediumWheels();

            // Assert
            Assert.Fail("Create or modify test");
        }

        [Test]
        public void CanCallAddFourDirectionTurret()
        {
            _testClass.PublicTank = new RedShotgunTank();
            // Act
            _testClass.AddFourDirectionTurret();

            // Assert
            Assert.Fail("Create or modify test");
        }

        [Test]
        public void CanCallAddPurpleCrown()
        {
            // Act
            _testClass.AddPurpleCrown();

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

        [Test]
        public void CanCallAddTurret()
        {
            _testClass.PublicTank = new RedShotgunTank();
            // Act
            var result = _testClass.AddTurret();

            // Assert
            Assert.Fail("Create or modify test");
        }

        [Test]
        public void CanCallAddWeapons()
        {
            _testClass.PublicTank = new RedShotgunTank();
            // Act
            var result = _testClass.AddWeapons();

            // Assert
            Assert.Fail("Create or modify test");
        }

        [Test]
        public void CanCallAssembleBody()
        {
            _testClass.PublicTank = new RedShotgunTank();
            // Act
            var result = _testClass.AssembleBody();

            // Assert
            Assert.Fail("Create or modify test");
        }
    }
}