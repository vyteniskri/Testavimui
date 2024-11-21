namespace Tests
{
    using System;
    using System.Drawing;
    using NUnit.Framework;
    using windowsForms_client.Prototype;

    [TestFixture]
    public class CoinTests
    {
        private Coin _testClass;
        private string _type;
        private int _x;
        private int _y;
        private CoinDetails _details;

        [SetUp]
        public void SetUp()
        {
            _type = "TestValue1418346775";
            _x = 1559889292;
            _y = 1845174802;
            _details = new CoinDetails(1360756783, "TestValue758427225", null);
            _testClass = new Coin(_type, _x, _y, _details);
        }

        [Test]
        public void CanConstruct()
        {
            // Act
            var instance = new Coin(_type, _x, _y, _details);

            // Assert
            Assert.That(instance, Is.Not.Null);
        }

        [Test]
        public void CannotConstructWithNullDetails()
        {
            Assert.Throws<ArgumentNullException>(() => new Coin(_type, _x, _y, default(CoinDetails)));
        }

        [TestCase("")]
        [TestCase("")]
        [TestCase("   ")]
        public void CannotConstructWithInvalidType(string value)
        {
            Assert.Throws<ArgumentNullException>(() => new Coin(value, _x, _y, _details));
        }

        [Test]
        public void CanCallShallowCopy()
        {
            // Act
            var result = _testClass.ShallowCopy();

            // Assert
            Assert.Fail("Create or modify test");
        }

        [Test]
        public void CanCallDeepCopy_Gold()
        {
            _testClass.Type = "Gold";
            // Act
            var result = _testClass.DeepCopy();

            // Assert
            Assert.Fail("Create or modify test");
        }

        [Test]
        public void CanCallDeepCopy_Diamond()
        {
            _testClass.Type = "Diamond";
            // Act
            var result = _testClass.DeepCopy();

            // Assert
            Assert.Fail("Create or modify test");
        }

        [Test]
        public void CanCallDeepCopy_Emerald()
        {
            _testClass.Type = "Emerald";
            // Act
            var result = _testClass.DeepCopy();

            // Assert
            Assert.Fail("Create or modify test");
        }

        [Test]
        public void CanCallDeepCopy_None()
        {
            _testClass.Type = "";
            // Act
            var result = _testClass.DeepCopy();

            // Assert
            Assert.Fail("Create or modify test");
        }

        [Test]
        public void CanCallGetImagePathForCoin()
        {
            _testClass.GetImagePathForCoin("Gold");

            // Assert
            Assert.Fail("Create or modify test");
        }

        [Test]
        public void CanCallGetHashCode()
        {
            // Act
            var result = _testClass.GetHashCode();

            // Assert
            Assert.Fail("Create or modify test");
        }

        [Test]
        public void TypeIsInitializedCorrectly()
        {
            Assert.That(_testClass.Type, Is.EqualTo(_type));
        }

        [Test]
        public void CanSetAndGetType()
        {
            // Arrange
            var testValue = "TestValue758384714";

            // Act
            _testClass.Type = testValue;

            // Assert
            Assert.That(_testClass.Type, Is.EqualTo(testValue));
        }

        [Test]
        public void XIsInitializedCorrectly()
        {
            Assert.That(_testClass.X, Is.EqualTo(_x));
        }

        [Test]
        public void CanSetAndGetX()
        {
            // Arrange
            var testValue = 931190356;

            // Act
            _testClass.X = testValue;

            // Assert
            Assert.That(_testClass.X, Is.EqualTo(testValue));
        }

        [Test]
        public void YIsInitializedCorrectly()
        {
            Assert.That(_testClass.Y, Is.EqualTo(_y));
        }

        [Test]
        public void CanSetAndGetY()
        {
            // Arrange
            var testValue = 1285213623;

            // Act
            _testClass.Y = testValue;

            // Assert
            Assert.That(_testClass.Y, Is.EqualTo(testValue));
        }

        [Test]
        public void DetailsIsInitializedCorrectly()
        {
            Assert.That(_testClass.Details, Is.SameAs(_details));
        }

        [Test]
        public void CanSetAndGetDetails()
        {
            // Arrange
            var testValue = new CoinDetails(1056801883, "TestValue371030796", null);

            // Act
            _testClass.Details = testValue;

            // Assert
            Assert.That(_testClass.Details, Is.SameAs(testValue));
        }
    }
}