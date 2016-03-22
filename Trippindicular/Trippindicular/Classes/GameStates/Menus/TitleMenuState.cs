using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

//Main menu, access to all sub-menus
class TitleMenuState : GameObjectList
{
    protected Button newGame, options, exitGame;
    protected SpriteGameObject background;
    protected PlayingState playingState;

    public TitleMenuState()
    {
        //Initialize playingState
        playingState = GameWorld.GameStateManager.GetGameState("playing") as PlayingState;

        //Background
        background = new SpriteGameObject("menuBackground");
        this.Add(background);

        //Make buttons
                //New Game
                newGame = new Button("button", "buttonFont", "font", 0, "New Game", 0);
                newGame.Position = new Vector2(300, 150);
                this.Add(newGame);

                //Options
                options = new Button("button", "buttonFont", "font", 0, "Options", 0);
                options.Position = new Vector2(300, 410);
                this.Add(options);

                //Exit Game
                exitGame = new Button("button", "buttonFont", "font", 0, "Exit Game", 0);
                exitGame.Position = new Vector2(300, 930);
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
        if (newGame.Pressed)
        {
            playingState.Initialize();
            GameWorld.GameStateManager.SwitchTo("hud");
        }
        else if (options.Pressed)
        {
            GameWorld.GameStateManager.GetGameState("settingsMenuTitle").Reset();
            GameWorld.GameStateManager.SwitchTo("settingsMenuTitle");
        }
        else if (exitGame.Pressed)
            GameWorld.Exited = true;
    }
}
