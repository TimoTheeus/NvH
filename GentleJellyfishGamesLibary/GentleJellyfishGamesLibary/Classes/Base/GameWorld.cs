using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;

//Class with all basic loops and variables needed for any game.
public class GameWorld : Game
{
    static public GraphicsDeviceManager graphics;
    static public Matrix ScaleMatrix;
    protected SpriteBatch spriteBatch;
    protected InputHelper inputHelper;
    
    //Vars needed for saving data
    protected IAsyncResult result;

    protected static Point resolution;
    protected static AssetLoader assetLoader;
    protected static GameStateManager gameStateManager;
    protected static R random;
    protected static Point screen;
    protected static bool exited;

    //Readonly properties (=> means get {return ...}(C# 6.0))
    public static Point Resolution => resolution;
    public static AssetLoader AssetLoader => assetLoader;
    public static GameStateManager GameStateManager => gameStateManager;

    //Property used to exit the game from anywhere
    public static bool Exited
    {
        set { exited = value; }
    }
    public static Point Screen
    {
        get { return screen; }
    }
    

    //Initialize the gameworld (also initializes settings).
    public GameWorld()
    {
        graphics = new GraphicsDeviceManager(this);
        GameSettings.Initialize();

        gameStateManager = new GameStateManager();
        inputHelper = new InputHelper();
        random = new R();
        screen = new Point(GraphicsDevice.Viewport.Width, GraphicsDevice.Viewport.Height);

    }
    //Method to load needed items
    protected override void LoadContent()
    {
        spriteBatch = new SpriteBatch(GraphicsDevice);
        assetLoader = new AssetLoader(Content);
        DrawTesting.Initialize(this.GraphicsDevice);
    }
    //Update the gamestatemanager and the testing class
    protected override void Update(GameTime gameTime)
    {
        gameStateManager.Update(gameTime);

        

        HandleInput();
    }
    //Handle input from the gamestatemanager
    protected void HandleInput()
    {
        inputHelper.Update();

        if (exited)
            this.Exit();
        gameStateManager.HandleInput(inputHelper);

        if (inputHelper.KeyPressed(Keys.F8))
            GameSettings.ApplySettings();
    }
    //Clear the screen, then draw the gamestatemanager with the right scale
    protected override void Draw(GameTime gameTime)
    {
        GraphicsDevice.Clear(Color.Green);

        spriteBatch.Begin(SpriteSortMode.Deferred, null, null, null, null, null, ScaleMatrix);
        gameStateManager.Draw(gameTime, spriteBatch);
        spriteBatch.End();
    }
}

