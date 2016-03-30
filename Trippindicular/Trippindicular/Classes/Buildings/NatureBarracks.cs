using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

class NatureBarracks:Building
{
    public NatureBarracks() : base("natureBarrack", "selectedTile")
    {
        Faction = Player.Faction.nature;
        name = "NATURE BARRACKS";
        level = 1;
        maxLevel = 3;
    }

    public override void LeftButtonAction()
    {
        GameData.LevelObjects.Add(new BarracksMenu(this));
        GameData.Cursor.HasClickedTile = false;
    }
}

