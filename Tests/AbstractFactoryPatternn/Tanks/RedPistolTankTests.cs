namespace Tests
{
    using System;
    using NUnit.Framework;
    using windowsForms_client.Tanks;

    [TestFixture]
    public class RedPistolTankTests
    {
        private RedPistolTank _testClass;
        private string _id;
        private int _x;
        private int _y;
        private string _name;

        [SetUp]
        public void SetUp()
        {
            _id = "TestValue1993304384";
            _x = 407696912;
            _y = 1206320890;
            _name = "TestValue2101657";
            _testClass = new RedPistolTank(_id, _x, _y, _name);
        }

        [Test]
        public void CanConstruct()
        {
            // Act
            var instance = new RedPistolTank();

            // Assert
            Assert.That(instance, Is.Not.Null);

            // Act
            instance = new RedPistolTank(_id, _x, _y, _name);

            // Assert
            Assert.That(instance, Is.Not.Null);
        }

        [TestCase("")]
        [TestCase("")]
        [TestCase("   ")]
        public void CannotConstructWithInvalidId(string value)
        {
            Assert.Throws<ArgumentNullException>(() => new RedPistolTank(value, _x, _y, _name));
        }

        [TestCase("")]
        [TestCase("")]
        [TestCase("   ")]
        public void CannotConstructWithInvalidName(string value)
        {
            Assert.Throws<ArgumentNullException>(() => new RedPistolTank(_id, _x, _y, value));
        }
    }
}