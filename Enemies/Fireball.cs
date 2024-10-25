using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System.Collections.Generic;
using static System.Formats.Asn1.AsnWriter;
using LegendOfZelda;

namespace LegendOfZelda;
public class Fireball
{
    private Vector2 position;
    private Vector2 velocity;
    private float speed = 150f;
    public bool IsActive { get; private set; } = true;  // Track whether the fireball is active
    //private float growthRate = 0.02f;
    //private float maxScale = 5.0f;
    private ISprite sprite;

    public Fireball(Vector2 startPosition, Vector2 direction)
    {
        this.position = startPosition;
        this.velocity = direction * speed;
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
        if (position.X < 0 || position.X > 800 || position.Y < 0 || position.Y > 600)
        {
            IsActive = false;
        }
    }

    public void Draw(SpriteBatch spriteBatch)
    {
        // Draw the fireball only if it is active
        if (IsActive)
        {
            Rectangle destinationRectangle = new Rectangle(
                (int)position.X,
                (int)position.Y,
                24,
                48
            );

            sprite.Draw(spriteBatch, destinationRectangle, Color.White);
        }
    }
}