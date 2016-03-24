using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

class Building:Tile
{

    public Building(string id = "", string assetName=""):base(assetName,id)
    {
        RemoveMenu();
    }
    public override void LeftButtonAction()
    {
        base.LeftButtonAction();
    }
    protected void RemoveMenu()
    {
        Menu menu = GameData.LevelObjects.Find("menu") as Menu;
        if (menu != null)
            GameData.LevelObjects.Remove(menu);
    }
}
