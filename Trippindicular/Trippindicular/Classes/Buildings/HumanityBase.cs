using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

class HumanityBase : PolyTileBuilding
{

    public HumanityBase() : base("humanityBase", "humanityBase")
    {
        this.health = 600;
        MaxHealth = health;
        Faction = Player.Faction.humanity;
        name = "HUMAN BASE";
        maxLevel = 2;
        if(GameData.player.GetFaction==Player.Faction.humanity)
        foreach (Tile t in GameData.LevelGrid.Objects)
        {
            Vector2 distance = new Vector2(Math.Abs(this.GlobalPosition.X - t.Position.X), Math.Abs(this.GlobalPosition.Y - t.Position.Y));
            double absDistance = Math.Sqrt(Math.Pow(distance.X, 2) + Math.Pow(distance.Y, 2));
            if (absDistance < 300)
            {
                t.PermaDiscovered = true;
                t.IsDark = false;
            }
        }
    }

    public override void Destroy()
    {
        base.Destroy();
        GameWorld.GameStateManager.SwitchTo("finish");
    }
    public override void LeftButtonAction()
    {
        GameData.LevelObjects.Add(new HumanityBaseMenu(this));
        GameData.Cursor.HasClickedTile = false;
    }
}

