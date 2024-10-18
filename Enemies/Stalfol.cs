﻿using LegendOfZelda;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LegendOfZelda;
public class Stalfol : ICollideable

{
    private Vector2 velocity;            // Velocity for movement
    //private float speed = 100f;          // Movement speed
    private Vector2 swordOffset;         // Offset of the sword relative to the skull
    private List<Rectangle> swordFrames;
    private Random random = new Random();
    private int currentSwordFrame = 0;   // Current frame for the sword
    private float swordFrameTime = 0.1f; // Duration of each sword swing frame
    private float swordFrameTimer = 0f;  // Timer for sword animation
    //private float directionChangeCooldown = 2f;  // Time between direction changes
    private float directionChangeTimer = 0f;     // Timer to track direction changes
    private float frameTime = 0.1f;
    private float frameTimer = 0f;
    private ISprite sprite;
    public Vector2 position { get; set; }
    private Rectangle destinationRectangle;
    private Boolean alive;

    public Stalfol(Vector2 Position)
    {
        this.position = Position;
        sprite = EnemySpriteFactory.Instance.CreateStalfolSprite();
        ChangeDirection();
        destinationRectangle = new Rectangle((int)this.position.X, (int)this.position.Y, Constants.StalfosWidth, Constants.StalfosHeight);
        alive = true;
    }

    private void ChangeDirection()
    {
        // Choose a random direction (up, down, left, right)
        int direction = random.Next(0, 4);

        switch (direction)
        {
            case 0:
                velocity = new Vector2(0, -Constants.StalfosSpeed);
                break;
            case 1:
                velocity = new Vector2(0, Constants.StalfosSpeed);
                break;
            case 2:
                velocity = new Vector2(-Constants.StalfosSpeed, 0);
                break;
            case 3:
                velocity = new Vector2(Constants.StalfosSpeed, 0);
                break;
        }
    }

    public void Update(GameTime gameTime)
    {
        // Update the direction change timer
        directionChangeTimer += (float)gameTime.ElapsedGameTime.TotalSeconds;

        // If it's time to change direction
        if (directionChangeTimer >= Constants.StalfosChangeDirectionCooldown)
        {
            // Choose a new random direction and reset the timer
            ChangeDirection(); 
            directionChangeTimer = 0f; 
        }
        sprite.Update(gameTime);
        // Update position based on velocity
        position += velocity * (float)gameTime.ElapsedGameTime.TotalSeconds;
        //angle need caculate
        //if the skull hits the screen edges and reflect its direction?????
        if (position.X <= 0 || position.X >= Constants.OriginalWidth - destinationRectangle.Width)
        {
            velocity.X *= -1; // Reflect on the X axis
        }

        if (position.Y <= 0 || position.Y >= Constants.OriginalHeight - destinationRectangle.Height)
        {
            velocity.Y *= -1; // Reflect on the Y axis
        }
    }

    public void Draw(SpriteBatch s)
    {
        if (alive)
        {
            // Use the current position for the destination rectangle, and size it appropriately
            destinationRectangle = new Rectangle((int)position.X, (int)position.Y, Constants.StalfosWidth, Constants.StalfosHeight);
            sprite.Draw(s, destinationRectangle, Color.White);
        }
    }
    public Rectangle getHitbox()
    {
        //put data in the the hitbox
        Rectangle hitbox = new Rectangle((int)position.X, (int)position.Y, Constants.StalfosWidth, Constants.StalfosHeight);
        //Debug.WriteLine("Hitbox of block retrieved!");
        //Debug.WriteLine($"Rectangle hitbox:{destinationRectangle.X} {destinationRectangle.Y} {destinationRectangle.Width} {destinationRectangle.Height}");
        //return it
        return hitbox;
    }

    public void takendamage() { alive = false; }

    public void attack() { }
}
