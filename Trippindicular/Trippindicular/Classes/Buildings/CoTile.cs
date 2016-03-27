using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

class CoTile : Building
{
    public Building mainTile;

    public CoTile() : base("coTile", "selectedTile")
    {

    }

    public override void DealDamage(float amount)
    {
        mainTile.DealDamage(amount);
    }

    public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
    {
    }
}
