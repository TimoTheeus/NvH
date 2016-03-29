using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using System.Text;

//strong vs fast melee
class Melee2 : Unit
{
    public Melee2(Player.Faction faction, string assetName = "", string id = "") : base(assetName, id)
    {
        this.faction = faction;
        if (this.faction == Player.Faction.nature)
        {
            Damage = 25;
            maxHealth = 200;
            health = maxHealth;
        }
        else {
            Damage = 25;
            maxHealth = 200;
            health = maxHealth;
        }
    }
    public override void Attack()
    {
        if (targetUnit != null)
        {
            if (targetUnit.Health <= 0)
            {
                targetUnit = null;
                return;
            }
            if (targetUnit is Unicorn)
            {
                targetUnit.DealDamage(this.Damage*2, this);
            }
            else
            { targetUnit.DealDamage(this.Damage, this); }
        }

        else
        {
            if (targetBuilding.Health <= 0)
            {
                targetBuilding = null;
                return;
            }
            targetBuilding.DealDamage(this.Damage, this);
        }

        attackTimer.Reset();
    }
}

