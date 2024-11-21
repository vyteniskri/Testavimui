namespace Tests
{
    using System;
    using NUnit.Framework;
    using windowsForms_client.Tanks;

    [TestFixture]
    public class BluePistolTankTests
    {
        private BluePistolTank _testClass;
        private string _id;
        private int _x;
        private int _y;
        private string _name;

        [SetUp]
        public void SetUp()
        {
            _id = "TestValue78861726";
            _x = 738802269;
            _y = 2083609690;
            _name = "TestValue149686094";
            _testClass = new BluePistolTank(_id, _x, _y, _name);
        }

        [Test]
        public void CanConstruct()
        {
            // Act
            var instance = new BluePistolTank();

            // Assert
            Assert.That(instance, Is.Not.Null);

            // Act
            instance = new BluePistolTank(_id, _x, _y, _name);

            // Assert
            Assert.That(instance, Is.Not.Null);
        }

        [TestCase("")]
        [TestCase("")]
        [TestCase("   ")]
        public void CannotConstructWithInvalidId(string value)
        {
            Assert.Throws<ArgumentNullException>(() => new BluePistolTank(value, _x, _y, _name));
        }

        [TestCase("")]
        [TestCase("")]
        [TestCase("   ")]
        public void CannotConstructWithInvalidName(string value)
        {
            Assert.Throws<ArgumentNullException>(() => new BluePistolTank(_id, _x, _y, value));
        }
    }
}