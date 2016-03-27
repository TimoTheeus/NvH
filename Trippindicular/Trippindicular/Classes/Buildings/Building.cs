using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Graphics;

class Building : Tile
{
    protected float health, maxHealth;
    protected HealthBar healthBar;
    protected Player.Faction faction;

    public Player.Faction Faction
    {
        get { return faction; }
        set { faction = value; }
    }

    public float Health
    {
        get { return health; }
        set { health = value; }
    }

    public float MaxHealth
    {
        get { return maxHealth; }
        set { maxHealth = value; }
    }
    public Building(string id = "", string assetName=""):base(assetName,id)
    {
        RemoveMenu();
        health = 1;
        maxHealth = 1;
        healthBar = new HealthBar(new Vector2(position.X, position.Y + sprite.Height / 2 + 10));
    }

    protected void RemoveMenu()
    {
        TileMenu menu = GameData.LevelObjects.Find("menu") as TileMenu;
        if (menu != null)
            GameData.LevelObjects.Remove(menu);
    }
    public virtual void DealDamage(float amount, GameObject attacker)
    {
        this.Health -= amount;
        if (this.Health <= 0)
        {
            TextGameObject text = new TextGameObject("smallFont", 10);
            text.Text = id + " was destroyed by " + attacker.ID;
            ((GameWorld.GameStateManager.GetGameState("hud") as HUD).hud.Find("eventLog") as EventLog).Add(text);
            Destroy();
        }
    }

    public virtual void Destroy()
    {
        GameData.LevelGrid.replaceTile(this, new Tile());
    }

    public virtual void HasBeenBuiltAction()
    {

    }

    public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
    {
        healthBar.Update(new Vector2(position.X, position.Y - sprite.Height / 2 - 10));
        healthBar.ChangeHealth((float)((health / maxHealth) * 1.5));
        healthBar.Draw(gameTime, spriteBatch);
        position -= new Vector2(0, sprite.Height / 2 - new Tile().Sprite.Height / 2);
        base.Draw(gameTime, spriteBatch);
        position += new Vector2(0, sprite.Height / 2 - new Tile().Sprite.Height / 2);
    }

}
