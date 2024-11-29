using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System.Collections.Generic;
using System;
using LegendOfZelda;
using System.Diagnostics;
using LegendOfZelda.Sounds;
using LegendOfZelda.LinkMovement;

namespace LegendOfZelda;
public class Goriya : IEnemy, ICollideable
{
    private Vector2 velocity;            // Velocity for movement
    private Vector2 projectileOffset;    // Offset for throwing projectiles
    private List<Projectile> projectiles; // List to keep track of projectiles
    private Random random = new Random();
    private float throwTimer = 0f;       // Timer to track when to throw a projectile
    private float directionChangeTimer = 0f;     // Timer to track when to change direction
    private ISprite sprite;
    public Vector2 position { get; set; }
    private Rectangle destinationRectangle;
    private Boolean alive;

    private int hp;
    public Boolean canTakeDamage { get; private set; }
    private double invincibilityTimer = .5;
    private double timeElapsed = 0;

    public bool HasDroppedItem { get; set; } = false;
    private ClassItems droppedItem;

    private bool keyStatus;
    DamageAnimation damageAnimation;
    public Goriya(Vector2 Position, bool hasKey)
    {
        damageAnimation = new DamageAnimation();
        this.sprite = EnemySpriteFactory.Instance.CreateUpGoriyaSprite();
        projectiles = new List<Projectile>();
        this.position = Position;
        alive = true;
        ChangeDirection();

        hp = 3;
        canTakeDamage = true;
        //see my message in Gel.cs about this - TJ
        if (hasKey == null)
        {
            keyStatus = false;
        }
        else if (hasKey)
        {
            keyStatus = true;
        }
        else
        {
            keyStatus = false;
        }
    }

    //Change the direction of Goriya itself
    public void ChangeDirection()
    {
        // Chose a random direction (up, down, left, right)
        int direction = random.Next(0, 4);

        switch (direction)
        {
            case 0: // Up
                velocity = new Vector2(0, -Constants.GoriyaSpeed);
                projectileOffset = new Vector2(0, -Constants.GoriyaProjectileOffset);
                sprite = EnemySpriteFactory.Instance.CreateUpGoriyaSprite();  // Switch to up-facing frames
                break;
            case 1: // Down
                velocity = new Vector2(0, Constants.GoriyaSpeed);
                projectileOffset = new Vector2(0, Constants.GoriyaProjectileOffset);
                sprite = EnemySpriteFactory.Instance.CreateDownGoriyaSprite();
                break;
            case 2: // Left
                velocity = new Vector2(-Constants.GoriyaSpeed, 0);
                projectileOffset = new Vector2(-Constants.GoriyaProjectileOffset, 0);
                sprite = EnemySpriteFactory.Instance.CreateLeftGoriyaSprite();   // Switch to left-facing frames
                break;
            case 3: // Right
                velocity = new Vector2(Constants.GoriyaSpeed, 0);
                projectileOffset = new Vector2(Constants.GoriyaProjectileOffset, 0);
                sprite = EnemySpriteFactory.Instance.CreateRightGoriyaSprite();  // Switch to right-facing frames
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
        // Update the timer for direction change
        directionChangeTimer += (float)gameTime.ElapsedGameTime.TotalSeconds;

        if (directionChangeTimer >= Constants.GoriyaChangeDirectionCooldown)
        {
            ChangeDirection();  // Choose a new random direction
            directionChangeTimer = 0f;  // Reset the direction change timer
        }

        // Update the timer for throwing projectiles
        throwTimer += (float)gameTime.ElapsedGameTime.TotalSeconds;

        if (throwTimer >= Constants.GoriyaThrowCooldown)
        {
            // Throw a projectile in the direction Goriya is facing
            ThrowProjectile();
            throwTimer = 0f; // Reset the throw timer
        }

        timeElapsed += gameTime.ElapsedGameTime.TotalSeconds;
        if (timeElapsed > invincibilityTimer)
        {
            canTakeDamage = true;
            timeElapsed = 0;
        }

        sprite.Update(gameTime);
        // Move Goriya
        position += velocity;
        damageAnimation.Update(gameTime);
    }

    private void ThrowProjectile()
    {
        // Determine the direction to throw the projectile (based on velocity)
        Vector2 direction = velocity;
        if (direction != Vector2.Zero)
        {
            direction.Normalize(); // Ensure the direction is normalized

            // Create a new projectile at Goriya's position
            Vector2 projectileStartPosition = new Vector2(position.X + projectileOffset.X, position.Y + projectileOffset.Y);
            RoomObjectManager.Instance.addProjectile(new Projectile(projectileStartPosition, direction, EnemySpriteFactory.Instance.CreateGoriyaProjectileSprite()));
        }
    }

    public void Draw(SpriteBatch s)
    {
        // Use the current position for the destination rectangle
        if (alive)
        {
            Color color = damageAnimation.GetCurrentColor();
            destinationRectangle = new Rectangle((int)position.X, (int)position.Y, Constants.GoriyaWidth, Constants.GoriyaHeight);

            sprite.Draw(s, destinationRectangle, color);
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
            hitbox = new Rectangle((int)position.X, (int)position.Y, Constants.GoriyaHitboxWidth, Constants.GoriyaHitboxHeight);
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
        if (canTakeDamage)
        {
            hp -= damage;
            SoundMachine.Instance.PlaySound("enemyHurt");
            damageAnimation.StartDamageEffect();
            if (hp <= 0)
            {
                alive = false;
            }
            invulnerable();
        }
    }

    public void Attack() { }
    public Boolean isAlive() { return alive; }

    public void DropItem()
    {
        if (!alive) { 
            Debug.WriteLine("DropItem called: Item drop initialized");
           
            if (keyStatus)
            {
                Debug.WriteLine("Key dropped!");
                droppedItem = new ClassItems(position, "Key");
                RoomObjectManager.Instance.staticItems.Add(droppedItem);
            }
            else
            {
                Debug.WriteLine("DropItem called: Item drop initialized");

                String roomDrop = RoomObjectManager.Instance.GetKey();
                if (roomDrop != null)
                {
                    Debug.WriteLine("Counter based key dropped");
                    ClassItems droppedKey = new ClassItems(position, roomDrop);
                    RoomObjectManager.Instance.staticItems.Add(droppedKey);
                }
                else
                {
                    //The single letter indicates which DropTable GetItemName will get an item name from.
                    String ItemTobeDroped = RoomObjectManager.Instance.GetItemName('B');
                    droppedItem = new ClassItems(position, ItemTobeDroped);
                    HasDroppedItem = true;
                    RoomObjectManager.Instance.staticItems.Add(droppedItem);
                }
            }
        }

    }
}
