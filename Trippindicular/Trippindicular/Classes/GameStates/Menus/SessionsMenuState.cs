using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Net;
using System;

namespace Trippindicular.Classes
{
    class SessionsMenuState : GameObjectList
    {

        protected Button createSession, options, exitGame, sessions;
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
            createSession = new Button("button", "buttonFont", "font", 0, "Create session", 0);
            createSession.Position = new Vector2(300, 150);
            this.Add(createSession);

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
            if (createSession.Pressed)
            {
                //GameWorld.CreateSession();
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
