using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

class FlameThrower : Unit
{
    public FlameThrower(string assetName = "selectedTile", string id = "flameThrower") : base(assetName, id)
    {
        Faction = Player.Faction.humanity;
        name = "FLAMETHROWER";
    }
}
