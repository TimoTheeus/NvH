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
    static public HexaGrid LevelGrid;
    static public SpriteGameObject selectedTile;
    static public Cursor Cursor;
    static public ResourceController ResourceController;
    static public Player naturePlayer;
    static public Player humanityPlayer;
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
                    GameData.LevelGrid.Add(new Tile(), i, j);
        GameData.LevelObjects.Add(GameData.LevelGrid);

        GameWorld.Camera.Bounds = new Rectangle(0-(int)tile.Sprite.Center.X - (int)(0.5*GameWorld.Screen.X), -(int)tile.Sprite.Center.Y - 
            (int)(0.5 * GameWorld.Screen.Y), GameData.LevelGrid.GetWidth(), GameData.LevelGrid.GetHeight());
        GameWorld.Camera.Pos= new Vector2(-(int)tile.Sprite.Center.X, -(int)tile.Sprite.Center.Y);

        selectedTile = new SpriteGameObject("selectedTile", 0, "selectedTile", 1);
        selectedTile.Origin = selectedTile.Sprite.Center;
        selectedTile.Position = new Vector2(-3000, -3000);
        GameData.LevelObjects.Add(selectedTile);

        

        naturePlayer = new Player(Player.Faction.nature);
        GameData.LevelObjects.Add(naturePlayer);
        humanityPlayer = new Player(Player.Faction.humanity);
        GameData.LevelObjects.Add(humanityPlayer);
        ResourceController = new ResourceController(1, 10, 10) ;
        GameData.LevelObjects.Add(ResourceController);

        Unit unit = new Unit("selectedTile","testUnit", 4);
        unit.Position = new Vector2(500, 500);
        Unit unit2 = new Unit("selectedTile", "testUnit2", 4);
        unit2.Position = new Vector2(700, 500);
        Unit unit3 = new Unit("selectedTile", "testUnit3", 4);
        unit3.Position = new Vector2(500, 700);
        Unit unit4 = new Unit("selectedTile", "testUnit4", 4);
        unit4.Position = new Vector2(700, 700);
        GameData.Units.Add(unit4);
        GameData.Units.Add(unit3);
        GameData.Units.Add(unit2);
        GameData.Units.Add(unit);

    }
    static public void AfterInitialize()
    {
    }
   
}

