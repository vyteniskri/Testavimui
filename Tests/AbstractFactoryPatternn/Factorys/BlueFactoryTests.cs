namespace Tests
{
    using System;
    using NUnit.Framework;
    using windowsForms_client.AbstractFactoryPatternn.Factorys;

    [TestFixture]
    public class BlueFactoryTests
    {
        private BlueFactory _testClass;

        [SetUp]
        public void SetUp()
        {
            _testClass = new BlueFactory();
        }

        [Test]
        public void CanCallcreatePistolTank()
        {
            // Arrange
            var id = "TestValue170046954";
            var x = 1883302036;
            var y = 1068573337;

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
            Assert.Throws<ArgumentNullException>(() => _testClass.createPistolTank(value, 886844745, 492158790));
        }

        [Test]
        public void CanCallcreateTommyGunTank()
        {
            // Arrange
            var id = "TestValue1390027241";
            var x = 346459777;
            var y = 1860143889;

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
            Assert.Throws<ArgumentNullException>(() => _testClass.createTommyGunTank(value, 903153960, 139377586));
        }

        [Test]
        public void CanCallcreateShotgunTank()
        {
            // Arrange
            var id = "TestValue2121768622";
            var x = 1316136969;
            var y = 1822525106;

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
            Assert.Throws<ArgumentNullException>(() => _testClass.createShotgunTank(value, 1739071399, 129608232));
        }
    }
}