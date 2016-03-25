using Microsoft.Xna.Framework;
using System;
using Microsoft.Xna.Framework.Graphics;

class Unit : SpriteGameObject
{
    float damage, maxHealth, health, speed, range,attackSpeed;
    Vector2 targetPosition;
    public Unit targetUnit;
    bool selected;
    Timer attackTimer;
    Player.Faction faction;
    HealthBar healthBar;

    public float AttackSpeed
    {
        get { return attackSpeed; }
        set { attackSpeed = value; }
    }
    public float Damage
    {
        get { return damage; }
        set { damage = value; }
    }
    public float Speed
    {
        get { return speed;  }
        set { speed = value; }
    }
    public float Range
    {

        get { return range; }
        set { range = value; }
    }
    public float Health
    {

        get { return health; }
        set { health = value; }
    }
    public Unit(string assetName="",string id = "", int layer = 0) : base(assetName,0, id,layer)
    {
        this.Origin = this.sprite.Center;
        speed = 200;
        range = 50;
        maxHealth = 100;
        damage = 20;
        this.health = maxHealth;
        selected = false;
        attackSpeed = 1;
        attackTimer = new Timer(this.AttackSpeed);
        healthBar = new HealthBar(new Vector2(position.X, position.Y + sprite.Height / 2 + 10));
    }

    public override void HandleInput(InputHelper ih)
    {
        Point mousePoint = new Point((int)(ih.MousePosition.X + GameWorld.Camera.Pos.X), (int)(ih.MousePosition.Y + GameWorld.Camera.Pos.Y));

        if (selected)
        {
            GameData.Cursor.HasClickedTile = false;
        }
        if (BoundingBox.Contains(mousePoint))
        {
            if (ih.LeftButtonPressed())
            {
                selected = true;
            }
        }
        else if (!this.BoundingBox.Contains(mousePoint))
        {
            if (ih.LeftButtonPressed())
            {
                selected = false;
            }
        }
        if (selected)
        {
            if (ih.RightButtonPressed())
            {
                for(int i = 0; i < GameData.Units.Objects.Count; i++)
                {
                    if(GameData.Units.Objects[i] is Unit)
                    {
                        Unit unit = GameData.Units.Objects[i] as Unit;
                        if (unit.BoundingBox.Contains(mousePoint))
                        {
                            targetUnit = unit;
                            continue;
                        }
                        else targetUnit = null;
                    }
                }
                if(targetUnit== null)
                {
                    targetPosition = GameData.Cursor.CurrentTile.Position;
                }
            }
        }
    }

    public override void Update(GameTime gameTime)
    {
        attackTimer.Update(gameTime);
        if (targetUnit != null)
        {
            MoveToUnit();
        }

        else if (targetPosition != Vector2.Zero)
        {
            MoveToTile();
        }
        base.Update(gameTime);
        healthBar.Update(new Vector2(position.X, position.Y - sprite.Height / 2 - 10));
        healthBar.ChangeHealth((health / maxHealth) * 2);
    }

    public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
    {
        healthBar.Draw(gameTime, spriteBatch);
        base.Draw(gameTime, spriteBatch);
    }

    protected void MoveToTile()
    {
        float differenceXPos = Math.Abs(targetPosition.X - this.GlobalPosition.X);
        float differenceYPos = Math.Abs(targetPosition.Y - this.GlobalPosition.Y);
        float xvelocity = 0;
        float yvelocity = 0;
        double angle = 0;
        float marginForError = 2;
        angle = Math.Atan((differenceXPos / differenceYPos));
        xvelocity = (float)(Math.Sin(angle) * this.Speed);
        yvelocity = (float)(Math.Cos(angle) * this.Speed);
        if (targetPosition.X >= this.GlobalPosition.X)
        {
            if (targetPosition.Y < this.GlobalPosition.Y)
            {
                this.Velocity = new Vector2(xvelocity, -yvelocity);
            }
            else if (targetPosition.Y > this.GlobalPosition.Y)
            {
                this.Velocity = new Vector2(xvelocity, yvelocity);
            }
        }
        else if (targetPosition.X <= this.GlobalPosition.X)
        {
            if (targetPosition.Y < this.GlobalPosition.Y)
            {
                this.Velocity = new Vector2(-xvelocity, -yvelocity);
            }
            else if (targetPosition.Y > this.GlobalPosition.Y)
            {
                this.Velocity = new Vector2(-xvelocity, yvelocity);
            }
        }
        if ((differenceXPos < marginForError && differenceXPos > -marginForError) &&(differenceYPos< marginForError && differenceYPos>-marginForError))
        {
            targetPosition = Vector2.Zero;
            this.Velocity = Vector2.Zero;
        }
       
    }
    protected void MoveToUnit()
    {
        float differenceXPos = Math.Abs(targetUnit.Position.X - this.GlobalPosition.X);
        float differenceYPos = Math.Abs(targetUnit.Position.Y - this.GlobalPosition.Y);
        float xvelocity = 0;
        float yvelocity = 0;
        double angle = 0;
        angle = Math.Atan((differenceXPos / differenceYPos));
        xvelocity = (float)(Math.Sin(angle) * this.Speed);
        yvelocity = (float)(Math.Cos(angle) * this.Speed);
        if (targetUnit.Position.X >= this.GlobalPosition.X)
        {
            if (targetUnit.Position.Y < this.GlobalPosition.Y)
            {
                this.Velocity = new Vector2(xvelocity, -yvelocity);
            }
            else if (targetUnit.Position.Y > this.GlobalPosition.Y)
            {
                this.Velocity = new Vector2(xvelocity, yvelocity);
            }
        }
        else if (targetUnit.Position.X <= this.GlobalPosition.X)
        {
            if (targetUnit.Position.Y < this.GlobalPosition.Y)
            {
                this.Velocity = new Vector2(-xvelocity, -yvelocity);
            }
            else if (targetUnit.Position.Y > this.GlobalPosition.Y)
            {
                this.Velocity = new Vector2(-xvelocity, yvelocity);
            }
        }
        if ((differenceXPos < Range && differenceXPos > -Range) && (differenceYPos < Range && differenceYPos > -Range))
        {
            this.Velocity = Vector2.Zero;
            if (attackTimer.Ended)
            {
                Attack();
            }
        }

    }
    protected void Attack()
    {
        targetUnit.DealDamage(this.Damage,this);
        if (targetUnit.Health <= 0)
            targetUnit = null;
        attackTimer.Reset();
    }

    public void DealDamage(float amount,GameObject attacker)
    {
        this.Health -= amount;
        if (Health <= 0)
        {
            Die();
        }
        if(targetUnit== null)
        {
            if(attacker is Unit)
            {
                Unit target = attacker as Unit;
                targetUnit = target;
            }
        }
    }
    protected virtual void Die()
    {
        GameData.Units.Remove(this);
    }
}

