﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;


class HumanityBarrack : PolyTileBuilding
{

    public HumanityBarrack() : base("humanityBarrack","humanityBarracks")
    {
        this.maxHealth = 100;
        this.health = 100;
    }

    public override void LeftButtonAction()
    {
        GameData.LevelObjects.Add(new BarracksMenu(this));
        GameData.Cursor.HasClickedTile = false;
    }
}

