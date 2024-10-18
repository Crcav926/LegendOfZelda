using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System.Collections.Generic;
using LegendOfZelda;

//This projectile is for Goriya
public class Projectile
{
    private Vector2 position;
    private Vector2 velocity;
    private Texture2D texture;
    private List<Rectangle> frames;  // List of rectangles representing the frames
    private int currentFrame = 0;    // Current frame of the animation
    private float frameTime = 0.1f;  // Time to display each frame (in seconds)
    private float frameTimer = 0f;   // Timer to track time passed for animation
    private float speed = 200f;      // Speed of the projectile
    private ISprite sprite;
    public bool IsActive { get; private set; } = true;  // Track whether the projectile is active


    public Projectile(Vector2 startPosition, Vector2 direction, ISprite sprite)
    {
        this.position = startPosition;
        this.velocity = direction * speed;
        this.sprite = sprite;
    }

    public void Update(GameTime gameTime)
    {
        // Update position based on velocity
        position += velocity * (float)gameTime.ElapsedGameTime.TotalSeconds;
        sprite.Update(gameTime);
        // Mark as inactive if it goes off-screen
        if (position.X < 0 || position.X > 800 || position.Y < 0 || position.Y > 600)
        {
            IsActive = false;
        }
    }

    public void Draw(SpriteBatch spriteBatch)
    {
        // Draw only if the projectile is active
        if (IsActive)
        {
            // Calculate the destination rectangle with scaling
            Rectangle destinationRectangle = new Rectangle(
                (int)position.X,
                (int)position.Y,
                (int)(30),  
                (int)(30)  
            );

            sprite.Draw(spriteBatch, destinationRectangle, Color.White);
        }
    }
}