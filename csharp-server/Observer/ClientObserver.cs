using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.WebSockets;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace csharp_server.Observer
{
    public class ClientObserver : IObserver
    {
        private static readonly SemaphoreSlim _sendLock = new SemaphoreSlim(1, 1);
        private WebSocket WebSocket;
        private Subject Server;
        public string PlayerId { get; private set; }
        public string PlayerColor { get; private set; }

        public ClientObserver(WebSocket webSocket)
        {
            this.WebSocket = webSocket;
        }

        public void SetServer(Subject server)
        {
            this.Server = server;
        }

        public void SetPlayerIdAndColor()
        {
            this.SetId();
            this.SetColor();
        }

        public void SetId()
        {
            PlayerId = Guid.NewGuid().ToString();
            this.Update(PlayerId);
        }

        public void SetColor()
        {
            if (Server.UsedColor == "Red")
            {
                this.PlayerColor = "Blue";
            }
            else if (Server.UsedColor == "Blue")
            {
                this.PlayerColor = "Red";
            }

            Server.SetUsedColor(this.PlayerColor);
            this.Update(this.PlayerColor);
        }


        public void NotifyServer(string message)
        {
            Server.NotifyAll(message); 
        }


        public async void Update(string message)
        {
            await _sendLock.WaitAsync();
            try
            {
                // Ensure the message is not null or empty
                if (string.IsNullOrEmpty(message))
                {
                    return; // Exit early if the message is null or empty
                }

                // Ensure the WebSocket is in a valid state before sending
                if (WebSocket.State != WebSocketState.Open)
                {
                    return; // Exit early if the WebSocket is not open
                }

           
                var buffer = Encoding.UTF8.GetBytes(message);
                await WebSocket.SendAsync(new ArraySegment<byte>(buffer), WebSocketMessageType.Text, true, CancellationToken.None);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error during WebSocket send: {ex.Message}");
            }
            finally
            {
                _sendLock.Release();
            }
        }

        public async Task HandleCommunication()
        {
            var buffer = new byte[8192];
            WebSocketReceiveResult result = await WebSocket.ReceiveAsync(new ArraySegment<byte>(buffer), CancellationToken.None);        

            while (!result.CloseStatus.HasValue)
            {
                var message = Encoding.UTF8.GetString(buffer, 0, result.Count);
                Console.WriteLine($"Received message from {PlayerId}: {message}");

                if (message.StartsWith("SubscribeUpgrade"))
                {
                    var upgrade = message.Split(',')[1];
                    this.Server.SubscribeToUpgrade(this, upgrade); // Subscribe this client to the upgrade
                }
                else
                {
                    // Notify all other clients (observers)
                    this.NotifyServer(message);
                }

                result = await WebSocket.ReceiveAsync(new ArraySegment<byte>(buffer), CancellationToken.None);
            }

            this.RemoveClient(result);
            
            
        }

        private readonly SemaphoreSlim _closeSemaphore = new SemaphoreSlim(1, 1);

        public async void RemoveClient(WebSocketReceiveResult result)
        {
            await _sendLock.WaitAsync();
            try
            {
                if (result == null)
                {
                    return;
                }
                // Ensure Server is not null
                if (Server == null)
                {
                    return; // Exit the method if Server is null
                }


                if (string.IsNullOrEmpty(this.PlayerColor))
                {
                    return;
                }

                // Update color availability if Server is set
                if (this.PlayerColor == "Blue")
                {
                    Server.SetUsedColor("Red");
                }
                else if (this.PlayerColor == "Red")
                {
                    Server.SetUsedColor("Blue");
                }
                else
                {
                    return; // Exit if the color is not valid
                }

                if (Server != null)
                {
                    Server.Detach(this);
                    Server.DeatchUpgradeUser(this);
                }
                else
                {
                    return;
                }

                if (PlayerId == null)
                {
                    return;
                }

                // Detach client from server (ensure Server is valid)
                Server.Detach(this);
                Server.DeatchUpgradeUser(this);

                // Notify server about the removal
                var removeMessage = $"Remove,{PlayerId}";
                this.NotifyServer(removeMessage);

                // Safely close the WebSocket (check if it's not null)
                if (WebSocket != null && WebSocket.State != WebSocketState.Aborted)
                {

                    try
                    {
                        if (WebSocket.State == WebSocketState.Open || WebSocket.State == WebSocketState.CloseReceived)
                        {
                            await WebSocket.CloseOutputAsync(result.CloseStatus.Value, result.CloseStatusDescription, CancellationToken.None);
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Error while closing WebSocket: {ex.Message}");
                    }
                }

                Console.WriteLine($"Client {PlayerId} disconnected");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error while removing client {PlayerId}: {ex.Message}");
            }
            finally
            {
                _sendLock.Release();
            }
        }

        

    }
}
