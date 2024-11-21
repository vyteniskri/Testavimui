namespace Tests
{
    using System;
    using System.Drawing;
    using NUnit.Framework;
    using windowsForms_client.Prototype;

    [TestFixture]
    public class CoinDetailsTests
    {
        private CoinDetails _testClass;
        private int _value;
        private string _imagePath;
        private Image _image;

        [TearDown]
        public void TearDown()
        {
            // Dispose of the image after each test
            Dispose();
        }

        public void Dispose()
        {
            // Dispose of the Image if it's not already disposed
            _image?.Dispose();
        }

        [SetUp]
        public void SetUp()
        {
            _value = 451858155;
            _imagePath = "TestValue800425875";
            _image = null;
            _testClass = new CoinDetails(_value, _imagePath, _image);
        }

        [Test]
        public void CanConstruct()
        {
            // Act
            var instance = new CoinDetails(_value, _imagePath, _image);

            // Assert
            Assert.That(instance, Is.Not.Null);
        }

        [Test]
        public void CannotConstructWithNullImage()
        {
            Assert.Throws<ArgumentNullException>(() => new CoinDetails(_value, _imagePath, default(Image)));
        }

        [TestCase("")]
        [TestCase("")]
        [TestCase("   ")]
        public void CannotConstructWithInvalidImagePath(string value)
        {
            Assert.Throws<ArgumentNullException>(() => new CoinDetails(_value, value, _image));
        }

        [Test]
        public void ValueIsInitializedCorrectly()
        {
            Assert.That(_testClass.Value, Is.EqualTo(_value));
        }

        [Test]
        public void CanSetAndGetValue()
        {
            // Arrange
            var testValue = 1790963113;

            // Act
            _testClass.Value = testValue;

            // Assert
            Assert.That(_testClass.Value, Is.EqualTo(testValue));
        }

        [Test]
        public void ImagePathIsInitializedCorrectly()
        {
            Assert.That(_testClass.ImagePath, Is.EqualTo(_imagePath));
        }

        [Test]
        public void CanSetAndGetImagePath()
        {
            // Arrange
            var testValue = "TestValue962473132";

            // Act
            _testClass.ImagePath = testValue;

            // Assert
            Assert.That(_testClass.ImagePath, Is.EqualTo(testValue));
        }
    }
}