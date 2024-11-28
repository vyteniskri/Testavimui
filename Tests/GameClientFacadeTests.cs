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
    using System.Reflection;

    [TestFixture]
    public class GameClientFacadeTests
    {

        private GameClientFacade _testClass;


        [SetUp]
        public void SetUp()
        {

            _testClass = new GameClientFacade("Pistol", "Movement speed boost", "Keyboard");

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

        [Test]
        public void CanCallIsCollidingWithCoin()
        {
            // Arrange
            var coin = new Coin("Gold", 500, 300, new CoinDetails(1, "Images/gold.jpg", null));

            _testClass.CurrentTank = new RedPistolTank();
            _testClass.CurrentTank.x_coordinate = 500;
            _testClass.CurrentTank.y_coordinate = 300;

            // Act
            var result = _testClass.IsCollidingWithCoin(_testClass.CurrentTank, coin);

            Console.WriteLine($"Tank is colliding with coin: {result}");

            // Assert
            Assert.That(result, Is.True, "Tank should be colliding with the coin.");
        }

        [Test]
        public void CannotCallIsCollidingWithCoinWhenTankIsFarAway()
        {
            // Arrange
            var coin = new Coin("Gold", 800, 600, new CoinDetails(1, "Images/gold.jpg", null));

            _testClass.CurrentTank = new RedPistolTank();
            _testClass.CurrentTank.x_coordinate = 100;
            _testClass.CurrentTank.y_coordinate = 100;

            // Act
            var result = _testClass.IsCollidingWithCoin(_testClass.CurrentTank, coin);

            Console.WriteLine($"Tank is colliding with coin: {result}");

            // Assert
            Assert.That(result, Is.False, "Tank should not be colliding with the coin.");
        }

        [Test]
        public void BeginGameLoop_SetsUpAndStartsGameLoopTimer()
        {
            // Act
            _testClass.BeginGameLoop();

            // Use reflection to access the private gameLoopTimer
            var gameLoopTimerField = typeof(GameClientFacade)
                .GetField("gameLoopTimer", BindingFlags.NonPublic | BindingFlags.Instance);
            var gameLoopTimer = (System.Timers.Timer)gameLoopTimerField.GetValue(_testClass);

            // Assert that the timer is initialized
            var isTimerInitialized = gameLoopTimer != null;
            Console.WriteLine($"Timer initialized: {isTimerInitialized}");
            Assert.That(isTimerInitialized, Is.True, "gameLoopTimer should be initialized.");

            // Assert the timer interval
            var intervalIsCorrect = gameLoopTimer?.Interval == 16;
            Console.WriteLine($"Timer interval is 16ms: {intervalIsCorrect}");
            Assert.That(intervalIsCorrect, Is.True, "gameLoopTimer should have an interval of 16ms.");

            // Assert the timer auto-reset property
            var autoResetIsCorrect = gameLoopTimer?.AutoReset == true;
            Console.WriteLine($"Timer auto-reset enabled: {autoResetIsCorrect}");
            Assert.That(autoResetIsCorrect, Is.True, "gameLoopTimer should be set to auto-reset.");

            // Assert the timer is started
            var isTimerEnabled = gameLoopTimer?.Enabled == true;
            Console.WriteLine($"Timer started: {isTimerEnabled}");
            Assert.That(isTimerEnabled, Is.True, "gameLoopTimer should be started.");

            //Stop game timer
            gameLoopTimer.Stop();
        }



    }
}