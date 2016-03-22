using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

//This is the main class, the game gets started from here.
class MainGame : GameWorld
{

    static void Main()
    {
        MainGame game = new MainGame();
        
        game.Run();
    }

    public MainGame()
    {
        Log.Initialize();
        Content.RootDirectory = "Content";
        this.IsMouseVisible = true;

        Log.Write(LogType.INFO, "Build Directory: " + Testing.AssemblyDirectory);
        Console.WriteLine("Build Directory: " + Testing.AssemblyDirectory);
    }

    protected override void LoadContent()
    {
        base.LoadContent();

        gameStateManager.AddGameState("playing", new PlayingState());
        gameStateManager.AddGameState("hud", new HUD());
        gameStateManager.AddGameState("titleMenu", new TitleMenuState());


        gameStateManager.AddGameState("settingsMenuTitle", new SettingsMenuOverlay(gameStateManager.GetGameState("titleMenu")));
        gameStateManager.AddGameState("settingsMenuPause", new SettingsMenuOverlay(gameStateManager.GetGameState("pauseMenu")));
        gameStateManager.AddGameState("finish", new FinishState());

        gameStateManager.SwitchTo("titleMenu");
    }
}

