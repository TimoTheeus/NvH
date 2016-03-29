using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Net;
using System;

namespace Trippindicular.Classes
{
    class SessionsMenuState : GameObjectList
    {

        protected Button joinGame, options, exitGame, sessions;
        protected SpriteGameObject background;
        protected PlayingState playingState;


        public SessionsMenuState()
        {
            //Initialize playingState
            playingState = GameWorld.GameStateManager.GetGameState("playing") as PlayingState;

            //Background
            background = new SpriteGameObject("menuBackground");
            this.Add(background);

            //Make buttons
            //New Game
            joinGame = new Button("button", "buttonFont", "font", 0, "Join Game", 0);
            joinGame.Position = new Vector2(300, 150);
            this.Add(joinGame);

            //Options
            options = new Button("button", "buttonFont", "font", 0, "Options", 0);
            options.Position = new Vector2(300, 280);
            this.Add(options);

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
            if (joinGame.Pressed)
            {
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
                GameWorld.GameStateManager.SwitchTo("titleMenu");
            }

        }
    }
}
