using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System.Collections.Generic;
using LegendOfZelda;

public class Aquamentus : IEnemy
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
    private ISprite sprite;
    private Vector2 position;
    private Rectangle destinationRectangle;
    public Aquamentus(Vector2 position)
    {
        this.position = position;
        fireballs = new List<Fireball>();
        sprite = EnemySpriteFactory.Instance.CreateAquamentusSprite();
        velocity = new Vector2(speed, 0);  // ontly Horizontal movement
        // Define the movement range (minX and maxX)
        minX = position.X - 10;
        maxX = position.X + 100;
        destinationRectangle = new Rectangle((int)position.X, (int)position.Y, 100, 100);
    }

    public void Update(GameTime gameTime)
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
        sprite.Update(gameTime);
    }

    private void ThrowFireball(Vector2 direction)
    {
        // Create a new fireball at Aquamentus's position and add it to the list
        Vector2 fireballStartPosition = new Vector2(position.X + 10, position.Y + 30); // Adjust the offset
        fireballs.Add(new Fireball(fireballStartPosition, direction));
    }

    public void Draw(SpriteBatch spriteBatch)
    {
        destinationRectangle = new Rectangle((int)position.X, (int)position.Y, 100, 100);

        sprite.Draw(spriteBatch, destinationRectangle, Color.White);

        // Draw all the fireballs
        foreach (Fireball fireball in fireballs)
        {
            fireball.Draw(spriteBatch);
        }
    }

    public void TakeDamage() { }

    public void Attack() { }
}