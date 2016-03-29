using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Lidgren.Network;
using Trippindicular.Classes;
using System;
using System.Collections.Generic;


//Class used to update and draw everything that is needed when the player is playing the game.
class PlayingState : IGameLoopObject
{

    private INetworkManager networkManager;
    private bool connected = false;
    public INetworkManager NetworkManager
    {
        get { return this.networkManager; }
        set { this.networkManager = value; }
    }



    public PlayingState()
    {
  
    }
    public void Initialize(bool host)
    {
        if (host)
        {
            this.networkManager = new ServerNetworkManager();
            this.networkManager.Connect();
            connected = true;
        }
        else
        {
            this.networkManager = new ClientNetworkManager();
            this.networkManager.Connect();
            connected = true;
            this.networkManager.SendMessage("test");
        }
        GameData.Initialize();
        GameData.AfterInitialize();
    }

    public void Update(GameTime gameTime)
    {
        ProcessNetworkMessages();
        GameData.Update(gameTime);
    }


    public void HandleInput(InputHelper ih)
    {

        GameData.LevelObjects.HandleInput(ih);
        if (ih.KeyPressed(Keys.F5))
            GameSettings.SetFullscreen(!GameSettings.Fullscreen);
        string ls = GameData.LevelObjects.getActionOutput();
        if (ls.Length > 3 && connected)
        {
            this.networkManager.SendMessage(ls);
            Console.WriteLine(ls);
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
                                Console.WriteLine("Connected to host");
                     
                                break;
                            case NetConnectionStatus.Disconnected:
                                Console.WriteLine("Disconnected");
                                break;
                        }
                        Console.WriteLine(im.ReadString());

            
                        break;
                    case NetIncomingMessageType.Data:
                        UpdateGameData(im.ReadString());
                        //
                        break;
                }

                this.networkManager.Recycle(im);
            }
        }

    private void UpdateGameData(string p)
    {
        string[] actions = p.Split(';');
        foreach (string s in actions)
        {
            if (s.Length > 3)
            {
                parseAction(s);
            }
        }
    }

    private void parseAction(string s)
    {
        string[] pairs = s.Split('$');
        if (pairs.Length > 1){
        string sig = pairs[1].Substring(0,4);
        if (sig.Equals("unit")) {
            string id = pairs[1].Substring(5,pairs[1].Length - 5);
            for (int i = 2; i < pairs.Length; i++)
            {
                 switch (pairs[i].Substring(0, 4))
                {
                    case "move":
                        try
                        {
                            string[] coords = pairs[i].Substring(5, pairs[i].Length - 5).Split(',');
                            Unit u = ((Unit)(GameData.LevelObjects.Find(id)));
                            u.TargetPosition = new Vector2(int.Parse(coords[0]), int.Parse(coords[1]));
                            u.TargetUnit = null;
                        }
                        catch (NullReferenceException e)
                        {
                            Console.WriteLine("null");
                        }
                        break;
       
                    case "targ":
                        string targID = pairs[i].Substring(5, pairs[i].Length - 5);
                        ((Unit)(GameData.LevelObjects.Find(id))).TargetUnit = (Unit) GameData.LevelObjects.Find(targID);
                        break;
                    case "buil":
                        //build
                        break;
                    case "damg":
                        try
                        {
                            string[] parameters = pairs[i].Substring(5, pairs[i].Length - 5).Split(',');
                            string attackerID = parameters[1];
                            Unit attacker = (Unit)(GameData.LevelObjects.Find(attackerID));
                            ((Unit)(GameData.LevelObjects.Find(id))).DealDamage(int.Parse(parameters[0]), attacker);
                            Console.WriteLine(s);
                            
                        }
                        catch (NullReferenceException e)
                        {
                            Console.WriteLine(e.ToString());
                        }
                        break;
                     case "dead":
                        try
                        {
                            GameData.Units.Remove(((Unit)(GameData.LevelObjects.Find(id))));
                        }
                        catch (NullReferenceException e) {
                            Console.WriteLine(e.ToString());

                        }
                        break;
                }
            }
        }
        }

    
    }

    public void Reset()
    {

    }

    public void Draw(GameTime gameTime, SpriteBatch spriteBatch)
    {
        GameData.DrawGame(gameTime, spriteBatch);
    }
}

