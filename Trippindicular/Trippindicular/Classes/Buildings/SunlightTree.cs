using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;


class SunlightTree:Building
{
    ResourceController resController;
    public SunlightTree() : base("sunlightTree","selectedTile")
    {
        
    }


    public override void Destroy()
    {
        base.Destroy();
        GameData.LevelObjects.Remove(resController);
    }
    public override void HasBeenBuiltAction()
    {
        resController = new ResourceController(1, 50, 0);
        GameData.LevelObjects.Add(resController);
    }
}

