using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

class TileMenu : Menu
{
    protected Button button1, button2, button3, button4;
    protected Tile tile;
    protected float sunlightTreeCooldown;

    public TileMenu(Tile tile, string id = "menu"):base(4,id)
    {
        this.tile = tile;
        background = new SpriteGameObject("button", 0, "background", 4);
        background.Position = new Vector2(GameData.Cursor.CurrentTile.Position.X, GameData.Cursor.CurrentTile.Position.Y + (GameData.Cursor.CurrentTile.Height * 3/2)) ;
        background.Origin = background.Sprite.Center;
        this.Add(background);
        AddButtons();
        if (tile is SunlightTree)
        {
            background.Sprite.Color = Color.Red;
        } else
        {
            background.Sprite.Color = Color.Green;
        }
        sunlightTreeCooldown = 5f;
    }

    protected void AddButtons()
    {
        if (tile is SunlightTree)
        {
            
        }
        else {
            button1 = new Button("checkBox", "", "", 0, "", 4);
            button1.Position = background.Position + new Vector2(-100, 0);
            button2 = new Button("checkBox", "", "", 0, "", 4);
            button2.Position = button1.Position + new Vector2(button1.Width, 0);
            button3 = new Button("checkBox", "", "", 0, "", 4);
            button3.Position = button1.Position + new Vector2(button1.Width * 2, 0);
            button4 = new Button("checkBox", "", "", 0, "", 4);
            button4.Position = button1.Position + new Vector2(button1.Width * 3, 0);
            addButton(button1);
            addButton(button2);
            addButton(button3);
            addButton(button4);
        }
    }
    public override void HandleInput(InputHelper inputHelper)
    {
        base.HandleInput(inputHelper);

        if (button1!=null&&button1.Pressed)
        { 
            button1.Sprite.SheetIndex = 1;
            GameData.Cursor.HasClickedTile = false;
            GameData.LevelObjects.Remove(this);
            if (this.tile is SunlightTree)
            {

            }
            else
            {
                tile.AddTimer(new Timer(sunlightTreeCooldown), new SunlightTree());
            }
        }
        else if (button2 != null && button2.Pressed)
        {
            button2.Sprite.SheetIndex = 1;
            GameData.Cursor.HasClickedTile = false;
            GameData.LevelObjects.Remove(this);
            tile.AddTimer(new Timer(sunlightTreeCooldown), new Mine());

        }
        else if (button3 != null && button3.Pressed)
        {
            button3.Sprite.SheetIndex = 1;
            GameData.Cursor.HasClickedTile = false;
            GameData.LevelObjects.Remove(this);
            tile.AddTimer(new Timer(sunlightTreeCooldown), new NatureBase());
        }
        else if (button4 != null && button4.Pressed)
        {
            button4.Sprite.SheetIndex = 1;
            GameData.Cursor.HasClickedTile = false;
            GameData.LevelObjects.Remove(this);
            tile.AddTimer(new Timer(sunlightTreeCooldown), new HumanityBarrack());
        }
    }
    public override void Update(GameTime gameTime)
    {
        base.Update(gameTime);
    }
}

