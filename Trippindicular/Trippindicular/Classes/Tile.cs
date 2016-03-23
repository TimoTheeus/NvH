using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Input;

class Tile : SpriteGameObject
{
    public Tile(string assetName="hexagonTile", string id="tile") : base(assetName, 0, id, 5)
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
        GameData.LevelObjects.Add(new Menu(this));
    }

    public virtual void Destroy()
    {

    }

}

