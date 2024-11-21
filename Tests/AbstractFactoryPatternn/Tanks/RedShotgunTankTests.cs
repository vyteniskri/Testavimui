namespace Tests
{
    using System;
    using NUnit.Framework;
    using windowsForms_client.Tanks;

    [TestFixture]
    public class RedShotgunTankTests
    {
        private RedShotgunTank _testClass;
        private string _id;
        private int _x;
        private int _y;
        private string _name;

        [SetUp]
        public void SetUp()
        {
            _id = "TestValue309782425";
            _x = 217214241;
            _y = 1238842090;
            _name = "TestValue580716479";
            _testClass = new RedShotgunTank(_id, _x, _y, _name);
        }

        [Test]
        public void CanConstruct()
        {
            // Act
            var instance = new RedShotgunTank();

            // Assert
            Assert.That(instance, Is.Not.Null);

            // Act
            instance = new RedShotgunTank(_id, _x, _y, _name);

            // Assert
            Assert.That(instance, Is.Not.Null);
        }

        [TestCase("")]
        [TestCase("")]
        [TestCase("   ")]
        public void CannotConstructWithInvalidId(string value)
        {
            Assert.Throws<ArgumentNullException>(() => new RedShotgunTank(value, _x, _y, _name));
        }

        [TestCase("")]
        [TestCase("")]
        [TestCase("   ")]
        public void CannotConstructWithInvalidName(string value)
        {
            Assert.Throws<ArgumentNullException>(() => new RedShotgunTank(_id, _x, _y, value));
        }
    }
}