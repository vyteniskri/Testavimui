namespace Tests
{
    using System;
    using NUnit.Framework;
    using windowsForms_client;

    [TestFixture]
    public class BulletTests
    {
        private Bullet _testClass;
        private int _bulletSpeed;
        private string _id;
        private int _y_aditionalHeight;
        private int _x_aditionalHeight;

        [SetUp]
        public void SetUp()
        {
            _bulletSpeed = 823368071;
            _id = "TestValue953578398";
            _y_aditionalHeight = 1933465001;
            _x_aditionalHeight = 1425809725;
            _testClass = new Bullet(_bulletSpeed, _id, _y_aditionalHeight, _x_aditionalHeight);
        }

        [Test]
        public void CanConstruct()
        {
            // Act
            var instance = new Bullet();

            // Assert
            Assert.That(instance, Is.Not.Null);

            // Act
            instance = new Bullet(_bulletSpeed, _id, _y_aditionalHeight, _x_aditionalHeight);

            // Assert
            Assert.That(instance, Is.Not.Null);
        }

        [TestCase("")]
        [TestCase("")]
        [TestCase("   ")]
        public void CannotConstructWithInvalidId(string value)
        {
            Assert.Throws<ArgumentNullException>(() => new Bullet(_bulletSpeed, value, _y_aditionalHeight, _x_aditionalHeight));
        }

        [Test]
        public void CanCallSetBaseBulletPosition_Right()
        {
            _testClass.Direction = "Right";

            // Arrange
            var x_coordinate = 1349248029;
            var y_coordinate = 1000046816;

            // Act
            _testClass.SetBaseBulletPosition(x_coordinate, y_coordinate);
            
            // Assert
            Assert.That(_testClass.X, Is.EqualTo(x_coordinate + 50));
        }

        [Test]
        public void CanCallSetBaseBulletPosition_Left()
        {
            _testClass.Direction = "Left";

            // Arrange
            var x_coordinate = 1349248029;
            var y_coordinate = 1000046816;

            // Act
            _testClass.SetBaseBulletPosition(x_coordinate, y_coordinate);

            // Assert
            Assert.That(_testClass.X, Is.EqualTo(x_coordinate - 25));
        }

        [Test]
        public void CanCallSetBaseBulletPosition_Up()
        {
            _testClass.Direction = "Up";

            // Arrange
            var x_coordinate = 1349248029;
            var y_coordinate = 1000046816;

            // Act
            _testClass.SetBaseBulletPosition(x_coordinate, y_coordinate);

            // Assert
            Assert.That(_testClass.Y, Is.EqualTo(x_coordinate - 10));
        }

        [Test]
        public void CanCallSetBaseBulletPosition_Down()
        {
            _testClass.Direction = "Down";

            // Arrange
            var x_coordinate = 1349248029;
            var y_coordinate = 1000046816;

            // Act
            _testClass.SetBaseBulletPosition(x_coordinate, y_coordinate);

            // Assert
            Assert.That(_testClass.Y, Is.EqualTo(x_coordinate + 50));
        }

        [Test]
        public void CanCallMove_Right()
        {
            _testClass.Direction = "Right";
            // Act
            _testClass.Move();

            // Assert
            Assert.Fail("Create or modify test");
        }

        [Test]
        public void CanCallMove_Left()
        {
            _testClass.Direction = "Left";
            // Act
            _testClass.Move();

            // Assert
            Assert.Fail("Create or modify test");
        }

        [Test]
        public void CanCallMove_Up()
        {
            _testClass.Direction = "Up";
            // Act
            _testClass.Move();

            // Assert
            Assert.Fail("Create or modify test");
        }

        [Test]
        public void CanCallMove_Down()
        {
            _testClass.Direction = "Down";
            // Act
            _testClass.Move();

            // Assert
            Assert.Fail("Create or modify test");
        }



        [Test]
        public void IdIsInitializedCorrectly()
        {
            Assert.That(_testClass.Id, Is.EqualTo(_id));
        }

        [Test]
        public void CanSetAndGetId()
        {
            // Arrange
            var testValue = "TestValue830588791";

            // Act
            _testClass.Id = testValue;

            // Assert
            Assert.That(_testClass.Id, Is.EqualTo(testValue));
        }

        [Test]
        public void CanSetAndGetX()
        {
            // Arrange
            var testValue = 1035893850;

            // Act
            _testClass.X = testValue;

            // Assert
            Assert.That(_testClass.X, Is.EqualTo(testValue));
        }

        [Test]
        public void CanSetAndGetY()
        {
            // Arrange
            var testValue = 600800038;

            // Act
            _testClass.Y = testValue;

            // Assert
            Assert.That(_testClass.Y, Is.EqualTo(testValue));
        }

        [Test]
        public void CanSetAndGetY_aditional()
        {
            // Arrange
            var testValue = 345904161;

            // Act
            _testClass.Y_aditional = testValue;

            // Assert
            Assert.That(_testClass.Y_aditional, Is.EqualTo(testValue));
        }

        [Test]
        public void CanSetAndGetX_aditional()
        {
            // Arrange
            var testValue = 2029742577;

            // Act
            _testClass.X_aditional = testValue;

            // Assert
            Assert.That(_testClass.X_aditional, Is.EqualTo(testValue));
        }

        [Test]
        public void BulletSpeedIsInitializedCorrectly()
        {
            Assert.That(_testClass.BulletSpeed, Is.EqualTo(_bulletSpeed));
        }

        [Test]
        public void CanSetAndGetBulletSpeed()
        {
            // Arrange
            var testValue = 1214224365;

            // Act
            _testClass.BulletSpeed = testValue;

            // Assert
            Assert.That(_testClass.BulletSpeed, Is.EqualTo(testValue));
        }

        [Test]
        public void CanSetAndGetWidth()
        {
            // Arrange
            var testValue = 869665318;

            // Act
            _testClass.Width = testValue;

            // Assert
            Assert.That(_testClass.Width, Is.EqualTo(testValue));
        }

        [Test]
        public void CanSetAndGetHeight()
        {
            // Arrange
            var testValue = 1645314081;

            // Act
            _testClass.Height = testValue;

            // Assert
            Assert.That(_testClass.Height, Is.EqualTo(testValue));
        }

        [Test]
        public void CanSetAndGetDirection()
        {
            // Arrange
            var testValue = "TestValue347427403";

            // Act
            _testClass.Direction = testValue;

            // Assert
            Assert.That(_testClass.Direction, Is.EqualTo(testValue));
        }
    }
}