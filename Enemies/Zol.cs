using LegendOfZelda;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using LegendOfZelda.Sounds;

// Should have the same movement as Gel
namespace LegendOfZelda;
public class Zol : IEnemy, ICollideable

{
    private Vector2 targetPosition;  // Target position for the sprite to jump to
    private float jumpTimer = 0f;    // Timer to track the time since the last jump
    private Random random = new Random();
    public Vector2 position { get; set; }
    private Rectangle destinationRectangle;
    private ISprite sprite;
    private Boolean alive;
    private int hp;
    public Boolean canTakeDamage { get; private set; }
    private double invincibilityTimer = 1.5;
    private double timeElapsed = 0;

    public bool HasDroppedItem { get; set; } = false;
    private ClassItems droppedItem;
    private bool keyStatus;
    public Zol(Vector2 position, bool hasKey)
    {
        this.position = position;
        // Set the initial target position
        targetPosition = position;
        sprite = EnemySpriteFactory.Instance.CreateZolSprite();
        alive = true;
        hp = 1;
        canTakeDamage = true;
        //see Gel.cs
        if (hasKey == null)
        {
            keyStatus = false;
        }
        else if (hasKey)
        {
            keyStatus = true;
        }
        else
        {
            keyStatus = false;
        }
    }
    public void ChangeDirection()
    {

    }
    public void invulnerable()
    {
        if (canTakeDamage)
        {
            canTakeDamage = false;
        }
    }
    public void Update(GameTime gameTime)
    {
        // Update the jump timer
        jumpTimer += (float)gameTime.ElapsedGameTime.TotalSeconds;
        // If the sprite is close enough to the target position, wait for the cooldown to set a new target position
        if (Vector2.Distance(position, targetPosition) < 1f)
        {
            // If the cooldown has passed, set a new target position
            if (jumpTimer >= Constants.ZolJumpCooldown)
            {
                // Set a new target position in a small area around the current position
                // Limit the jump to a small range
                targetPosition = new Vector2(
                    position.X + random.Next(-(int)Constants.ZolJumpRange, (int)Constants.ZolJumpRange),
                    position.Y + random.Next(-(int)Constants.ZolJumpRange, (int)Constants.ZolJumpRange)
                );

                // Reset the timer for the next jump
                jumpTimer = 0f;
            }
        }

        timeElapsed += gameTime.ElapsedGameTime.TotalSeconds;
        if (timeElapsed > invincibilityTimer)
        {
            canTakeDamage = true;
            timeElapsed = 0;
        }

        // Move towards the target position smoothly
        Vector2 direction = targetPosition - position;

        // If the direction is non-zero, normalize it and move the sprite
        if (direction.Length() > 0)
        {
            direction.Normalize();
            position += direction * Constants.ZolJumpSpeed * (float)gameTime.ElapsedGameTime.TotalSeconds;
        }

        // Animate the sprite
        sprite.Update(gameTime);
    }

    public void Draw(SpriteBatch s)
    {
        // Use the current position for the destination rectangle, and size it appropriately
        destinationRectangle = new Rectangle((int)position.X, (int)position.Y, Constants.ZolWidth, Constants.ZolHeight);

        sprite.Draw(s, destinationRectangle, Color.White);

        if (HasDroppedItem)
        {
            //this should only be called when the droppedItem has been assigned a value...
            droppedItem.Draw(s);
        }
    }
    public Rectangle getHitbox()
    {
        //put data in the the hitbox
        Rectangle hitbox = new Rectangle((int)position.X, (int)position.Y, Constants.ZolHitboxWidth, Constants.ZolHitboxHeight);
        //Debug.WriteLine("Hitbox of block retrieved!");
        //Debug.WriteLine($"Rectangle hitbox:{destinationRectangle.X} {destinationRectangle.Y} {destinationRectangle.Width} {destinationRectangle.Height}");
        //return it
        return hitbox;
    }
    public String getCollisionType()
    {
        return "Enemy";
    }
    public void TakeDamage(int damage)
    {
        hp -= damage;
        
        SoundMachine.Instance.PlaySound("enemyHurt");
        if (hp <= 0)
        {
            alive = false;
        }
    }

    public void Attack() { }
    public Boolean isAlive() { return alive; }

    public void DropItem()
    {
        if (!alive)
        {
            if (keyStatus)
            {
                Debug.WriteLine("Key dropped!");
                droppedItem = new ClassItems(position, "Key");
                RoomObjectManager.Instance.staticItems.Add(droppedItem);
            }
            else
            {
                Debug.WriteLine("DropItem called: Item drop initialized");
                //The single letter indicates which DropTable GetItemName will get an item name from.
                String ItemTobeDroped = RoomObjectManager.Instance.GetItemName('C');
                droppedItem = new ClassItems(position, ItemTobeDroped);
                HasDroppedItem = true;
                RoomObjectManager.Instance.staticItems.Add(droppedItem);
            }
        }
    }
}
