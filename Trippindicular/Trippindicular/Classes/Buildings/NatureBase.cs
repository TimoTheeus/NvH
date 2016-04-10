using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

class NatureBase : PolyTileBuilding
{
    public NatureBase() : base("natureBase", "natureBase")
    {
        this.health = 600;
        MaxHealth = health;
        Faction = Player.Faction.nature;
        name = "NATURE BASE";
        level = 1;
        maxLevel = 3;
        if (GameData.player.GetFaction == Player.Faction.nature)
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
        GameData.LevelObjects.Add(new NatureBaseMenu(this));
        GameData.Cursor.HasClickedTile = false;
    }
    
}

