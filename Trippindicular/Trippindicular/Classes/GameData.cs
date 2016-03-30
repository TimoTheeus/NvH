using Microsoft.Xna.Framework;
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
    static public GameObjectList Buildings;
    static public HexaGrid LevelGrid;
    static public SpriteGameObject selectedTile;
    static public Cursor Cursor;
    static public ResourceController ResourceController;
    static public Player player;
    static public int unitIdIndex;
    static bool host;
    static List<Forest> forests;
    public static bool Host { get { return host; } set { host = value; } }

    static public int UnitIdIndex
    {
        get { return unitIdIndex; }
        set { unitIdIndex = value; }
    }

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

    static public void ClientInitialize(List<Forest> trees, Player plyr)
    {
        Tile tile = new Tile();
        GameData.Player = plyr;
        GameData.LevelGrid = new HexaGrid(30, 40, tile.Width, tile.Height, true, "levelGrid");
        for (int i = 0; i < LevelGrid.Columns; i++)
            for (int j = 0; j < LevelGrid.Rows; j++)
            {
                if (i > (int)(LevelGrid.Columns * .25) && i < (int)(LevelGrid.Columns * .75))
                {
                    bool ftile = false;
                    string id = "";
                    foreach (Forest f in trees)
                    {
                        if (f.forestPoint.X == i && f.forestPoint.Y == j)
                        {
                            id = f.ID;
                            ftile = true;
                            break;
                        }
                    }
                    if (ftile)
                    {
                            Forest f = new Forest(new Point(i, j));
                            f.gridPosition = new Point(i, j);
                            f.ID = id;
                            GameData.LevelGrid.Add(f, i, j);
                            GameData.Buildings.Add(f);
                            forests.Add(f);
                     } else {
                            int type = 1 + (int)(GameWorld.Random.NextDouble() * 7);
                            Tile t = new Tile("environment" + type);
                            t.gridPosition = new Point(i, j);
                            GameData.LevelGrid.Add(t, i, j);
                     }
                }
 
                else
                {
                    int type = 1 + (int)(GameWorld.Random.NextDouble() * 7);
                    Tile t = new Tile("environment" + type);
                    t.gridPosition = new Point(i, j);
                    GameData.LevelGrid.Add(t, i, j);
                }
            }        
        HumanityBase hBase = new HumanityBase();
        hBase.gridPosition = new Point(2, 11);
        hBase.Position = GameData.LevelGrid.Objects[2, 11].Position;
        GameData.LevelGrid.Objects[2, 11] = hBase;
        GameData.Buildings.Add(hBase);
        NatureBase nBase = new NatureBase();
        nBase.gridPosition = new Point(GameData.LevelGrid.Columns - 2, GameData.LevelGrid.Rows - 11);
        nBase.Position = GameData.LevelGrid.Objects[GameData.LevelGrid.Columns - 2, GameData.LevelGrid.Rows - 11].Position;
        GameData.LevelGrid.Objects[GameData.LevelGrid.Columns - 2, GameData.LevelGrid.Rows - 11] = nBase;
        GameData.Buildings.Add(nBase);
        GameData.LevelObjects.Add(GameData.LevelGrid);

        if (GameData.Cursor != null)
        {
            GameData.LevelObjects.Remove(GameData.Cursor);
        }
        if (GameData.player.GetFaction == Player.Faction.humanity)
        {
            GameData.Cursor = new Cursor("humanityCursor");
        }
        else {
            GameData.Cursor = new Cursor("natureCursor");
        }
        GameData.LevelObjects.Add(GameData.Cursor);

        GameWorld.Camera.Bounds = new Rectangle(0 - (int)tile.Sprite.Center.X - (int)(0.5 * GameWorld.Screen.X), -(int)tile.Sprite.Center.Y -
            (int)(0.5 * GameWorld.Screen.Y), GameData.LevelGrid.GetWidth(), GameData.LevelGrid.GetHeight());
        GameWorld.Camera.Bounds = new Rectangle(0 - (int)tile.Sprite.Center.X , -(int)tile.Sprite.Center.Y,
            GameData.LevelGrid.GetWidth(), (GameData.LevelGrid.GetHeight()));
        if (plyr.GetFaction == Player.Faction.humanity)
        {
            //GameWorld.Camera.Pos = new Vector2(0, 0);
            GameWorld.Camera.Pos = new Vector2(-(int)tile.Sprite.Center.X, -(int)tile.Sprite.Center.Y);
        }
        else
        {
            GameWorld.Camera.Pos = new Vector2(-(int)tile.Sprite.Center.X, -(int)tile.Sprite.Center.Y);
            int y = GameData.LevelGrid.GetHeight();
            int x = GameData.LevelGrid.GetWidth();
            GameWorld.Camera.Pos = new Vector2(3380, 85);

        }

        selectedTile = new SpriteGameObject("selectedTile", 0, "selectedTile", 1);
        selectedTile.Origin = selectedTile.Sprite.Center;
        selectedTile.Position = new Vector2(-3000, -3000);
        GameData.LevelObjects.Add(selectedTile);



        //naturePlayer = new Player(Player.Faction.nature);
        //GameData.LevelObjects.Add(naturePlayer);
        GameData.LevelObjects.Add(player);
        //ResourceController = new ResourceController(1, 10, 10);
        //GameData.LevelObjects.Add(ResourceController);
        NatureWorker unit = new NatureWorker();
        unit.Position = new Vector2(500, 500);
        NatureWorker unit2 = new NatureWorker();
        unit2.Position = new Vector2(700, 500);
        Melee1 unit3 = new Melee1(Player.Faction.nature, "selectedTile", "natMelee");
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
        foreach (Unit u in GameData.Units.Objects)
        {
            if (u.Faction == Player.Faction.humanity)
            {
                u.Sprite.Color = Color.Red;
            }
            else
            {
                u.Sprite.Color = Color.Green;
            }
        }



    }


    //Method that initializes the settings and data used in GameData.
    static public void Initialize()
    {
        LevelObjects = new GameObjectList();
        Buildings = new GameObjectList(4);
        GameData.LevelObjects.Add(Buildings);
        Units = new GameObjectList(4);
        LevelObjects.Add(Units);
        Cursor = new Cursor();
        GameData.LevelObjects.Add(Cursor);

        forests = new List<Forest>();

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




    internal static string InitializeMessage()
    {
        string msg = "$init";
        msg += "$trees:";
        foreach (Forest f in forests)
        {
            msg += f.ID + "," + f.forestPoint.X.ToString() + "," + f.forestPoint.Y.ToString()+"|";
        }
        string facString = "";
        if (GameData.Player.GetFaction == Player.Faction.nature)
        {
            facString = "nature";
        } else {
            facString = "humanity";
        }

        msg += "$factn:" + facString;
        return msg;
    }

    public static void HostInitialize()
    {
        Tile tile = new Tile();
        //GameData.player.GetFaction = Player.Faction.nature;

        int idIndex = 0;
        GameData.LevelGrid = new HexaGrid(30, 40, tile.Width, tile.Height, true, "levelGrid");
        for (int i = 0; i < LevelGrid.Columns; i++)
            for (int j = 0; j < LevelGrid.Rows; j++)
            {
                if (i > (int)(LevelGrid.Columns * .25) && i < (int)(LevelGrid.Columns * .75))
                    switch (GameWorld.Random.Next(12))
                    {
                        case 0:
                            Forest f = new Forest(new Point(i,j));
                            f.gridPosition = new Point(i, j);
                            f.ID = f.ID + idIndex.ToString();
                            idIndex++;
                            GameData.LevelGrid.Add(f, i, j);
                            forests.Add(f);
                            GameData.Buildings.Add(f);
                            break;
                        default:
                            int type = 1 + (int)(GameWorld.Random.NextDouble() * 7);
                            Tile t = new Tile("environment" + type);
                            t.gridPosition = new Point(i, j);
                            GameData.LevelGrid.Add(t, i, j);
                            break;
                    }
                else
                {
                    int type = 1 + (int)(GameWorld.Random.NextDouble() * 7);
                    Tile t = new Tile("environment" + type);
                    t.gridPosition = new Point(i, j);
                    GameData.LevelGrid.Add(t, i, j);
                }
         }        
        HumanityBase hBase = new HumanityBase();
        hBase.gridPosition = new Point(2, 11);
        hBase.Position = GameData.LevelGrid.Objects[2, 11].Position;
        GameData.LevelGrid.Objects[2, 11] = hBase;
        GameData.Buildings.Add(hBase);
        NatureBase nBase = new NatureBase();
        nBase.gridPosition = new Point(GameData.LevelGrid.Columns - 2, GameData.LevelGrid.Rows - 11);
        nBase.Position = GameData.LevelGrid.Objects[GameData.LevelGrid.Columns - 2, GameData.LevelGrid.Rows - 11].Position;
        GameData.LevelGrid.Objects[GameData.LevelGrid.Columns - 2, GameData.LevelGrid.Rows - 11] = nBase;
        GameData.Buildings.Add(nBase);
        GameData.LevelObjects.Add(GameData.LevelGrid);

        GameWorld.Camera.Bounds = new Rectangle(0-(int)tile.Sprite.Center.X, -(int)tile.Sprite.Center.Y, 
            GameData.LevelGrid.GetWidth(), GameData.LevelGrid.GetHeight());
        GameWorld.Camera.Pos= new Vector2(-(int)tile.Sprite.Center.X, -(int)tile.Sprite.Center.Y);
        if (player.GetFaction == Player.Faction.humanity)
        {
            GameWorld.Camera.Pos = new Vector2(0, 0);
        }
        else
        {
            //GameWorld.Camera.Pos = new Vector2(-(int)tile.Sprite.Center.X, -(int)tile.Sprite.Center.Y);
            int y = GameData.LevelGrid.GetHeight();
            int x = GameData.LevelGrid.GetWidth();
            GameWorld.Camera.Pos = new Vector2(3380, 85);

        }

        selectedTile = new SpriteGameObject("selectedTile", 0, "selectedTile", 1);
        selectedTile.Origin = selectedTile.Sprite.Center;
        selectedTile.Position = new Vector2(-3000, -3000);
        GameData.LevelObjects.Add(selectedTile);

        if (GameData.Cursor != null)
        {
            GameData.LevelObjects.Remove(GameData.Cursor);
        }
        if (GameData.player.GetFaction == Player.Faction.humanity)
        {
            GameData.Cursor = new Cursor("humanityCursor");
        }
        else {
            GameData.Cursor = new Cursor("humanityCursor");
        }

        

        GameData.LevelObjects.Add(GameData.Cursor);

        

        //naturePlayer = new Player(Player.Faction.nature);
        //GameData.LevelObjects.Add(naturePlayer);
        GameData.LevelObjects.Add(player);
        //ResourceController = new ResourceController(1, 10, 10) ;
        //GameData.LevelObjects.Add(ResourceController);
        NatureWorker unit = new NatureWorker();
        unit.Position = new Vector2(500, 500);
        NatureWorker unit2 = new NatureWorker();
        unit2.Position = new Vector2(700, 500);
        Melee1 unit3 = new Melee1(Player.Faction.nature, "selectedTile", "natMelee");
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

    public static Player Player { get { return player; } set { player = value; } }
}

