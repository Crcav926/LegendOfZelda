using LegendOfZelda;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using LegendOfZelda.Sounds;

namespace LegendOfZelda;
public class Gel : IEnemy, ICollideable

{
    private Vector2 targetPosition;  // Target position for the sprite to jump to
    private float jumpSpeed = 50f;   // Speed of the jump
    private float jumpCooldown = 1f; // Cooldown time in seconds between jumps
    private float jumpTimer = 0f;    // Timer to track the time since the last jump
    private Random random = new Random();
    private float frameTimer = 0f;  // Timer to track time since last frame change
    public Vector2 position { get; set; }
    private Rectangle destinationRectangle;
    private ISprite sprite;
    private Boolean alive;
    private int hp;
    public Boolean canTakeDamage { get; private set; }
    private double invincibilityTimer = 1.5;
    private double timeElapsed = 0;

    public bool HasDroppedItem { get; set; } = false;
    private ClassItems droppedItem;

    public Gel(Vector2 Position)
    {
        // Set the initial target position
        targetPosition = Position;
        this.position = Position;
        destinationRectangle = new Rectangle((int)position.X, (int)position.Y, 32, 60);
        sprite = EnemySpriteFactory.Instance.CreateGelSprite();
        alive = true;
        hp = 1;
        canTakeDamage = true;
    }
    // TODO: Make Gel change direction
    public void ChangeDirection()
    {
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
        // Update the frame timer
        frameTimer += (float)gameTime.ElapsedGameTime.TotalSeconds;
        //????????????????????????
        // Update the jump timer
        jumpTimer += (float)gameTime.ElapsedGameTime.TotalSeconds;
        // If the sprite is close enough to the target position, wait for the cooldown to set a new target position
        if (Vector2.Distance(position, targetPosition) < 1f)
        {
            // If the cooldown has passed, set a new target position
            if (jumpTimer >= jumpCooldown)
            {
                // Set a new target position in a small area around the current position
                // I limit the jump to a small range (50 pixels) 
                float jumpRange = 50f;
                targetPosition = new Vector2(
                    position.X + random.Next(-(int)jumpRange, (int)jumpRange),
                    position.Y + random.Next(-(int)jumpRange, (int)jumpRange)
                );

                // Reset the timer for the next jump
                jumpTimer = 0f;
            }
        }

        timeElapsed += gameTime.ElapsedGameTime.TotalSeconds;
        if (timeElapsed > invincibilityTimer)
        {
            canTakeDamage = true;
            timeElapsed = 0;
        }

        // Move towards the target position smoothly
        Vector2 direction = targetPosition - position;

        // Ifdirection != 0, normalize it and move the sprite
        if (direction.Length() > 0)
        {
            direction.Normalize();
            position += direction * jumpSpeed * (float)gameTime.ElapsedGameTime.TotalSeconds;
        }
        sprite.Update(gameTime);
    }

    public void Draw(SpriteBatch s)
    {
        // Use the current position for the destination rectangle, and size it appropriately
        destinationRectangle = new Rectangle((int)position.X, (int)position.Y, 32, 60);
        sprite.Draw(s, destinationRectangle, Color.White);

        if (HasDroppedItem)
        {
            //this should only be called when the droppedItem has been assigned a value...
            droppedItem.Draw(s);
        }
    }
    public Vector2 getPosition()
    {
        return this.position;
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
    public void TakeDamage(int damage)
    {
        hp -= damage;
        SoundMachine.Instance.GetSound("enemyHurt").Play();

        if (hp <= 0)
        {
            alive = false;
        }
    }

    public void Attack() { }
    public Boolean isAlive() { return alive; }

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
