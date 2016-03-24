using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


class SunlightTree:Building
{
    ResourceController resController;
    public SunlightTree() : base("sunlightTree","selectedTile")
    {
        resController = new ResourceController(1, 50, 0);
        GameData.LevelObjects.Add(resController);
    }


    public override void LeftButtonAction()
    {
        GameData.LevelObjects.Add(new Menu(this));
    }

    public override void Destroy()
    {
        GameData.LevelObjects.Remove(resController);
    }

}

