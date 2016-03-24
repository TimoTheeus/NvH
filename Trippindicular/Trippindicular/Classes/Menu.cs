using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

class Menu : GameObjectList
{
    protected Button button1, button2, button3, button4;
    protected SpriteGameObject background;
    protected Tile tile;

    public Menu(Tile tile,string id = "menu"):base(4,id)
    {
        this.tile = tile;
        background = new SpriteGameObject("button", 0, "background", 4);
        background.Position = new Vector2(GameData.Cursor.CurrentTile.Position.X, GameData.Cursor.CurrentTile.Position.Y + (GameData.Cursor.CurrentTile.Height * 3/2)) ;
        background.Origin = background.Sprite.Center;
        this.Add(background);
        button1 = new Button("checkBox","","" ,0, "", 4);
        button1.Position = background.Position;
        this.Add(button1);
        if (tile is SunlightTree)
        {
            background.Sprite.Color = Color.Red;
        } else
        {
            background.Sprite.Color = Color.Green;
        }
    }

    public void addButton(Button b)
    {
        this.Add(b);
    }
    public override void HandleInput(InputHelper inputHelper)
    {
        base.HandleInput(inputHelper);

        if (inputHelper.LeftButtonPressed() && !inputHelper.MouseInBox(background.BoundingBox))
        {
            
            GameData.LevelObjects.Remove(this);

            GameData.Cursor.HasClickedTile = false;
        }
        if (button1.Pressed)
        {
            button1.Sprite.SheetIndex = 1;

            GameData.Cursor.HasClickedTile = false;
            GameData.LevelObjects.Remove(this);
            if (this.tile is SunlightTree)
            {

            }
            else
            {
                GameData.LevelGrid.replaceTile(this.tile, new SunlightTree());
            }
        }
    }
    public override void Update(GameTime gameTime)
    {
        base.Update(gameTime);
    }
}

