namespace Tests
{
    using System;
    using NUnit.Framework;
    using windowsForms_client.Tanks;

    [TestFixture]
    public class RedTommyGunTankTests
    {
        private RedTommyGunTank _testClass;
        private string _id;
        private int _x;
        private int _y;
        private string _name;

        [SetUp]
        public void SetUp()
        {
            _id = "TestValue1721591834";
            _x = 1953959884;
            _y = 305372852;
            _name = "TestValue61247392";
            _testClass = new RedTommyGunTank(_id, _x, _y, _name);
        }

        [Test]
        public void CanConstruct()
        {
            // Act
            var instance = new RedTommyGunTank();

            // Assert
            Assert.That(instance, Is.Not.Null);

            // Act
            instance = new RedTommyGunTank(_id, _x, _y, _name);

            // Assert
            Assert.That(instance, Is.Not.Null);
        }

        [TestCase("")]
        [TestCase("")]
        [TestCase("   ")]
        public void CannotConstructWithInvalidId(string value)
        {
            Assert.Throws<ArgumentNullException>(() => new RedTommyGunTank(value, _x, _y, _name));
        }

        [TestCase("")]
        [TestCase("")]
        [TestCase("   ")]
        public void CannotConstructWithInvalidName(string value)
        {
            Assert.Throws<ArgumentNullException>(() => new RedTommyGunTank(_id, _x, _y, value));
        }
    }
}