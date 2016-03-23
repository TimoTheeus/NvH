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
    public override void HandleInput(InputHelper ih)
    {
        if (GameData.Cursor.CurrentTile == this&&ih.LeftButtonPressed())
        {
            LeftButtonAction();
           
        }
    }
    
    public virtual void LeftButtonAction()
    {
        //Create this building's menu
    }

}
