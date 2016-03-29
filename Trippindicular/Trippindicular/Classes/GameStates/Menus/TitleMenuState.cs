using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Net;
using Microsoft.Xna.Framework.GamerServices;

//Main menu, access to all sub-menus
class TitleMenuState : GameObjectList
{
    protected Button newGame,humanityGame, options, exitGame, sessions;
    protected SpriteGameObject background;
    protected PlayingState playingState;
    PacketReader packetReader = new PacketReader();
    PacketWriter packetWriter = new PacketWriter();
    protected Button createGame;

    public TitleMenuState()
    {
        GameData.Host = true;
        //Initialize playingState
        playingState = GameWorld.GameStateManager.GetGameState("playing") as PlayingState;

        //Background
        background = new SpriteGameObject("menuBackground");
        this.Add(background);

        //Make buttons
                //New Game
                newGame = new Button("button", "buttonFont", "font", 0, "Nature", 0);
                newGame.Position = new Vector2(300, 150);
                this.Add(newGame);
                //New Game
                humanityGame = new Button("button", "buttonFont", "font", 0, "Humanity", 0);
                humanityGame.Position = new Vector2(700, 150);
                this.Add(humanityGame);



                //Options
                options = new Button("button", "buttonFont", "font", 0, "Options", 0);
                options.Position = new Vector2(300, 280);
                this.Add(options);

                //Options
                sessions = new Button("button", "buttonFont", "font", 0, "Sessions", 0);
                sessions.Position = new Vector2(300, 410);
                this.Add(sessions);

                //Exit Game
                exitGame = new Button("button", "buttonFont", "font", 0, "Exit Game", 0);
                exitGame.Position = new Vector2(300, 540);
                this.Add(exitGame);

                createGame = new Button("button", "buttonFont", "font", 0, "Create Game", 0);
                createGame.Position = new Vector2(300, 670);
                this.Add(createGame);
    }

    public override void Reset()
    {
        base.Reset();
    }

    public override void HandleInput(InputHelper inputHelper)
    {
        //base
        base.HandleInput(inputHelper);

        if (inputHelper.KeyPressed(Keys.Home))
        {
            GameData.Host = false;
        }
        //Buttons
        if (newGame.Pressed)
        {
            GameData.player = new Player(Player.Faction.nature);
            playingState.Initialize(GameData.Host);
            GameWorld.GameStateManager.SwitchTo("hud");
        }
        else if (humanityGame.Pressed)
        {
            GameData.player = new Player(Player.Faction.humanity);
            playingState.Initialize(GameData.Host);
            GameWorld.GameStateManager.SwitchTo("hud");
        }
        else if (options.Pressed)
        {
            GameWorld.GameStateManager.GetGameState("settingsMenuTitle").Reset();
            GameWorld.GameStateManager.SwitchTo("settingsMenuTitle");
        }
        else if (exitGame.Pressed)
        {
            GameWorld.Exited = true;
        }
        else if (sessions.Pressed)
        {
            GameWorld.GameStateManager.SwitchTo("sessionsMenu");
        }
        else if (createGame.Pressed)
        {
            GameWorld.GameStateManager.SwitchTo("hostLobby");
        }
    }
}
