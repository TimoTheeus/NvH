using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

class Building:Tile
{
    protected float health;

    public float Health
    {
        get { return health; }
        set { health = value; }
    }
    public Building(string id = "", string assetName=""):base(assetName,id)
    {
        RemoveMenu();
        health = 1;
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
    protected void DealDamage(float amount)
    {
        this.Health -= amount;
        if (this.Health <= 0)
        {
            Destroy();
        }
    }

}
