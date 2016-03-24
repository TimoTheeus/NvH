using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;


class Mine : Building
{
    ResourceController resController;
    public Mine() : base("mine","selectedTile")
    {
        resController = new ResourceController(1, 50, 0);
        GameData.LevelObjects.Add(resController);
    }
    public override void Destroy()
    {
        base.Destroy();
        GameData.LevelObjects.Remove(resController);
    }
}

