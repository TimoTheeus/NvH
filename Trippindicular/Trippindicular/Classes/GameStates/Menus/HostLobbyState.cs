using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Net;
using Lidgren.Network;
using Lidgren.Network.Xna;
using System;

namespace Trippindicular.Classes
{
    class HostLobbyState : GameObjectList
    {

        protected Button createSession, joinSession, options, exitGame, sessions;
        protected SpriteGameObject background;
        protected PlayingState playingState;
        private  INetworkManager networkManager;
        private bool connected = false;
        public INetworkManager NetworkManager
        {
            get { return this.networkManager; }
            set { this.networkManager = value; }
        }

        public HostLobbyState()
        {
            //Initialize playingState
            playingState = GameWorld.GameStateManager.GetGameState("playing") as PlayingState;

            //Background
            background = new SpriteGameObject("menuBackground");
            this.Add(background);

            //Make buttons
            //New Game
            createSession = new Button("button", "buttonFont", "font", 0, "Create session", 0);
            createSession.Position = new Vector2(300, 150);
            this.Add(createSession);

            joinSession = new Button("button", "buttonFont", "font", 0, "Join session", 0);
            joinSession.Position = new Vector2(300, 280);
            this.Add(joinSession);


            //Options
            exitGame = new Button("button", "buttonFont", "font", 0, "Exit", 0);
            exitGame.Position = new Vector2(300, 410);
            this.Add(exitGame);

            
        }


        public override void Reset()
        {
            base.Reset();
        }

        public override void HandleInput(InputHelper inputHelper)
        {
            //base
            base.HandleInput(inputHelper);

            //Buttons
            if (createSession.Pressed)
            {
                if (!connected)
                {
                    this.networkManager = new ServerNetworkManager();
                    this.networkManager.Connect();
                    connected = true;
                }
            }
            else if (joinSession.Pressed)
            {
                this.networkManager = new ClientNetworkManager();
                this.networkManager.Connect();
                connected = true;
                this.networkManager.SendMessage("test");

            }
            else if (exitGame.Pressed)
            {
                GameWorld.GameStateManager.SwitchTo("titleMenu");
            }

        }

        private void ProcessNetworkMessages()
        {
            NetIncomingMessage im;

            while ((im = this.networkManager.ReadMessage()) != null)
            {
                switch (im.MessageType)
                {
                    case NetIncomingMessageType.VerboseDebugMessage:
                    case NetIncomingMessageType.DebugMessage:
                    case NetIncomingMessageType.WarningMessage:
                    case NetIncomingMessageType.ErrorMessage:
                        Console.WriteLine(im.ReadString());
                        break;
                    case NetIncomingMessageType.StatusChanged:
                        switch ((NetConnectionStatus)im.ReadByte())
                        {
                            case NetConnectionStatus.Connected:
                                if (!this.IsHost)
                                {
                                    Console.WriteLine("Connected to host");
                                }
                                else
                                {
                                    Console.WriteLine("Connected to client");
                                }

                                break;
                            case NetConnectionStatus.Disconnected:
                                Console.WriteLine(
                                    this.IsHost ? "Disconnected" : "Disconnected from {0}", im.SenderEndpoint);
                                break;
                        }
                        Console.WriteLine(im.ReadString());

                        break;
                    case NetIncomingMessageType.Data:
                        Console.WriteLine(im.ReadString());

                        break;
                }

                this.networkManager.Recycle(im);
            }
        }

        public override void Update(GameTime gameTime)
        {
            if (connected)
            {
                ProcessNetworkMessages();
            }
            base.Update(gameTime);
        }
        private bool isHost = false;
        public bool IsHost { get { return isHost; } set{isHost = value;} }
    }
}

