using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

class ResourceController : GameObject
{
    Timer passiveResourceTimer;
    protected const int passiveResourceAmount = 1;
    public ResourceController() : base("resourceController")
    {
        passiveResourceTimer = new Timer(1);
    }
    public override void Update(GameTime gameTime)
    {
        passiveResourceTimer.Update(gameTime);
        checkPassiveTimer();
    }
    public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
    {

    }

    protected void checkPassiveTimer()
    {
        if (passiveResourceTimer.Ended)
        {
            for (int i = 0; i < GameData.LevelObjects.Objects.Count; i++)
            {
                if (GameData.LevelObjects.Objects[i] is Player)
                {
                    Player player = GameData.LevelObjects.Objects[i] as Player;
                    player.MainResource += passiveResourceAmount;
                }
            }
            passiveResourceTimer.Reset();
        }
    }
}

