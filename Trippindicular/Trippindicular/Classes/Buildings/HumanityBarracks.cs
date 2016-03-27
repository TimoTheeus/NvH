using System;
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

    public override void HandleInput(InputHelper ih)
    {
        if (GameData.Cursor.CurrentTile == this && ih.LeftButtonPressed() && GameData.Cursor.HasClickedTile)
        {
            LeftButtonAction();
        }
    }

    public override void LeftButtonAction()
    {
        GameData.LevelObjects.Add(new BarracksMenu(this));
    }
}

