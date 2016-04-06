using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

class Menu : GameObjectList
{
    protected SpriteGameObject background;
    protected string actionString;
    protected bool actionSent;

    public Menu(int layer = 0, string id = "") : base(layer, id) 
    {
        actionString = null;
        actionSent = false;
    }

    public void addButton(Button b)
    {
        this.Add(b);
    }
    public override void Update(GameTime gameTime)
    {
        base.Update(gameTime);
        if (actionSent)
        {
            GameData.LevelObjects.Remove(this);
        }
    }
    public override void HandleInput(InputHelper inputHelper)
    {
        if (inputHelper.LeftButtonPressed() && !inputHelper.MouseInBox(background.BoundingBox))
        {
            if (actionString == null)
            {
                GameData.LevelObjects.Remove(this);
            }
            else { visible = false; }

            GameData.Cursor.HasClickedTile = false;
        }
        base.HandleInput(inputHelper);
    }
}
