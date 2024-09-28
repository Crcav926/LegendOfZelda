using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System.Collections.Generic;

public class Aquamentus : DynamicSprite
{
    private Vector2 velocity;
    private float speed = 80f;
    private List<Fireball> fireballs;    // List to track active fireballs
    private List<Rectangle> rightFrames;
    private List<Rectangle> projectileFrames; // List of rectangles for fireball animation
    private float throwCooldown = 3f;    // Time between fireball throws
    private float throwTimer = 0f;       // Timer to track when to throw a fireball
    private float frameTime = 0.1f;
    private float frameTimer = 0f;
    private float minX;  // Left boundary for movement
    private float maxX;  // Right boundary for movement
    public Aquamentus(SpriteBatch spriteBatch, Vector2 position, Texture2D texture, List<Rectangle> rightFrames, List<Rectangle> projectileFrames)
        : base(spriteBatch, position, texture, rightFrames)  // Use rightFrames as default for Aquamentus
    {
        this.rightFrames = rightFrames;
        this.projectileFrames = projectileFrames;
        fireballs = new List<Fireball>();
        velocity = new Vector2(speed, 0);  // ontly Horizontal movement
        // Define the movement range (minX and maxX)
        minX = position.X - 10;
        maxX = position.X + 100;
    }

    public override void Update(GameTime gameTime)
    {
        // Update the timer for throwing fireballs
        throwTimer += (float)gameTime.ElapsedGameTime.TotalSeconds;

        if (throwTimer >= throwCooldown)
        {
            // Throw 3 fireballs in different directions
            ThrowFireball(new Vector2(-1, -1));
            ThrowFireball(new Vector2(-1, 0));
            ThrowFireball(new Vector2(-1, 1));
            throwTimer = 0f;
        }

        // Update and remove inactive fireballs
        fireballs.RemoveAll(f => !f.IsActive);

        foreach (Fireball fireball in fireballs)
        {
            fireball.Update(gameTime);
        }

        // Animate the sprite
        frameTimer += (float)gameTime.ElapsedGameTime.TotalSeconds;
        if (frameTimer >= frameTime)
        {
            currentFrame++;
            if (currentFrame >= rightFrames.Count)
            {
                currentFrame = 0;
            }
            frameTimer = 0f;
        }

        // Move Aquamentus horizontally
        position += velocity * (float)gameTime.ElapsedGameTime.TotalSeconds;

        // Reverse direction if Aquamentus reach the boundary
        if (position.X <= minX || position.X >= maxX)
        {
            velocity.X *= -1;
        }

        // Ensure Aquamentus stays within screen bounds
        position.X = MathHelper.Clamp(position.X, 0, 800 - destinationRectangle.Width);
        position.Y = MathHelper.Clamp(position.Y, 0, 600 - destinationRectangle.Height);
    }

    private void ThrowFireball(Vector2 direction)
    {
        // Create a new fireball at Aquamentus's position and add it to the list
        Vector2 fireballStartPosition = new Vector2(position.X + 10, position.Y + 30); // Adjust the offset
        fireballs.Add(new Fireball(fireballStartPosition, direction, textures, projectileFrames));
    }

    public override void Draw()
    {
        destinationRectangle = new Rectangle((int)position.X, (int)position.Y, 100, 100);

        spriteBatch.GraphicsDevice.Clear(Color.CornflowerBlue);
        spriteBatch.Begin();

        spriteBatch.Draw(textures, destinationRectangle, rightFrames[currentFrame], Color.White);

        // Draw all the fireballs
        foreach (Fireball fireball in fireballs)
        {
            fireball.Draw(spriteBatch);
        }

        spriteBatch.End();
    }

    public override void takendamage() { }

    public override void attack() { }
}