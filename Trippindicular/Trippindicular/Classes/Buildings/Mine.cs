using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;


class Mine : Building
{
    ResourceController resController;
    public Mine() : base("mine","selectedTile")
    {
        Faction = Player.Faction.humanity;
    }

    public override void HandleInput(InputHelper ih)
    {
        if (GameData.Cursor.CurrentTile == this && ih.LeftButtonPressed() && GameData.Cursor.HasClickedTile)
        {
            GameData.Cursor.HasClickedTile = false;
        }
    }

    public override void Destroy()
    {
        base.Destroy();
        GameData.LevelObjects.Remove(resController);
    }
    public override void HasBeenBuiltAction()
    {
        resController = new ResourceController(1, 0, 50);
        GameData.LevelObjects.Add(resController);
    }
}

