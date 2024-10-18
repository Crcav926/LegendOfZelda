﻿using LegendOfZelda;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Wallmaster : IEnemy

{
    private Vector2 targetPosition;  // Target position for the sprite to jump to
    private float jumpSpeed = 80f;   // Speed of the jump
    private float jumpCooldown = 1f; // Cooldown time in seconds between jumps
    private float jumpTimer = 0f;    // Timer to track the time since the last jump
    private Random random = new Random();
    private float frameTime = 0.1f; // Duration of each frame in seconds 
    private float frameTimer = 0f;  // Timer to track time since last frame change
    public Vector2 position { get; set; }
    private Rectangle destinationRectangle;
    private ISprite sprite;

    public Wallmaster(Vector2 position)
    {
        // Set the initial target position
        targetPosition = position;
        this.position = position;
        this.sprite = EnemySpriteFactory.Instance.CreateWallmasterSprite();
    }

    public void Update(GameTime gameTime)
    {

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
                float jumpRange = 100f;
                targetPosition = new Vector2(
                    position.X + random.Next(-(int)jumpRange, (int)jumpRange),
                    position.Y + random.Next(-(int)jumpRange, (int)jumpRange)
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
            position += direction * jumpSpeed * (float)gameTime.ElapsedGameTime.TotalSeconds;
        }
        // Update / Animate the sprite
        sprite.Update(gameTime);
    }

    public void Draw(SpriteBatch s)
    {
        // Use the current position for the destination rectangle, and size it appropriately
        // I change the size of the rectangle since it is closest to the real size
        destinationRectangle = new Rectangle((int)position.X, (int)position.Y, 30, 30);
        sprite.Draw(s, destinationRectangle, Color.White);
    }



    public void takendamage() { }

    public void attack() { }
}