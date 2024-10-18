using LegendOfZelda;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;

namespace LegendOfZelda;
public class BladeTrap : IEnemy, ICollideable
{
    private bool isActive = true;        // Whether the BladeTrap is currently active
    private float activeTime = 10f;      // Time to stay active in seconds
    private float hiddenTime = 2f;        // Time to stay hidden in seconds
    private float timer = 0f;             // Timer to track visibility
    private ISprite sprite;
    public Vector2 position { get; set; }
    private Rectangle destinationRectangle;

    public BladeTrap(Vector2 position)
    {
        this.position = position;
        sprite = EnemySpriteFactory.Instance.CreateBladeTrapSprite();
    }

    public void Update(GameTime gameTime)
    {
        // Update the active timer
        timer += (float)gameTime.ElapsedGameTime.TotalSeconds;

        // TODO -- If Link is In-Line with trap, move towards him
        if (isActive && timer >= activeTime)
        {
            // After 10 seconds of being active, disable the sprite and reset the timer
            isActive = false;
            timer = 0f;
        }
        else if (!isActive && timer >= hiddenTime)
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
            destinationRectangle = new Rectangle((int)position.X, (int)position.Y, 60, 60);
            sprite.Draw(s, destinationRectangle, Color.White);

        }
    }
    public Rectangle getHitbox()
    {
        //put data in the the hitbox
        Rectangle hitbox = new Rectangle((int)position.X, (int)position.Y, 60, 60);
        //Debug.WriteLine("Hitbox of block retrieved!");
        //Debug.WriteLine($"Rectangle hitbox:{destinationRectangle.X} {destinationRectangle.Y} {destinationRectangle.Width} {destinationRectangle.Height}");
        //return it
        return hitbox;
    }

    public void takendamage() 
    {
        // Does nothing, Bladetraps can't take damage
    }

    public void attack() 
    {
        // Worry about later
    }
}