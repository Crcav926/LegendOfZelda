using LegendOfZelda;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LegendOfZelda;
public class Keese : IEnemy, ICollideable

{
    private Vector2 targetPosition;  // Target position for the sprite to jump to
    private Vector2 velocity;  // direction and speed
    private float speed = 100f;
    private Random random = new Random();
    private float frameTime = 0.1f; // Duration of each frame in seconds 
    private float frameTimer = 0f;  // Timer to track time since last frame change
    private ISprite sprite;
    private Rectangle destinationRectangle;
    private Boolean alive;
    public Vector2 position { get; set; }
    public Keese(Vector2 position)
    {
        // Set the initial target position (I dont know so I randomlzie it here
        this.position = position;
        targetPosition = position;
        velocity = new Vector2(
            (float)(random.NextDouble() * 2 - 1),
            (float)(random.NextDouble() * 2 - 1)
        );
        // Normalize to ensure consistent speed in all directions
        velocity.Normalize();
        velocity *= speed;
        sprite = EnemySpriteFactory.Instance.CreateKeeseSprite();
        destinationRectangle = new Rectangle((int)position.X, (int)position.Y, 60, 60);
        alive = true;
    }
    public void ChangeDirection()
    {
        // Choose a random direction (up, down, left, right)
        int direction = random.Next(0, 4);

        switch (direction)
        {
            case 0:
                velocity = new Vector2(speed, -speed);
                break;
            case 1:
                velocity = new Vector2(-speed, speed);
                break;
            case 2:
                velocity = new Vector2(-speed, -speed);
                break;
            case 3:
                velocity = new Vector2(speed, speed);
                break;
        }
    }
    public void Update(GameTime gameTime)
    {
        // Update the frame timer for animation transitions
        frameTimer += (float)gameTime.ElapsedGameTime.TotalSeconds;
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
        sprite.Update(gameTime);
    }

    public void Draw(SpriteBatch s)
    {
        if (alive)
        {
            // Use the current position for the destination rectangle, and size it appropriately
            destinationRectangle = new Rectangle((int)position.X, (int)position.Y, 60, 60);

            sprite.Draw(s, destinationRectangle, Color.White);
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
    public void takendamage() { alive = false; }

    public void attack() { }
}
