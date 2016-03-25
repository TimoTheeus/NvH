using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework;

class Tile : SpriteGameObject
{
    public Point gridPosition;
    protected List<Timer> buildTimers;
    protected List<SpriteGameObject> objectsToBuild;

    public Tile(string assetName="hexagonTile", string id="tile") : base(assetName, 0, id, 1)
    {
        this.Origin = this.sprite.Center;
        buildTimers = new List<Timer>();
        objectsToBuild = new List<SpriteGameObject>();
    }

    public override void HandleInput(InputHelper ih)
    {
        if (GameData.Cursor.CurrentTile == this && ih.LeftButtonPressed() && GameData.Cursor.HasClickedTile)
        {
            LeftButtonAction();
        }
    }
    public override void Update(GameTime gameTime)
    {
        base.Update(gameTime);
        for(int i = 0; i < buildTimers.Count; i++)
        {
            buildTimers[i].Update(gameTime);
            if (buildTimers[i].Ended)
            {
                if (objectsToBuild[i] is Unit)
                {
                    objectsToBuild[i].Position= new Vector2(this.Position.X + this.Sprite.Width / 2 - objectsToBuild[i].Sprite.Width / 2, this.Position.Y + this.Sprite.Height / 2);
                    GameData.LevelObjects.Add(objectsToBuild[i]);
                }
                else { GameData.LevelGrid.replaceTile(this, objectsToBuild[i] as Tile); }
                buildTimers.Remove(buildTimers[i]);
                objectsToBuild.Remove(objectsToBuild[i]);
            }
        }
    }

    public virtual void LeftButtonAction()
    {
        GameData.LevelObjects.Add(new TileMenu(this));
    }

    public virtual void Destroy()
    {
    }
    public void AddTimer(Timer timer, SpriteGameObject objectToBuild)
    {
        buildTimers.Add(timer);
        objectsToBuild.Add(objectToBuild);
    }

}

