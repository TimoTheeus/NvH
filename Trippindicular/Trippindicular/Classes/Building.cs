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
    }
    public override void LeftButtonAction()
    {
        base.LeftButtonAction();
    }

}
