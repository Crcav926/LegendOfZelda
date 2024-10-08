using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System.Collections.Generic;
using System;

public class Goriya : DynamicSprite
{
    private Vector2 velocity;            // Velocity for movement
    private float speed = 100f;          // Movement speed
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

    public Goriya(SpriteBatch spriteBatch, Vector2 position, Texture2D texture, List<Rectangle> upFrames, List<Rectangle> downFrames, List<Rectangle> leftFrames, List<Rectangle> rightFrames, List<Rectangle> projectileFrames)
        : base(spriteBatch, position, texture, upFrames)  // Use upFrames as the default for Goriyaa
    {
        this.upFrames = upFrames;
        this.downFrames = downFrames;
        this.leftFrames = leftFrames;
        this.rightFrames = rightFrames;
        this.projectileFrames = projectileFrames;
        this.currentFrames = upFrames;  // Default to up facing

        projectiles = new List<Projectile>();
        ChangeDirection();
    }

    //Change the direction of Goriya itself
    private void ChangeDirection()
    {
        // Chose a random direction (up, down, left, right)
        int direction = random.Next(0, 4);

        switch (direction)
        {
            case 0: // Up
                velocity = new Vector2(0, -speed);
                projectileOffset = new Vector2(0, -10);
                currentFrames = upFrames;  // Switch to up-facing frames
                break;
            case 1: // Down
                velocity = new Vector2(0, speed);
                projectileOffset = new Vector2(0, 10);
                currentFrames = downFrames;  // Switch to down-facing frames
                break;
            case 2: // Left
                velocity = new Vector2(-speed, 0);
                projectileOffset = new Vector2(-10, 0);
                currentFrames = leftFrames;  // Switch to left-facing frames
                break;
            case 3: // Right
                velocity = new Vector2(speed, 0);
                projectileOffset = new Vector2(10, 0);
                currentFrames = rightFrames;  // Switch to right-facing frames
                break;
        }

        // Reset frame index when switching directions
        currentFrame = 0;
    }

    public override void Update(GameTime gameTime)
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

        // Animate the Goriya sprite based on the current direction's frames
        frameTimer += (float)gameTime.ElapsedGameTime.TotalSeconds;
        if (frameTimer >= frameTime)
        {
            currentFrame++;
            if (currentFrame >= currentFrames.Count)
            {
                currentFrame = 0;  
            }
            frameTimer = 0f;
        }

        // Move Goriya
        position += velocity * (float)gameTime.ElapsedGameTime.TotalSeconds;

        // Check if Goriya hits the screen edges and reflect direction
        if (position.X <= 0 || position.X >= 800 - destinationRectangle.Width)
        {
            velocity.X *= -1; // Reflect on the X axis
        }

        if (position.Y <= 0 || position.Y >= 600 - destinationRectangle.Height)
        {
            velocity.Y *= -1; // Reflect on the Y axis
        }

        // Ensure Goriya stays within screen bounds
        position.X = MathHelper.Clamp(position.X, 0, 800 - destinationRectangle.Width);
        position.Y = MathHelper.Clamp(position.Y, 0, 600 - destinationRectangle.Height);
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
            projectiles.Add(new Projectile(projectileStartPosition, direction, textures, projectileFrames));
        }
    }

    public override void Draw(SpriteBatch s)
    {
        // Use the current position for the destination rectangle
        destinationRectangle = new Rectangle((int)position.X, (int)position.Y, 60, 60);

        spriteBatch.GraphicsDevice.Clear(Color.CornflowerBlue);
        spriteBatch.Begin();

        // Draw Goriya with the current frame from the active frames for the current direction
        spriteBatch.Draw(textures, destinationRectangle, currentFrames[currentFrame], Color.White);

        // Draw all the projectiles
        foreach (Projectile projectile in projectiles)
        {
            projectile.Draw(spriteBatch);
        }

        spriteBatch.End();
    }

    public override void takendamage() { }

    public override void attack() { }
}