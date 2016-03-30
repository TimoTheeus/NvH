using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

class HumanityBaseMenu : Menu
{
    protected Button button1, button2, button3, button4, button5;
    protected Tile tile;
    protected Spell spell;
    private string actionString;
    private bool actionSent;
    protected Player player;

    public HumanityBaseMenu(Tile tile)
        : base(10, "barracksMenu")
    {
        actionString = null;
        actionSent = false;
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
        addButton(button2);
        addButton(button3);
        button4 = new Button("checkBox", "", "", 0, "", 4);
        button4.Position = button1.Position + new Vector2(button1.Width * 3, 0);
        if ((tile as Building).level >= 2)
            addButton(button4);
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
            GameData.Cursor.HasClickedTile = false;
            GameData.LevelObjects.Remove(this);
            (this.tile as Building).level += 1;
        }
        else if (button2 != null && button2.Pressed)
        {
            unit = new HumanityWorker();
            player.MainResource -= unit.ResourceCosts.X;
            player.SecondaryResource -= unit.ResourceCosts.Y;
            unit.Position = new Vector2(tile.Position.X + new Tile().Sprite.Width / 2 - unit.Sprite.Width / 2, tile.Position.Y +
                new Tile().Sprite.Height / 2);
            GameData.Cursor.HasClickedTile = false;
            GameData.LevelObjects.Remove(this);
        }
        else if (button3 != null && button3.Pressed)
        {
            unit = new WoodCutter();
            player.MainResource -= unit.ResourceCosts.X;
            player.SecondaryResource -= unit.ResourceCosts.Y;
            unit.Position = new Vector2(tile.Position.X + new Tile().Sprite.Width / 2 - unit.Sprite.Width / 2, tile.Position.Y +
                new Tile().Sprite.Height / 2);
            GameData.Cursor.HasClickedTile = false;
            GameData.LevelObjects.Remove(this);
        }
        else if (button4 != null && button4.Pressed)
        {
            //Temporary unit spell
        }
        if (unit != null)
        {
            GameData.AddUnit(unit);
            this.actionString = "$addu:" + unit.ID + "$type:" + unit.GetType() + "$posi:" + unit.Position.X + "," + unit.Position.Y;//;
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



