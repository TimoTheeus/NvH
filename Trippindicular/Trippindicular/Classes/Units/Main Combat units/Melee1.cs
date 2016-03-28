using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

//strong vs melee2 and ranged
class Melee1 : Unit
{
    public Melee1(Player.Faction faction, string assetName = "", string id = "") : base(assetName, id)
    {
        this.faction = faction;
        if (this.faction == Player.Faction.nature)
        {
            Damage = 30;
            maxHealth = 200;
            health = maxHealth;
            resourceCosts = new Point(30, 0);
        }
        else {
            Damage = 15;
            maxHealth = 120;
            health = maxHealth;
            resourceCosts = new Point(10, 0);
        }
    }
}

