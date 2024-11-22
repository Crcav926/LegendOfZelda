using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System.Collections.Generic;
using System;
using LegendOfZelda;
using System.Diagnostics;
using LegendOfZelda.Sounds;
using LegendOfZelda.LinkMovement;
using static System.Net.Mime.MediaTypeNames;

namespace LegendOfZelda;
//Create based on Goriya
public class Dodongo : IEnemy, ICollideable
{
    private Vector2 velocity;            // Velocity for movement
    //moved to constants
    //private float speed = 2f;          // Movement speed
    //private Vector2 projectileOffset;    // Offset for throwing projectiles
    //private List<Projectile> projectiles; // List to keep track of projectiles
    private Random random = new Random();
    //moved to constants
    //private float throwCooldown = 2f;    // Time between throws
    private float throwTimer = 0f;       // Timer to track when to throw a projectile
    //moved to constants
    //private float directionChangeCooldown = 2f;  // Time between direction changes
    private float directionChangeTimer = 0f;     // Timer to track when to change direction
    private ISprite sprite;
    public Vector2 position { get; set; }
    private Rectangle destinationRectangle;
    private Boolean alive;

    private int hp;
    private readonly int Damage;
    public Boolean canTakeDamage { get; private set; }
    private double invincibilityTimer = .5;
    private double timeElapsed = 0;

    public bool HasDroppedItem { get; set; } = false;
    private ClassItems droppedItem;
    private ClassItems droppedKey;

    private bool keyStatus;
    DamageAnimation damageAnimation;
    public Dodongo(Vector2 Position, bool hasKey)
    {
        damageAnimation = new DamageAnimation();
        this.sprite = EnemySpriteFactory.Instance.CreateDownDodongoSprite();
        //projectiles = new List<Projectile>();
        this.position = Position;
        //destinationRectangle = new Rectangle((int)this.position.X, (int)this.position.Y, 60, 60);
        alive = true;
        ChangeDirection();
        // I did not change it here since it will cause extra issue.
        Damage = Constants.DodongoDamage;
        hp = Constants.DodongoHp;
        canTakeDamage = true;

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
                velocity = new Vector2(0, -Constants.DodongoSpeed);
                //projectileOffset = new Vector2(0, -Constants.GoriyaProjectileOffset);
                sprite = EnemySpriteFactory.Instance.CreateUpDodongoSprite();  // Switch to up-facing frames
                break;
            case 1: // Down
                velocity = new Vector2(0, Constants.DodongoSpeed);
                //projectileOffset = new Vector2(0, Constants.GoriyaProjectileOffset);
                sprite = EnemySpriteFactory.Instance.CreateDownDodongoSprite();
                break;
            case 2: // Left
                velocity = new Vector2(-Constants.DodongoSpeed2, 0);
                //projectileOffset = new Vector2(-Constants.GoriyaProjectileOffset, 0);
                sprite = EnemySpriteFactory.Instance.CreateLeftDodongoSprite();   // Switch to left-facing frames
                break;
            case 3: // Right
                velocity = new Vector2(Constants.DodongoSpeed2, 0);
                //projectileOffset = new Vector2(Constants.GoriyaProjectileOffset, 0);
                sprite = EnemySpriteFactory.Instance.CreateRightDodongoSprite();  // Switch to right-facing frames
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

        if (directionChangeTimer >= Constants.DarkNutChangeDirectionCooldown)
        {
            ChangeDirection();  // Choose a new random direction
            directionChangeTimer = 0f;  // Reset the direction change timer
        }

        // Update the timer for throwing projectiles
        //throwTimer += (float)gameTime.ElapsedGameTime.TotalSeconds;

        //if (throwTimer >= Constants.GoriyaThrowCooldown)
        //{
        //    // Throw a projectile in the direction Goriya is facing
        //    ThrowProjectile();
        //    throwTimer = 0f; // Reset the throw timer
        //}

        timeElapsed += gameTime.ElapsedGameTime.TotalSeconds;
        if (timeElapsed > invincibilityTimer)
        {
            canTakeDamage = true;
            timeElapsed = 0;
        }

        // Update and remove inactive projectiles
        //projectiles.RemoveAll(p => !p.IsActive);

        //foreach (Projectile projectile in projectiles)
        //{
        //    projectile.Update(gameTime);
        //}

        sprite.Update(gameTime);
        // Move Goriya
        position += velocity;

        // Check if Goriya hits the screen edges and reflect direction
        //not sure if this should use original or screen width/height.
        //Because of the walls, the goriyas will never hit the edge of the screen, so perhaps a better check is needed - TJ
        if (position.X <= 0 || position.X >= Constants.OriginalWidth - destinationRectangle.Width)
        {
            velocity.X *= -1; // Reflect on the X axis
        }

        if (position.Y <= 0 || position.Y >= Constants.OriginalHeight - destinationRectangle.Height)
        {
            velocity.Y *= -1; // Reflect on the Y axis
        }
        damageAnimation.Update(gameTime);
    }

    //private void ThrowProjectile()
    //{
    //    // Determine the direction to throw the projectile (based on velocity)
    //    Vector2 direction = velocity;
    //    if (direction != Vector2.Zero)
    //    {
    //        direction.Normalize(); // Ensure the direction is normalized

    //        // Create a new projectile at Goriya's position
    //        Vector2 projectileStartPosition = new Vector2(position.X + projectileOffset.X, position.Y + projectileOffset.Y);
    //        projectiles.Add(new Projectile(projectileStartPosition, direction, EnemySpriteFactory.Instance.CreateGoriyaProjectileSprite()));
    //    }
    //}

    public void Draw(SpriteBatch s)
    {
        // Use the current position for the destination rectangle
        if (alive)
        {
            Color color = damageAnimation.GetCurrentColor();
            //destinationRectangle = new Rectangle((int)position.X, (int)position.Y, Constants.GoriyaWidth, Constants.GoriyaHeight);
            if (velocity.X != 0)
            {
                destinationRectangle = new Rectangle((int)position.X, (int)position.Y, Constants.DodongoWidth1, Constants.DodongoHeight1);
            }
            else
            {
                destinationRectangle = new Rectangle((int)position.X, (int)position.Y, Constants.DodongoWidth2, Constants.DodongoHeight1);
            }
            sprite.Draw(s, destinationRectangle, color);
            // Draw all the projectiles
            //foreach (Projectile projectile in projectiles)
            //{
            //    projectile.Draw(s);
            //}
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
            if (velocity.X != 0)
            {
                hitbox = new Rectangle((int)position.X, (int)position.Y, Constants.DodongoHitboxWidth1, Constants.DodongoHitboxHeight1);
            } else
            {
                hitbox = new Rectangle((int)position.X, (int)position.Y, Constants.DodongoHitboxWidth2, Constants.DodongoHitboxHeight2);
            }
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
            SoundMachine.Instance.GetSound("enemyHurt").Play();
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
        if (!alive)
        {
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
                    //for now I'm using Rupees to test drops
                    String ItemTobeDroped = RoomObjectManager.Instance.GetItemName('B');
                    droppedItem = new ClassItems(position, ItemTobeDroped);
                    HasDroppedItem = true;
                    RoomObjectManager.Instance.staticItems.Add(droppedItem);
                }
            }
        }

    }
}
