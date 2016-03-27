using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

class HumanityBase : PolyTileBuilding
{

    public HumanityBase() : base("humanityBase", "selectedTile")
    {
        this.health = 100;
    }

    public override void Destroy()
    {
        base.Destroy();
        GameWorld.GameStateManager.SwitchTo("finish");
    }
}

