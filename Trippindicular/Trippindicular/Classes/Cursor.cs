using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Graphics;

class Cursor : SpriteGameObject
{
    protected bool hasClickedTile;
    protected Unit clickedUnit;
    protected Tile currentTile;
    protected Tile tileForOrigin;
    protected const int borderWidth = 100;

    public bool HasClickedTile
    {
        get { return hasClickedTile; }
        set { hasClickedTile = value; }
    }

    public Unit ClickedUnit
    {
        get { return clickedUnit; }
        set { clickedUnit = value; }
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
        this.Position = inputHelper.MousePosition + GameWorld.Camera.Pos;
        Point position = new Point((int)(inputHelper.MousePosition.X + tileForOrigin.Sprite.Center.X + GameWorld.Camera.Pos.X),
            (int)(inputHelper.MousePosition.Y + tileForOrigin.Sprite.Center.Y + GameWorld.Camera.Pos.Y));

        if (!hasClickedTile)
        {
            currentTile = GameData.LevelGrid.GetTile(position);
            if (currentTile != null)
                GameData.selectedTile.Position = currentTile.Position;
        }
        for (int i = 0; i < GameData.Units.Objects.Count; i++)
        {
            // make return property that returns the right value instead 
        }
        //stop hovering tiles 
        if (inputHelper.LeftButtonPressed() && currentTile != null && !hasClickedTile && !HoveringOverUnit(inputHelper))
        {
            hasClickedTile = true;
        }

        if (inputHelper.IsKeyDown(Keys.Right) || inputHelper.MousePosition.X > GameSettings.GameWidth - borderWidth)
        {
            GameWorld.Camera.Move(new Vector2(15, 0));

        }
        else if (inputHelper.IsKeyDown(Keys.Left) || inputHelper.MousePosition.X < borderWidth)
        {
            GameWorld.Camera.Move(new Vector2(-15, 0));

        }
        else if (inputHelper.IsKeyDown(Keys.Up) || inputHelper.MousePosition.Y < borderWidth)
        {
            GameWorld.Camera.Move(new Vector2(0, -15));
        }
        else if (inputHelper.IsKeyDown(Keys.Down) || inputHelper.MousePosition.Y > GameSettings.GameHeight - borderWidth)
        {
            GameWorld.Camera.Move(new Vector2(0, 15));
        }

    }
    public bool HoveringOverUnit(InputHelper ih)
    {
        Point mousePoint = new Point((int)(ih.MousePosition.X + GameWorld.Camera.Pos.X), (int)(ih.MousePosition.Y + GameWorld.Camera.Pos.Y));
        {
            for (int i = 0; i < GameData.Units.Objects.Count; i++)
            {
                if (GameData.Units.Objects[i].BoundingBox.Contains(mousePoint))
                {
                    return true;
                }
            }
        }
        return false;
    }
}


