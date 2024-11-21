namespace Tests
{
    using System;
    using NSubstitute;
    using NUnit.Framework;
    using windowsForms_client.Factory;
    using windowsForms_client.Strategy;

    [TestFixture]
    public class SnowTests
    {
        private Snow _testClass;
        private int _x;
        private int _y;
        private IStrategy _strategy;

        [SetUp]
        public void SetUp()
        {
            _x = 1629807108;
            _y = 437283100;
            _strategy = Substitute.For<IStrategy>();
            _testClass = new Snow(_x, _y, _strategy);
        }

        [Test]
        public void CanConstruct()
        {
            // Act
            var instance = new Snow(_x, _y, _strategy);

            // Assert
            Assert.That(instance, Is.Not.Null);
        }

        [Test]
        public void CannotConstructWithNullStrategy()
        {
            Assert.Throws<ArgumentNullException>(() => new Snow(_x, _y, default(IStrategy)));
        }
    }
}