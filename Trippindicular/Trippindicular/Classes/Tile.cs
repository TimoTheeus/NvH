using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework;

class Tile : SpriteGameObject
{
    public Point gridPosition;

    public Tile(string assetName="hexagonTile", string id="tile") : base(assetName, 0, id, 1)
    {
        this.Origin = this.sprite.Center;
    }

    public override void HandleInput(InputHelper ih)
    {
        if (GameData.Cursor.CurrentTile == this && ih.LeftButtonPressed() && GameData.Cursor.HasClickedTile)
        {
            LeftButtonAction();
        }
    }

    public virtual void LeftButtonAction()
    {
        GameData.LevelObjects.Add(new TileMenu(this));
    }

    public virtual void Destroy()
    {
    }

}

