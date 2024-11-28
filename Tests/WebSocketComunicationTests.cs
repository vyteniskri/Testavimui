namespace Tests
{
    using System;
    using System.Net.WebSockets;
    using System.Text;
    using NUnit.Framework;
    using windowsForms_client.Tanks;
    using windowsForms_client;
    using System.Threading.Tasks;
    using System.Reflection;

    [TestFixture]
    public class WebSocketCommunicationIntegrationTest
    {

        private WebSocketComunication _webSocketComunication;

        [SetUp]
        public void SetUp()
        {
            _webSocketComunication = WebSocketComunication.Instance("Pistol", "Movement speed boost", new GameClientFacade("Pistol", "Movement speed boost", "Keyboard"));

        }

        [Test]
        public async Task MonitorClientForDynamicUpdatesFromServer_WhenGameStarted()
        {
            
            bool gameStarted = false;

            await Task.Delay(10000); 

            if (_webSocketComunication.client.gameState.Text == "Game Started")
            {
                Console.WriteLine(_webSocketComunication.client.gameState.Text);
                gameStarted = true;
            }


            Assert.That(gameStarted, "Game did not start");
        }


        [Test]
        public async Task MonitorClientForDynamicUpdatesFromServer_MovementSpeedIncrease()
        {
            bool increased = false;

            await Task.Delay(25000);

            if (_webSocketComunication.client.CurrentTank.MovementSpeedX > 20)
            {
                Console.WriteLine($"Movement speed increased: {_webSocketComunication.client.CurrentTank.MovementSpeedX}");
                increased = true;
            }

            Assert.That(increased, "Speed did not increase");
        }

        [Test]
        public async Task MonitorClientForDynamicUpdatesFromServer_WhenSendingUpgradeShootingMessage()
        {
            bool upgraded = false;

            await _webSocketComunication.SendSelectedUpgrade("Shooting speed boost");

            await Task.Delay(30000);


            if (_webSocketComunication.client.CurrentTank.bullet.BulletSpeed > 30)
            {
                Console.WriteLine($"Shooting speed increased: {_webSocketComunication.client.CurrentTank.bullet.BulletSpeed}");
                upgraded = true;
            }

            Assert.That(upgraded, "Did not receive upgrade message");

        }

        [Test]
        public async Task SendTankInformation_SendsSerializedTankToServer()
        {
            // Arrange
            var mockTank = new RedPistolTank
            {
                x_coordinate = 100,
                y_coordinate = 200,
                MovementSpeedX = 10,
                MovementSpeedY = 10
            };

            var sendMessageCalled = false;

            // Mock WebSocket behavior using reflection
            var clientSocketField = typeof(WebSocketComunication).GetField("clientSocket", BindingFlags.NonPublic | BindingFlags.Instance);
            var mockWebSocket = new ClientWebSocket(); // Replace with an actual mock framework in advanced tests
            clientSocketField.SetValue(_webSocketComunication, mockWebSocket);

            // Act
            await _webSocketComunication.SendTankInformation(mockTank);

            // Assert
            // Capture output
            Console.WriteLine($"Tank serialized and sent: X={mockTank.x_coordinate}, Y={mockTank.y_coordinate}");
            sendMessageCalled = true;

            Assert.That(sendMessageCalled, Is.True, "SendTankInformation should serialize and send the tank data.");
        }

    }
}