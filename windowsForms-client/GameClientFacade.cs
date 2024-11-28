﻿using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Net.WebSockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Timers;
using windowsForms_client.AbstractFactoryPatternn;
using windowsForms_client.AbstractFactoryPatternn.Factorys;
using windowsForms_client.Tanks;
using System.Text.Json;
using System.Drawing;
using System.Runtime.CompilerServices;
using windowsForms_client.Strategy;
using windowsForms_client.Factory;
using windowsForms_client.Prototype;
using windowsForms_client.Adapter;
using System.Security.AccessControl;

namespace windowsForms_client

{
    public partial class GameClientFacade : Form
    {
        private bool isMousePressed = false;
        private Point mousePosition;
        public string controlType;


        private IControl _controlAdapter;
        public Tank CurrentTank;
        private List<Tank> allPlayers = new List<Tank>();
        private System.Timers.Timer gameLoopTimer;
        private bool spacebarPressed = false;
        private (int x, int y) lastSentPosition;
        private WebSocketComunication webSocketComunication;

        private System.Timers.Timer gameTimer;
        private System.Timers.Timer coinTimer;
        public int elapsedSeconds = 0;

        private System.Timers.Timer temporaryEffectTimer;
        private List<Obstacle> obstacles = new List<Obstacle>();
        private List<IStrategy> randomStrategies = new List<IStrategy>
        {
            new FastStrategy(),
            new SlowStrategy(),
            new StuckStrategy(),
            new BlindnessStrategy()
        };
        private Dictionary<Obstacle, (Color OriginalColor, IStrategy OriginalStrategy)> originalObstacleStates = new Dictionary<Obstacle, (Color, IStrategy)>();
        private Coin coin;
        private int gamePhase = 1;



        public GameClientFacade(string tankType, string selectedUpgrade, string controlType)
        {
            InitializeComponent();
            PrintTankType(tankType);

            this.controlType = controlType;

            gameTimer = new System.Timers.Timer(1000);
            gameTimer.Elapsed += OnGameTimerElapsed;
            DisplayTime();

            KeyDown += OnKeyDown;
            KeyUp += OnKeyUp;

            MouseDown += OnMouseDownHandler;
            MouseUp += OnMouseUpHandler;

            webSocketComunication = WebSocketComunication.Instance(tankType, selectedUpgrade, this);
            this.FormClosing += GameClient_FormClosing;
            InitializeObstacles(); // Call to initialize obstacles

            temporaryEffectTimer = new System.Timers.Timer(10000);
            temporaryEffectTimer.Elapsed += OnTemporaryEffectTimerElapsed;
            temporaryEffectTimer.Start();

            coinTimer = new System.Timers.Timer(10000);
            coinTimer.Elapsed += OnCoinTimerElapsed;
            coinTimer.Start();
        }

        // Initialize obstacles AND coind
        public void InitializeObstacles()
        {
            ObstacleCreator mistCreator = new MistCreator();
            ObstacleCreator mudCreator = new MudCreator();
            ObstacleCreator iceCreator = new IceCreator();
            ObstacleCreator snowCreator = new SnowCreator();

            obstacles.Add(mistCreator.CreateObstacle(100, 100, new BlindnessStrategy()));
            obstacles.Add(mistCreator.CreateObstacle(600, 100, new BlindnessStrategy()));
            obstacles.Add(mudCreator.CreateObstacle(200, 250, new SlowStrategy()));
            obstacles.Add(iceCreator.CreateObstacle(600, 350, new FastStrategy()));
            obstacles.Add(snowCreator.CreateObstacle(350, 150, new StuckStrategy()));


            foreach (var obstacle in obstacles)
            {
                originalObstacleStates[obstacle] = (GetObstacleColor(obstacle), obstacle.Strategy);
            }
            //PLEASE CHECK IF THIS CAUSES ERRORS TO U

            string imagePath = @"Images\gold.jpg";
            //Console.WriteLine(imagePath);

            //COMMENT THIS
            coin = new Coin("Gold", new Random().Next(0, 800), new Random().Next(0, 300), new CoinDetails(1, imagePath, Image.FromFile(imagePath)));

            Invalidate();
        }

        public void StartCountingTime()
        {
            gameTimer.Start();
        }

        public void StopCountingTime()
        {
            gameTimer.Stop();
            elapsedSeconds = 0;
            DisplayTime();
        }

