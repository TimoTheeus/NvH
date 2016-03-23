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

    public Menu(Tile tile,string id = ""):base(4,id)
    {
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
        }
    }

    public void addButton(Button b)
    {
        this.Add(b);
    }
    public override void HandleInput(InputHelper inputHelper)
    {
        base.HandleInput(inputHelper);
        if (button1.Pressed)
        {
            button1.Sprite.SheetIndex = 1;
            //Create a unit
        }
        if (inputHelper.LeftButtonPressed() && !inputHelper.MouseInBox(background.BoundingBox))
        {
            GameData.LevelObjects.Remove(this);
            GameData.Cursor.HasClickedTile = false;
        }

    }
    public override void Update(GameTime gameTime)
    {
        base.Update(gameTime);
    }
}

