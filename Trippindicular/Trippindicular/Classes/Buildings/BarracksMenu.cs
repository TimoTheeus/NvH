﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

class BarracksMenu : Menu
{
    protected Button button1, button2, button3, button4, button5;
    protected Tile tile;
    protected Player player;
    private string actionString;
    private bool actionSent;

    public BarracksMenu(Tile tile) : base(4, "barracksMenu")
    {
        this.tile = tile;
        actionSent = false;
        background = new SpriteGameObject("button", 0, "background", 4);
        background.Position = new Vector2(GameData.Cursor.CurrentTile.Position.X, GameData.Cursor.CurrentTile.Position.Y + (new Tile().Height * 3 / 2));
        background.Origin = background.Sprite.Center;
        this.Add(background);
        this.actionString = null;
        button1 = new Button("checkBox", "", "", 0, "", 4);
        button1.Position = background.Position + new Vector2(-120, 0);
        button2 = new Button("checkBox", "", "", 0, "", 4);
        button2.Position = button1.Position + new Vector2(button1.Width, 0);
        button3 = new Button("checkBox", "", "", 0, "", 4);
        button3.Position = button1.Position + new Vector2(button1.Width * 2, 0);
        button4 = new Button("checkBox", "", "", 0, "", 4);
        button4.Position = button1.Position + new Vector2(button1.Width * 3, 0);
        button5 = new Button("checkBox", "", "", 0, "", 4);
        button5.Position = button1.Position + new Vector2(button1.Width * 4, 0);
        addButton(button1);
        addButton(button2);
        addButton(button3);
        if((tile as Building).level >= 2)
            addButton(button4);
        if((tile as Building).level >= 3)
            addButton(button5);

        for (int i = 0; i < GameData.LevelObjects.Objects.Count; i++)
        {
            if (GameData.LevelObjects.Objects[i] is Player)
            {
                player = GameData.LevelObjects.Objects[i] as Player;
                return;
            }
        }
    }

    public override void HandleInput(InputHelper inputHelper)
    {
        base.HandleInput(inputHelper);
        Unit unit = null;
        if (button1 != null && button1.Pressed && (tile as Building).level < (tile as Building).maxLevel)
        {
            button1.Sprite.SheetIndex = 1;
            (tile as Building).level += 1;
            GameData.Cursor.HasClickedTile = false;
            GameData.LevelObjects.Remove(this);
        }

        if (button2 != null && button2.Pressed)
        {
            button2.Sprite.SheetIndex = 1;
            GameData.Cursor.HasClickedTile = false;

            if (tile is NatureBarracks)
            {
                unit = new NatureWorker();
                player.MainResource -= unit.ResourceCosts.X;
                player.SecondaryResource -= unit.ResourceCosts.Y;
            }
            else
            {
                unit = new HumanityWorker();
                player.MainResource -= unit.ResourceCosts.X;
                player.SecondaryResource -= unit.ResourceCosts.Y;
            }
            unit.Position = new Vector2(tile.Position.X + new Tile().Sprite.Width / 2 - unit.Sprite.Width / 2, tile.Position.Y + new Tile().Sprite.Height / 2);
        }
        else if (button3 != null && button3.Pressed)
        {
            button3.Sprite.SheetIndex = 1;
            GameData.Cursor.HasClickedTile = false;


            if (tile is NatureBarracks)
            {
                unit = new Melee2(Player.Faction.nature, "natureWolf", "unit");
                player.MainResource -= unit.ResourceCosts.X;
                player.SecondaryResource -= unit.ResourceCosts.Y;
            }
            else
            {
                unit = new Melee1(Player.Faction.humanity, "flamethrower","flamethrowerUnit");
                player.MainResource -= unit.ResourceCosts.X;
                player.SecondaryResource -= unit.ResourceCosts.Y;
            }
            unit.Position = new Vector2(tile.Position.X + new Tile().Sprite.Width / 2 - unit.Sprite.Width / 2, tile.Position.Y + new Tile().Sprite.Height / 2);
        }
        else if (button4 != null && button4.Pressed)
        {
            button4.Sprite.SheetIndex = 1;
            GameData.Cursor.HasClickedTile = false;

            if (tile is NatureBarracks)
            {
                unit = new Unicorn("unicorn", "unicorn");
                player.MainResource -= unit.ResourceCosts.X;
                player.SecondaryResource -= unit.ResourceCosts.Y;
            }
            else
            {
                unit = new Unicorn("selectedTile", "unit");
                player.MainResource -= unit.ResourceCosts.X;
                player.SecondaryResource -= unit.ResourceCosts.Y;
            }
            unit.Position = new Vector2(tile.Position.X + new Tile().Sprite.Width / 2 - unit.Sprite.Width / 2, tile.Position.Y + new Tile().Sprite.Height / 2);
        }
        else if (button5 != null && button5.Pressed)
        {
            button5.Sprite.SheetIndex = 1;
            GameData.Cursor.HasClickedTile = false;
            
            if (tile is NatureBarracks)
            {
                unit = new Ranged(Player.Faction.nature, "selectedTile", "unicorn");
                player.MainResource -= unit.ResourceCosts.X;
                player.SecondaryResource -= unit.ResourceCosts.Y;
            }
            else
            {
                unit = new Ranged(Player.Faction.humanity, "selectedTile", "unit");
                player.MainResource -= unit.ResourceCosts.X;
                player.SecondaryResource -= unit.ResourceCosts.Y;
            }
            unit.Position = new Vector2(tile.Position.X + new Tile().Sprite.Width / 2 - unit.Sprite.Width / 2, tile.Position.Y + new Tile().Sprite.Height / 2);
        }
        if (unit != null)
        {
            GameData.AddUnit(unit);
            this.actionString = "$addu:" + unit.ID  + "$type:"+ unit.GetType() + "$posi:" + unit.Position.X + "," + unit.Position.Y;//;
            
        }
    }

    public override void Update(GameTime gameTime)
    {
        base.Update(gameTime);
        if (actionSent)
        {
            GameData.LevelObjects.Remove(this);
        }
    }

    public override string getActionOutput()
    {
        string s = this.actionString;
        if (s != null)
        {
            actionSent = true;
            this.actionString = null;
        }
        return s;
    }
}
