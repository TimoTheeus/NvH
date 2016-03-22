using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Input;

class Tile : SpriteGameObject
{
    public Tile(string assetName="hexagonTile", string id="tile") : base(assetName, 0, id, 5)
    {
         //this.Origin = this.sprite.Center;
    }

   
   public void SetMenu(TileMenu menu)
    {
        menu.Add(new TileMenuItem());
        menu.Add(new TileMenuItem());
        menu.Add(new TileMenuItem());
        menu.Add(new TileMenuItem());
        menu.Add(new TileMenuItem());
    } 
}

