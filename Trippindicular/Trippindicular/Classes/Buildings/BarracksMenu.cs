using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

class BarracksMenu : Menu
{
    protected Button button1, button2, button3;
    protected Tile tile;

    public BarracksMenu(Tile tile) : base(4, "barracksMenu")
    {
        this.tile = tile;
        background = new SpriteGameObject("button", 0, "background", 4);
        background.Position = new Vector2(GameData.Cursor.CurrentTile.Position.X, GameData.Cursor.CurrentTile.Position.Y + (new Tile().Height * 3 / 2));
        background.Origin = background.Sprite.Center;
        this.Add(background);
        button1 = new Button("checkBox", "", "", 0, "", 4);
        button1.Position = background.Position + new Vector2(-100, 0);
        button2 = new Button("checkBox", "", "", 0, "", 4);
        button2.Position = button1.Position + new Vector2(button1.Width, 0);
        button3 = new Button("checkBox", "", "", 0, "", 4);
        button3.Position = button1.Position + new Vector2(button1.Width * 2, 0);
        addButton(button1);
        addButton(button2);
        addButton(button3);
    }

    public override void HandleInput(InputHelper inputHelper)
    {
        base.HandleInput(inputHelper);

        if (button1 != null && button1.Pressed)
        {
            button1.Sprite.SheetIndex = 1;
            GameData.Cursor.HasClickedTile = false;
            GameData.LevelObjects.Remove(this);
            Unit unit;
            if (tile is NatureBarracks)
            {
                unit = new NatureWorker();
            }
            else
            {
                unit = new HumanityWorker();
            }
            unit.Position = new Vector2(tile.Position.X + new Tile().Sprite.Width / 2 - unit.Sprite.Width / 2, tile.Position.Y + new Tile().Sprite.Height / 2);
            GameData.AddUnit(unit);
        }
        else if (button2 != null && button2.Pressed)
        {
            button2.Sprite.SheetIndex = 1;
            GameData.Cursor.HasClickedTile = false;
            GameData.LevelObjects.Remove(this);
            Unit unit;
            if (tile is NatureBarracks)
            {
                unit = new Unit("selectedTile", "unit");
            }
            else
            {
                unit = new WoodCutter();
            }
            unit.Position = new Vector2(tile.Position.X + new Tile().Sprite.Width / 2 - unit.Sprite.Width / 2, tile.Position.Y + new Tile().Sprite.Height / 2);
            GameData.AddUnit(unit);
        }
        else if (button3 != null && button3.Pressed)
        {
            button3.Sprite.SheetIndex = 1;
            GameData.Cursor.HasClickedTile = false;
            GameData.LevelObjects.Remove(this);
            Unit unit;
            if (tile is NatureBarracks)
            {
                unit = new Unit("selectedTile", "unit");
            }
            else
            {
                unit = new FlameThrower("selectedTile", "unit");
            }
            unit.Position = new Vector2(tile.Position.X + new Tile().Sprite.Width / 2 - unit.Sprite.Width / 2, tile.Position.Y + new Tile().Sprite.Height / 2);
            GameData.AddUnit(unit);
        }
    }
}
