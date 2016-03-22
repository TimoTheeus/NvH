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
    static public HexaGrid LevelGrid;
    static public SpriteGameObject selectedTile;
    static public Cursor Cursor;

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
        Tile tile = new Tile();
        GameData.LevelGrid = new HexaGrid(30, 40, tile.Width, tile.Height, true, "levelGrid");
        for (int i = 0; i < LevelGrid.Columns; i++)
            for (int j = 0; j < LevelGrid.Rows; j++)
                GameData.LevelGrid.Add(new Tile(), i, j);
        GameData.LevelObjects.Add(GameData.LevelGrid);

        selectedTile = new SpriteGameObject("selectedTile", 0, "selectedTile", 1);
        selectedTile.Origin = selectedTile.Sprite.Center;
        GameData.LevelObjects.Add(selectedTile);
        selectedTile.Position = new Vector2(-3000, -3000);

        Cursor = new Cursor();
        GameData.LevelObjects.Add(Cursor);
    }
    static public void AfterInitialize()
    {
    }
   
}

