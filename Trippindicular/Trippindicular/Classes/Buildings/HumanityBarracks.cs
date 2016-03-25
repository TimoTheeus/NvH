using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;


class HumanityBarrack : Building
{
    public HumanityBarrack() : base("humanityBarrack","selectedTile")
    {
    }

    public override void HandleInput(InputHelper ih)
    {
        if (GameData.Cursor.CurrentTile == this && ih.LeftButtonPressed() && GameData.Cursor.HasClickedTile)
        {
            LeftButtonAction();
        }
    }

    public virtual void LeftButtonAction()
    {
        GameData.LevelObjects.Add(new BarracksMenu(this));
    }
}

