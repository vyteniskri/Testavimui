using windowsForms_client.Tanks;

namespace Tests
{
    using System;
    using NUnit.Framework;
    using windowsForms_client;
    using windowsForms_client.BuilderPattern;

    [TestFixture]
    public class PistolTankBuilderTests
    {
        private class TestPistolTankBuilder : PistolTankBuilder
        {
            public Tank Publictank { get => base.tank; set => base.tank = value; }
        }

        private TestPistolTankBuilder _testClass;

        [SetUp]
        public void SetUp()
        {
            _testClass = new TestPistolTankBuilder();
        }

        [Test]
        public void CanCallAddLightArmor()
        {
            // Act
            _testClass.AddLightArmor();

            // Assert
            Assert.Fail("Create or modify test");
        }

        [Test]
        public void CanCallAddFastBullets()
        {
            _testClass.Publictank = new RedPistolTank();
            // Act
            _testClass.AddFastBullets();

            // Assert
            Assert.Fail("Create or modify test");
        }

        [Test]
        public void CanCallAddFastWheels()
        {
            _testClass.Publictank = new RedPistolTank();
            // Act
            _testClass.AddFastWheels();

            // Assert
            Assert.Fail("Create or modify test");
        }

        [Test]
        public void CanCallAddFourDirectionTurret()
        {
            _testClass.Publictank = new RedPistolTank();
            // Act
            _testClass.AddFourDirectionTurret();

            // Assert
            Assert.Fail("Create or modify test");
        }

        [Test]
        public void CanCallAddFunnyMustache()
        {
            // Act
            _testClass.AddFunnyMustache();

            // Assert
            Assert.Fail("Create or modify test");
        }

        [Test]
        public void CanCallAddWeapons()
        {
            _testClass.Publictank = new RedPistolTank();
            // Act
            var result = _testClass.AddWeapons();

            // Assert
            Assert.Fail("Create or modify test");
        }

        [Test]
        public void CanCallAssembleBody()
        {
            _testClass.Publictank = new RedPistolTank();
            // Act
            var result = _testClass.AssembleBody();

            // Assert
            Assert.Fail("Create or modify test");
        }

        [Test]
        public void CanCallAddTurret()
        {
            _testClass.Publictank = new RedPistolTank();
            
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