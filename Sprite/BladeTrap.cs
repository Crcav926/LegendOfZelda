using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;

public class BladeTrap : DynamicSprite
{
    private bool isActive = true;        // Whether the BladeTrap is currently active
    private float activeTime = 10f;      // Time to stay active in seconds
    private float hiddenTime = 2f;        // Time to stay hidden in seconds
    private float timer = 0f;             // Timer to track visibility
    private Random random = new Random(); // Random generator for position
    private GraphicsDevice graphicsDevice; // Get current window

    public BladeTrap(SpriteBatch spriteBatch, Vector2 position, Texture2D textures, List<Rectangle> sourceRectangle, GraphicsDevice graphicsDevice)
        : base(spriteBatch, position, textures, sourceRectangle)
    {
        this.graphicsDevice = graphicsDevice;  // Save reference to GraphicsDevice
        SetRandomPosition();  // Set the initial random position
    }

    private void SetRandomPosition()
    {
        int windowWidth = graphicsDevice.Viewport.Width;
        int windowHeight = graphicsDevice.Viewport.Height;
        // Set a random position within the window boundaries
        // Generate the trap within the game window
        // I use -30 since sometime I cannot see it the the edge of the screen

        int x = random.Next(0, windowWidth - 30);
        int y = random.Next(0, windowHeight - 30);
        position = new Vector2(x, y);
    }

    public override void Update(GameTime gameTime)
    {
        // Update the active timer
        timer += (float)gameTime.ElapsedGameTime.TotalSeconds;

        if (isActive && timer >= activeTime)
        {
            // After 10 seconds of being active, disable the sprite and reset the timer
            isActive = false;
            timer = 0f;
        }
        else if (!isActive && timer >= hiddenTime)
        {
            // After 2 seconds of being disable, active the sprite at a new random position
            SetRandomPosition();
            isActive = true;
            timer = 0f;
        }
    }

    public override void Draw(SpriteBatch s)
    {
        // Draw the BladeTrap only if it is active
        if (isActive)
        {

            destinationRectangle = new Rectangle((int)position.X, (int)position.Y, 60, 60);

            spriteBatch.GraphicsDevice.Clear(Color.CornflowerBlue);
            spriteBatch.Begin();


            spriteBatch.Draw(textures, destinationRectangle, sourceRectangle[currentFrame], Color.White);

            spriteBatch.End();
        }
    }

    public void TakeDamage() { }

    public void Attack() { }
}