        private void OnGameTimerElapsed(object sender, ElapsedEventArgs e)
        {
            elapsedSeconds++;
            DisplayTime();

        }
        private void OnCoinTimerElapsed(object sender, ElapsedEventArgs e)
        {
            if (gamePhase >= 3)
            {
                (sender as System.Timers.Timer).Stop();
                return;
            }
            Coin clonedCoin = coin.DeepCopy();
            coin = clonedCoin;
            gamePhase++;
            Console.WriteLine(coin.Details.ImagePath);

            Invalidate();
        }

        public void DisplayTime()
        {
            TimeLabel.Text = $"Time: {elapsedSeconds / 60:D2}:{elapsedSeconds % 60:D2}";
        }

        public void DisplayGameState(string state)
        {
            if (state == "Start")
            {
                gameState.Text = "Game Started";
            }
            else if (state == "Stop")
            {
                gameState.Text = "Game Stoped";
            }
        }

        private async void GameClient_FormClosing(object sender, FormClosingEventArgs e)
        {
            TimeLabel.Dispose();
            await webSocketComunication.SendAsyncClosing();
        }

        public void InitializeTank(string tankType, string tankColor, string playerId)
        {

            if (tankColor == "Red")
            {
                AbstractFactory RF = new RedFactory();
                if (tankType == "Pistol")
                {
                    CurrentTank = RF.createPistolTank(playerId, 600, 200);

                }
                if (tankType == "TommyGun")
                {
                    CurrentTank = RF.createTommyGunTank(playerId, 600, 200);
                }
                if (tankType == "Shotgun")
                {
                    CurrentTank = RF.createShotgunTank(playerId, 600, 200);
                }

            }
            else if (tankColor == "Blue")
            {
                AbstractFactory BF = new BlueFactory();
                if (tankType == "Pistol")
                {
                    CurrentTank = BF.createPistolTank(playerId, 100, 200);
                }
                if (tankType == "TommyGun")
                {
                    CurrentTank = BF.createTommyGunTank(playerId, 100, 200);
                }
                if (tankType == "Shotgun")
                {
                    CurrentTank = BF.createShotgunTank(playerId, 100, 200);
                }
            }

            Console.WriteLine(CurrentTank.getNameOfTank());
            allPlayers.Add(CurrentTank);
            if (controlType == "Mouse")
            {
                _controlAdapter = new MouseControlAdapter(CurrentTank);
            }
            else
            {
                _controlAdapter = new KeyboardControlAdapter(CurrentTank);
            }
            BeginGameLoop();
        }


        public void BeginGameLoop()
        {
            // Start the game loop (60 FPS -> 16ms interval)
            gameLoopTimer = new System.Timers.Timer(16);
            gameLoopTimer.Elapsed += OnGameLoop;
            gameLoopTimer.AutoReset = true;
            gameLoopTimer.Start();
        }


        private void OnKeyDown(object sender, KeyEventArgs e)
        {

            if (!CurrentTank.IsFrozen && this.controlType == "Keyboard")
            {
                if (e.KeyCode == Keys.Up) _controlAdapter.MoveUp();
                if (e.KeyCode == Keys.Down) _controlAdapter.MoveDown();
                if (e.KeyCode == Keys.Left) _controlAdapter.MoveLeft();
                if (e.KeyCode == Keys.Right) _controlAdapter.MoveRight();
            }

            // Shoot when spacebar is pressed
            if (e.KeyCode == Keys.Space && !spacebarPressed && !CurrentTank.IsBulletFrozen)
            {
                spacebarPressed = true;
                _controlAdapter.Shoot();
            }
        }


        private void OnKeyUp(object sender, KeyEventArgs e)
        {
            if (CurrentTank == null || _controlAdapter == null)
            {
                return; // Do nothing if CurrentTank or _controlAdapter is null
            }
            if (this.controlType == "Keyboard")
            {
                if (e.KeyCode == Keys.Up || e.KeyCode == Keys.Down) _controlAdapter.StopMovementY();
                if (e.KeyCode == Keys.Left || e.KeyCode == Keys.Right) _controlAdapter.StopMovementX();

                if (e.KeyCode == Keys.Space)
                {
                    _controlAdapter.StopShooting(); // Stop shooting when space is released
                    spacebarPressed = false;
                }
            }

        }


