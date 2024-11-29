using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System.Collections.Generic;
using static System.Formats.Asn1.AsnWriter;
using LegendOfZelda;
using System.Reflection.Metadata;
using System;

namespace LegendOfZelda;
public class GanonFireball : ICollideable, IProjectile
{
    private Vector2 position;
    private Vector2 velocity;
    private float speed = 150f;
    public bool IsActive { get; private set; } = true;  // Track whether the fireball is active
    //private float growthRate = 0.02f;
    //private float maxScale = 5.0f;
    private ISprite sprite;

    private Rectangle destinationRectangle;


    public GanonFireball(Vector2 startPosition, Vector2 direction)
    {
        this.position = startPosition;
        this.velocity = direction * Constants.FireballSpeed;
        sprite = EnemySpriteFactory.Instance.CreateFireBallSprite();
    }

    public void Update(GameTime gameTime)
    {
        // Update the fireball position based on velocity
        position += velocity * (float)gameTime.ElapsedGameTime.TotalSeconds;
        sprite.Update(gameTime);

        // Increase the size of the fireball
        //scale += growthRate;

        // Mark fireball as inactive if it reaches maximum scale
        //if (scale >= maxScale)
        //{
        //    IsActive = false;
        //}

        // Mark fireball as inactive if it goes off-screen
        //NOTE: not sure if this should use original width/height or screen width/height. Testing needed. - TJ
        if (position.X < 0 || position.X > Constants.OriginalWidth || position.Y < 0 || position.Y > Constants.OriginalHeight)
        {
            IsActive = false;
        }
    }

    public void Draw(SpriteBatch spriteBatch)
    {
        // Draw the fireball only if it is active
        if (IsActive)
        {
            destinationRectangle = new Rectangle(
                (int)position.X,
                (int)position.Y,
                Constants.FireballWidth,
                Constants.FireballHeight
            );

            sprite.Draw(spriteBatch, destinationRectangle, Color.White);
        }
    }

    public Rectangle getHitbox()
    {
        if (IsActive)
        {
            return destinationRectangle;
        }
        else
        {
            return new Rectangle(0, 0, 0, 0);
        }
    }

    public String getCollisionType()
    {
        return "Projectile";
    }


    public void deleteSelf()
    {
        IsActive = false;
        RoomObjectManager.Instance.removeProjectileFromMovers(this);
    }
}
