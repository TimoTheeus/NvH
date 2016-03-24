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
    protected int wood;
    protected int coal;
    protected TextGameObject mainResource;
    protected TextGameObject secondaryResource;

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
            else return wood;
        }
        set
        {
            if (this.faction == Player.Faction.nature)
                sunlight = value;
            else wood = value;
        }
    }
    public int SecondaryResource
    {
        get
        {
            if (this.faction == Player.Faction.nature)
                return water;
            else return coal;
        }
        set
        {
            if (this.faction == Player.Faction.nature)
                water = value;
            else coal = value;
        }
    }

    public Player(Faction faction)
    {
        this.faction = faction;
        MainResource = 0;
        SecondaryResource = 0;
        mainResource = new TextGameObject("smallFont", 4, "mainResourceText");
        mainResource.Position = new Vector2(1500, 0);
        secondaryResource = new TextGameObject("smallFont", 4, "secondaryResourceText");
        secondaryResource.Position = new Vector2(1200, 0);
        HUD hud = GameWorld.GameStateManager.GetGameState("hud") as HUD;
        hud.hud.Add(mainResource);
        hud.hud.Add(secondaryResource);
    }
    public override void Update(GameTime gameTime)
    {
        mainResource.Text = this.MainResource.ToString();
        secondaryResource.Text = this.SecondaryResource.ToString();
    }
    public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
    {
    }
}
