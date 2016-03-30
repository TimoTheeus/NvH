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
    protected string actionString;

    public TileMenu(Tile tile, string id = "menu") : base(4, id)
    {
        this.tile = tile;
        background = new SpriteGameObject("button", 0, "background", 4);
        background.Position = new Vector2(GameData.Cursor.CurrentTile.Position.X, GameData.Cursor.CurrentTile.Position.Y + (GameData.Cursor.CurrentTile.Height * 3 / 2));
        background.Origin = background.Sprite.Center;
        this.Add(background);
        AddButtons();
        background.Sprite.Color = Color.Green;

        sunlightTreeCooldown = 5f;
        actionString = null;
    }

    protected void AddButtons()
    {
  
            button1 = new Button("checkBox", "", "", 0, "", 4);
            button1.Position = background.Position + new Vector2(-100, 0);
            button2 = new Button("checkBox", "", "", 0, "", 4);
            button2.Position = button1.Position + new Vector2(button1.Width, 0);
            addButton(button1);
            addButton(button2);
        if (GameData.player.GetFaction == Player.Faction.nature)
        {
            button3 = new Button("checkBox", "", "", 0, "", 4);
            button3.Position = button1.Position + new Vector2(button1.Width * 2, 0);
            addButton(button3);
        }

        
    }
    public override void HandleInput(InputHelper inputHelper)
    {
        base.HandleInput(inputHelper);

        Building b = null;
        //Mine or SunlightTree
        if (button1 != null && button1.Pressed)
        {
            button1.Sprite.SheetIndex = 1;
            GameData.Cursor.HasClickedTile = false;
            GameData.LevelObjects.Remove(this);
            if (GameData.player.GetFaction == Player.Faction.humanity)
            {
                b = new Mine();
                tile.AddTimer(new Timer(sunlightTreeCooldown), new Mine());
            }
            else
            {
                b = new SunlightTree();
                tile.AddTimer(new Timer(sunlightTreeCooldown), new SunlightTree());
            }
        }
        //Barracks, barracks
        else if (button2 != null && button2.Pressed)
        {
            button2.Sprite.SheetIndex = 1;
            GameData.Cursor.HasClickedTile = false;
            GameData.LevelObjects.Remove(this);
            if (GameData.player.GetFaction == Player.Faction.humanity)
            {
                b = new HumanityBarrack();
                tile.AddTimer(new Timer(sunlightTreeCooldown), new HumanityBarrack());
            }
            else
            {
                b = new NatureBarracks();
                tile.AddTimer(new Timer(sunlightTreeCooldown), new NatureBarracks());
            }

        }
        else if (button3 != null && button3.Pressed)
        {
            button3.Sprite.SheetIndex = 1;
            GameData.Cursor.HasClickedTile = false;
            GameData.LevelObjects.Remove(this);
            if (GameData.player.GetFaction == Player.Faction.humanity)
            {
                b = new Mine();
                tile.AddTimer(new Timer(sunlightTreeCooldown), new Mine());
            }
            else
            {
                b = new WaterTree();
                tile.AddTimer(new Timer(sunlightTreeCooldown), new WaterTree());
            }
        }
        if (b != null)
        {
            GameData.player.MainResource -= b.ResourceCosts.X;
            GameData.player.SecondaryResource -= b.ResourceCosts.Y;
        }
    }
    public override void Update(GameTime gameTime)
    {
        base.Update(gameTime);
    }
    protected void FireFireball()
    {

    }
    public override string getActionOutput()
    {
        if (actionString != null)
        {
            return actionString;
        }
        else return null;
    }
}

