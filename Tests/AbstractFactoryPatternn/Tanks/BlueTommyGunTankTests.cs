namespace Tests
{
    using System;
    using NUnit.Framework;
    using windowsForms_client.Tanks;

    [TestFixture]
    public class BlueTommyGunTankTests
    {
        private BlueTommyGunTank _testClass;
        private string _id;
        private int _x;
        private int _y;
        private string _name;

        [SetUp]
        public void SetUp()
        {
            _id = "TestValue1611266021";
            _x = 608260245;
            _y = 862982777;
            _name = "TestValue2025885942";
            _testClass = new BlueTommyGunTank(_id, _x, _y, _name);
        }

        [Test]
        public void CanConstruct()
        {
            // Act
            var instance = new BlueTommyGunTank();

            // Assert
            Assert.That(instance, Is.Not.Null);

            // Act
            instance = new BlueTommyGunTank(_id, _x, _y, _name);

            // Assert
            Assert.That(instance, Is.Not.Null);
        }

        [TestCase("")]
        [TestCase("")]
        [TestCase("   ")]
        public void CannotConstructWithInvalidId(string value)
        {
            Assert.Throws<ArgumentNullException>(() => new BlueTommyGunTank(value, _x, _y, _name));
        }

        [TestCase("")]
        [TestCase("")]
        [TestCase("   ")]
        public void CannotConstructWithInvalidName(string value)
        {
            Assert.Throws<ArgumentNullException>(() => new BlueTommyGunTank(_id, _x, _y, value));
        }
    }
}