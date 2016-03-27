﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;


class HumanityWorker : Unit
{

    public HumanityWorker(string assetName="") : base(assetName, "")
    {
        this.Damage = 0;
        Range = 0;
    }
    protected override string RightClickAction()
    {
        Point p = new Point((int)this.Position.X + 20, (int)this.Position.Y + 20);
        GameData.LevelGrid.GetTile(p).IsBeingBuilt = false;
        base.RightClickAction();
        return "unit:" + this.id + ":move:" + p.X + "," + p.Y;
    }
    protected override void ArrivedAtTileAction()
    {
        base.ArrivedAtTileAction();
        Point p = new Point((int)this.Position.X+20, (int)this.Position.Y+20);
        GameData.LevelGrid.GetTile(p).IsBeingBuilt = true;
    }

    public override string getActionOutput()
    {
        return RightClickAction();
    }
}
