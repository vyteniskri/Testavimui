namespace Tests
{
    using System;
    using System.Net.WebSockets;
    using System.Text;
    using NUnit.Framework;
    using windowsForms_client.Tanks;
    using windowsForms_client;
    using System.Threading.Tasks;

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

    }
}