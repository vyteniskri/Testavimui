namespace Tests
{
    using System;
    using System.Drawing;
    using System.Threading;
    using Moq;
    using NSubstitute;
    using NUnit.Framework;
    using windowsForms_client;
    using windowsForms_client.AbstractFactoryPatternn;
    using windowsForms_client.Adapter;
    using windowsForms_client.Prototype;
    using windowsForms_client.Strategy;
    using windowsForms_client.Tanks;

    [TestFixture]
    public class GameClientFacadeTests
    {

        private GameClientFacade _testClass;


        [SetUp]
        public void SetUp()
        {

            _testClass = new GameClientFacade("PistolTank", "Red", "");

        }

        [TearDown]
        public void TearDown()
        {
            _testClass?.Dispose();
            _testClass = null;
        }


        /// ------ Jei runninsit visus testus vienu metu uzkomentuokit visus testavimo metodus po apacia.----------

        [Test]
        public void InitializeTank_CreatesBlueTommyGunTankWithKeyboardControl()
        {
            // Arrange
            string tankType = "TommyGun";
            string tankColor = "Blue";
            string playerId = "Player2";
            _testClass.controlType = "Keyboard";

            // Act
            _testClass.InitializeTank(tankType, tankColor, playerId);


            var controlAdapter = typeof(GameClientFacade)
                .GetField("_controlAdapter", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);
            var usedAdapter = controlAdapter?.GetValue(_testClass);


            Console.WriteLine($"Current tank is: {_testClass.CurrentTank}");
            Console.WriteLine($"Tank is controlled by: {usedAdapter}");
            // Assert
            Assert.That(_testClass.CurrentTank, Is.TypeOf<BlueTommyGunTank>());
            Assert.That(usedAdapter, Is.TypeOf<KeyboardControlAdapter>());
        }


        [Test]
        public void CanCallIsCollidingWithObstacle()
        {

            var obstacle = new Obstacle(600, 200, new BlindnessStrategy());

            _testClass.CurrentTank = new RedPistolTank();
            _testClass.CurrentTank.x_coordinate = 600;
            _testClass.CurrentTank.y_coordinate = 200;

            // Act
            var result = _testClass.IsCollidingWithObstacle(_testClass.CurrentTank, obstacle);

            Console.WriteLine($"Tank is coliding with object: {result}");
            // Assert
            Assert.That(result, Is.True);
        }

    }
}