using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;

//Class used to update and draw everything that is needed when the player is playing the game.
class PlayingState : IGameLoopObject
{


    public PlayingState()
    {
  
    }
    public void Initialize()
    {
        GameData.Initialize();
        GameData.AfterInitialize();
    }

    public void Update(GameTime gameTime)
    {
        GameData.Update(gameTime);
    }


    public void HandleInput(InputHelper ih)
    {

        GameData.LevelObjects.HandleInput(ih);
        if (ih.KeyPressed(Keys.F5))
            GameSettings.SetFullscreen(!GameSettings.Fullscreen);
        List<string> ls = GameData.LevelObjects.getActionOutputs();
        foreach (string s in ls) {
            Console.WriteLine(s);
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

