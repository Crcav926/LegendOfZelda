using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System.Collections.Generic;
using static System.Formats.Asn1.AsnWriter;

public class Fireball
{
    private Vector2 position;
    private Vector2 velocity;
    private Texture2D texture;
    private List<Rectangle> frames;
    private int currentFrame = 0;    // Current frame of  fireball 
    private float frameTime = 0.1f;  // Time to display..
    private float frameTimer = 0f;   // Timer to track time passed for animation
    private float speed = 150f;
    public bool IsActive { get; private set; } = true;  // Track whether the fireball is active
    // Try to make the fireball bigger and bigger 
    private float scale = 3.0f;
    //private float growthRate = 0.02f;
    //private float maxScale = 5.0f;

    public Fireball(Vector2 startPosition, Vector2 direction, Texture2D texture, List<Rectangle> frames)
    {
        this.position = startPosition;
        this.velocity = direction * speed;
        this.texture = texture;
        this.frames = frames;
    }

    public void Update(GameTime gameTime)
    {
        // Update the fireball position based on velocity
        position += velocity * (float)gameTime.ElapsedGameTime.TotalSeconds;

        // Animate the fireball
        frameTimer += (float)gameTime.ElapsedGameTime.TotalSeconds;
        if (frameTimer >= frameTime)
        {
            currentFrame++;
            if (currentFrame >= frames.Count)
            {
                currentFrame = 0;
            }
            frameTimer = 0f;
        }

        // Increase the size of the fireball
        //scale += growthRate;

        // Mark fireball as inactive if it reaches maximum scale
        //if (scale >= maxScale)
        //{
        //    IsActive = false;
        //}

        // Mark fireball as inactive if it goes off-screen
        if (position.X < 0 || position.X > 800 || position.Y < 0 || position.Y > 600)
        {
            IsActive = false;
        }
    }

    public void Draw(SpriteBatch spriteBatch)
    {
        // Draw the fireball only if it is active
        if (IsActive)
        {
            Rectangle sourceRectangle = frames[currentFrame];  // Get the current frame
            Rectangle destinationRectangle = new Rectangle(
                (int)position.X,
                (int)position.Y,
                (int)(sourceRectangle.Width * scale),
                (int)(sourceRectangle.Height * scale)
            );

            spriteBatch.Draw(texture, destinationRectangle, sourceRectangle, Color.White);
        }
    }
}