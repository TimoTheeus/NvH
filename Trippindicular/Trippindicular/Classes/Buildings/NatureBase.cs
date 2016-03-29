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
        this.health = 1;
        Faction = Player.Faction.nature;
        name = "NATURE BASE";
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

