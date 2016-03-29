using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

class NatureBaseMenu : Menu
{
    protected Button button1, button2;
    protected Tile tile;
    protected Spell spell;

    public NatureBaseMenu(Tile tile)
        : base(10, "natureBaseMenu")
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
        addButton(button1);
        addButton(button2);
    }

    public override void HandleInput(InputHelper inputHelper)
    {
        base.HandleInput(inputHelper);

        if (button1 != null && button1.Pressed)
        {
            spell = new MeteorStorm();
            GameData.Cursor.Spell = spell;
            GameData.Cursor.HasClickedTile = false;
            GameData.LevelObjects.Remove(this);
        }
        else if (button2 != null && button2.Pressed)
        {
            spell = new SnowStorm();
            GameData.Cursor.Spell = spell;
            GameData.Cursor.HasClickedTile = false;
            GameData.LevelObjects.Remove(this);
        }
    }
}



