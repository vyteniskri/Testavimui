using windowsForms_client.Tanks;

namespace Tests
{
    using System;
    using NUnit.Framework;
    using windowsForms_client;
    using windowsForms_client.BuilderPattern;

    [TestFixture]
    public class BuilderTests
    {
        private class TestBuilder : Builder
        {
            public Tank Publictank { get => base.tank; set => base.tank = value; }

            public bool PublicIsBodyAssembled
            {
                get => base.isBodyAssembled;
                set => base.isBodyAssembled = value; 
            }

            public bool PublicIsTurretAdded
            {
                get => base.isTurretAdded;
                set => base.isTurretAdded = value;
            }

            public override Builder AssembleBody()
            {
                return default(Builder);
            }

            public override Builder AddWeapons()
            {
                return default(Builder);
            }

            public override Builder AddTurret()
            {
                return default(Builder);
            }

            public override Builder AddDecoration()
            {
                return default(Builder);
            }
        }

        private TestBuilder _testClass;

        [SetUp]
        public void SetUp()
        {
            _testClass = new TestBuilder();
        }

        [Test]
        public void CanCallGetBuildable_ExceptionTrown()
        {
            _testClass.PublicIsBodyAssembled = true;
            _testClass.PublicIsTurretAdded = true;
            // Act
            var result = _testClass.GetBuildable();

            // Assert
            Assert.Fail("Create or modify test");
        }

        [Test]
        public void CanCallGetBuildable_NoException()
        {
            // Act
            var result = _testClass.GetBuildable();

            // Assert
            Assert.Fail("Create or modify test");
        }

        [Test]
        public void CanCallStartNew()
        {
            // Arrange
            var newTank = new RedPistolTank();

            // Act
            var result = _testClass.StartNew(newTank);

            // Assert
            Assert.Fail("Create or modify test");
        }

        [Test]
        public void CannotCallStartNewWithNullNewTank()
        {
            Assert.Throws<ArgumentNullException>(() => _testClass.StartNew(default(Tank)));
        }

        [Test]
        public void CanSetAndGetPublictank()
        {
            // Arrange
            var testValue = new RedPistolTank();

            // Act
            _testClass.Publictank = testValue;

            // Assert
            Assert.That(_testClass.Publictank, Is.SameAs(testValue));
        }
    }
}