        private async void OnGameLoop(object sender, ElapsedEventArgs e)
        {

            if (isMousePressed)
            {
                // Calculate the direction based on mouse position and move the tank accordingly
                int dx = mousePosition.X - CurrentTank.x_coordinate;
                int dy = mousePosition.Y - CurrentTank.y_coordinate;

                if (Math.Abs(dx) > Math.Abs(dy))
                {
                    if (dx > 0) _controlAdapter.MoveRight();
                    else _controlAdapter.MoveLeft();
                }
                else
                {
                    if (dy > 0) _controlAdapter.MoveDown();
                    else _controlAdapter.MoveUp();
                }
            }

            await this.Move();

            await this.Shoot();

            if (IsCollidingWithCoin(CurrentTank, coin))
            {
                Coin clonedCoin = coin.ShallowCopy();
                coin = clonedCoin;
            }
        }
        private void OnMouseDownHandler(object sender, MouseEventArgs e)
        {

            if (e.Button == MouseButtons.Left && controlType == "Mouse")
            {
                isMousePressed = true;
                mousePosition = e.Location;
                _controlAdapter.Shoot();  // Shoot when mouse button is pressed
            }
        }

        private void OnMouseUpHandler(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                isMousePressed = false;
            }
        }
        //protected override void OnMouseMove(MouseEventArgs e)
        //{
        //    base.OnMouseMove(e);

        //    // Update the current mouse position
        //    mousePosition = e.Location;

        //    // Calculate the angle from the tank's position to the mouse position
        //    if (CurrentTank != null)
        //    {
        //        float dx = mousePosition.X - CurrentTank.x_coordinate;
        //        float dy = mousePosition.Y - CurrentTank.y_coordinate;
        //        float angle = (float)(Math.Atan2(dy, dx) * (180 / Math.PI)); // Angle in degrees

        //        // If your tank has a turret rotation property, set it here
        //        CurrentTank.TurretAngle = angle;
        //    }

        //    Invalidate(); // Refresh to show turret rotation
        //}

        private async Task Move()
        {
            CurrentTank.UpdatePosition(ClientSize.Width, ClientSize.Height);

            foreach (var obstacle in obstacles)
            {
                if (IsCollidingWithObstacle(CurrentTank, obstacle))
                {
                    if (!obstacle.HasBeenAffected)
                    {
                        obstacle.Strategy.ApplyStrategy(CurrentTank);
                        obstacle.HasBeenAffected = true;
                    }
                }
                else
                {
                    if (obstacle.HasBeenAffected)
                    {
                        obstacle.HasBeenAffected = false;
                    }
                }
            }

            if (CurrentTank.x_coordinate != lastSentPosition.x || CurrentTank.y_coordinate != lastSentPosition.y)
            {
                lastSentPosition = (CurrentTank.x_coordinate, CurrentTank.y_coordinate);
                await webSocketComunication.SendTankInformation(CurrentTank);
            }
        }


        public bool IsCollidingWithObstacle(Tank tank, Obstacle obstacle)
        {
            Rectangle tankRect = new Rectangle(tank.x_coordinate, tank.y_coordinate, 50, 50);
            Rectangle obstacleRect = new Rectangle(obstacle.x_coordinate, obstacle.y_coordinate, 50, 50);
            return tankRect.IntersectsWith(obstacleRect);
        }

        public bool IsCollidingWithCoin(Tank tank, Coin coin)
        {
            Rectangle tankRect = new Rectangle(tank.x_coordinate, tank.y_coordinate, 50, 50);
            Rectangle coinRect = new Rectangle(coin.X, coin.Y, 10, 10);
            return tankRect.IntersectsWith(coinRect);
        }


        private async Task Shoot()
        {
            bool isBullet = false;
            // Shooting

            for (int i = CurrentTank.bullets.Count - 1; i >= 0; i--)
            {

                isBullet = true;
                var bullet = CurrentTank.bullets[i];

                bullet.Move();
                // Remove bullet if it's out of bounds
                if (bullet.X > ClientSize.Width || bullet.X < 0 || bullet.Y > ClientSize.Height || bullet.Y < 0)
                {
                    CurrentTank.bullets.RemoveAt(i);
                }

            }
            if (isBullet)
            {
                await webSocketComunication.SendTankInformation(CurrentTank);
            }

        }


