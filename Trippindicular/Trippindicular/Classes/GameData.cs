﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

//Class used for all static data used in the game.
static class GameData
{
    static Point resolution;
    //This is the list with all the objects of the current level in it.
    static public GameObjectList LevelObjects;
    static public GameObjectList Units;
    static public HexaGrid LevelGrid;
    static public SpriteGameObject selectedTile;
    static public Cursor Cursor;
    static public ResourceController ResourceController;
    static public Player player;
    static public int unitIdIndex;
    static bool host;
    public static bool Host { get { return host; } set { host = value; } }


    static public Point Resolution
    {
        get { return resolution; }
        set { if (resolution == null) resolution = value; }
    }

    static public void Update(GameTime gameTime)
    {
        LevelObjects.Update(gameTime);
    }

    //This is where the objects in the game (LevelObjects) are drawn.
    static public void DrawGame(GameTime gameTime, SpriteBatch spriteBatch)
    {
        LevelObjects.Draw(gameTime, spriteBatch);
    }

    //Method that initializes the settings and data used in GameData.
    static public void Initialize()
    {
        LevelObjects = new GameObjectList();
        Units = new GameObjectList(4);
        LevelObjects.Add(Units);
        Cursor = new Cursor();
        GameData.LevelObjects.Add(Cursor);
        Tile tile = new Tile();
        GameData.LevelGrid = new HexaGrid(30, 40, tile.Width, tile.Height, true, "levelGrid");
        for (int i = 0; i < LevelGrid.Columns; i++)
            for (int j = 0; j < LevelGrid.Rows; j++)
            {
                if (i > (int)(LevelGrid.Columns * .25) && i < (int)(LevelGrid.Columns * .75))
                    switch (GameWorld.Random.Next(12))
                    {
                        case 0:
                            Forest f = new Forest();
                            f.gridPosition = new Point(i, j);
                            GameData.LevelGrid.Add(f, i, j);
                            break;
                        default:
                            Tile t = new Tile();
                            t.gridPosition = new Point(i, j);
                            GameData.LevelGrid.Add(t, i, j);
                            break;
                    }
                else
                {
                    Tile t = new Tile();
                    t.gridPosition = new Point(i, j);
                    GameData.LevelGrid.Add(t, i, j);
                }
            }
                    
        GameData.LevelObjects.Add(GameData.LevelGrid);

        GameWorld.Camera.Bounds = new Rectangle(0-(int)tile.Sprite.Center.X - (int)(0.5*GameWorld.Screen.X), -(int)tile.Sprite.Center.Y - 
            (int)(0.5 * GameWorld.Screen.Y), GameData.LevelGrid.GetWidth(), GameData.LevelGrid.GetHeight());
        GameWorld.Camera.Pos= new Vector2(-(int)tile.Sprite.Center.X, -(int)tile.Sprite.Center.Y);

        selectedTile = new SpriteGameObject("selectedTile", 0, "selectedTile", 1);
        selectedTile.Origin = selectedTile.Sprite.Center;
        selectedTile.Position = new Vector2(-3000, -3000);
        GameData.LevelObjects.Add(selectedTile);

        

        //naturePlayer = new Player(Player.Faction.nature);
        //GameData.LevelObjects.Add(naturePlayer);
        GameData.LevelObjects.Add(player);
        ResourceController = new ResourceController(1, 10, 10) ;
        GameData.LevelObjects.Add(ResourceController);
        NatureWorker unit = new NatureWorker();
        unit.Position = new Vector2(500, 500);
        NatureWorker unit2 = new NatureWorker();
        unit2.Position = new Vector2(700, 500);
        NatureWorker unit3 = new NatureWorker();
        unit3.Position = new Vector2(900, 500);
        HumanityWorker unit4 = new HumanityWorker();
        unit4.Position = new Vector2(1100, 500);
        FlameThrower unit5 = new FlameThrower();
        unit5.Position = new Vector2(500, 700);
        FlameThrower unit6 = new FlameThrower();
        unit6.Position = new Vector2(700, 700);
        WoodCutter unit7 = new WoodCutter();
        unit7.Position = new Vector2(900, 700);
        WoodCutter unit8 = new WoodCutter();
        unit8.Position = new Vector2(1100, 700);
        GameData.AddUnit(unit8);
        GameData.AddUnit(unit7);
        GameData.AddUnit(unit6);
        GameData.AddUnit(unit5);
        GameData.AddUnit(unit4);
        GameData.AddUnit(unit3);
        GameData.AddUnit(unit2);
        GameData.AddUnit(unit);

    }
    static public void AfterInitialize()
    {
    }

    static public void AddUnit(Unit obj)
    {
        unitIdIndex++;
        obj.ID = obj.ID + unitIdIndex.ToString();
        GameData.Units.Add(obj);
    }



}

