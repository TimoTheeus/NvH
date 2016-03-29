using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

class NatureBaseMenu : Menu
{
    protected Button button1, button2, button3;
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
        button1.Position = background.Position + new Vector2(-120, 0);
        button2 = new Button("checkBox", "", "", 0, "", 4);
        button2.Position = button1.Position + new Vector2(button1.Width, 0);
        button3 = new Button("checkBox", "", "", 0, "", 4);
        button3.Position = button1.Position + new Vector2(button1.Width * 2, 0);
        addButton(button1);
        if((tile as Building).level >= 2)
            addButton(button2);
        if ((tile as Building).level >= 3)
            addButton(button3);
        
    }

    public override void HandleInput(InputHelper inputHelper)
    {
        base.HandleInput(inputHelper);

        if (button1 != null && button1.Pressed && (tile as Building).level < (tile as Building).maxLevel)
        {
            GameData.Cursor.HasClickedTile = false;
            GameData.LevelObjects.Remove(this);
            (this.tile as Building).level += 1;
        }
        else if (button2 != null && button2.Pressed)
        {
            spell = new SnowStorm();
            GameData.Cursor.Spell = spell;
            GameData.Cursor.HasClickedTile = false;
            GameData.LevelObjects.Remove(this);
        }
        else if (button3 != null && button3.Pressed)
        {
            spell = new MeteorStorm();
            GameData.Cursor.Spell = spell;
            GameData.Cursor.HasClickedTile = false;
            GameData.LevelObjects.Remove(this);
        }

    }
}



