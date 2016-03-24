using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

class NatureBase : Building
{
    public NatureBase() : base("natureBase", "selectedTile")
    {
        this.health = 100;
    }
    public override void HandleInput(InputHelper ih)
    {
        base.HandleInput(ih);
        if (ih.KeyPressed(Keys.K)){
            DealDamage(50);
        }
    }
    public override void Destroy()
    {
        base.Destroy();
        GameWorld.GameStateManager.SwitchTo("finish");
    }
    
}

