using Microsoft.Xna.Framework;
using System;


class Unit : SpriteGameObject
{
    int damage, maxHealth, health, speed, range;
    Vector2 targetPosition;
    public Unit targetUnit;
    bool targeting;
    Player.Faction faction;

    public Unit(string id = "", int layer = 0) : base(id, layer)
    {
        speed = 200;
        range = 50;

    }

    public void SetTargetUnit(Unit targetUnit)
    {
        this.targetPosition = targetUnit.Position;
        this.targetUnit = targetUnit;
    }

    public void SetTargetPosition(Vector2 targetPosition)
    {
        this.targetUnit = null;
        this.targetPosition = targetPosition;
        velocity = new Vector2(-(Position.X - targetPosition.X) / (float)Math.Sqrt(Math.Pow(Position.X - targetPosition.X, 2) + Math.Pow(Position.Y - targetPosition.Y, 2)) * speed,
                               -(Position.Y - targetPosition.Y) / (float)Math.Sqrt(Math.Pow(Position.X - targetPosition.X, 2) + Math.Pow(Position.Y - targetPosition.Y, 2)) * speed);
    }

    public override void HandleInput(InputHelper ih)
    {
        if (faction == GameData.player.GetFaction && ih.LeftButtonPressed() && BoundingBox.Contains((new Point((int)GameData.Cursor.Position.X, (int)GameData.Cursor.Position.Y))))
        {
            targeting = true;
        }

        if(targeting && ih.LeftButtonPressed())
        {

        } 
    }

    public override void Update(GameTime gameTime)
    {
        if(targetUnit != null)
        {
            if ((int)Math.Sqrt(Math.Pow(Position.X - targetUnit.Position.X, 2) + Math.Pow(Position.Y - targetUnit.Position.Y, 2)) > range)
            {
                velocity = new Vector2(-(Position.X - targetUnit.Position.X) / (float)Math.Sqrt(Math.Pow(Position.X - targetUnit.Position.X, 2) + Math.Pow(Position.Y - targetUnit.Position.Y, 2)) * speed,
                                       -(Position.Y - targetUnit.Position.Y) / (float)Math.Sqrt(Math.Pow(Position.X - targetUnit.Position.X, 2) + Math.Pow(Position.Y - targetUnit.Position.Y, 2)) * speed);
            }
            
            else
            {
                velocity = new Vector2(0, 0);
            }
        }

        else if(targetPosition != null)
        {
            if((int)Math.Sqrt(Math.Pow(Position.X - targetPosition.X, 2) + Math.Pow(Position.Y - targetPosition.Y, 2)) < 5)
            {
                targetPosition = Position;
                velocity = Vector2.Zero;
            }
        }
        base.Update(gameTime);
    }

    
}
