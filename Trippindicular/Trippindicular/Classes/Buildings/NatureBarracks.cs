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
    }
}

