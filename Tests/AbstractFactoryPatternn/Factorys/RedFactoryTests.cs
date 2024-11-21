namespace Tests
{
    using System;
    using NUnit.Framework;
    using windowsForms_client.AbstractFactoryPatternn.Factorys;

    [TestFixture]
    public class RedFactoryTests
    {
        private RedFactory _testClass;

        [SetUp]
        public void SetUp()
        {
            _testClass = new RedFactory();
        }

        [Test]
        public void CanCallcreatePistolTank()
        {
            // Arrange
            var id = "TestValue1366224537";
            var x = 569286087;
            var y = 20064503;

            // Act
            var result = _testClass.createPistolTank(id, x, y);

            // Assert
            Assert.Fail("Create or modify test");
        }

        [TestCase("")]
        [TestCase("")]
        [TestCase("   ")]
        public void CannotCallcreatePistolTankWithInvalidId(string value)
        {
            Assert.Throws<ArgumentNullException>(() => _testClass.createPistolTank(value, 2066991851, 1516782107));
        }

        [Test]
        public void CanCallcreateTommyGunTank()
        {
            // Arrange
            var id = "TestValue593948863";
            var x = 1888076357;
            var y = 926774413;

            // Act
            var result = _testClass.createTommyGunTank(id, x, y);

            // Assert
            Assert.Fail("Create or modify test");
        }

        [TestCase("")]
        [TestCase("")]
        [TestCase("   ")]
        public void CannotCallcreateTommyGunTankWithInvalidId(string value)
        {
            Assert.Throws<ArgumentNullException>(() => _testClass.createTommyGunTank(value, 1722440077, 1333120487));
        }

        [Test]
        public void CanCallcreateShotgunTank()
        {
            // Arrange
            var id = "TestValue738562268";
            var x = 1521641931;
            var y = 2132969482;

            // Act
            var result = _testClass.createShotgunTank(id, x, y);

            // Assert
            Assert.Fail("Create or modify test");
        }

        [TestCase("")]
        [TestCase("")]
        [TestCase("   ")]
        public void CannotCallcreateShotgunTankWithInvalidId(string value)
        {
            Assert.Throws<ArgumentNullException>(() => _testClass.createShotgunTank(value, 1080509500, 1768047505));
        }
    }
}