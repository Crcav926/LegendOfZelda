using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System.Collections.Generic;
using System;
using LegendOfZelda;

namespace LegendOfZelda;
public class Goriya : IEnemy, ICollideable
{
    private Vector2 velocity;            // Velocity for movement
    private float speed = 2f;          // Movement speed
    private Vector2 projectileOffset;    // Offset for throwing projectiles
    private List<Projectile> projectiles; // List to keep track of projectiles
    private List<Rectangle> upFrames;    // Frames when facing up
    private List<Rectangle> downFrames;  // Frames when facing down
    private List<Rectangle> leftFrames;  // Frames when facing left
    private List<Rectangle> rightFrames; // Frames when facing right
    private List<Rectangle> projectileFrames; // List of rectangles for the projectile animation
    private Random random = new Random();
    private float throwCooldown = 2f;    // Time between throws
    private float throwTimer = 0f;       // Timer to track when to throw a projectile
    private List<Rectangle> currentFrames; // Current frames for the current direction
    private float frameTime = 0.1f;
    private float frameTimer = 0f;
    private float directionChangeCooldown = 2f;  // Time between direction changes
    private float directionChangeTimer = 0f;     // Timer to track when to change direction
    private ISprite sprite;
    public Vector2 position { get; set; }
    private Rectangle destinationRectangle;
    private Boolean alive;

    public Goriya(Vector2 Position)
    {

        this.sprite = EnemySpriteFactory.Instance.CreateUpGoriyaSprite();
        projectiles = new List<Projectile>();
        this.position = Position;
        destinationRectangle = new Rectangle((int)this.position.X, (int)this.position.Y, 60, 60);
        alive = true;
        ChangeDirection();
    }

    //Change the direction of Goriya itself
    public void ChangeDirection()
    {
        // Chose a random direction (up, down, left, right)
        int direction = random.Next(0, 4);

        switch (direction)
        {
            case 0: // Up
                velocity = new Vector2(0, -speed);
                projectileOffset = new Vector2(0, -10);
                sprite = EnemySpriteFactory.Instance.CreateUpGoriyaSprite();  // Switch to up-facing frames
                break;
            case 1: // Down
                velocity = new Vector2(0, speed);
                projectileOffset = new Vector2(0, 10);
                sprite = EnemySpriteFactory.Instance.CreateDownGoriyaSprite();
                break;
            case 2: // Left
                velocity = new Vector2(-speed, 0);
                projectileOffset = new Vector2(-10, 0);
                sprite = EnemySpriteFactory.Instance.CreateLeftGoriyaSprite();   // Switch to left-facing frames
                break;
            case 3: // Right
                velocity = new Vector2(speed, 0);
                projectileOffset = new Vector2(10, 0);
                sprite = EnemySpriteFactory.Instance.CreateRightGoriyaSprite();  // Switch to right-facing frames
                break;
        }
    }

    public void Update(GameTime gameTime)
    {
        // Update the timer for direction change
        directionChangeTimer += (float)gameTime.ElapsedGameTime.TotalSeconds;

        if (directionChangeTimer >= directionChangeCooldown)
        {
            ChangeDirection();  // Choose a new random direction
            directionChangeTimer = 0f;  // Reset the direction change timer
        }

        // Update the timer for throwing projectiles
        throwTimer += (float)gameTime.ElapsedGameTime.TotalSeconds;

        if (throwTimer >= throwCooldown)
        {
            // Throw a projectile in the direction Goriya is facing
            ThrowProjectile();
            throwTimer = 0f; // Reset the throw timer
        }

        // Update and remove inactive projectiles
        projectiles.RemoveAll(p => !p.IsActive);

        foreach (Projectile projectile in projectiles)
        {
            projectile.Update(gameTime);
        }

        sprite.Update(gameTime);
        // Move Goriya
        position += velocity;

        // Check if Goriya hits the screen edges and reflect direction
        if (position.X <= 0 || position.X >= 800 - destinationRectangle.Width)
        {
            velocity.X *= -1; // Reflect on the X axis
        }

        if (position.Y <= 0 || position.Y >= 600 - destinationRectangle.Height)
        {
            velocity.Y *= -1; // Reflect on the Y axis
        }
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
            projectiles.Add(new Projectile(projectileStartPosition, direction, EnemySpriteFactory.Instance.CreateGoriyaProjectileSprite()));
        }
    }

    public void Draw(SpriteBatch s)
    {
        // Use the current position for the destination rectangle
        if (alive)
        {
            destinationRectangle = new Rectangle((int)position.X, (int)position.Y, 45, 40);

            sprite.Draw(s, destinationRectangle, Color.White);
            // Draw all the projectiles
            foreach (Projectile projectile in projectiles)
            {
                projectile.Draw(s);
            }
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
    public void takendamage() 
    {
        alive = false;
    }

    public void attack() { }
}
