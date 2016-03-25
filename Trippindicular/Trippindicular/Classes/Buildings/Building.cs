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
    public override void LeftButtonAction()
    {
        base.LeftButtonAction();
    }
    protected void RemoveMenu()
    {
        TileMenu menu = GameData.LevelObjects.Find("menu") as TileMenu;
        if (menu != null)
            GameData.LevelObjects.Remove(menu);
    }
    public void DealDamage(float amount)
    {
        this.Health -= amount;
        if (this.Health <= 0)
        {
            GameData.LevelGrid.replaceTile(this, new Tile());
        }
    }

    public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
    {
        healthBar.Update(new Vector2(position.X, position.Y - sprite.Height / 2 - 10));
        healthBar.ChangeHealth((float)((health / maxHealth) * 1.5));
        healthBar.Draw(gameTime, spriteBatch);
        base.Draw(gameTime, spriteBatch);
    }

}
