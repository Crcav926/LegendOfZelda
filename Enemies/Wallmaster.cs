using LegendOfZelda;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LegendOfZelda;
public class Wallmaster : IEnemy, ICollideable

{
    private Vector2 targetPosition;  // Target position for the sprite to jump to
    //private float jumpSpeed = 80f;   // Speed of the jump
    //private float jumpCooldown = 1f; // Cooldown time in seconds between jumps
    private float jumpTimer = 0f;    // Timer to track the time since the last jump
    private Random random = new Random();
    public Vector2 position { get; set; }
    private Rectangle destinationRectangle;
    private ISprite sprite;
    private Boolean alive;

    public Wallmaster(Vector2 position)
    {
        // Set the initial target position
        targetPosition = position;
        this.position = position;
        this.sprite = EnemySpriteFactory.Instance.CreateWallmasterSprite();
        alive = true;
    }
    public void ChangeDirection() { }

    public void Update(GameTime gameTime)
    {

        //????????????????????????
        // Update the jump timer
        jumpTimer += (float)gameTime.ElapsedGameTime.TotalSeconds;
        // If the sprite is close enough to the target position, wait for the cooldown to set a new target position
        if (Vector2.Distance(position, targetPosition) < 1f)
        {
            // If the cooldown has passed, set a new target position
            if (jumpTimer >= Constants.WallmasterJumpCooldown)
            {
                // Set a new target position in a small area around the current position
                targetPosition = new Vector2(
                    position.X + random.Next(-(int)Constants.WallmasterJumpRange, (int)Constants.WallmasterJumpRange),
                    position.Y + random.Next(-(int)Constants.WallmasterJumpRange, (int)Constants.WallmasterJumpRange)
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
            position += direction * Constants.WallmasterJumpSpeed * (float)gameTime.ElapsedGameTime.TotalSeconds;
        }
        // Update / Animate the sprite
        sprite.Update(gameTime);
    }

    public void Draw(SpriteBatch s)
    {
        // Use the current position for the destination rectangle, and size it appropriately
        // I change the size of the rectangle since it is closest to the real size
        destinationRectangle = new Rectangle((int)position.X, (int)position.Y, Constants.WallmasterWidth, Constants.WallmasterHeight);
        sprite.Draw(s, destinationRectangle, Color.White);
    }
    public Rectangle getHitbox()
    {
        //put data in the the hitbox
        Rectangle hitbox = new Rectangle((int)position.X, (int)position.Y, Constants.WallmasterWidth, Constants.WallmasterHeight);
        //Debug.WriteLine("Hitbox of block retrieved!");
        //Debug.WriteLine($"Rectangle hitbox:{destinationRectangle.X} {destinationRectangle.Y} {destinationRectangle.Width} {destinationRectangle.Height}");
        //return it
        return hitbox;
    }

    public String getCollisionType()
    {
        return "Enemy";
    }
    public void takendamage() { }

    public void attack() { }
    public Boolean isAlive() { return alive; }
}
