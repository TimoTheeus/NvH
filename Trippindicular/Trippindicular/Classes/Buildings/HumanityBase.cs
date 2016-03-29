﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

class HumanityBase : PolyTileBuilding
{

    public HumanityBase() : base("humanityBase", "humanityBase")
    {
        this.health = 1;
        Faction = Player.Faction.humanity;
        name = "HUMAN BASE";
    }

    public override void Destroy()
    {
        base.Destroy();
        GameWorld.GameStateManager.SwitchTo("finish");
    }
}

