using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

class Cursor : SpriteGameObject
{
    protected bool hasClickedTile;
    protected Tile currentTile;
    protected Tile tileForOrigin;
    protected const int borderWidth = 100;

    public bool HasClickedTile
    {
        get { return hasClickedTile; }
        set { hasClickedTile = value; }
    }
    public Tile CurrentTile
    {
        get { return currentTile; }
        set { currentTile = value; }
    }
    public Cursor() : base("cursorDot", 0, "cursor", 10)
    {
        hasClickedTile = false;
        tileForOrigin = new Tile();
    }
    public override void HandleInput(InputHelper inputHelper)
    {
        base.HandleInput(inputHelper);
        this.Position = inputHelper.MousePosition+GameWorld.Camera.Pos;
        Point position = new Point((int)(inputHelper.MousePosition.X + tileForOrigin.Sprite.Center.X+GameWorld.Camera.Pos.X), 
            (int)(inputHelper.MousePosition.Y + tileForOrigin.Sprite.Center.Y + GameWorld.Camera.Pos.Y));

        if (!hasClickedTile)
        {
            currentTile = GameData.LevelGrid.GetTile(position);
            if (currentTile != null)
                GameData.selectedTile.Position = currentTile.Position;
        }
        //Create popup and stop hovering tiles 
        if (inputHelper.LeftButtonPressed() && currentTile != null && !hasClickedTile)
        {
            hasClickedTile = true;
        }
        //If player clicks again while there is a menu popup and the mouse is not in the boundingbox of the menu, hasClickedTile = false and the menu should
        //disappear.   DOESNT WORK YET, GOTTA HAVE MENU FIRST TO TEST BETTER.
        else if (inputHelper.LeftButtonPressed() && hasClickedTile)
        {
            hasClickedTile = false;
        }
        if (inputHelper.IsKeyDown(Keys.Right)||this.Position.X>GameWorld.Screen.X-borderWidth + GameWorld.Camera.Pos.X)
        {
            GameWorld.Camera.Move(new Vector2(10, 0));

        }
        if (inputHelper.IsKeyDown(Keys.Left) || this.Position.X < borderWidth + GameWorld.Camera.Pos.X)
        {
            GameWorld.Camera.Move(new Vector2(-10, 0));

        }
        if (inputHelper.IsKeyDown(Keys.Up) || this.Position.Y < borderWidth + GameWorld.Camera.Pos.Y)
        {
            GameWorld.Camera.Move(new Vector2(0, -10));

        }
        if (inputHelper.IsKeyDown(Keys.Down) || this.Position.Y > GameWorld.Screen.Y - borderWidth+GameWorld.Camera.Pos.Y)
        {
            GameWorld.Camera.Move(new Vector2(0, 10));
        }

    }
}

