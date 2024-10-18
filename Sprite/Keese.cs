using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Keese : DynamicSprite

{
    private Vector2 targetPosition;  // Target position for the sprite to jump to
    private Vector2 velocity;  // direction and speed
    private float speed = 100f;
    private Random random = new Random();
    private float frameTime = 0.1f; // Duration of each frame in seconds 
    private float frameTimer = 0f;  // Timer to track time since last frame change
    public Keese(SpriteBatch spriteBatch, Vector2 position, Texture2D textures, List<Rectangle> sourceRectangle) : base(spriteBatch, position, textures, sourceRectangle)
    {
        // Set the initial target position (I dont know so I randomlzie it here
        targetPosition = position;
        velocity = new Vector2(
            (float)(random.NextDouble() * 2 - 1),
            (float)(random.NextDouble() * 2 - 1)
        );
        // Normalize to ensure consistent speed in all directions
        velocity.Normalize();
        velocity *= speed;
    }

    public override void Update(GameTime gameTime)
    {
        // Update the frame timer for animation transitions
        frameTimer += (float)gameTime.ElapsedGameTime.TotalSeconds;

        // Only update the frame if enough time has passed (based on frameTime)
        if (frameTimer >= frameTime)
        {
            // Move to the next frame in the animation
            currentFrame++;
            if (currentFrame == totalFrames)
                currentFrame = 0;

            // Reset the frame timer
            frameTimer = 0f;
        }

        // Update position based on velocity
        position += velocity * (float)gameTime.ElapsedGameTime.TotalSeconds;

        // Check for collisions with screen edges and reflect velocity
        if (position.X <= 0 || position.X >= 800 - destinationRectangle.Width)
        {
            velocity.X *= -1; // Reverse X direction
        }

        if (position.Y <= 0 || position.Y >= 600 - destinationRectangle.Height)
        {
            velocity.Y *= -1; // Reverse Y direction
        }

        // Ensure the sprite stays within screen bounds
        position.X = MathHelper.Clamp(position.X, 0, 800 - destinationRectangle.Width);
        position.Y = MathHelper.Clamp(position.Y, 0, 600 - destinationRectangle.Height);
    }

    public override void Draw(SpriteBatch s)
    {
        // Use the current position for the destination rectangle, and size it appropriately
        destinationRectangle = new Rectangle((int)position.X, (int)position.Y, 60, 60);

        spriteBatch.GraphicsDevice.Clear(Color.CornflowerBlue);
        spriteBatch.Begin();
        // Draw the sprite using the updated position
        spriteBatch.Draw(textures, destinationRectangle, sourceRectangle[currentFrame], Color.White);
        spriteBatch.End();
    }

    public void TakeDamage() { }

    public void Attack() { }
}
