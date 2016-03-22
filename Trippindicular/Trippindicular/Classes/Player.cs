using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

class Player : GameObject
{
    protected Faction faction;
    protected int sunlight;
    protected int water;
    protected int humaninityMainResource;
    protected int humaninitySecondResource;

    public Faction GetFaction
    {
        get { return faction; }
    }
    public enum Faction
    {
        nature,
        humanity
    }

    public int MainResource
    {
        get
        {
            if (this.faction == Player.Faction.nature)
                return sunlight;
            else return humaninityMainResource;
        }
        set
        {
            if (this.faction == Player.Faction.nature)
                sunlight = value;
            else humaninityMainResource = value;
        }
    }
    public int SecondaryResource
    {
        get
        {
            if (this.faction == Player.Faction.nature)
                return water;
            else return humaninitySecondResource;
        }
        set
        {
            if (this.faction == Player.Faction.nature)
                water = value;
            else humaninitySecondResource = value;
        }
    }

    public Player(Faction faction)
    {
        this.faction = faction;
    }
}
