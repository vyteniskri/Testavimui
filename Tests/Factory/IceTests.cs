namespace Tests
{
    using System;
    using NSubstitute;
    using NUnit.Framework;
    using windowsForms_client.Factory;
    using windowsForms_client.Strategy;

    [TestFixture]
    public class IceTests
    {
        private Ice _testClass;
        private int _x;
        private int _y;
        private IStrategy _strategy;

        [SetUp]
        public void SetUp()
        {
            _x = 583235874;
            _y = 1185378798;
            _strategy = Substitute.For<IStrategy>();
            _testClass = new Ice(_x, _y, _strategy);
        }

        [Test]
        public void CanConstruct()
        {
            // Act
            var instance = new Ice(_x, _y, _strategy);

            // Assert
            Assert.That(instance, Is.Not.Null);
        }

        [Test]
        public void CannotConstructWithNullStrategy()
        {
            Assert.Throws<ArgumentNullException>(() => new Ice(_x, _y, default(IStrategy)));
        }
    }
}