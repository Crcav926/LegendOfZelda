using LegendOfZelda;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace LegendOfZelda;
public class BladeTrap : IEnemy, ICollideable
{
    private bool isActive = true;        // Whether the BladeTrap is currently active
    //both moved into constants file.
    //private float activeTime = 10f;      // Time to stay active in seconds
    //private float hiddenTime = 2f;        // Time to stay hidden in seconds
    private float timer = 0f;             // Timer to track visibility
    private ISprite sprite;
    public Vector2 position { get; set; }
    private Rectangle destinationRectangle;
    private Boolean alive;

    public bool HasDroppedItem { get; set; } = false;
    private ClassItems droppedItem;

    public BladeTrap(Vector2 position, bool hasKey)
    {
        this.position = position;
        sprite = EnemySpriteFactory.Instance.CreateBladeTrapSprite();
        alive = true;
    }
    public void ChangeDirection()
    {

    }
    public void Update(GameTime gameTime)
    {
        // Update the active timer
        timer += (float)gameTime.ElapsedGameTime.TotalSeconds;

        // TODO -- If Link is In-Line with trap, move towards him
        if (isActive && timer >= Constants.BladeTrapActiveTime)
        {
            // After 10 seconds of being active, disable the sprite and reset the timer
            isActive = false;
            timer = 0f;
        }
        else if (!isActive && timer >= Constants.BladeTrapHiddenTime)
        {
            // After 2 seconds of being disable, active the sprite at a new random position
            isActive = true;
            timer = 0f;
        }
    }

    public void Draw(SpriteBatch s)
    {
        // Draw the BladeTrap only if it is active
        if (isActive)
        {
            destinationRectangle = new Rectangle((int)position.X, (int)position.Y, Constants.BladeTrapWidth, Constants.BladeTrapHeight);
            sprite.Draw(s, destinationRectangle, Color.White);

        }
    }
    public Rectangle getHitbox()
    {
        //put data in the the hitbox
        Rectangle hitbox = new Rectangle((int)position.X, (int)position.Y, Constants.BladeTrapWidth, Constants.BladeTrapHeight);
        //Debug.WriteLine("Hitbox of block retrieved!");
        //Debug.WriteLine($"Rectangle hitbox:{destinationRectangle.X} {destinationRectangle.Y} {destinationRectangle.Width} {destinationRectangle.Height}");
        //return it
        return hitbox;
    }

    public void TakeDamage(int damage)
    {
        // Does nothing, Bladetraps can't take damage
    }

    public void Attack()
    {
        // Worry about later
    }
        
    public Boolean isAlive() { return alive; }
    public String getCollisionType()
    {
        return "Enemy";
    }

    public void DropItem()
    {
        if (!alive)
        {
            Debug.WriteLine("DropItem called: Item drop initialized");
            //for now I'm using Rupees to test drops
            droppedItem = new ClassItems(position, "OrangeRupee");
            HasDroppedItem = true;
        }
    }
}