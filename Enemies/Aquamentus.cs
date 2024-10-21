using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace LegendOfZelda;
public class Aquamentus : IEnemy, ICollideable
{
    private Vector2 velocity;
    private float speed = 80f;
    private List<Fireball> fireballs;    // List to track active fireballs
    private List<Rectangle> rightFrames;
    private List<Rectangle> projectileFrames; // List of rectangles for fireball animation
    private float throwCooldown = 3f;    // Time between fireball throws
    private float throwTimer = 0f;       // Timer to track when to throw a fireball
    private float frameTime = 0.1f;
    private float frameTimer = 0f;
    private float minX;  // Left boundary for movement
    private float maxX;  // Right boundary for movement
    private ISprite sprite;
    public Boolean alive { get; private set; }
    public Vector2 position { get; set; }
    private Rectangle destinationRectangle;
    public Aquamentus(Vector2 position)
    {
        this.position = position;
        fireballs = new List<Fireball>();
        sprite = EnemySpriteFactory.Instance.CreateAquamentusSprite();
        velocity = new Vector2(speed, 0);  // ontly Horizontal movement
        // Define the movement range (minX and maxX)
        minX = position.X - 10;
        maxX = position.X + 100;
        destinationRectangle = new Rectangle((int)position.X, (int)position.Y, 80, 80);
        alive = true;
    }
    public void ChangeDirection()
    {
        velocity.X *= -1;
    }

    public void Update(GameTime gameTime)
    {
        // Update the timer for throwing fireballs
        throwTimer += (float)gameTime.ElapsedGameTime.TotalSeconds;
        if (throwTimer >= throwCooldown)
        {
            // Throw 3 fireballs in different directions
            ThrowFireball(new Vector2(-1, -1));
            ThrowFireball(new Vector2(-1, 0));
            ThrowFireball(new Vector2(-1, 1));
            throwTimer = 0f;
        }

        // Update and remove inactive fireballs
        fireballs.RemoveAll(f => !f.IsActive);

        foreach (Fireball fireball in fireballs)
        {
            fireball.Update(gameTime);
        }

        // Move Aquamentus horizontally
        position += velocity * (float)gameTime.ElapsedGameTime.TotalSeconds;

        // Reverse direction if Aquamentus reach the boundary
        if (position.X <= minX || position.X >= maxX)
        {
            velocity.X *= -1;
        }

        sprite.Update(gameTime);
    }

    private void ThrowFireball(Vector2 direction)
    {
        // Create a new fireball at Aquamentus's position and add it to the list
        Vector2 fireballStartPosition = new Vector2(position.X + 10, position.Y + 30); // Adjust the offset
        fireballs.Add(new Fireball(fireballStartPosition, direction));
    }

    public void Draw(SpriteBatch spriteBatch)
    {
        if (alive) {
        destinationRectangle = new Rectangle((int)position.X, (int)position.Y, 80, 80);

        sprite.Draw(spriteBatch, destinationRectangle, Color.White);

        // Draw all the fireballs
        foreach (Fireball fireball in fireballs)
        {
            fireball.Draw(spriteBatch);
        }
        }
    }

    public void takendamage() 
    { 
        alive = false; 
    }

    public void attack() { }
    public Boolean isAlive() { return alive; }
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
}