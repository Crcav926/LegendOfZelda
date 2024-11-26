using LegendOfZelda.Sounds;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;

namespace LegendOfZelda;
public class Ganon : IEnemy, ICollideable
{
    public Vector2 position { get; set; }
    private Vector2 velocity;
    private List<Fireball> fireballs;
    private float fireballCooldown = 2f;  // Time between fireball attacks
    private float fireballTimer = 0f;
    private ISprite sprite;
    private ISprite vulnerableSprite;
    private bool isVisible;
    private bool isVulnerable;
    private double visibilityTimer = 1.5;  // Visible duration when hit
    private double vulnerableTimer = 5.0; // Time Ganon stays vulnerable
    private double elapsedTime = 0;
    private double vulnerableTimeElapsed = 0;

    private int hp;
    private bool alive;
    private Rectangle destinationRectangle;
    public bool canTakeDamage { get; private set; }
    public bool HasDroppedItem { get; set; } = false;

    public Ganon(Vector2 startPosition)
    {
        position = startPosition;
        sprite = EnemySpriteFactory.Instance.CreateGanonSprite();
        vulnerableSprite = EnemySpriteFactory.Instance.CreateGanonVulnerableSprite();
        velocity = Vector2.Zero;
        fireballs = new List<Fireball>();
        hp = 3;  // Total hits before becoming vulnerable
        isVisible = true;
        isVulnerable = false;
        alive = true;
        canTakeDamage = true;
    }

    public void Update(GameTime gameTime)
    {

        fireballTimer += (float)gameTime.ElapsedGameTime.TotalSeconds;

        // Ganon throwing fireballs
        if (fireballTimer >= fireballCooldown)
        {
            ThrowFireballs();
            fireballTimer = 0f;
        }

        // Ganon's visibility
        if (!isVulnerable)
        {
            elapsedTime += gameTime.ElapsedGameTime.TotalSeconds;
            if (elapsedTime >= visibilityTimer)
            {
                isVisible = false;
                elapsedTime = 0;

                // Ensure he reappears at intervals
                isVisible = true;
            }
        }

        // Ganon's vulnerability
        if (isVulnerable)
        {
            vulnerableTimeElapsed += gameTime.ElapsedGameTime.TotalSeconds;
            if (vulnerableTimeElapsed >= vulnerableTimer)
            {
                isVulnerable = false;
                vulnerableTimeElapsed = 0;
                isVisible = false;  // Ganon disappears again
                hp = 3;  // Reset HP
            }
        }

        // Update fireballs
        fireballs.RemoveAll(f => !f.IsActive);
        foreach (Fireball fireball in fireballs)
        {
            fireball.Update(gameTime);
            RoomObjectManager.Instance.addProjectile(fireball);
        }
    }

    private void ThrowFireballs()
    {
        Vector2 fireballStartPosition = new Vector2(
            position.X + Constants.GanonFireballXOffset,
            position.Y + Constants.GanonFireballYOffset
        );

        fireballs.Add(new Fireball(fireballStartPosition, new Vector2(0, -1)));  // Up
        fireballs.Add(new Fireball(fireballStartPosition, new Vector2(1, -1))); // Up-Right
        fireballs.Add(new Fireball(fireballStartPosition, new Vector2(1, 0)));  // Right
        fireballs.Add(new Fireball(fireballStartPosition, new Vector2(1, 1)));  // Down-Right
        fireballs.Add(new Fireball(fireballStartPosition, new Vector2(0, 1)));  // Down
    }

    public void TakeDamage(int damage)
    {
        SoundMachine.Instance.PlaySound("enemyHurt");
        isVisible = true;
        if (!isVulnerable)
        {
            hp -= damage;
            if (hp == 0)
            {
                isVulnerable = true;
                //ganon vulnerable sound?
            }
        }
        else
        {
            // Vulnerable state: one hit defeats Ganon
            alive = false;
        }
    }

    public void Draw(SpriteBatch spriteBatch)
    {
        ISprite currentSprite;
        if (isVulnerable)
        {
            currentSprite = vulnerableSprite;
        }
        else
        {
            currentSprite = sprite;
        }

        if (isVisible)
        {
            destinationRectangle = new Rectangle((int)position.X, (int)position.Y, Constants.GanonWidth, Constants.GanonHeight);
            currentSprite.Draw(spriteBatch, destinationRectangle, Color.White);
        }

        // Draw fireballs
        foreach (Fireball fireball in fireballs)
        {
            fireball.Draw(spriteBatch);
        }
    }

    public Rectangle getHitbox()
    {
        Rectangle hitbox = new Rectangle(0, 0, 0, 0);
        if (alive & isVisible)
        {
            hitbox = new Rectangle((int)position.X, (int)position.Y, Constants.GanonHitboxWidth, Constants.GanonHitboxHeight);
        }
        return hitbox;
    }

    public bool isAlive()
    {
        return alive;
    }
    public void Attack() { }
    public void DropItem()
    {
        //to do
    }
    public void ChangeDirection() { }

    public String getCollisionType()
    {
        return "Enemy";
    }
}

