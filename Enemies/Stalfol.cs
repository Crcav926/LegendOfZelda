using LegendOfZelda;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace LegendOfZelda;
public class Stalfol : IEnemy, ICollideable

{
    private Vector2 velocity;            // Velocity for movement
    private float speed = 2f;          // Movement speed
    private Random random = new Random();
    private float directionChangeCooldown = 2f;  // Time between direction changes
    private float directionChangeTimer = 0f;     // Timer to track direction changes
    private ISprite sprite;
    public Vector2 position { get; set; }
    private Rectangle destinationRectangle;
    private Boolean alive;
    private int hp;
    private readonly Dictionary<string, int> swordDamage;
    public Boolean canTakeDamage { get; private set; }
    private double invincibilityTimer = 1.5;
    private double timeElapsed = 0;

    public bool HasDroppedItem { get; set; } = false;
    private ClassItems droppedItem;

    public Stalfol(Vector2 Position, bool hasKey)
    {
        this.position = Position;
        sprite = EnemySpriteFactory.Instance.CreateStalfolSprite();
        ChangeDirection();
        destinationRectangle = new Rectangle((int)this.position.X, (int)this.position.Y, 60, 60);
        alive = true;

        hp = 2;
        swordDamage = new Dictionary<string, int>
        {
            { "WOOD", 1 },
            { "WHITE", 2 },
            { "MAGIC", 2 }
        };
        canTakeDamage = true;
    }

    public void ChangeDirection()
    {
        // Choose a random direction (up, down, left, right)
        int direction = random.Next(0, 4);

        switch (direction)
        {
            case 0:
                velocity = new Vector2(0, -speed);
                break;
            case 1:
                velocity = new Vector2(0, speed);
                break;
            case 2:
                velocity = new Vector2(-speed, 0);
                break;
            case 3:
                velocity = new Vector2(speed, 0);
                break;
        }
    }
    public void invulnerable()
    {
        if (canTakeDamage)
        {
            canTakeDamage = false;
        }

    }
    public void Update(GameTime gameTime)
    {
        // Update the direction change timer
        directionChangeTimer += (float)gameTime.ElapsedGameTime.TotalSeconds;

        // If it's time to change direction
        if (directionChangeTimer >= directionChangeCooldown)
        {
            // Choose a new random direction and reset the timer
            ChangeDirection(); 
            directionChangeTimer = 0f; 
        }
        timeElapsed += gameTime.ElapsedGameTime.TotalSeconds;

        //if we're invincible undo that
        if (timeElapsed > invincibilityTimer)
        {
            canTakeDamage = true;
            timeElapsed = 0;
        }

        sprite.Update(gameTime);
        // Update position based on velocity
        position += velocity;
        //angle need caculate
        //if the skull hits the screen edges and reflect its direction?????
        if (position.X <= 0 || position.X >= 800 - destinationRectangle.Width)
        {
            velocity.X *= -1; // Reflect on the X axis
        }

        if (position.Y <= 0 || position.Y >= 600 - destinationRectangle.Height)
        {
            velocity.Y *= -1; // Reflect on the Y axis
        }
    }

    public void Draw(SpriteBatch s)
    {
        if (alive)
        {
            // Use the current position for the destination rectangle, and size it appropriately
            destinationRectangle = new Rectangle((int)position.X, (int)position.Y, 40, 40);
            sprite.Draw(s, destinationRectangle, Color.White);
        }
        if (HasDroppedItem)
        {
            //this should only be called when the droppedItem has been assigned a value...
            droppedItem.Draw(s);
        }
    }
    public Rectangle getHitbox()
    {
        Rectangle hitbox = new Rectangle(0, 0, 0, 0);
        //put data in the the hitbox
        if (alive)
        {
            hitbox = new Rectangle((int)position.X, (int)position.Y, 45, 40);
        }
        //Debug.WriteLine("Hitbox of block retrieved!");
        //Debug.WriteLine($"Rectangle hitbox:{destinationRectangle.X} {destinationRectangle.Y} {destinationRectangle.Width} {destinationRectangle.Height}");
        //return it
        return hitbox;
    }
    public String getCollisionType()
    {
        return "Enemy";
    }
    public Boolean isAlive() { return alive; }
    public void TakeDamage(int damage)
    {
        if ( canTakeDamage)
        {
            Debug.WriteLine($"{damage} damage done to {this.GetType().Name}");
            hp -= damage;

            if (hp <= 0)
            {
                alive = false;
            }
            invulnerable();
        }
    }
    public void Attack() { }

    public void DropItem()
    {
        if (!alive)
        {
            Debug.WriteLine("DropItem called: Item drop initialized");
            //for now I'm using Rupees to test drops
            String ItemTobeDroped = RoomObjectManager.Instance.GetItemName('C');
            droppedItem = new ClassItems(position, ItemTobeDroped);
            HasDroppedItem = true;
            RoomObjectManager.Instance.staticItems.Add(droppedItem);
        }
    }
}
