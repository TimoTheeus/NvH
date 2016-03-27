using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

class WoodCutter : Unit
{
    public WoodCutter() : base("selectedTile", "WoodCutter")
    {

    }

    public override void Attack()
    {
        Player player = (Player)GameData.LevelObjects.Find("player");
        if(targetBuilding != null && player.GetFaction == Player.Faction.humanity)
        {
            player.MainResource += 20;
        }
        base.Attack();
    }
}
