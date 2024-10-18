using LegendOfZelda;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LegendOfZelda;
public class Gel : IEnemy, ICollideable

{
    private Vector2 targetPosition;  // Target position for the sprite to jump to
    //private float jumpSpeed = 50f;   // Speed of the jump
    private float jumpCooldown = 1f; // Cooldown time in seconds between jumps
    private float jumpTimer = 0f;    // Timer to track the time since the last jump
    private Random random = new Random();
    private float frameTime = 0.1f; // Duration of each frame in seconds 
    private float frameTimer = 0f;  // Timer to track time since last frame change
    public Vector2 position { get; set; }
    private Rectangle destinationRectangle;
    private ISprite sprite;
    public Gel(Vector2 Position)
    {
        // Set the initial target position
        targetPosition = Position;
        this.position = Position;
        destinationRectangle = new Rectangle((int)position.X, (int)position.Y, Constants.GelWidth, Constants.GelHeight);
        sprite = EnemySpriteFactory.Instance.CreateGelSprite();
    }

    public void Update(GameTime gameTime)
    {
        // Update the frame timer
        frameTimer += (float)gameTime.ElapsedGameTime.TotalSeconds;
        //????????????????????????
        // Update the jump timer
        jumpTimer += (float)gameTime.ElapsedGameTime.TotalSeconds;
        // If the sprite is close enough to the target position, wait for the cooldown to set a new target position
        if (Vector2.Distance(position, targetPosition) < 1f)
        {
            // If the cooldown has passed, set a new target position
            if (jumpTimer >= jumpCooldown)
            {
                // Set a new target position in a small area around the current position
                // I limit the jump to a small range (50 pixels) 
                targetPosition = new Vector2(
                    position.X + random.Next(-(int)Constants.GelJumpRange, (int)Constants.GelJumpRange),
                    position.Y + random.Next(-(int)Constants.GelJumpRange, (int)Constants.GelJumpRange)
                );

                // Reset the timer for the next jump
                jumpTimer = 0f;
            }
        }

        // Move towards the target position smoothly
        Vector2 direction = targetPosition - position;

        // Ifdirection != 0, normalize it and move the sprite
        if (direction.Length() > 0)
        {
            direction.Normalize();
            position += direction * Constants.GelJumpSpeed * (float)gameTime.ElapsedGameTime.TotalSeconds;
        }
        sprite.Update(gameTime);
    }

    public void Draw(SpriteBatch s)
    {
        // Use the current position for the destination rectangle, and size it appropriately
        destinationRectangle = new Rectangle((int)position.X, (int)position.Y, Constants.GelWidth, Constants.GelHeight);
        sprite.Draw(s, destinationRectangle, Color.White);

    }
    public Vector2 getPosition()
    {
        return this.position;
    }
    public Rectangle getHitbox()
    {
        //put data in the the hitbox
        Rectangle hitbox = new Rectangle((int)position.X, (int)position.Y, Constants.GelWidth, Constants.GelHeight);
        //Debug.WriteLine("Hitbox of block retrieved!");
        //Debug.WriteLine($"Rectangle hitbox:{destinationRectangle.X} {destinationRectangle.Y} {destinationRectangle.Width} {destinationRectangle.Height}");
        //return it
        return hitbox;
    }
    public void takendamage() { }

    public void attack() { }
}
