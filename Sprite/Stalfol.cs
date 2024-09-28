using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Stalfol : DynamicSprite

{
    private Vector2 velocity;            // Velocity for movement
    private float speed = 100f;          // Movement speed
    private Vector2 swordOffset;         // Offset of the sword relative to the skull
    private List<Rectangle> swordFrames;
    private Random random = new Random();
    private int currentSwordFrame = 0;   // Current frame for the sword
    private float swordFrameTime = 0.1f; // Duration of each sword swing frame
    private float swordFrameTimer = 0f;  // Timer for sword animation
    private float directionChangeCooldown = 2f;  // Time between direction changes
    private float directionChangeTimer = 0f;     // Timer to track direction changes
    private float frameTime = 0.1f;
    private float frameTimer = 0f;

    public Stalfol(SpriteBatch spriteBatch, Vector2 position, Texture2D textures, List<Rectangle> sourceRectangle, List<Rectangle> swordFrames) : base(spriteBatch, position, textures, sourceRectangle)
    {
        // Set the initial target position (it should be random)
        this.swordFrames = swordFrames;

        // Set the initial sword offset

        swordOffset = new Vector2(10, 0);
        ChangeDirection();
    }

    private void ChangeDirection()
    {
        // Choose a random direction (up, down, left, right)
        int direction = random.Next(0, 4);

        switch (direction)
        {
            case 0:
                velocity = new Vector2(0, -speed);
                // swings upward
                swordOffset = new Vector2(0, -60);
                break;
            case 1:
                velocity = new Vector2(0, speed);
                // swings downward
                swordOffset = new Vector2(0, 60);
                break;
            case 2:
                velocity = new Vector2(-speed, 0);
                // swings left
                swordOffset = new Vector2(-60, 0);
                break;
            case 3:
                velocity = new Vector2(speed, 0);
                // swings right
                swordOffset = new Vector2(60, 0);
                break;
        }
    }

    public override void Update(GameTime gameTime)
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

        // Animate the sword swing
        swordFrameTimer += (float)gameTime.ElapsedGameTime.TotalSeconds;
        if (swordFrameTimer >= swordFrameTime)
        {
            currentSwordFrame++;
            if (currentSwordFrame >= swordFrames.Count)
            {
                currentSwordFrame = 0; // Loop back to the first sword frame
            }
            swordFrameTimer = 0f;
        }

        // Animate the skull
        frameTimer += (float)gameTime.ElapsedGameTime.TotalSeconds;
        if (frameTimer >= frameTime)
        {
            currentFrame++;
            if (currentFrame >= totalFrames)
            {
                currentFrame = 0; // Loop back to the first skull frame
            }
            frameTimer = 0f;
        }

        // Update position based on velocity
        position += velocity * (float)gameTime.ElapsedGameTime.TotalSeconds;
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

        // Ensure the skull stays within screen bounds
        position.X = MathHelper.Clamp(position.X, 0, 800 - destinationRectangle.Width);
        position.Y = MathHelper.Clamp(position.Y, 0, 600 - destinationRectangle.Height);
    }

    public override void Draw()
    {
        // Use the current position for the destination rectangle, and size it appropriately
        destinationRectangle = new Rectangle((int)position.X, (int)position.Y, 60, 60);

        spriteBatch.GraphicsDevice.Clear(Color.CornflowerBlue);
        spriteBatch.Begin();
        // Draw the sprite using the updated position
        spriteBatch.Draw(textures, destinationRectangle, sourceRectangle[currentFrame], Color.White);
        // Position the sword relative to the skull
        Rectangle swordRectangle = new Rectangle(
        (int)(position.X + swordOffset.X),
        (int)(position.Y + swordOffset.Y), swordFrames[currentSwordFrame].Width * 3, swordFrames[currentSwordFrame].Height * 3);
        spriteBatch.Draw(textures, swordRectangle, swordFrames[currentSwordFrame], Color.White);
        spriteBatch.End();
    }

    public override void takendamage() { }

    public override void attack() { }
}