        public void UpdatePlayerPosition(Tank receivedTank)
        {
            // Find existing player tank
            var existingPlayer = allPlayers.FirstOrDefault(t => t.playerId == receivedTank.playerId);

            if (existingPlayer != null)
            {
                // Update properties of the existing player tank
                existingPlayer.x_coordinate = receivedTank.x_coordinate; // Assuming Tank has a Position property
                existingPlayer.y_coordinate = receivedTank.y_coordinate; // If your Tank class has a Rotation property

                // Optionally, update bullets if necessary
                existingPlayer.bullets.Clear(); // Clear existing bullets
                existingPlayer.bullets.AddRange(receivedTank.bullets);

            }
            else
            {
                // Add new player tank
                allPlayers.Add(receivedTank);
            }

            Invalidate(); // Refresh the UI
        }


        public void RemovePlayer(string receivedTankId)
        {
            allPlayers.RemoveAll(t => t.playerId == receivedTankId);

            Invalidate(); // Refresh the UI
        }


        public void UpgradePlayer(int upgradeValue, string upgradeType)
        {
            if (upgradeType == "Movement")
            {
                CurrentTank.UpdateMovement(upgradeValue);
            }
            else if (upgradeType == "Shooting")
            {
                CurrentTank.UpdateShooting(upgradeValue);
            }
            else if (upgradeType == "Health")
            {
                CurrentTank.UpdateHealth(upgradeValue);
            }
            else if (upgradeType == "Shield")
            {
                CurrentTank.UpdateShield(upgradeValue);
            }
        }

        private void OnTemporaryEffectTimerElapsed(object sender, ElapsedEventArgs e)
        {
            ApplyRandomStrategiesToObstacles();
            Invalidate();
            Task.Delay(5000).ContinueWith(_ =>
            {
                RevertObstacleStrategies();
                Invalidate();
                temporaryEffectTimer.Stop();
                temporaryEffectTimer.Start();
            });
        }
        private void RevertObstacleStrategies()
        {
            foreach (var obstacle in obstacles)
            {
                var originalState = originalObstacleStates[obstacle];
                obstacle.Strategy = originalState.OriginalStrategy;
                obstacle.SetTempColor(originalState.OriginalColor);
            }
        }
        private void ApplyRandomStrategiesToObstacles()
        {
            Random random = new Random();
            foreach (var obstacle in obstacles)
            {
                int randomIndex = random.Next(randomStrategies.Count);
                obstacle.Strategy = randomStrategies[randomIndex];
                obstacle.SetTempColor(Color.Magenta);
            }
        }
        private Color GetObstacleColor(Obstacle obstacle)
        {
            if (obstacle is Mist)
            {
                obstacle.SetOriginalColor(Color.LightGray);
                obstacle.SetTempColor(Color.LightGray);
                return Color.LightGray;
            }

            if (obstacle is Mud)
            {
                obstacle.SetOriginalColor(Color.SaddleBrown);
                obstacle.SetTempColor(Color.SaddleBrown);
                return Color.SaddleBrown;
            }

            if (obstacle is Ice)
            {
                obstacle.SetOriginalColor(Color.LightSteelBlue);
                obstacle.SetTempColor(Color.LightSteelBlue);
                return Color.LightSteelBlue;
            }

            if (obstacle is Snow)
            {
                obstacle.SetOriginalColor(Color.LightBlue);
                obstacle.SetTempColor(Color.LightBlue);
                return Color.LightBlue;
            }
            obstacle.SetOriginalColor(Color.Black);
            obstacle.SetTempColor(Color.Black);
            return Color.Black;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            // Adding obstacles to the game
            foreach (var obstacle in obstacles)
            {
                e.Graphics.FillRectangle(new SolidBrush(obstacle.GetTempColor()), obstacle.x_coordinate, obstacle.y_coordinate, 50, 50);
            }

            //COMMENT THIS
            e.Graphics.DrawImage(coin.Details.image, coin.X, coin.Y, 10, 10);

            foreach (var player in allPlayers.ToList())
            {
                e.Graphics.FillRectangle(new SolidBrush(player.Color), player.x_coordinate, player.y_coordinate, 50, 50);
                Console.WriteLine($"Player at ({player.x_coordinate}, {player.y_coordinate}), Color: {player.Color}");
                foreach (var bullet in player.bullets.ToList())
                {
                    e.Graphics.FillRectangle(new SolidBrush(player.Color), bullet.X, bullet.Y, bullet.Width, bullet.Height);
                }
            }
        }


        private void PrintTankType(string tankType)
        {

            if (tankType == "Pistol")
            {

                Console.WriteLine("Pistol tank created.");
            }
            else if (tankType == "TommyGun")
            {

                Console.WriteLine("TommyGun tank created.");
            }
        }

        private void GameClientFacade_Load(object sender, EventArgs e)
        {

        }
    }
}
